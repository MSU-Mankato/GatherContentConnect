using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GatherContentConnect.Objects;
using GatherContentConnect.Data;
using Newtonsoft.Json;
using System.Text;

namespace GatherContentConnect
{
    public class GcConnectClient
    {
        private readonly GcDataRepository<GcMe> _meClient;
        private readonly GcDataRepository<GcAccount> _accountClient;
        private readonly GcDataRepository<GcProject> _projectClient;
        private readonly GcDataRepository<GcStatus> _statusClient;
        private readonly GcDataRepository<GcItem> _itemClient;
        private readonly GcDataRepository<GcTemplate> _templateClient;
        private readonly GcDataRepository<GcFile> _fileClient;
        private readonly GcDataRepository<string> _postClient;

        private readonly string _apiKey, _userEmail;

        public GcConnectClient(string apiKey, string userEmail)
        {
            _meClient = new GcDataRepository<GcMe>(apiKey, userEmail);
            _accountClient = new GcDataRepository<GcAccount>(apiKey, userEmail);
            _projectClient = new GcDataRepository<GcProject>(apiKey, userEmail);
            _statusClient = new GcDataRepository<GcStatus>(apiKey, userEmail);
            _itemClient = new GcDataRepository<GcItem>(apiKey, userEmail);
            _templateClient = new GcDataRepository<GcTemplate>(apiKey, userEmail);
            _fileClient = new GcDataRepository<GcFile>(apiKey, userEmail);
            _postClient = new GcDataRepository<string>(apiKey, userEmail);

            _apiKey = apiKey;
            _userEmail = userEmail;
        }

        /* Get method for Me starts. */
        public GcMe GetMe()
        {
            return _meClient.GetSingle("me").Data;
        }

        public async Task<GcMe> GetMeAsync()
        {
            return await GetSingleAsync<GcMe>("me");
        }

        /* Get method for Me ends. */

        /* Get methods  for Accounts start. */

        public GcAccount GetAccountById(int accountId)
        {
            var urlPath = $"accounts/{accountId}";
            return _accountClient.GetSingle(urlPath).Data;
        }
        public async Task<GcAccount> GetAccountbyIdAsync(int accountId)
        {
            var urlPath = $"accounts/{accountId}";
            return await GetSingleAsync<GcAccount>(urlPath);
        }

        public ICollection<GcAccount> GetAccounts()
        {
            return _accountClient.GetAll("accounts").Data;
        }

        public async Task<ICollection<GcAccount>> GetAccountsAsync()
        {
            return await GetCollectionAsync<GcAccount>("accounts");
        }

        public ICollection<GcDataObject<GcAccount>> GetAccountsByIds(IEnumerable<int> accountIds)
        {
            return _accountClient.GetObjectCollection("accounts/", accountIds.ToList());
        }

        /* Get methods for Accounts end. */

        /* Get methods for Projects start. */

        public GcProject GetProjectById(int projectId)
        {
            var urlPath = $"projects/{projectId}";
            return _projectClient.GetSingle(urlPath).Data;
        }

        public async Task<GcProject> GetProjectByIdAsync(int projectId)
        {
            var urlPath = $"projects/{projectId}";
            return await GetSingleAsync<GcProject>(urlPath);
        }

        public ICollection<GcProject> GetProjectsByAccountId(int accountId)
        {
            var urlPath = $"projects?account_id={accountId}";
            return _projectClient.GetAll(urlPath).Data;
        }

        public async Task<ICollection<GcProject>> GetProjectsByAccountIdAsync(int accountId)
        {
            var urlPath = $"projects?account_id={accountId}";
            return await GetCollectionAsync<GcProject>(urlPath);
        }

        public ICollection<GcDataObject<GcProject>> GetProjectsByIds(List<int> projectIds)
        {
            return _projectClient.GetObjectCollection("projects/", projectIds);
        }

        /* Get methods for Projects end. */

        /* Get methods for Statuses of Projects start. */

        public GcStatus GetStatusById(int projectId, int statusId)
        {
            var urlPath = $"projects/{projectId}/statuses/{statusId}";
            return _statusClient.GetSingle(urlPath).Data;
        }

        public async Task<GcStatus> GetStatusByIdAsync(int projectId, int statusId)
        {
            var urlPath = $"projects/{projectId}/statuses/{statusId}";
            return await GetSingleAsync<GcStatus>(urlPath);
        }

        public ICollection<GcStatus> GetStatusesByProjectId(int projectId)
        {
            var urlPath = $"projects/{projectId}/statuses";
            return _statusClient.GetAll(urlPath).Data;
        }

        public async Task<ICollection<GcStatus>> GetStatusesByProjectIdAsync(int projectId)
        {
            var urlPath = $"projects/{projectId}/statuses";
            return await GetCollectionAsync<GcStatus>(urlPath);
        }

        public ICollection<GcDataObject<GcStatus>> GetStatusesByIds(int projectId, IEnumerable<int> statusIds)
        {
            var urlPath = $"projects/{projectId}/statuses/";
            return _statusClient.GetObjectCollection(urlPath, statusIds.ToList());
        }

        /* Get methods for Statuses of Projects end. */

        /* Get methods for Items start. */

        public GcItem GetItemById(string itemId)
        {
            var urlPath = $"items/{itemId}";
            return _itemClient.GetSingle(urlPath).Data;
        }

        public async Task<GcItem> GetItemByIdAsync(string itemId)
        {
            var urlPath = $"items/{itemId}";
            return await GetSingleAsync<GcItem>(urlPath);
        }

        public ICollection<GcItem> GetItemsByProjectId(int projectId)
        {
            var urlPath = $"items?project_id={projectId}";
            return _itemClient.GetAll(urlPath).Data;
        }

        public async Task<ICollection<GcItem>> GetItemsByProjectIdAsync(int projectId)
        {
            var urlPath = $"items?project_id={projectId}";
            return await GetCollectionAsync<GcItem>(urlPath);
        }

        public ICollection<GcDataObject<GcItem>> GetItemsByIds(List<int> itemIds)
        {
            return _itemClient.GetObjectCollection("items/", itemIds);
        }

        public async Task<ICollection<GcDataObject<GcItem>>> GetItemsByIdsAsync(List<int> itemIds)
        {
            return await GetObjectCollectionAsync<GcItem>("items/", itemIds);
        }

        public ICollection<GcItem> GetItemsByTemplateId(int templateId, int projectId)
        {
            ICollection<GcItem> returnItems = new List<GcItem>();
            try
            {
                var tempItems = GetItemsByProjectId(projectId);
                if (tempItems != null)
                {
                    returnItems = tempItems.Where(i => i.TemplateId == templateId).ToList();
                }
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne);
            }
            return returnItems;
        }
        
        public async Task<ICollection<GcItem>> GetItemsbyTemplateIdAsync(int templateId, int projectId)
        {
            ICollection<GcItem> returnItems = new List<GcItem>();
            try
            {
                var tempItems = await GetItemsByProjectIdAsync(projectId);
                if (tempItems != null)
                {
                    returnItems = tempItems.Where(i => i.TemplateId == templateId).ToList();
                }
            }
            catch (NullReferenceException ne)
            {
                Console.WriteLine(ne);
            }
            return returnItems;
        }

        /* Get methods for Items end. */

        /* Get method for Files of Items starts. */

        public ICollection<GcFile> GetFilesByItemId(int itemId)
        {
            var urlPath = $"items/{itemId}/files/";
            return _fileClient.GetAll(urlPath).Data;
        }

        public async Task<ICollection<GcFile>> GetfilesByItemIdAsync(int itemId)
        {
            var urlPath = $"items/{itemId}/files/";
            return await GetCollectionAsync<GcFile>(urlPath);
        }

        /* Get method for Files of Items ends. */

        /* Get methods for Templates start. */

        public GcTemplate GetTemplateById(int templateId)
        {
            var urlPath = $"templates/{templateId}";
            return _templateClient.GetSingle(urlPath).Data;
        }

        public async Task<GcTemplate> GetTemplateByIdAsync(int templateId)
        {
            var urlPath = $"templates/{templateId}";
            return await GetSingleAsync<GcTemplate>(urlPath);
        }


        public ICollection<GcTemplate> GetTemplatesByProjectId(string projectId)
        {
            var urlPath = $"templates?project_id={projectId}";
            return _templateClient.GetAll(urlPath).Data;
        }

        public async Task<ICollection<GcTemplate>> GetTemplatesByProjectIdAsync(string projectId)
        {
            var urlPath = $"templates?project_id={projectId}";
            return await GetCollectionAsync<GcTemplate>(urlPath);
        }


        public ICollection<GcDataObject<GcTemplate>> GetTemplatesByIds(List<int> templateIds)
        {
            return _templateClient.GetObjectCollection("templates/", templateIds);
        }

        public async Task<ICollection<GcDataObject<GcTemplate>>> GetTemplatesByIdsAsync(List<int> templateIds)
        {
            return await GetObjectCollectionAsync<GcTemplate>("templates/", templateIds);            
        }

        /* Get methods for Templates end. */

        /* Post methods for Projects start. */

        public string PostProject(int accountId, string name, string type)
        {
            return _postClient.PostObject("projects", new NameValueCollection
                {
                    {"account_id", accountId.ToString()},
                    {"name", name},
                    {"type", type}
                }
            );
        }

        public async Task<HttpResponseMessage> PostProjectAsync(int accountId, string name, string type)
        {
            return await _postClient.PostObjectAsync("projects", new Dictionary<string, string>
                {
                    {"account_id", accountId.ToString()},
                    {"name", name},
                    {"type", type}
                }
            );
        }

        /* Post methods for Projects end. */

        /* Post methods for Items start. */

        public string PostItem(int projectId, string name, [Optional] int? parentId, [Optional] int? templateId,
            [Optional] ICollection<GcConfig> configs)
        {
            var nameValueCollection = new NameValueCollection
            {
                { "project_id", projectId.ToString() },
                { "name", name }
            };
            if (parentId != null) nameValueCollection.Add("parent_id", parentId.ToString());
            if (templateId != null) nameValueCollection.Add("template_id", templateId.ToString());
            if (configs != null && configs.Count > 0) nameValueCollection.Add("config", Convert.ToBase64String(Encoding.UTF8.GetBytes
                (JsonConvert.SerializeObject(configs))));
            return _postClient.PostObject("items", nameValueCollection);
        }

        public async Task<HttpResponseMessage> PostItemAsync(int projectId, string name, [Optional] int? parentId, [Optional] int? templateId,
            [Optional] ICollection<GcConfig> configs)
        {
            var dataDictionary = new Dictionary<string, string>
            {
                { "project_id", projectId.ToString() },
                { "name", name }
            };
            if (parentId != null) dataDictionary.Add("parent_id", parentId.ToString());
            if (templateId != null) dataDictionary.Add("template_id", templateId.ToString());
            if (configs != null && configs.Count > 0) dataDictionary.Add("config", Convert.ToBase64String(Encoding.UTF8.GetBytes
                (JsonConvert.SerializeObject(configs))));
            return await _postClient.PostObjectAsync("items", dataDictionary);
        }

        public string SaveItem(int itemId, ICollection<GcConfig> configs)
        {
            var newUrlPath = $"items/{itemId}/save";
            return _postClient.PostObject(newUrlPath, new NameValueCollection
            {
                {
                    "config", Convert.ToBase64String(Encoding.UTF8.GetBytes
                        (JsonConvert.SerializeObject(configs)))
                }
            });
        }

        public async Task<HttpResponseMessage> SaveItemAsync(int itemId, ICollection<GcConfig> configs)
        {
            var newUrlPath = $"items/{itemId}/save";
            return await _postClient.PostObjectAsync(newUrlPath, new Dictionary<string, string>
            {
                {
                    "config", Convert.ToBase64String(Encoding.UTF8.GetBytes
                        (JsonConvert.SerializeObject(configs)))
                }
            });
        }

        public string ApplyTemplate(int itemId, int templateId)
        {
            var newUrlPath = $"items/{itemId}/apply_template";
            return _postClient.PostObject(newUrlPath, new NameValueCollection
            {
                {"template_id", templateId.ToString()}
            });
        }

        public async Task<HttpResponseMessage> ApplyTemplateAsync(int itemId, int templateId)
        {
            var newUrlPath = $"items/{itemId}/apply_template";
            return await _postClient.PostObjectAsync(newUrlPath, new Dictionary<string, string>
            {
                {"template_id", templateId.ToString()}
            });
        }

        public string ChooseStatus(int itemId, int statusId)
        {
            var newUrlPath = $"items/{itemId}/choose_status";
            return _postClient.PostObject(newUrlPath, new NameValueCollection
            {
                {"status_id", statusId.ToString()}
            });
        }

        public async Task<HttpResponseMessage> ChooseStatusAsync(int itemId, int statusId)
        {
            var newUrlPath = $"items/{itemId}/choose_status";
            return await _postClient.PostObjectAsync(newUrlPath, new Dictionary<string, string>
            {
                {"status_id", statusId.ToString()}
            });
        }
        /* Post methods for Items end. */
        private async Task<T1> GetSingleAsync<T1>(string urlPath)
        {
            using (var repo = new GcDataRepository<T1>(_apiKey, _userEmail))
            {
                var result = await repo.GetSingleAsync(urlPath);
                return result.Data;
            }
        }

        private async Task<ICollection<T1>> GetCollectionAsync<T1>(string urlPath)
        {
            using (var repo = new GcDataRepository<T1>(_apiKey, _userEmail))
            {
                var result = await repo.GetAllAsync(urlPath);
                return result.Data;
            }
        }

        private async Task<ICollection<GcDataObject<T1>>> GetObjectCollectionAsync<T1>(string urlPath, List<int> ids)
        {
            using (var repo = new GcDataRepository<T1>(_apiKey, _userEmail))
            {
                return await repo.GetObjectCollectionAsync(urlPath, ids);
            }
        }
    }
}