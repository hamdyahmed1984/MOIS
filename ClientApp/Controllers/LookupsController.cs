using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using ClientApp.Controllers.Resources.Lookups;
using Domain.Entities;
using Domain.Entities.Lookups;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //[ApiExplorerSettings(GroupName = "Contains end points for lookups")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class LookupsController : ControllerBase
    {
        private readonly ICachedLookupsService _lookupsService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public LookupsController(ICachedLookupsService lookupService, IMapper mapper, ILoggerFactory logger)
        {
            _lookupsService = lookupService;
            _mapper = mapper;
            _logger = logger.CreateLogger("LookupsController");
        }

        [Route("/api/[controller]/genders")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<LookupBaseResource>> GetGendersAsync()
        {
            var gendersResource = _mapper.Map<IEnumerable<LookupBase>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<Gender>());
            return gendersResource;
        }

        [Route("/api/[controller]/govs")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetGovsAsync()
        {
            return _mapper.Map<IEnumerable<Governorate>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<Governorate>());
        }

        [Route("/api/[controller]/police-depts")]
        [HttpGet]
        public async Task<IEnumerable<PoliceDepartmentResource>> GetPoliceDepartmentsAsync()
        {
            return _mapper.Map<IEnumerable<PoliceDepartment>, IEnumerable<PoliceDepartmentResource>>(await _lookupsService.GetLookups<PoliceDepartment>(null, null, "Governorate"));
        }

        [Route("/api/[controller]/postal-codes")]
        [HttpGet]
        public async Task<IEnumerable<PostalCodeResource>> GetPostalCodesAsync()
        {
            return _mapper.Map<IEnumerable<PostalCode>, IEnumerable<PostalCodeResource>>(await _lookupsService.GetLookups<PostalCode>(null, null, "Governorate"));
        }

        [Route("/api/[controller]/relations")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetRelationsAsync()
        {
            return _mapper.Map<IEnumerable<Relation>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<Relation>());
        }

        [Route("/api/[controller]/nid-issue-reasons")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetNidIssueReasonsAsync()
        {
            return _mapper.Map<IEnumerable<NidIssueReason>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<NidIssueReason>());
        }

        [Route("/api/[controller]/nid-job-types")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetNidJobTypesAsync()
        {
            return _mapper.Map<IEnumerable<JobTypeNID>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<JobTypeNID>());
        }

        [Route("/api/[controller]/states")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetStatesAsync()
        {
            return _mapper.Map<IEnumerable<State>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<State>());
        }

        //[Route("/api/[controller]/order-status")]
        //[HttpGet]
        //public async Task<IEnumerable<LookupBaseResource>> GetOrderStatusesAsync()
        //{
        //    return _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<LookupBaseResource>>(await _lookupsService.GetLookups<OrderStatus>());
        //}

        [Route("/api/[controller]/lookups-types")]
        [HttpGet]
        public IEnumerable<string> GetLookupTypes()
        {
            return Enum.GetNames(typeof(LookupType));//.Cast<LookupType>();
        }

        [Route("/api/[controller]/lookups-by-type")]
        [HttpGet]
        public async Task<IEnumerable<LookupBaseResource>> GetLookups([FromHeader]string lookupsType)
        {
            object _lookupsType;
            bool valid = Enum.TryParse(typeof(LookupType), lookupsType, true, out _lookupsType);
            if (valid)
            {
                switch ((LookupType)_lookupsType)
                {
                    case LookupType.Genders:
                        return await GetGendersAsync();
                    case LookupType.Relations:
                        return await GetRelationsAsync();
                    case LookupType.NidIssuingReasons:
                        return await GetNidIssueReasonsAsync();
                    case LookupType.NidJobTypes:
                        return await GetNidJobTypesAsync();
                    case LookupType.Governorates:
                        return await GetGovsAsync();
                    case LookupType.PoliceDepartments:
                        return await GetPoliceDepartmentsAsync();
                    case LookupType.PostalCodes:
                        return await GetPostalCodesAsync();
                    case LookupType.States:
                        return await GetStatesAsync();
                    //case LookupType.OrderStatus:
                    //    return await GetOrderStatusesAsync();
                }
            }
            return null;
        }

        [Route("/api/[controller]/all-lookups")]
        [HttpGet]
        public async Task<Dictionary<string, IEnumerable<LookupBaseResource>>> GetAllLookups()
        {
            return new Dictionary<string, IEnumerable<LookupBaseResource>>
            {
                { "Genders", await GetGendersAsync() },
                { "Relations", await GetRelationsAsync() },
                { "NidIssuingReasons", await GetNidIssueReasonsAsync()},
                { "NidJobTypes", await GetNidJobTypesAsync()},
                { "Governorates", await GetGovsAsync()},
                { "PoliceDepartments", await GetPoliceDepartmentsAsync()},
                { "PostalCodes", await GetPostalCodesAsync()},
                { "States", await GetStatesAsync()},
                //{ "OrderStatuses", await GetOrderStatusesAsync()}
            };
        }
    }
}