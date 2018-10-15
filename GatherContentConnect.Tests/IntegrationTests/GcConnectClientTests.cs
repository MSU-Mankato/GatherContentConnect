using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatherContentConnect.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System;
using System.Configuration;
using GatherContentConnect.Tests.IntegrationTests.Utility;

namespace GatherContentConnect.Tests.IntegrationTests
{
    [TestClass]
    public class GcConnectClientTests
    {
        private GcConnectClient _clientObject;
        private GcTestConfigData _configData;

        [TestInitialize]
        public void InitializeTests()
        {
            _configData = new GcTestConfigData();
            _clientObject = new GcConnectClient(_configData.ApiKey, _configData.Email);
        }
        /* Tests for Getting the components start. */
        [TestMethod]
        public void GetMeTest()
        {
            var meObject = _clientObject.GetMe();
            Assert.IsNotNull(meObject);
            Assert.AreEqual(meObject.FirstName, _configData.FirstName);
            Assert.AreEqual(meObject.LastName, _configData.LastName);
        }

        [TestMethod ]
        public async Task GetMeAsync()
        {
            var meObject = await _clientObject.GetMeAsync();
            Assert.IsNotNull(meObject);
            Assert.AreEqual(meObject.FirstName, _configData.FirstName);
            Assert.AreEqual(meObject.LastName, _configData.LastName);
        }

        [TestMethod]
        public void GetAccountByIdTest()
        {
            var accountObject = _clientObject.GetAccountById(_configData.AccountId);
            Assert.IsNotNull(accountObject);
            Assert.AreEqual(accountObject.Id, _configData.AccountId.ToString());
        }

        [TestMethod]
        public async Task GetAccountbyIdAsyncTest()
        {
            var expectedAccountObject = await _clientObject.GetAccountbyIdAsync(_configData.AccountId);
            Assert.IsNotNull(expectedAccountObject);
            Assert.AreEqual(expectedAccountObject.Id, _configData.AccountId.ToString());
        }

        [TestMethod]
        public void GetAccountsTest()
        {
            var accountObject = _clientObject.GetAccounts();
            Assert.IsNotNull(accountObject);
            CollectionAssert.AllItemsAreUnique(accountObject.ToList());
            CollectionAssert.AllItemsAreNotNull(accountObject.ToList());
        }

        [TestMethod]
        public async Task GetAccountsAsyncTest()
        {
            var expectedAccountObject = await _clientObject.GetAccountsAsync();
            Assert.IsNotNull(expectedAccountObject);
            CollectionAssert.AllItemsAreUnique(expectedAccountObject.ToList());
            CollectionAssert.AllItemsAreNotNull(expectedAccountObject.ToList());
        }

        [TestMethod]
        public void GetAccountsByIdsTest()
        {
            var idList = new List<int>{_configData.AccountId };
            var accountObject = _clientObject.GetAccountsByIds(idList);
            Assert.IsNotNull(accountObject);
            Assert.AreEqual(accountObject.ToList()[0].Data.Id, _configData.AccountId.ToString());
            Assert.AreEqual(accountObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetProjectByIdTest()
        {
            var projectObject = _clientObject.GetProjectById(_configData.ProjectId);
            Assert.IsNotNull(projectObject);
            Assert.AreEqual(projectObject.Id, _configData.ProjectId);
        }

        [TestMethod]
        public void GetProjectsByAccountIdTest()
        {
            var projectObject = _clientObject.GetProjectsByAccountId(_configData.AccountId);
            Assert.IsNotNull(projectObject);
            CollectionAssert.AllItemsAreUnique(projectObject.ToList());
            CollectionAssert.AllItemsAreNotNull(projectObject.ToList());
        }

        [TestMethod]
        public async Task GetProjectsByAccountIdAsyncTest()
        {
            var expectedProjectObject = await _clientObject.GetProjectsByAccountIdAsync(_configData.AccountId);
            Assert.IsNotNull(expectedProjectObject);
            CollectionAssert.AllItemsAreUnique(expectedProjectObject.ToList());
            CollectionAssert.AllItemsAreNotNull(expectedProjectObject.ToList());
        }

        [TestMethod]
        public void GetProjectsByIdsTest()
        {
            var idList = new List<int> { _configData.ProjectId };
            var projectObject = _clientObject.GetProjectsByIds(idList);
            Assert.IsNotNull(projectObject);
            Assert.AreEqual(projectObject.ToList()[0].Data.Id, _configData.ProjectId);
            Assert.AreEqual(projectObject.ToList().Count, 1);
        }

        [TestMethod]
        public async Task GetProjectByIdAsyncTest()
        {
            var expectedProjectObject = await _clientObject.GetProjectByIdAsync(_configData.ProjectId);
            Assert.IsNotNull(expectedProjectObject);
        }

        [TestMethod]
        public void GetStatusByIdTest()
        {
            var statusObject = _clientObject.GetStatusById( _configData.ProjectId, _configData.StatusId);
            Assert.IsNotNull(statusObject);
            Assert.AreEqual(statusObject.Id, _configData.StatusId.ToString());
        }

        [TestMethod]
        public async Task GetStatusByIdAsyncTest()
        {
            var statusObject =await _clientObject.GetStatusByIdAsync(_configData.ProjectId, _configData.StatusId);
            Assert.IsNotNull(statusObject);
            Assert.AreEqual(statusObject.Id, _configData.StatusId.ToString());
        }

        [TestMethod]
        public void GetStatusesByProjectIdTest()
        {
            var statusObject = _clientObject.GetStatusesByProjectId(_configData.ProjectId);
            Assert.IsNotNull(statusObject);
            CollectionAssert.AllItemsAreNotNull(statusObject.ToList());
            CollectionAssert.AllItemsAreUnique(statusObject.ToList());
        }

        [TestMethod]
        public async Task GetStatusesByProjectIdAsyncTest()
        {
            var expectedStatusObject =await _clientObject.GetStatusesByProjectIdAsync(_configData.ProjectId);
            Assert.IsNotNull(expectedStatusObject);
            CollectionAssert.AllItemsAreNotNull(expectedStatusObject.ToList());
            CollectionAssert.AllItemsAreUnique(expectedStatusObject.ToList());
        }

        [TestMethod]
        public void GetStatusesByIdsTest()
        {
            var idList = new List<int> {_configData.StatusId};
            var statusObject = _clientObject.GetStatusesByIds(_configData.ProjectId, idList);
            Assert.AreEqual(statusObject.ToList()[0].Data.Id, _configData.StatusId.ToString());
            Assert.AreEqual(statusObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetItemByIdTest()
        {
            var itemObject = _clientObject.GetItemById(_configData.ItemId.ToString());
            Assert.IsNotNull(itemObject);
            Assert.AreEqual(itemObject.Id, _configData.ItemId);
        }

        [TestMethod]
        public async Task GetItemByIdAsyncTest()
        {
            var expectedItemObject = await _clientObject.GetItemByIdAsync(_configData.ItemId.ToString());
            Assert.IsNotNull(expectedItemObject);
        }

        [TestMethod]
        public void GetItemsByProjectIdTest()
        {
            var itemObject = _clientObject.GetItemsByProjectId(_configData.ProjectId);
            Assert.IsNotNull(itemObject);
            CollectionAssert.AllItemsAreUnique(itemObject.ToList());
            CollectionAssert.AllItemsAreNotNull(itemObject.ToList());
        }

        [TestMethod]
        public async Task GetItemsByProjectIdAsyncTest()
        {
            var expectedItemObject = await _clientObject.GetItemsByProjectIdAsync(_configData.ProjectId);
            Assert.IsNotNull(expectedItemObject);
            CollectionAssert.AllItemsAreNotNull(expectedItemObject.ToList());
            CollectionAssert.AllItemsAreUnique(expectedItemObject.ToList());
        }

        [TestMethod]
        public void GetItemsByIdsTest()
        {
            var itemIds = new List<int> { _configData.ItemId };
            var itemObject = _clientObject.GetItemsByIds(itemIds);
            Assert.IsNotNull(itemObject);
            Assert.AreEqual(itemObject.ToList()[0].Data.Id, _configData.ItemId);
            Assert.AreEqual(itemObject.ToList().Count, 1);
        }

        [TestMethod]
        public async Task GetItemsByIdsAsyncTest()
        {
            var itemIds = new List<int> { _configData.ItemId };
            var itemObject = await  _clientObject.GetItemsByIdsAsync(itemIds);
            Assert.IsNotNull(itemObject);
            Assert.AreEqual(itemObject.ToList()[0].Data.Id, _configData.ItemId);
            Assert.AreEqual(itemObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetItemsByTemplateIdTest()
        {
            var itemObject = _clientObject.GetItemsByTemplateId(_configData.TemplateId, _configData.ProjectId);
            Assert.IsNotNull(itemObject);
            CollectionAssert.AllItemsAreUnique(itemObject.ToList());
            CollectionAssert.AllItemsAreNotNull(itemObject.ToList());
        }

        [TestMethod]
        public async Task GetItemsbyTemplateIdAsync()
        {
            var expectedItemObject = await _clientObject.GetItemsbyTemplateIdAsync(_configData.TemplateId, _configData.ProjectId);
            Assert.IsNotNull(expectedItemObject);
            CollectionAssert.AllItemsAreNotNull(expectedItemObject.ToList());
            CollectionAssert.AllItemsAreUnique(expectedItemObject.ToList());
        }

        [TestMethod]
        public void GetFilesByItemIdTest()
        {
            var fileObject = _clientObject.GetFilesByItemId(_configData.ItemId);
            Assert.IsNotNull(fileObject);
            CollectionAssert.AllItemsAreUnique(fileObject.ToList());
            CollectionAssert.AllItemsAreNotNull(fileObject.ToList());
        }

        [TestMethod]
        public async Task GetfilesByItemIdAsyncTest()
        {
            var expectedFileObject =await _clientObject.GetfilesByItemIdAsync(_configData.ItemId);
            Assert.IsNotNull(expectedFileObject);
            CollectionAssert.AllItemsAreUnique(expectedFileObject.ToList());
            CollectionAssert.AllItemsAreNotNull(expectedFileObject.ToList());
        }

        [TestMethod]
        public void GetTemplateByIdTest()
        {
            var templateObject = _clientObject.GetTemplateById(_configData.TemplateId);
            Assert.IsNotNull(templateObject);
            Assert.AreEqual(templateObject.Id, _configData.TemplateId);
        }

        [TestMethod]
        public async Task GetTemplateByIdAsync()
        {
            var expectedTemplateObject =await _clientObject.GetTemplateByIdAsync(_configData.TemplateId);
            Assert.IsNotNull(expectedTemplateObject);
            Assert.AreEqual(expectedTemplateObject.Id, _configData.TemplateId);
        }

        [TestMethod]
        public void GetTemplateByProjectIdTest()
        {
            var templateObject = _clientObject.GetTemplatesByProjectId(_configData.ProjectId.ToString());
            Assert.IsNotNull(templateObject);
            CollectionAssert.AllItemsAreUnique(templateObject.ToList());
            CollectionAssert.AllItemsAreNotNull(templateObject.ToList());
        }

        [TestMethod]
        public async Task GetTemplatesByProjectIdAsyncTest()
        {
            var expectedTemplateObject = await _clientObject.GetTemplatesByProjectIdAsync(_configData.ProjectId.ToString());
            Assert.IsNotNull(expectedTemplateObject);
            CollectionAssert.AllItemsAreUnique(expectedTemplateObject.ToList());
            CollectionAssert.AllItemsAreNotNull(expectedTemplateObject.ToList());
        }


        [TestMethod]
        public void GetTemplatesByIdsTest()
        {
            var templateIds = new List<int> { _configData.TemplateId };
            var templateObject = _clientObject.GetTemplatesByIds(templateIds);
            Assert.IsNotNull(templateObject);
            Assert.AreEqual(templateObject.ToList()[0].Data.Id, _configData.TemplateId);
            Assert.AreEqual(templateObject.ToList().Count, 1);
        }

        [TestMethod]
        public async Task GetTemplatesByIdsAsyncTest()
        {
            var expectedTemplateIds = new List<int> { _configData.TemplateId };
            var expectedTemplateObject = await _clientObject.GetTemplatesByIdsAsync(expectedTemplateIds);
            Assert.IsNotNull(expectedTemplateObject);
            Assert.AreEqual(expectedTemplateObject.ToList()[0].Data.Id, _configData.TemplateId);
            Assert.AreEqual(expectedTemplateObject.ToList().Count, 1);
        }

        /* Tests for Getting the components end. */

        /* Tests for Invalid Credentials sent to the components start. */

        [TestMethod]
        public void GetMe_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "matt.p@gathercontent.com");
            var meObject = invalidCredential.GetMe();
            Assert.IsNull(meObject);
        }

        [TestMethod]
        public void GetAccountById_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var accountObject = invalidCredential.GetAccountById(_configData.AccountId);
            Assert.IsNull(accountObject);
        }

        [TestMethod]
        public void GetAccounts_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var accountObject = invalidCredential.GetAccounts();
            Assert.IsNull(accountObject);
        }

        [TestMethod]
        public void GetAccountsByIds_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "a.b@gathercontent.com");
            var idList = new List<int>() {_configData.AccountId};
            var accountObject = invalidCredential.GetAccountsByIds(idList);
            Assert.IsNotNull(accountObject);
            Assert.AreEqual(accountObject.ToList()[0].Data, null);
            Assert.AreEqual(accountObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetProjectById_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "a.b@gathercontent.com");
            var projectObject = invalidCredential.GetProjectById(103613);
            Assert.IsNull(projectObject);
        }

        [TestMethod]
        public void GetProjectsByAccountId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "a.b@gathercontent.com");
            var projectObject = invalidCredential.GetProjectsByAccountId(30982);
            Assert.IsNull(projectObject);
        }

        [TestMethod]
        public void GetProjectsByIds_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "abcd.efg@gathercontent.com");
            var idList = new List<int>() { 100013, 003614 };
            var projectObject = invalidCredential.GetProjectsByIds(idList);
            Assert.IsNotNull(projectObject);
            Assert.AreEqual(projectObject.ToList()[0].Data, null);
            Assert.AreEqual(projectObject.ToList()[1].Data, null);
            Assert.AreEqual(projectObject.ToList().Count, 2);
        }

        [TestMethod]
        public void GetStatusById_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "abc.def@gathercontent.com");
            var statusObject = invalidCredential.GetStatusById(103613, 558644);
            Assert.IsNull(statusObject);
        }

        [TestMethod]
        public void GetStatusesByProjectId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                "s122@gathercontent.com");
            var statusObject = invalidCredential.GetStatusesByProjectId(1231);
            Assert.IsNull(statusObject);
        }

        [TestMethod]
        public void GetStatusesByIds_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var idList = new List<int>() { 558644, 558649 };
            var statusObject = invalidCredential.GetStatusesByIds(103613, idList);
            Assert.AreEqual(statusObject.ToList()[0].Data, null);
            Assert.AreEqual(statusObject.ToList()[1].Data, null);
            Assert.AreEqual(statusObject.ToList().Count, 2);
        }

        [TestMethod]
        public void GetItemById_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var itemObject = invalidCredential.GetItemById("3891577");
            Assert.IsNull(itemObject);
        }

        [TestMethod]
        public void GetItemsByProjectId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var itemObject = invalidCredential.GetItemsByProjectId(103614);
            Assert.IsNull(itemObject);
        }

        [TestMethod]
        public void GetItemsByIds_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var itemIds = new List<int> { 1577, 333333};
            var itemObject = invalidCredential.GetItemsByIds(itemIds);
            Assert.IsNotNull(itemObject);
            Assert.AreEqual(itemObject.ToList()[0].Data, null);
            Assert.AreEqual(itemObject.ToList()[1].Data, null);
            Assert.AreEqual(itemObject.ToList().Count, 2);
        }

        [TestMethod]
        public void GetItemsByTemplateId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var itemObject = invalidCredential.GetItemsByTemplateId(0000, 14041);
            Assert.IsNotNull(itemObject);
            Assert.AreEqual(itemObject.Count,0);
        }

        [TestMethod]
        public void GetFilesByItemId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var fileObject = invalidCredential.GetFilesByItemId(_configData.ItemId);
            Assert.IsNull(fileObject);
        }

        [TestMethod]
        public void GetTemplateById_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var templateObject = invalidCredential.GetTemplateById(_configData.TemplateId);
            Assert.IsNull(templateObject);
        }

        [TestMethod]
        public void GetTemplateByProjectId_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var templateObject = invalidCredential.GetTemplatesByProjectId(_configData.TemplateId.ToString());
            Assert.IsNull(templateObject);
        }

        [TestMethod]
        public void GetTemplatesByIds_InvalidCredential()
        {
            var invalidCredential = new GcConnectClient("abc",
                _configData.Email);
            var templateIds = new List<int> { _configData.TemplateId};
            var templateObject = invalidCredential.GetTemplatesByIds(templateIds);
            Assert.IsNotNull(templateObject);
            Assert.AreEqual(templateObject.ToList()[0].Data,null);
            Assert.AreEqual(templateObject.ToList().Count, 1);
        }
        /* Tests for Invalid Credentials sent to the components end. */

        /* Tests for Posting the components start.*/

        [TestMethod]
        public void PostProjectTest()
        {
            var projectObject = _clientObject.PostProject(_configData.AccountId, _configData.ProjectName,
                _configData.ProjectType);
            Assert.IsNotNull(projectObject);
            Assert.AreEqual(projectObject, HttpStatusCode.Accepted.ToString());
        }


        /*Test method for posting project by passing invalid account Id*/
        [TestMethod]
        public void PostProjectByInvalidAccountIdTest()
        {
            var projectObject = _clientObject.PostProject(12345, _configData.ProjectName,
                _configData.ProjectType);
            Assert.AreEqual(projectObject, HttpStatusCode.NotFound.ToString());
        }

        /*Test method for posting project by passing null for name and type */
        [TestMethod]
        public void PostProjectByInvalidProjectValueTest()
        {
            var projectObject = _clientObject.PostProject(_configData.AccountId, null, null);
            Assert.AreEqual(projectObject, HttpStatusCode.BadRequest.ToString());
        }
        /*Test method for posting new items by project_id and item_name*/
        [TestMethod]
        public void PostItemTest()
        {
            var itemObject = _clientObject.PostItem(_configData.ProjectId, _configData.ItemName);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method for posting new items by project_id and item_name with async*/
        [TestMethod]
        public async Task PostItemAsyncTest()
        {
            var itemObject = await  _clientObject.PostItemAsync(_configData.ProjectId, _configData.ItemName);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method for posting new items by project_id and template_id*/
        [TestMethod]
        public void PostItemTestWithTemplateId()
        {
            var itemObject = _clientObject.PostItem(_configData.ProjectId, _configData.ItemName, templateId:_configData.TemplateId);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method for posting new items by project_id and template_id with async method*/
        [TestMethod]
        public async Task PostItemTestAsyncWithTemplateId()
        {
            var itemObject =await _clientObject.PostItemAsync(_configData.ProjectId, _configData.ItemName, templateId: _configData.TemplateId);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Accepted);
        }

        /*Test method for posting new items by project_id and config*/
        [TestMethod]
        public void PostItemTestWithConfig()
        {
            var configs = _clientObject.GetTemplateById(_configData.TemplateId).Config;
            var itemObject = _clientObject.PostItem(_configData.ProjectId, _configData.ItemName, configs: configs);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method for posting new items by project_id and config with async method*/
        [TestMethod]
        public async Task PostItemTestAsyncWithConfig()
        {
            var configs = _clientObject.GetTemplateById(_configData.TemplateId).Config;
            var itemObject = await  _clientObject.PostItemAsync(_configData.ProjectId, _configData.ItemName, configs: configs);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method for posting new items by all parameters*/
        [TestMethod]
        public void PostItemTestWithAllParams()
        {
            var configs = _clientObject.GetTemplateById(_configData.TemplateId).Config;
            var itemObject = _clientObject.PostItem(_configData.ProjectId, _configData.ItemName, _configData.TemplateId, configs: configs);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method for posting new items by all parameters with async method*/
        [TestMethod]
        public async Task PostItemAsyncTestWithAllParams()
        {
            var configs = _clientObject.GetTemplateById(632806).Config;
            var itemObject = await _clientObject.PostItemAsync(_configData.ProjectId, _configData.ItemName, _configData.TemplateId, configs: configs);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method for posting new items by invalid config*/
        [TestMethod]
        public void PostItemTestWithInvalidConfig()
        {
            var gc = new GcConfig
            {
                Label = "Update Content",
                IsHidden = false,
                Elements = new List<GcElement>()
            };
            var configs = new List<GcConfig> {gc};
            var itemObject = _clientObject.PostItem(_configData.ProjectId, _configData.ItemName, _configData.TemplateId, configs: configs);
            Assert.AreEqual(itemObject, HttpStatusCode.BadRequest.ToString());
        }
        /*Test method for posting new items by invalid config for async method*/
        [TestMethod]
        public async Task PostItemAsyncTestWithInvalidConfig()
        {
            var gc = new GcConfig
            {
                Label = "Update Content",
                IsHidden = false,
                Elements = new List<GcElement>()
            };
            var configs = new List<GcConfig> { gc };
            var itemObject = await _clientObject.PostItemAsync(_configData.ProjectId, _configData.ItemName, _configData.TemplateId, configs: configs);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.BadRequest);
        }

        /*Test method for posting items to invalid project Id*/
        [TestMethod]
        public void PostItemByInvalidProjectIdTest()
        {
            var itemObject = _clientObject.PostItem(123456, _configData.ProjectName);
            Assert.AreEqual(itemObject, HttpStatusCode.Forbidden.ToString());
        }
        /*Test method for posting items to invalid project Id for async method*/
        [TestMethod]
        public async Task PostItemAsyncByInvalidProjectIdTest()
        {
            var itemObject = await _clientObject.PostItemAsync(123456, _configData.ProjectName);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Forbidden);
        }

        /*Test method for posting null values to item*/
        [TestMethod]
       public void PostItemByInvalidValueTest()
        {
            var itemObject = _clientObject.PostItem(123456, null);
            Assert.AreEqual(itemObject, HttpStatusCode.BadRequest.ToString());
        }
        /*Test method to update items config*/
        [TestMethod]
        public void SaveItemTest()
        {
            var config = _clientObject.GetItemById(_configData.ItemId.ToString()).Config;
            var itemObject = _clientObject.SaveItem(_configData.ItemId, config);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method to update items config with async method*/
        [TestMethod]
        public async Task SaveItemAsyncTest()
        {
            var config = _clientObject.GetItemById(_configData.ItemId.ToString()).Config;
            var itemObject = await _clientObject.SaveItemAsync(_configData.ItemId, config);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.Accepted);
        }

        /*test method for saving items data by invalid Item Id*/
        [TestMethod]
        public void SaveItemByInvalidIdTest()
        {
            var config = _clientObject.GetItemById(_configData.ItemId.ToString()).Config;
            var itemObject = _clientObject.SaveItem(123456, config);
            Assert.AreEqual(itemObject, HttpStatusCode.NotFound.ToString());
        }
        /*test method for saving items data by invalid Item Id for async method*/
        [TestMethod]
        public async Task SaveItemAsyncByInvalidIdTest()
        {
            var config = _clientObject.GetItemById(_configData.ItemId.ToString()).Config;
            var itemObject = await _clientObject.SaveItemAsync(123456, config);
            Assert.AreEqual(itemObject.StatusCode, HttpStatusCode.NotFound);
        }
        /*test method for applying template to an item*/
        [TestMethod]
        public void ApplyTemplateTest()
        {
           var itemObject = _clientObject.ApplyTemplate(_configData.ItemId, _configData.TemplateId);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }

        /*Test method for applying invalid template by using the invalid item id and template_id*/
        [TestMethod]
        public void ApplyInvalidTemplateTest()
        {
            var itemObject = _clientObject.ApplyTemplate(_configData.ItemId, 123324);
            Assert.AreEqual(itemObject, HttpStatusCode.NotFound.ToString());
        }
        /*Test method for choosing status for an item*/
        [TestMethod] 
        public void ChooseStatusTest()
        {
            var itemObject = _clientObject.ChooseStatus(_configData.ItemId, _configData.StatusId);
            Assert.AreEqual(itemObject, HttpStatusCode.Accepted.ToString());
        }
        /*Test method for choosing invalid status id status to an Item*/
        [TestMethod]
        public void ChooseStatusByInvalidStatusIdTest()
        {
            var itemObject = _clientObject.ChooseStatus(_configData.ItemId, 123456);
            Assert.AreEqual(itemObject,HttpStatusCode.Forbidden.ToString());
        }
        /*Test method to post new project via async method*/
        [TestMethod]
        public async Task PostProjectAsyncTest()
        {
            var projectObject = await  _clientObject.PostProjectAsync(_configData.ProjectId, "First project from ConnectClientTests",
                "ongoing-website-content");
            Assert.AreEqual(projectObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method to choose status via async method*/
        [TestMethod]
        public async Task ChooseStatusAsync()
        {
            var statusObject = await  _clientObject.ChooseStatusAsync(_configData.ItemId, _configData.StatusId);
            Assert.AreEqual(statusObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method to choose invalid status id via async method*/
        [TestMethod]
        public async Task ChooseStatusAsyncByInvalidStatusId()
        {
            var statusObject = await _clientObject.ChooseStatusAsync(_configData.ItemId, 112323);
            Assert.AreEqual(statusObject.StatusCode, HttpStatusCode.BadRequest);
        }
        /*Test method to apply template via async method*/
        [TestMethod]
        public async Task ApplyTemplateAsyncTest()
        {
            var tempObject = await _clientObject.ApplyTemplateAsync(_configData.ItemId, _configData.TemplateId);
            Assert.AreEqual(tempObject.StatusCode, HttpStatusCode.Accepted);
        }
        /*Test method to apply template with invalid template id status via async method*/
        [TestMethod]
        public async Task ApplyTemplateAsyncTestWithInvalidTemplateId()
        {
            var tempObject = await _clientObject.ApplyTemplateAsync(_configData.ItemId, 123123);
            Assert.AreEqual(tempObject.StatusCode, HttpStatusCode.BadRequest);
        }

        /* Tests for Posting the components end.*/
    }
}