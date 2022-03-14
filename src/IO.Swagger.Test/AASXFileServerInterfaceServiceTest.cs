using IO.Swagger.Services;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;

namespace IO.Swagger.Test
{
    internal class AASXFileServerInterfaceServiceTest
    {
        private AASXFileServerInterfaceService? _fileService;
        private RestClient? _client;

        [SetUp]
        public void Setup()
        {
            _fileService = new AASXFileServerInterfaceService();
            var options = new RestClientOptions("http://localhost:5001")
            {
                ThrowOnAnyError = true,
                Timeout = 5000
            };
            _client = new RestClient(options);
        }

        //[Test]
        //public void TestGetAASXByPackageId()
        //{
        //    var restRquest = new RestRequest("/packages/{packageId}")
        //            .AddUrlSegment("packageId", "MA");

        //    var response = _client?.GetAsync(restRquest).Result;

        //    var filename = @"C:\Development\Test\Test.aasx";
        //    var bytes = response?.Content;
        //    var content = Encoding.UTF8.GetBytes(bytes);
        //    File.WriteAllBytes(filename, content);
        //}

        [Test]
        public void TestPutAASXPackageById()
        {
            try
            {
                var filePath = @"C:\Development\AASX\Example_AAS_ServoDCMotor_21.aasx";
                byte[] data = File.ReadAllBytes(filePath);

                var restRequest = new RestRequest("/packages/{packageId}", Method.Put)
                    .AddUrlSegment("packageId", "MA")
                    .AddParameter("fileName", "Example_AAS_ServoDCMotor_21.aasx")
                    .AddParameter("aasIds", "testId")
                    .AddFile("file", data, "no_file_name_provided");


                var response = _client?.PutAsync(restRequest);

                Console.WriteLine(response?.Result.StatusCode);


                Assert.IsNotNull(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void PostAASXPackage()
        {
            try
            {
                var filePath = @"C:\Development\TestJui_AAS.aasx";
                byte[] data = File.ReadAllBytes(filePath);

                var restRequest = new RestRequest("/packages", Method.Post)
                    .AddParameter("fileName", "TestJui_AAS.aasx")
                    .AddParameter("aasIds", "testId")
                    .AddFile("file", data, "no_file_name_provided");


                var response = _client?.PostAsync(restRequest);

                Console.WriteLine(response?.Result.StatusCode);


                Assert.IsNotNull(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
