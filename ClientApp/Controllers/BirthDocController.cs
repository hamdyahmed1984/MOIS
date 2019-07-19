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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BirthDocController : ControllerBase
    {
        private readonly IBirthDocService _birthDocService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public BirthDocController(IBirthDocService birthDocService, IMapper mapper, ILoggerFactory logger)
        {
            _birthDocService = birthDocService;
            _mapper = mapper;
            _logger = logger.CreateLogger("BirthDocController");
        }

        
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost]
        [Route("/api/[controller]/create-birth-docs")]
        public async Task<IActionResult> CreateBirthDocsAsync([FromBody]IEnumerable<BirthDocResourceIn> birthDocResources)
        {
            _logger.LogInformation("Received BirthDocResource list: {@BirthDocs}", birthDocResources);
            var birthDocs = _mapper.Map<IEnumerable<BirthDocResourceIn>, IEnumerable<BirthDoc>>(birthDocResources);

            var result = await _birthDocService.CreateBirthDocsAsync(birthDocs/*, birthDocResources.Select(a=>a.GenderCode), birthDocResources.Select(a=>a.RelationCode)*/, true);

            if (result.Any(a => !a.Success))
                return BadRequest(result.First(a => !a.Success).Message);

            var savedBirthDocs = _mapper.Map<IEnumerable<BirthDoc>, IEnumerable<BirthDocResourceOut>>(result.Select(a => a.BirthDoc));
            return Ok(savedBirthDocs);
        }

        [HttpGet]
        [Route("/api/[controller]/doc-price")]
        public async Task<IActionResult> GetDocPriceAsync()
        {            
            var docPrice = await _birthDocService.GetDocPrice();
            return Ok(docPrice);
        }
    }
}