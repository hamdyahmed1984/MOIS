using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Communication;
using Domain.Entities.Documents;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CsrService : ICsrService
    {
        private readonly ICsrRepository _CsrRepository;
        private readonly ILogger _logger;

        public CsrService(ICsrRepository csrRepository, ILogger<RequestService> logger)
        {
            _logger = logger;
            _CsrRepository = csrRepository;
        }

        public async Task<CsrResponse> CreateCsrAsync(CriminalStateRecord csr)
        {
            try
            {
                csr.NumberOfCopies = _CsrRepository.GetDefaultNumberOfCopies();
                _logger.LogInformation("Creating criminal state record: {@CSR}", csr);
                await _CsrRepository.CreateCsr(csr);
                await SaveChangesAsync();

                return new CsrResponse(csr);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while saving the criminal state record: {ex.Message}");
                // Do some logging stuff
                return new CsrResponse($"An error occurred while saving the criminal state record: {ex.Message}");
            }
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _CsrRepository.UnitOfWork.CommitChangesAsync();
        }        
    }
}
