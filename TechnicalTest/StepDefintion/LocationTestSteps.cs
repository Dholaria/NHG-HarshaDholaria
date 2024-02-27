using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TechnicalTest
{
    [Binding]
    public class LocationTestSteps
    {
        private readonly LocationClient _locationClient;
        public LocationTestSteps(LocationClient locationClient)
        {
            _locationClient = locationClient;
        }

        [Given(@"I make a request to get location information (.*),(.*)")]
        public async Task GivenIMakeARequestToGetLocationInformation(string countryCode, string postCode)
        {
            await _locationClient.GetLocationInformationAsync(countryCode, postCode);
        }
        
        [Then(@"I verify the request status (.*)")]
        public void ThenTheRequestShouldBeSuccessful(bool isSuccessful)
        {    
            _locationClient.VerifyRequestStatus(isSuccessful);
        }
    }
}