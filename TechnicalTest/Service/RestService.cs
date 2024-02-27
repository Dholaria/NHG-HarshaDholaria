using RestSharp;
using System.Threading.Tasks;

namespace TechnicalTest.Service
{
    public class RestService
    {
        public async Task<RestResponse> GetAsync(string url)
        {
            RestClient restClient = new RestClient(url);
            var request = new RestRequest("", Method.Get);

            // Make the asynchronous request
            var restResponse = await restClient.ExecuteAsync(request);

            return restResponse;
        }
    }
}