using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Communication;
using Domain.Entities;
using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using System.Linq;
using Microsoft.Extensions.Logging;
using Application.Configs;
using Microsoft.Extensions.Options;

namespace Application.Services
{
    public class RequestService : IRequestService
    {
        //private readonly IRepository<Request> _requestRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly ILogger _logger;
        private readonly ICachedLookupsService _lookupsService;
        private readonly IBirthDocService _birthDocService;
        private readonly IDeathDocService _deathRecordService;
        private readonly IMarriageDocService _marriageDocService;
        private readonly IDivorceDocService _divorceDocService;
        private readonly INidDocService _nidDocService;
        private readonly PostalPackageOptions _postalPackageOptions;

        public RequestService(IRequestRepository requestRepository, ILogger<RequestService> logger, ICachedLookupsService lookupsService, IOptions<AppConfigs> appConfigs,
            IBirthDocService birthDocService, IDeathDocService deathRecordService,
            IMarriageDocService marriageDocService, IDivorceDocService divorceDocService, INidDocService nidDocService)
        {
            _logger = logger;
            _requestRepository = requestRepository;
            _lookupsService = lookupsService;
            _birthDocService = birthDocService;
            _deathRecordService = deathRecordService;
            _marriageDocService = marriageDocService;
            _divorceDocService = divorceDocService;
            _postalPackageOptions = appConfigs.Value.PostalPackageOptions;
            _nidDocService = nidDocService;
        }

        public async Task<RequestResponse> GetRequestAsync(int requestId)
        {
            try
            {
                _logger.LogInformation($"Getting request with Id: {requestId}");

                var request = await _requestRepository.GetRequest(requestId);

                if (request == null)//No error occured but request not found
                    return new RequestResponse(true, $"There is no request with Id: {requestId}.");

                return new RequestResponse(request);
            }
            catch (Exception ex)
            {
                string errorMsg = $"An error occurred while trying to get the request with Id:{requestId}. {ex.Message}";
                errorMsg += ex.InnerException != null ? $"\r\nInner exception message: {ex.InnerException.Message}" : "";
                _logger.LogError(ex, errorMsg);
                // Do some logging stuff
                return new RequestResponse(errorMsg);
            }
        }

        public async Task<RequestResponse> CreateRequestAsync(Request request, string issuerCode, bool previewOnly = false)
        {
            try
            {
                _logger.LogInformation("Creating request: {@Request}", request);
                await SetIssuerId(request, issuerCode);
                await _requestRepository.CreateRequest(request);
            
                bool allDocsAreValid = await CreateAllDocuments(request);
                request.SetPrice(CalculateDocumentsPrice(request));
                request.SetPostalFees(CalculatePostalFees(request));

                if (!previewOnly)
                    await SaveChangesAsync();

                return new RequestResponse(request);
            }
            catch(Exception ex)
            {
                string errorMsg = $"An error occurred while saving the request: {ex.Message}";
                errorMsg += ex.InnerException != null ? $"\r\nInner exception message: {ex.InnerException.Message}" : "";
                _logger.LogError(ex, errorMsg);
                // Do some logging stuff
                return new RequestResponse(errorMsg);
            }
        }

        private decimal CalculateDocumentsPrice(Request request)
        {
            decimal totalPrice = 0;
            //Note: aggregate is used here because it is faster than sum as the aggregate method uses a foreach loop internally
            //where the sum mehtod uses Select and an iterator which adds an additional overhead
            //totalPrice += request.BirthDocs.Sum(a => a.Price);
            totalPrice += request.BirthDocs.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.CriminalStateRecords.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.DeathDocs.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.DivorceDocs.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.FamilyRecords.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.MarriageDocs.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.NidDoc.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.PersonalRecords.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.WorkPermitClearances.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.WorkPermitRenews.Aggregate(0m, (result, element) => result + element.Price);
            totalPrice += request.WorkPermitReplaces.Aggregate(0m, (result, element) => result + element.Price);
            return totalPrice;
        }

        private decimal CalculatePostalFees(Request request)
        {
            //We should cast any at least one part of the division operation to keep the fraction
            return Math.Ceiling(request.GetDocsCount() / (decimal)_postalPackageOptions.PackageItemsMaxCount) * _postalPackageOptions.PackagePrice;            
        }



        private async Task<bool> CreateAllDocuments(Request request)
        {
            //Return false on first document failed
            if (request.BirthDocs.Count > 0)
                if (!await CreateBirthDocs(request.BirthDocs)) return false;
            if (request.DeathDocs.Count > 0)
                if (!await CreateDeathRecords(request.DeathDocs)) return false;
            if (request.MarriageDocs.Count > 0)
                if (!await CreateMarriageDocs(request.MarriageDocs)) return false;
            if (request.DivorceDocs.Count > 0)
                if (!await CreateDivorceDocs(request.DivorceDocs)) return false;
            if (request.NidDoc.Count > 1)
                throw new Exception("A request should should no more than one NID document.");
            if (request.NidDoc.Count == 1)
                if (!await CreateNidDocs(request.NidDoc)) return false;
            return true;
        }

        private async Task<bool> CreateNidDocs(IReadOnlyCollection<NidDoc> nationalIdenNumbers)
        {
            var doc = await _nidDocService.CreateNidDocAsync(nationalIdenNumbers.First());
            return doc.Success ? true : false;//If all docs are created successfully return true, else return false
        }

        private async Task<bool> CreateBirthDocs(IReadOnlyCollection<BirthDoc> birthDocs)
        {
            var docs = await _birthDocService.CreateBirthDocsAsync(birthDocs);
            return docs.All(a => a.Success) ? true : false;//If all docs are created successfully return true, else return false
        }

        private async Task<bool> CreateDeathRecords(IReadOnlyCollection<DeathDoc> deathRecords)
        {
            var docs = await _deathRecordService.CreateDeathDocsAsync(deathRecords);
            return docs.All(a => a.Success) ? true : false;//If all docs are created successfully return true, else return false
        }

        private async Task<bool> CreateMarriageDocs(IReadOnlyCollection<MarriageDoc> marriageDocs)
        {
            var docs = await _marriageDocService.CreateMarriageDocsAsync(marriageDocs);
            return docs.All(a => a.Success) ? true : false;//If all docs are created successfully return true, else return false
        }

        private async Task<bool> CreateDivorceDocs(IReadOnlyCollection<DivorceDoc> divorceDocs)
        {
            var docs = await _divorceDocService.CreateDivorceDocsAsync(divorceDocs);
            return docs.All(a => a.Success) ? true : false;//If all docs are created successfully return true, else return false
        }

        private async Task SetIssuerId(Request request, string issuerCode)
        {
            var issuer = await _lookupsService.FindWhere<Issuer>(a => a.Code == issuerCode);
            request.SetIssueId(issuer?.Id ?? 0);
        }

        private async Task<int> SaveChangesAsync()
        {
            return await _requestRepository.UnitOfWork.CommitChangesAsync();
        }

        //public async Task<Request> GetRequest(int reqId)
        //{
        //    return await _requestRepository.FindAsync(reqId);
        //}

        //public async Task<Request> AddRequestState(Request req, RequestState reqState)
        //{
        //    req.AddRequestState(reqState);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddPaymentDetails(Request req, PaymentDetails paymentDetails)
        //{
        //    req.AddPaymentDetail(paymentDetails);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddBirthCertificateDoc(Request req, BirthCertificate birthCertificateDoc)
        //{
        //    req.AddBirthCertificateDoc(birthCertificateDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddCriminalStateRecordDoc(Request req, CriminalStateRecord criminalStateRecordDoc)
        //{
        //    req.AddCriminalStateRecordDoc(criminalStateRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddDeathRecordDoc(Request req, DeathRecord deathRecordDoc)
        //{
        //    req.AddDeathRecordDoc(deathRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddDivorceRecordDoc(Request req, DivorceRecord divorceRecordDoc)
        //{
        //    req.AddDivorceRecordDoc(divorceRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddDWorkPermitClearanceDoc(Request req, WorkPermitClearance workPermitClearanceDoc)
        //{
        //    req.AddDWorkPermitClearanceDoc(workPermitClearanceDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddFamilyRecordDoc(Request req, FamilyRecord familyRecordDoc)
        //{
        //    req.AddFamilyRecordDoc(familyRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddMarriageRecordDoc(Request req, MarriageRecord marriageRecordDoc)
        //{
        //    req.AddMarriageRecordDoc(marriageRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddNationalIdenNumberDoc(Request req, NationalIdenNumber nationalIdenNumberDoc)
        //{
        //    req.AddNationalIdenNumberDoc(nationalIdenNumberDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddPersonalRecordDoc(Request req, PersonalRecord personalRecordDoc)
        //{
        //    req.AddPersonalRecordDoc(personalRecordDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddWorkPermitRenewDoc(Request req, WorkPermitRenew workPermitRenewDoc)
        //{
        //    req.AddWorkPermitRenewDoc(workPermitRenewDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> AddWorkPermitReplaceDoc(Request req, WorkPermitReplace workPermitReplaceDoc)
        //{
        //    req.AddWorkPermitReplaceDoc(workPermitReplaceDoc);
        //    await SaveChangesAsync();
        //    return req;
        //}

        //public async Task<Request> ChangePaymentMethod(Request req, PaymentMethod paymentMethod)
        //{
        //    req.ChangePaymentMethod(paymentMethod);
        //    await SaveChangesAsync();
        //    return req;
        //}
    }
}
