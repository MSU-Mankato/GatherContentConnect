using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using GatherContentConnect.Objects;

namespace GatherContentConnect.Interface
{
    public interface IGcDataRepository<T> : IDisposable
    {
        //method that gets single object.
        GcDataObject<T> GetSingle(string urlPath);
        //method that gets all the objects.
        GcDataCollection<T> GetAll(string urlPath);
        //method that gets some objects.
        ICollection<GcDataObject<T>> GetObjectCollection(string urlPath, List<int> ids);
        //method that posts an object.
        string PostObject(string urlPath, NameValueCollection nameValue);


        //method that gets single object.
        Task<GcDataObject<T>> GetSingleAsync(string urlPath);
        //method that gets all the objects.
        Task<GcDataCollection<T>> GetAllAsync(string urlPath);
        //method that gets some objects.
        Task<ICollection<GcDataObject<T>>> GetObjectCollectionAsync(string urlPath, List<int> ids);
        //method that posts an object.
        Task<HttpResponseMessage> PostObjectAsync(string urlPath, Dictionary<string, string> dataDictionary);



    }
}