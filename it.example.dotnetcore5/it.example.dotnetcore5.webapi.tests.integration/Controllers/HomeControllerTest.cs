using it.example.dotnetcore5.webapi.tests.integration.Controllers.Helpers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace it.example.dotnetcore5.webapi.tests.integration.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IHost _factory;
        private HttpClient _client;

        #region SetUp and TearDown
        [OneTimeSetUp]
        public void SetupOneTime()
        {
            var hostBuilder = CreateHostBuilderTestHelper.GetHostBuilderTest();
            _factory = hostBuilder.Start();
            _client = _factory.GetTestClient();
        }

        [OneTimeTearDown]
        public void TearDownOneTime()
        {
            _client.Dispose();
            _factory.Dispose();
        }
        #endregion

        [Test]
        [Category("Integration Test")]
        public async Task should_retrieve_all_posts()
        {
            // Arrange
            var endpoint = "/api/home";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [Category("Integration Test")]
        public async Task should_retrieve_post_by_id(int id)
        {
            // Arrange
            var endpoint = string.Format("/api/home/{0}", id.ToString());

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.IsSuccessStatusCode);
            Assert.That(!string.IsNullOrWhiteSpace(responseString));
        }

        [Test]
        [Category("Integration Test")]
        public async Task should_retrieve_no_one_post()
        {
            // Arrange
            var endpoint = "/api/home/1000";

            // Act
            var response = await _client.GetAsync(endpoint);
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.That(response.StatusCode == HttpStatusCode.NoContent);
            Assert.That(string.IsNullOrWhiteSpace(responseString));
        }
    }
}
