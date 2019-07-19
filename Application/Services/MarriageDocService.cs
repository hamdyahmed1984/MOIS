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
    public class MarriageDocService : IMarriageDocService
    {
        private readonly IMarriageDocRepository _marriageDocRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;

        public MarriageDocService(IMarriageDocRepository marriageDocRepository, ILogger<MarriageDocService> logger, ICachedLookupsService lookupsService)
        {
            _logger = logger;
            _marriageDocRepository = marriageDocRepository;
            _lookupsService = lookupsService;
        }

        public async Task<IEnumerable<MarriageDocResponse>> CreateMarriageDocsAsync(IEnumerable<MarriageDoc> marriageDocs, bool autoSave = false)
        {
            for (int i = 0; i < marriageDocs.Count(); i++)
            {
                MarriageDoc marriageDoc = marriageDocs.ElementAt(i);
                await ValidateRelation(marriageDoc);
                await SetDefaultStateId(marriageDoc);
                marriageDoc.Price = await GetDocPrice();
                await _marriageDocRepository.CreateMarriageDoc(marriageDoc);
            }
            if (autoSave)
                await SaveChangesAsync();

            return marriageDocs.Select(a => new MarriageDocResponse(a));
        }

        private async Task ValidateRelation(MarriageDoc marriageDoc)
        {
            var allDocTypeRelations = await _lookupsService.GetLookups<DocumentTypeRelation>();
            var docType = await GetDocType();
            if (!allDocTypeRelations.Any(a => a.DocumentTypeId == docType.Id && a.RelationId == marriageDoc.RelationId))
                throw new DomainException($"The relation of the requester and the marriage document owner is not valid.\r\nMarriageDoc Name: {marriageDoc?.Name?.FullName}, RelationId:{marriageDoc?.RelationId}");
        }

        public async Task<decimal> GetDocPrice()
        {
            var docType = await GetDocType();
            return docType.Price;
        }

        public async Task<DocumentType> GetDocType()
        {
            return await _lookupsService.FindWhere<DocumentType>(a => a.Code == "MOICSO003");
        }

        private async Task SetDefaultStateId(MarriageDoc marriageDoc)
        {
            var defaultState = await _lookupsService.FindWhere<State>(a => a.Code == "NEW");
            marriageDoc.StateId = defaultState?.Id;
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _marriageDocRepository.UnitOfWork.CommitChangesAsync();
        }
    }
}
