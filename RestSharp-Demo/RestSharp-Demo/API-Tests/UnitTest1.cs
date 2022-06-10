using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace API_Tests
{
    public class Tests
    {

        [Test]
        public async Task Get_All_Issues()
        {
          var client = new RestClient("https://api.github.com");  
          var requestIssues = new RestRequest("repos/shestakov14/API-Collections/issues");
          var IssueResponse = await client.ExecuteAsync(requestIssues);

            Assert.AreEqual(HttpStatusCode.OK, IssueResponse.StatusCode);
        }
    }
}