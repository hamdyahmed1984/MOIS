using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Communication;
using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using Microsoft.Extensions.Logging;
using Domain.ValueObjects;
using Domain;
using Domain.Exceptions;

namespace Application.Services
{
    public class BirthDocService : IBirthDocService
    {
        private readonly IBirthDocRepository _birthDocRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;

        public BirthDocService(IBirthDocRepository birthDocRepository, ILogger<BirthDocService> logger, ICachedLookupsService lookupsService)
        {
            _logger = logger;
            _birthDocRepository = birthDocRepository;
            _lookupsService=lookupsService;
        }

        public async Task<IEnumerable<BirthDocResponse>> CreateBirthDocsAsync(IEnumerable<BirthDoc> birthDocs, bool autoSave = false)
        {
            for (int i = 0; i < birthDocs.Count(); i++)
            {
                BirthDoc birthDoc = birthDocs.ElementAt(i);

                await ValidateRelation(birthDoc);
                await SetDefaultStateId(birthDoc);
                SetDefaultNID(birthDoc);
                birthDoc.Price = await GetDocPrice();
                await _birthDocRepository.CreateBirthDoc(birthDoc);
            }
            if (autoSave)
                await SaveChangesAsync();
            return birthDocs.Select(a => new BirthDocResponse(a));
            //return birthDocs.Select(a => new BirthDocResponse($"An error occurred while saving the birth docs: {ex.Message}"));
            //return new BirthDocResponse($"An error occurred while saving the birth doc: {ex.Message}");
        }

        private async Task ValidateRelation(BirthDoc birthDoc)
        {
            var allDocTypeRelations = await _lookupsService.GetLookups<DocumentTypeRelation>();
            var docType = await GetDocType();
            if (!allDocTypeRelations.Any(a => a.DocumentTypeId == docType.Id && a.RelationId == birthDoc.RelationId && a.GenderId == birthDoc.GenderId))
                throw new DomainException($"The relation of the requester and the birth document owner is not valid.\r\nBirthDoc Name: {birthDoc?.Name?.FullName}, RelationId:{birthDoc?.RelationId}");
        }

        public async Task<decimal> GetDocPrice()
        {
            var docType = await GetDocType();
            return docType.Price;
        }

        public async Task<DocumentType> GetDocType()
        {
            return await _lookupsService.FindWhere<DocumentType>(a => a.Code == "MOICSO001");
        }

        private async Task SetDefaultStateId(BirthDoc birthDoc)
        {
            var defaultState = await _lookupsService.FindWhere<State>(a => a.Code == "NEW");
            birthDoc.StateId = defaultState?.Id;
        }

        private void SetDefaultNID(BirthDoc birthDoc)
        {
            /*
             * This is a workaround:
             * We have the NID as DDD value object and to handle value objects in ef core we use OwnsOne in fluent api
             * OwnsOne doesn't allow null properties for values objects except if you are saving it in a deparate table
             * We can avoid this be setting NID prop to an empty new instance with the value of NationalIdenNumber = null
             * but this will through an exception in the constructor of NID value object
             */
            if (birthDoc.IsFirstTime/* && birthDoc.NID == null*/)
                birthDoc.NID = new NID(Constants.DEFAULT_NID_NUMBER);
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _birthDocRepository.UnitOfWork.CommitChangesAsync();
        }
    }
}
