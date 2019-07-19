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
    public class MarriageDocController : ControllerBase
    {
        private readonly IMarriageDocService _marriageDocService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public MarriageDocController(IMarriageDocService marriageDocService, IMapper mapper, ILoggerFactory logger)
        {
            _marriageDocService = marriageDocService;
            _mapper = mapper;
            _logger = logger.CreateLogger("MarriageDocController");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-marriage-docs")]
        public async Task<IActionResult> CreateMarriageDocsAsync([FromBody]IEnumerable<MarriageDocResourceIn> marriageDocsResource)
        {
            _logger.LogInformation("Received MarriageDocResource list: {@MarriageDoc}", marriageDocsResource);
            var marriageDocs = _mapper.Map<IEnumerable<MarriageDocResourceIn>, IEnumerable<MarriageDoc>>(marriageDocsResource);

            var result = await _marriageDocService.CreateMarriageDocsAsync(marriageDocs, true);

            if (result.Any(a => !a.Success))
                return BadRequest(result.First(a => !a.Success).Message);

            var savedMarriageDocs = _mapper.Map<IEnumerable<MarriageDoc>, IEnumerable<MarriageDocResourceOut>>(result.Select(a=>a.MarriageDoc));
            return Ok(savedMarriageDocs);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/doc-price")]
        public async Task<IActionResult> GetDocPriceAsync()
        {            
            var docPrice = await _marriageDocService.GetDocPrice();
            return Ok(docPrice);
        }
    }
}