using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Text;
using Application.Configs;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Domain.VerificationPlatform;
using Application.Interfaces;

namespace ClientApp.VerificationPlatform
{
    public class TokenVerificationService: ITokenVerificationService
    {
        private readonly VerificationPlatformOptions _verificationPlatformOptions;
        private readonly ILogger _logger;
        public TokenVerificationService(IOptions<AppConfigs> appConfigs, ILoggerFactory logger)
        {
            _verificationPlatformOptions = appConfigs.Value.VerificationPlatformOptions;
            _logger = logger.CreateLogger("TokenVerification");
        }
        public VerificationModel ValidateLogin(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                _logger.LogError($"Failed to validate token. Email or Token is empty. Email: {email} , Token: {token}.");
                return null;
            }

            try
            {
                _logger.LogInformation($"Validating Email: {email}, Token: {token}.");

                if (_verificationPlatformOptions.BypassVerificationApi)
                {
                    return ValidateLogin_Test(email, token);
                }
                else
                {
                    WebClient client = new WebClient();
                    var reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("Email", email);
                    reqparm.Add("Token", token);
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    client.Headers.Add("Accept", "application/json");
                    client.Headers.Add("Authorization", "bearer " + GetAccessToken());
                    byte[] responseBytes = client.UploadValues(_verificationPlatformOptions.ApiValidateLoginUrl, "POST", reqparm);
                    string responseBody = Encoding.UTF8.GetString(responseBytes);
                    var R = JObject.Parse(responseBody);
                    var Status = R["status"].ToString();

                    _logger.LogInformation($"Validation Result: {responseBody}.");

                    VerificationModel model = new VerificationModel();
                    model.Status = R["status"].ToString();
                    model.Message = R["message"].ToString();
                    if (R["data"].Any())
                    {
                        model.FullName = R["data"]["fullName"].ToString();
                        model.NID = R["data"]["cardId"].ToString();
                        model.NidFactoryNo = R["data"]["cardFactoryNumber"].ToString();
                        model.Email = R["data"]["email"].ToString();
                        model.MotherFirstName = R["data"]["motherFirstName"].ToString();
                        model.Mobile = R["data"]["mobile"].ToString();
                        model.GovernorateId = R["data"]["governorateId"].ToString();
                        model.Address = R["data"]["address"].ToString();
                        model.JobTitle = R["data"]["jobTitle"].ToString();
                    }
                    if (model != null && model.Status == "1")
                        return model;
                    else return null;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Failed to validate token.", ex);
                return null;
            }
        }

        public VerificationModel ValidateLogin_Test(string email, string token)
        {
            try
            {
                _logger.LogInformation($"ValidateLogin_Test: Validating Email: {email}, Token: {token}.");               

                VerificationModel model = new VerificationModel();
                model.Status = "1";
                model.Message = "message";
                model.FullName = "باسم إبراهيم محمد";
                model.NID = "27906250103655";
                model.NidFactoryNo = "HC7429791";
                model.Email = "basemibraheem@gmail.com";
                model.MotherFirstName = "الست الوالدة";
                model.Mobile = "01112288890";
                model.GovernorateId = "1040";
                model.Address = "برج المعادي الجديدة الدائري -ميدان الجزائر - البساتين - القاهرة";
                model.JobTitle = "مهندس كهرباء حر";

                return model;
            }
            catch (Exception ex)
            {
                _logger.LogError("ValidateLogin_Test: Failed to validate token.", ex);
                return null;
            }
        }

        private string GetAccessToken()
        {
            WebClient client = new WebClient();
            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("username", _verificationPlatformOptions.ApiUserName);
            reqparm.Add("password", _verificationPlatformOptions.ApiPassword);
            reqparm.Add("grant_type", "password");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.Headers.Add("Accept", "application/json");
            client.Headers.Add("TargetModuleId", "674152");

            byte[] responsebytes = client.UploadValues(_verificationPlatformOptions.ApiGetAccessTokenUrl, "POST", reqparm);
            string responsebody = Encoding.UTF8.GetString(responsebytes);
            var R = JObject.Parse(responsebody);
            var AccessToken = R["access_token"].ToString();

            return AccessToken;
        }

    }
}
