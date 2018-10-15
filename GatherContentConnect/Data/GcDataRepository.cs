using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using GatherContentConnect.Interface;
using GatherContentConnect.Http;
using Newtonsoft.Json;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Data
{
    public class GcDataRepository<T> : IGcDataRepository<T>
    {
        //data object that can contain the http credentials.
        private readonly GcHttpClient _dataObjectClient;

        public GcDataRepository(string apiKey, string userEmail)
        {
            _dataObjectClient = new GcHttpClient(apiKey, userEmail);
        }

        //method that gets single object.
        public GcDataObject<T> GetSingle(string urlPath)
        {
            
            var returnableObject = new GcDataObject<T>();
            try
            {
                var jsonString = _dataObjectClient.GetData(urlPath);
                //deserializing the jsonString content to a specified C# object.
                returnableObject = JsonConvert.DeserializeObject<GcDataObject<T>>(jsonString);
            }
            catch (JsonException je)
            {
                Console.WriteLine(je);
            }
            return returnableObject;
        }

        public async Task<GcDataObject<T>> GetSingleAsync(string urlPath)
        {
            var returnableObject = new GcDataObject<T>();
            try
            {
                var response = await _dataObjectClient.GetDataAsync(urlPath);
                if (response.IsSuccessStatusCode)
                {
                    var resultString = await response.Content.ReadAsStringAsync();
                    returnableObject = JsonConvert.DeserializeObject<GcDataObject<T>>(resultString);
                    return returnableObject;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return returnableObject;
        }

        //method that gets all the objects.
        public GcDataCollection<T> GetAll(string urlPath)
        {
            var returnableObject = new GcDataCollection<T>();
            try
            {
                var jsonString = _dataObjectClient.GetData(urlPath);
                //deserializing the jsonString content to a enumerated C# objects.
                returnableObject = JsonConvert.DeserializeObject<GcDataCollection<T>>(jsonString);
            }
            catch (JsonException je)
            {
                Console.WriteLine(je);
            }

            return returnableObject;
        }

        public async Task<GcDataCollection<T>> GetAllAsync(string urlPath)
        {
            var returnableObject = new GcDataCollection<T>();
            try
            {
                var response = await _dataObjectClient.GetDataAsync(urlPath);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    //deserializing the jsonString content to a enumerated C# objects.
                    returnableObject = JsonConvert.DeserializeObject<GcDataCollection<T>>(responseString); 
                }
            }
            catch (JsonException je)
            {
                Console.WriteLine(je);
            }

            return returnableObject;
        }

        //method that gets some objects.
        public ICollection<GcDataObject<T>> GetObjectCollection(string urlPath, List<int> ids)
        {
            return ids.Select(id => GetSingle(urlPath + id)).ToList();
        }

        //method that posts an object.
        public string PostObject(string urlPath, NameValueCollection nameValue)
        {
            var postString = _dataObjectClient.PostData(urlPath, nameValue);
            return postString;
        }
                
        public async Task<ICollection<GcDataObject<T>>> GetObjectCollectionAsync(string urlPath, List<int> ids)
        {
            var objectList = new List<GcDataObject<T>>();
            foreach (var id in ids)
            {
                var l = await GetSingleAsync(urlPath + id);
                objectList.Add(l);
            }
            return objectList;
        }

        public async Task<HttpResponseMessage> PostObjectAsync(string urlPath, Dictionary<string, string> dataDictionary)
        {
            var response = _dataObjectClient.PostDataAsync(urlPath, dataDictionary);
            return await response;
        }

        public void Dispose()
        {
            _dataObjectClient?.Dispose();
        }
    }
}