using Application.Interfaces;
using Domain.Entities.Lookups;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp.HealthChecks
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly ICachedLookupsService _cachedLookupsService;
        public ApiHealthCheck(ICachedLookupsService cachedLookupsService) => _cachedLookupsService = cachedLookupsService;

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            var isHealthy = false;
            var genders = await _cachedLookupsService.GetLookups<Gender>();

            if (genders.Any())
                isHealthy = true;

            if (isHealthy)
                return HealthCheckResult.Healthy("I am healthy :)");
            return HealthCheckResult.Unhealthy("I am not healthy :(");
        }
    }
}
