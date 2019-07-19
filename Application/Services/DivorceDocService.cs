using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Communication;
using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using Microsoft.Extensions.Logging;
using Domain.Exceptions;

namespace Application.Services
{
    public class DivorceDocService : IDivorceDocService
    {
        private readonly IDivorceDocRepository _divorceDocRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;

        public DivorceDocService(IDivorceDocRepository divorceDocRepository, ILogger<DivorceDocService> logger, ICachedLookupsService lookupsService)
        {
            _logger = logger;
            _divorceDocRepository = divorceDocRepository;
            _lookupsService = lookupsService;
        }

        public async Task<IEnumerable<DivorceDocResponse>> CreateDivorceDocsAsync(IEnumerable<DivorceDoc> divorceDocs, bool autoSave = false)
        {

            for (int i = 0; i < divorceDocs.Count(); i++)
            {
                DivorceDoc divorceDoc = divorceDocs.ElementAt(i);
                await ValidateRelation(divorceDoc);
                await SetDefaultStateId(divorceDoc);
                divorceDoc.Price = await GetDocPrice();
                await _divorceDocRepository.CreateDivorceDoc(divorceDoc);
            }
            if (autoSave)
                await SaveChangesAsync();

            return divorceDocs.Select(a => new DivorceDocResponse(a));
        }

        private async Task ValidateRelation(DivorceDoc divorceDoc)
        {
            var allDocTypeRelations = await _lookupsService.GetLookups<DocumentTypeRelation>();
            var docType = await GetDocType();
            if (!allDocTypeRelations.Any(a => a.DocumentTypeId == docType.Id && a.RelationId == divorceDoc.RelationId))
                throw new DomainException($"The relation of the requester and the divorce document owner is not valid.\r\nDivorceDoc Name: {divorceDoc?.Name?.FullName}, RelationId:{divorceDoc?.RelationId}");
        }

        public async Task<decimal> GetDocPrice()
        {
            var docType = await GetDocType();
            return docType.Price;
        }

        public async Task<DocumentType> GetDocType()
        {
            return await _lookupsService.FindWhere<DocumentType>(a => a.Code == "MOICSO004");
        }

        private async Task SetDefaultStateId(DivorceDoc divorceDoc)
        {
            var defaultState = await _lookupsService.FindWhere<State>(a => a.Code == "NEW");
            divorceDoc.StateId = defaultState?.Id;
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _divorceDocRepository.UnitOfWork.CommitChangesAsync();
        }
    }
}
