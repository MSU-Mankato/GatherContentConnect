using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GatherContentConnect.Objects;
using GatherContentConnect.Data;
using GatherContentConnect.Tests.IntegrationTests.Utility;


namespace GatherContentConnect.Tests.IntegrationTests
{
    [TestClass]
    public class GcServiceTests
    {
        private GcDataRepository<GcProject> _serviceObject;
        private GcTestConfigData _configData;

        [TestInitialize]
        public void InitializeTests()
        {
            _configData = new GcTestConfigData();
           _serviceObject = new GcDataRepository<GcProject>(_configData.ApiKey, _configData.Email);
        }

        [TestMethod]
        public void GetSingleObjectTest()
        {
            var singleDataObject = _serviceObject.GetSingle($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(singleDataObject);
            Assert.AreEqual(singleDataObject.Data.Id, _configData.ProjectId);
        }

        [TestMethod]
        public void GetAllObjectsTest()
        {
            var allDataObject = _serviceObject.GetAll($"projects?account_id={_configData.AccountId}");
            Assert.IsNotNull(allDataObject);
            CollectionAssert.AllItemsAreUnique(allDataObject.Data.ToList());
            CollectionAssert.AllItemsAreNotNull(allDataObject.Data.ToList());
        }

        [TestMethod]
        public void GetObjectCollectionTest()
        {
            var projectIds = new List<int>()
            {
                _configData.ProjectId
            };
            var someDataObject = _serviceObject.GetObjectCollection("projects/", projectIds);
            Assert.IsNotNull(someDataObject);
            Assert.AreEqual(someDataObject.ToList()[0].Data.Id, _configData.ProjectId);
            Assert.AreEqual(someDataObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetSingleObject_InvalidUrl()
        {
            var singleDataObject = _serviceObject.GetSingle($"proje/{_configData.ProjectId}");
            Assert.IsNotNull(singleDataObject);
            Assert.AreEqual(singleDataObject.Data, null);
        }

        [TestMethod]
        public void GetAllObjects_InvalidUrl()
        {
            var allDataObject = _serviceObject.GetSingle("prot");
            Assert.IsNotNull(allDataObject);
            Assert.AreEqual(allDataObject.Data, null);
        }

        [TestMethod]
        public void GetObjectCollection_InvalidUrl()
        {
            var projectIds = new List<int> { _configData.ProjectId };
            var someDataObject = _serviceObject.GetObjectCollection("prot", projectIds);
            Assert.IsNotNull(someDataObject);
            Assert.AreEqual(someDataObject.ToList()[0].Data, null);
            Assert.AreEqual(someDataObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetSingleObject_InvalidId()
        {
            var singleDataObject = _serviceObject.GetSingle("projects/1234");
            Assert.IsNotNull(singleDataObject);
            Assert.AreEqual(singleDataObject.Data, null);
        }

        [TestMethod]
        public void GetObjectCollection_InvalidId()
        {
            var projectIds = new List<int> { 1234 };
            var someDataObject = _serviceObject.GetObjectCollection("projects/", projectIds);
            Assert.IsNotNull(someDataObject);
            Assert.AreEqual(someDataObject.ToList()[0].Data, null);
            Assert.AreEqual(someDataObject.ToList().Count, 1);
        }

        [TestMethod]
        public void GetSingleObject_InvalidCredential()
        {
            _serviceObject = new GcDataRepository<GcProject>("123", "abc");
            var singleDataObject = _serviceObject.GetSingle($"projects/{_configData.ProjectId}");
            Assert.IsNotNull(singleDataObject);
            Assert.AreEqual(singleDataObject.Data, null);
        }

        [TestMethod]
        public void GetAllObjects_InvalidCredential()
        {
            _serviceObject = new GcDataRepository<GcProject>("123", _configData.Email);
            var allDataObject = _serviceObject.GetAll("projects");
            Assert.IsNotNull(allDataObject);
            Assert.AreEqual(allDataObject.Data, null);
        }

        [TestMethod]
        public void GetObjectCollection_InvalidCredential()
        {
            var projectIds = new List<int> { _configData.ProjectId };
            _serviceObject = new GcDataRepository<GcProject>("123", _configData.Email);
            var someDataObject = _serviceObject.GetObjectCollection("projects/", projectIds);
            Assert.IsNotNull(someDataObject);
            Assert.AreEqual(someDataObject.ToList()[0].Data, null);
            Assert.AreEqual(someDataObject.ToList().Count, 1);
        }
    }
}