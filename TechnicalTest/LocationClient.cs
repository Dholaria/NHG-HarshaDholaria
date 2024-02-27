using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using TechnicalTest.Service;

namespace TechnicalTest
{
    public class LocationClient
    {
        private readonly RestService _restService;
        private readonly ConfigurationProvider _configurationProvider;
        private RestResponse _response;

        public LocationClient(RestService restService, ConfigurationProvider configurationProvider)
        {
            _restService = restService;
            _configurationProvider = configurationProvider;
        }

        public async Task GetLocationInformationAsync(string countryCode, string postCode)
        {
            var baseUrl = _configurationProvider.GetUrl();
            var url = string.Format(baseUrl, countryCode, postCode);
            _response = await _restService.GetAsync(url);
        }

        public void VerifyRequestStatus(bool isSuccessful)
        {
            if (isSuccessful)
            {
                Assert.AreEqual(HttpStatusCode.OK, _response.StatusCode);
            }
            else
            {
                Assert.AreEqual(HttpStatusCode.NotFound, _response.StatusCode);
            }
        }
    }
}