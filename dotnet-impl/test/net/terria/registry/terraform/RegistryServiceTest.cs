using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using net.terria.registry.terraform;
using Microsoft.VisualBasic;

namespace net.terria.registry.terraform
{
    [TestFixture]
    public class RegistryServiceTest
    {

        private static string REGISTRY_STORAGE_PATH = "../../../../registry/";
        

        private String _registry_storage = REGISTRY_STORAGE_PATH;

        [SetUp]
        public void Setup()
        {
            if (!Directory.Exists(_registry_storage))
            {
                Directory.CreateDirectory(_registry_storage);
            }

             Console.Out.WriteLine("Registry Storage Root: " + Path.GetFullPath(_registry_storage));
        }

        [TearDown]
        public void TearDown()
        {
            // do nothing for now
            Console.Out.WriteLine("Registry Storage Root: " + Path.GetFullPath(_registry_storage));
        }

        [Test]
        public void TestInitWithModule()
        {
            // Create provider structure under terraform/providers
            var modulesPath = Path.Combine(_registry_storage, "terraform", "modules");
            var namespacePath = Path.Combine(modulesPath, "azure");
            var modulePath = Path.Combine(namespacePath, "terraform-azurerm-avm-utl-regions");
            var versionPath = Path.Combine(modulePath, "0.1.0");
            var platformPath = Path.Combine(versionPath, "azurerm");

            Directory.CreateDirectory(platformPath);

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("registry.storage.path", _registry_storage) })
                .Build();

            var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<RegistryService>();

            var service = new RegistryService(logger, config);

            Assert.That(service.GetModules().Count, Is.GreaterThan(0));
            Assert.That(service.GetModule("terraform", "azure", "terraform-azurerm-avm-utl-regions"), Is.Not.Null);
        }


        [Test]
        public void TestInitWithProvider()
        {
            // Create provider structure under terraform/providers
            var providersPath = Path.Combine(_registry_storage, "terraform", "providers");
            var namespacePath = Path.Combine(providersPath, "hashicorp");
            var providerPath = Path.Combine(namespacePath, "aws");
            var versionPath = Path.Combine(providerPath, "1.0.0");
            var platformPath = Path.Combine(versionPath, "linux", "amd64");

            Directory.CreateDirectory(platformPath);

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { new KeyValuePair<string, string>("registry.storage.path", _registry_storage) })
                .Build();

            var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<RegistryService>();

            var service = new RegistryService(logger, config);

            Assert.That(service.GetProviders().Count, Is.GreaterThan(0));
            Assert.That(service.GetProvider("terraform", "hashicorp", "aws"), Is.Not.Null);
        }

        // Add more tests as needed
    }
}