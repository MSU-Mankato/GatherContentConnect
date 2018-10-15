using System;
using System.Collections.Specialized;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatherContentConnect.Http;
using System.Collections.Generic;
using System.Configuration;
using GatherContentConnect.Tests.IntegrationTests.Utility;

namespace GatherContentConnect.Tests.IntegrationTests
{
    [TestClass]
    public class GcHttpClientTests
    {
        private GcHttpClient _restClient;
        private GcTestConfigData _configData;

        [TestInitialize]
        public void InitializeTests()
        {
            _configData = new GcTestConfigData();
            _restClient = new GcHttpClient(_configData.ApiKey, _configData.Email);
        }

        [TestMethod]
        public void GetDataTest()
        {
            var jsonString = _restClient.GetData($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(jsonString);
            Assert.IsTrue(jsonString.StartsWith("{\"data"));
        }

        [TestMethod]
        public void GetData_InvalidUrl()
        {
            var result = _restClient.GetData("projects/1234");
            Assert.AreEqual(result, HttpStatusCode.NotFound.ToString());
        }

        [TestMethod]
        public void GetData_InvalidCredential()
        {
            var credClient = new GcHttpClient("123", "abc");
            var jsonString = credClient.GetData($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(jsonString);
            Assert.IsFalse(jsonString.StartsWith("{\"data"));
        }

        [TestMethod]
        public async Task GetDataAsync_InvalidCredential()
        {
            var credClient = new GcHttpClient("123", "abc");
            var response = await credClient.GetDataAsync($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccessStatusCode);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public async Task GetDataAsyncTest()
        {
            var response = await _restClient.GetDataAsync($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);       
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(jsonString.Contains(_configData.ProjectId.ToString()));
        }

        [TestMethod]
        public async Task GetDataAsync_InvalidUrl()
        {
            var response = await _restClient.GetDataAsync("projects/1234");
            Assert.IsNotNull(response);
            var jsonString = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(jsonString.Contains("Project not found"));
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void PostDataTest()
        {
            var response = _restClient.PostData("projects", new NameValueCollection()
            {
                {"account_id", _configData.AccountId.ToString()},
                {"name", _configData.ProjectName},
                {"type", _configData.ProjectType }
            });
            Assert.IsNotNull(response);
            Assert.AreEqual(response, HttpStatusCode.Accepted.ToString());
        }
        [TestMethod]
        public async Task PostDataAsyncTest()
        {
            var dataDictionary = new Dictionary<string, string>
            {
                { "project_id", _configData.ProjectId.ToString()},
                { "name", _configData.ItemName}
            };
            var response = await _restClient.PostDataAsync("items", dataDictionary);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Accepted);   
        }

        [TestMethod]
        public async Task PostDataAsync_InvalidData()
        {
            var dataDictionary = new Dictionary<string, string>
            {
                { "project_id", "1111"},
                { "name", _configData.ItemName}
            };
            var response = await _restClient.PostDataAsync("items", dataDictionary);
            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccessStatusCode);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }
        [TestMethod]
        public async Task PostDataAsync_InvalidParam()
        {
            var dataDictionary = new Dictionary<string, string>
            {
                { "id", "1111"},
                { "item_name", _configData.ItemName }
            };
            var response = await _restClient.PostDataAsync("items", dataDictionary);
            Assert.IsNotNull(response);
            Assert.IsFalse(response.IsSuccessStatusCode);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}