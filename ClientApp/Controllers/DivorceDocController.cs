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
    public class DivorceDocController : ControllerBase
    {
        private readonly IDivorceDocService _divorceDocService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DivorceDocController(IDivorceDocService divorceDocService, IMapper mapper, ILoggerFactory logger)
        {
            _divorceDocService = divorceDocService;
            _mapper = mapper;
            _logger = logger.CreateLogger("DivorceDocController");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-divorce-docs")]
        public async Task<IActionResult> CreateDivorceDocsAsync([FromBody]IEnumerable<DivorceDocResourceIn> divorceDocsResource)
        {
            _logger.LogInformation("Received DivorceDocResource list: {@DivorceDoc}", divorceDocsResource);
            var divorceDocs = _mapper.Map<IEnumerable<DivorceDocResourceIn>, IEnumerable<DivorceDoc>>(divorceDocsResource);

            var result = await _divorceDocService.CreateDivorceDocsAsync(divorceDocs, true);

            if (result.Any(a => !a.Success))
                return BadRequest(result.First(a => !a.Success).Message);

            var savedDivorceDocs = _mapper.Map<IEnumerable<DivorceDoc>, IEnumerable<DivorceDocResourceOut>>(result.Select(a=>a.DivorceDoc));
            return Ok(savedDivorceDocs);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/doc-price")]
        public async Task<IActionResult> GetDocPriceAsync()
        {            
            var docPrice = await _divorceDocService.GetDocPrice();
            return Ok(docPrice);
        }
    }
}