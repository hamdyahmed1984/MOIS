using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FunctionalTests
{
    /// <summary>
    /// This class is used to bypass authentication
    /// </summary>
    public class TestingAuthenticationHandler : AuthenticationHandler<TestingAuthenticationOptions>
    {
        public TestingAuthenticationHandler(IOptionsMonitor<TestingAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                "Test Scheme");

            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }

    public static class TestingAuthenticationExtensions
    {
        public static AuthenticationBuilder AddTestingAuth(this AuthenticationBuilder builder, Action<TestingAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<TestingAuthenticationOptions, TestingAuthenticationHandler>("Test Scheme", "Test Auth", configureOptions);
        }
    }

    public class TestingAuthenticationOptions : AuthenticationSchemeOptions
    {
        public virtual ClaimsIdentity Identity { get; } = new ClaimsIdentity(new Claim[]
        {
            new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", Guid.NewGuid().ToString()),
        }, "test");
    }
}
