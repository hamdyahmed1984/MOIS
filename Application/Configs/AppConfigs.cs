using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Configs
{
    public class AppConfigs
    {
        public TokenOptions TokenOptions { get; set; }
        public VerificationPlatformOptions VerificationPlatformOptions { get; set; }
        public PostalPackageOptions PostalPackageOptions { get; set; }
    }

    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public long AccessTokenExpiration { get; set; }
        public long RefreshTokenExpiration { get; set; }
    }

    public class PostalPackageOptions
    {
        public int PackagePrice { get; set; }
        public int PackageItemsMaxCount { get; set; }
    }

    public class VerificationPlatformOptions
    {
        public bool BypassVerificationApi { get; set; }
        public string ApiValidateLoginUrl { get; set; }
        public string ApiLoginUrl { get; set; }
        public string ApiGetAccessTokenUrl { get; set; }
        public string ApiUserName { get; set; }
        public string ApiPassword { get; set; }
    }
}
