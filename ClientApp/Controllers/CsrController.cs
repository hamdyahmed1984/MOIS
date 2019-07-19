using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientApp.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using ClientApp.Extensions;
using Domain.Entities.Documents;

namespace ClientApp.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class CsrController : ControllerBase
    {
        private readonly ICsrService _CsrService;
        private readonly IMapper _mapper;
        public CsrController(ICsrService csrService, IMapper mapper)
        {
            _CsrService = csrService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-csr-doc")]
        public async Task<IActionResult> CreateCsrDocAsync([FromBody]CsrResource CsrResource)
        {
            var csrDoc = _mapper.Map<CsrResource, CriminalStateRecord>(CsrResource);

            var result = await _CsrService.CreateCsrAsync(csrDoc);

            if (!result.Success)
                return BadRequest(result.Message);

            var savedCsrDoc = _mapper.Map<CriminalStateRecord, CsrResource>(result.CSR);
            return Ok(savedCsrDoc);
        }
    }
}