using System.IO;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using net.terria.registry.terraform;

namespace net.terria.registry.terraform
{
    [TestFixture]
    public class RegistryApplicationTest
    {

        private static string REGISTRY_STORAGE_PATH = "../../../../registry/";
        

        private String _registry_storage = REGISTRY_STORAGE_PATH;


        private WebApplicationFactory<RegistryApplication> _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<RegistryApplication>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        config.AddInMemoryCollection(new Dictionary<string, string>
                        {
                            ["Registry:StoragePath"] = Path.GetFullPath(_registry_storage)
                        });
                    });
                });

            Console.Out.WriteLine("Registry Storage Root: " + Path.GetFullPath(_registry_storage));                
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();

            
        }

        [Test]
        public async Task TestProvidersVersionsEndpointReturnsNotFoundWhenNoData()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/providers/terraform/hashicorp/aws/versions");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task TestModulesVersionsEndpointReturnsNotFoundWhenNoData()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/modules/terraform/hashicorp/vpc/aws/versions");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        // Add more integration tests as needed
    }
}