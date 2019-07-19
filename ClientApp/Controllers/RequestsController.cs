using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ClientApp.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;
using System;
using ClientApp.VerificationPlatform;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Application.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace ClientApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        //private readonly IServiceProvider _serviceProvider;
        private readonly ITokenVerificationService _tokenVerification;

        public RequestsController(IRequestService requestService, IMapper mapper, ILoggerFactory loggerFactory, ITokenVerificationService tokenVerification)
        {
            _requestService = requestService;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger("RequestsController");
            _tokenVerification = tokenVerification;
        }

        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-cso-request")]
        //[ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RequestResourceOut>> CreateCsoRequestAsync([FromBody]RequestResourceIn requestResource, [FromHeader]bool previewOnly, [FromHeader]string email, [FromHeader]string token)
        {
            var msg = ValidateVerificationPlatformLogin(requestResource, email, token);
            if (!string.IsNullOrWhiteSpace(msg))
                return BadRequest(new ErrorResource(msg));

            return await CreateRequestAsync(requestResource, "MOI-CSO", previewOnly);
        }      

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-csr-request")]
        public async Task<ActionResult<RequestResourceOut>> CreateCsrRequestAsync([FromBody]RequestResourceIn requestResource, [FromHeader]bool previewOnly, [FromHeader]string email, [FromHeader]string token)
        {
            var msg = ValidateVerificationPlatformLogin(requestResource, email, token);
            if (!string.IsNullOrWhiteSpace(msg))
                return BadRequest(new ErrorResource(msg));
            return await CreateRequestAsync(requestResource, "MOI-CSR", previewOnly);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [HttpPost]
        [Route("/api/[controller]/create-wp-request")]
        public async Task<ActionResult<RequestResourceOut>> CreateWpRequestAsync([FromBody]RequestResourceIn requestResource, [FromHeader]bool previewOnly, [FromHeader]string email, [FromHeader]string token)
        {
            var msg = ValidateVerificationPlatformLogin(requestResource, email, token);
            if (!string.IsNullOrWhiteSpace(msg))
                return BadRequest(new ErrorResource(msg));
            return await CreateRequestAsync(requestResource, "MOI-WP", previewOnly);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/[controller]/request-status")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> GetRequestAsync([FromHeader] int? requestId)
        {
            if (!requestId.HasValue)
                return BadRequest(new ErrorResource("RequestId must have a value, please send it in the header of the request"));
            var result = await _requestService.GetRequestAsync(requestId.Value);

            if (result.Success && result.Request == null)
                return NotFound(new ErrorResource(result.Message));

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var requiredRequest = _mapper.Map<Request, RequestStateResource>(result.Request);
            return Ok(requiredRequest);
        }

        private async Task<ActionResult<RequestResourceOut>> CreateRequestAsync(RequestResourceIn requestResource, string issuerCode, bool previewOnly = false)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState.GetErrorMessages());

            var request = _mapper.Map<RequestResourceIn, Request>(requestResource);

            var result = await _requestService.CreateRequestAsync(request, issuerCode, previewOnly);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var savedRequest = _mapper.Map<Request, RequestResourceOut>(result.Request);
            return Ok(savedRequest);
        }

        private string ValidateVerificationPlatformLogin(RequestResourceIn requestResource, string email, [FromHeader]string token)
        {
            //var verificationModel = new TokenVerification(_serviceProvider.GetService<IOptions<AppConfigs>>(), _serviceProvider.GetService<ILoggerFactory>())
            //    .ValidateLogin(email, token);
            var verificationModel = _tokenVerification.ValidateLogin(email, token);
            if (verificationModel == null)
                return "Not authorized to create requests.";
            if (requestResource.NID == null || requestResource.NID.NationalIdenNumber != verificationModel.NID)
                return "Not the same NID as the logged in citizen.";
            if (requestResource.Name == null) requestResource.Name = new RequesterNameResource();
            if (requestResource.ContactDetails == null) requestResource.ContactDetails = new ContactDetailsResource();
            if (requestResource.NID == null) requestResource.NID = new NIDResource();
            requestResource.Name.FirstName = verificationModel.FullName;
            requestResource.Name.FatherName = "...";
            requestResource.Name.GrandFatherName = "...";
            requestResource.Name.FamilyName = "...";
            requestResource.MotherFullName = verificationModel.MotherFirstName;
            requestResource.NID.NationalIdenNumber = verificationModel.NID;
            requestResource.ContactDetails.Mobile1 = verificationModel.Mobile;
            requestResource.ContactDetails.Email = verificationModel.Email;
            return string.Empty;
        }
    }
}