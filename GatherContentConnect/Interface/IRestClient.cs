using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;

namespace GatherContentConnect.Interface
{
    public interface IRestClient : IDisposable
    {
        string GetData(string urlPath);
        Task<HttpResponseMessage> GetDataAsync(string url);

        string PostData(string url, NameValueCollection dataPairs);
        Task<HttpResponseMessage> PostDataAsync(string url, Dictionary<string, string> payload);
    }
}
