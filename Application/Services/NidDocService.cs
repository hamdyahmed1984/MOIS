using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Communication;
using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class NidDocService : INidDocService
    {
        private readonly INidDocRepository _nidDocRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;

        public NidDocService(INidDocRepository nidDocRepository, ILogger<NidDocService> logger, ICachedLookupsService lookupsService)
        {
            _logger = logger;
            _nidDocRepository = nidDocRepository;
            _lookupsService=lookupsService;
        }

        public async Task<NidDocResponse> CreateNidDocAsync(NidDoc nationalIdenNumber, bool autoSave = false)
        {
            await SetDefaultStateId(nationalIdenNumber);
            nationalIdenNumber.Price = await GetDocPrice();
            await _nidDocRepository.CreateNidDoc(nationalIdenNumber);
            if (autoSave)
                await SaveChangesAsync();

            return new NidDocResponse(nationalIdenNumber);
        }

        public async Task<decimal> GetDocPrice()
        {
            var docType = await GetDocType();
            return docType.Price;
        }

        public async Task<DocumentType> GetDocType()
        {
            return await _lookupsService.FindWhere<DocumentType>(a => a.Code == "MOICSO002");
        }

        private async Task SetDefaultStateId(NidDoc nationalIdenNumber)
        {
            var defaultState = await _lookupsService.FindWhere<State>(a => a.Code == "NEW");
            nationalIdenNumber.StateId = defaultState?.Id;
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _nidDocRepository.UnitOfWork.CommitChangesAsync();
        }
    }
}
