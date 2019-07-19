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
    public class DeathDocService : IDeathDocService
    {
        private readonly IDeathDocRepository _deathDocRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;

        public DeathDocService(IDeathDocRepository deathDocRepository, ILogger<DeathDocService> logger, ICachedLookupsService lookupsService)
        {
            _logger = logger;
            _deathDocRepository = deathDocRepository;
            _lookupsService=lookupsService;
        }

        public async Task<IEnumerable<DeathDocResponse>> CreateDeathDocsAsync(IEnumerable<DeathDoc> deathRecords, bool autoSave = false)
        {
            for (int i = 0; i < deathRecords.Count(); i++)
            {
                DeathDoc deathRecord = deathRecords.ElementAt(i);
                await ValidateRelation(deathRecord);
                await SetDefaultStateId(deathRecord);
                SetDefaultNID(deathRecord);
                deathRecord.Price = await GetDocPrice();
                await _deathDocRepository.CreateDeathDoc(deathRecord);
            }
            if (autoSave)
                await SaveChangesAsync();

            return deathRecords.Select(a => new DeathDocResponse(a));
        }

        private async Task ValidateRelation(DeathDoc deathDoc)
        {
            var allDocTypeRelations = await _lookupsService.GetLookups<DocumentTypeRelation>();
            var docType = await GetDocType();
            if (!allDocTypeRelations.Any(a => a.DocumentTypeId == docType.Id && a.RelationId == deathDoc.RelationId && a.GenderId == deathDoc.GenderId))
                throw new DomainException($"The relation of the requester and the death document owner is not valid.\r\nDeathDoc Name: {deathDoc?.Name?.FullName}, RelationId:{deathDoc?.RelationId}");
        }

        public async Task<decimal> GetDocPrice()
        {
            var docType = await GetDocType();
            return docType.Price;
        }

        public async Task<DocumentType> GetDocType()
        {
            return await _lookupsService.FindWhere<DocumentType>(a => a.Code == "MOICSO005");
        }

        private async Task SetDefaultStateId(DeathDoc deathRecord)
        {
            var defaultState = await _lookupsService.FindWhere<State>(a => a.Code == "NEW");
            deathRecord.StateId = defaultState?.Id;
        }

        private void SetDefaultNID(DeathDoc deathDoc)
        {
            /*
             * This is a workaround:
             * We have the NID as DDD value object and to handle value objects in ef core we use OwnsOne in fluent api
             * OwnsOne doesn't allow null properties for values objects except if you are saving it in a deparate table
             * We can avoid this be setting NID prop to an empty new instance with the value of NationalIdenNumber = null
             * but this will through an exception in the constructor of NID value object
             */
            if (deathDoc.NID == null)
                deathDoc.NID = new NID(Constants.DEFAULT_NID_NUMBER);
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _deathDocRepository.UnitOfWork.CommitChangesAsync();
        }
    }
}
