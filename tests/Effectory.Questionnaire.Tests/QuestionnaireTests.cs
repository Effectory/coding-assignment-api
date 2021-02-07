using Effectory.Services.Questionnaire;
using Effectory.Services.Questionnaire.Helpers;
using Effectory.Services.Questionnaire.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Effectory.Questionnaire.Tests
{
    public class QuestionnaireTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public QuestionnaireTests()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Get_Questions_Returns_Correct_Number_Of_Results()
        {
            //Arrange
            const int Actual = 5;

            //Act
            var response = await _client.GetAsync("/api/v1/questionnaire/1000/subjects/2605515/questions");
            var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<PagedResult<QuestionModel>>(stream, SerializationHelper.SerializerOptions.Value);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(result.Count, Actual);
        }
    }
}
