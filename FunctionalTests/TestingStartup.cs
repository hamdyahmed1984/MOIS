using Application.Configs;
using Application.Security.Tokens;
using ClientApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalTests
{
    /// <summary>
    /// This class is used to bypass authentication by overriding the AuthenticationHandler and allow all requests
    /// </summary>
    public class TestingStartup: Startup
    {
        public TestingStartup(ILogger<TestingStartup> logger, IConfiguration configuration) : base(logger, configuration)
        {
        }

        protected override void ConfigureAuth(IServiceCollection services, TokenOptions tokenOptions, SigningConfigurations signingConfigurations)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Test Scheme"; // has to match scheme in TestingAuthenticationExtensions
                options.DefaultChallengeScheme = "Test Scheme";
            }).AddTestingAuth(o => { });
        }
    }
}
