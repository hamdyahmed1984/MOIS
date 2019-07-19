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
    public class DeathDocController : ControllerBase
    {
        private readonly IDeathDocService _deathDocService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public DeathDocController(IDeathDocService deathDocService, IMapper mapper, ILoggerFactory logger)
        {
            _deathDocService = deathDocService;
            _mapper = mapper;
            _logger = logger.CreateLogger("DeathDocController");
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-death-docs")]
        public async Task<IActionResult> CreateDeathDocsAsync([FromBody]IEnumerable<DeathDocResourceIn> deathDocsResource)
        {
            _logger.LogInformation("Received DeathDocResource list: {@DeathDocs}", deathDocsResource);
            var deathrecords = _mapper.Map<IEnumerable<DeathDocResourceIn>, IEnumerable<DeathDoc>>(deathDocsResource);

            var result = await _deathDocService.CreateDeathDocsAsync(deathrecords, true);

            if (result.Any(a => !a.Success))
                return BadRequest(result.First(a => !a.Success).Message);

            var savedDeathRecords = _mapper.Map<IEnumerable<DeathDoc>, IEnumerable<DeathDocResourceOut>>(result.Select(a => a.DeathDoc));
            return Ok(savedDeathRecords);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/doc-price")]
        public async Task<IActionResult> GetDocPriceAsync()
        {            
            var docPrice = await _deathDocService.GetDocPrice();
            return Ok(docPrice);
        }
    }
}