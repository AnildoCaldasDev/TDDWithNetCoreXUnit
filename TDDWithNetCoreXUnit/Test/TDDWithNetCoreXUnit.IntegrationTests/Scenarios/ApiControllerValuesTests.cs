using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDDWithNetCoreXUnit.IntegrationTests.Fixtures;
using Xunit;

namespace TDDWithNetCoreXUnit.IntegrationTests.Scenarios
{
    public class ApiControllerValuesTests
    {
        private readonly TestContext _testContext;

        public ApiControllerValuesTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ValuesReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("api/values/5");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Values_GetById_ValuesReturnsArgumentExceptionResponse_WhenValueIs_Six()
        {
            var response = await _testContext.Client.GetAsync("api/values/6");
            //response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Values_GetById_ReturnsBadRequestResponse_WhenPassStringToIntegerParameter()
        {
            var response = await _testContext.Client.GetAsync("api/values/xxx");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Values_GetById_CorrectContentType()
        {
            var response = await _testContext.Client.GetAsync("/api/values/5");
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString().Should().Be("text/plain; charset=utf-8");
        }

        [Fact]
        public async Task Values_PostNewValue_ReturnsCreatedResponse()
        {
            //fonte: https://carldesouza.com/httpclient-getasync-postasync-sendasync-c/
            //fonte: https://stackoverflow.com/questions/36625881/how-do-i-pass-an-object-to-httpclient-postasync-and-serialize-as-a-json-body


            //deu certo com uma string simples:
            var json = JsonConvert.SerializeObject("teste");
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            //var valueModel = new ValueModel();
            //valueModel.ValueId = 1;
            //valueModel.Value = "MeuValor";

            //var json = JsonConvert.SerializeObject(valueModel);
            //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");


            var response = await _testContext.Client.PostAsync("/api/values", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);

        }
    }
}
