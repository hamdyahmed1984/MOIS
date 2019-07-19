using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientApp.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.Documents;
using Microsoft.Extensions.Logging;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NidDocController : ControllerBase
    {
        private readonly INidDocService _nidDocService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public NidDocController(INidDocService nidDocService, IMapper mapper, ILoggerFactory logger)
        {
            _nidDocService = nidDocService;
            _mapper = mapper;
            _logger = logger.CreateLogger("NidDocController");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-nid-doc")]
        public async Task<IActionResult> CreateNidDocAsync([FromBody]NidDocResourceIn nidDocResource)
        {
            _logger.LogInformation("Received NidDocResource: {@NidDocResource}", nidDocResource);
            var nidDoc = _mapper.Map<NidDocResourceIn, NidDoc>(nidDocResource);

            var result = await _nidDocService.CreateNidDocAsync(nidDoc, true);

            if (!result.Success)
                return BadRequest(result.Message);

            var savedNidDoc = _mapper.Map<NidDoc, NidDocResourceOut>(result.NidDoc);
            return Ok(savedNidDoc);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/doc-price")]
        public async Task<IActionResult> GetDocPriceAsync()
        {            
            var docPrice = await _nidDocService.GetDocPrice();
            return Ok(docPrice);
        }
    }
}