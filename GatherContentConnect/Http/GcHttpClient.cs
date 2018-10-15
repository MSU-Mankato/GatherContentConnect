using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GatherContentConnect.Interface;

namespace GatherContentConnect.Http
{
    public class GcHttpClient : IRestClient
    {
        private readonly WebClient _webClient;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.gathercontent.com";
        public GcHttpClient(string apiKey, string userEmail)
        {
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userEmail}:{apiKey}")));

            _httpClient = new HttpClient
            { 
                BaseAddress = new Uri(BaseUrl),
                DefaultRequestHeaders = { Authorization = authValue }                
            };
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.gathercontent.v0.5+json");

            _webClient = new WebClient
            {
                BaseAddress = BaseUrl//,
                //Credentials = new NetworkCredential(userEmail, apiKey)
            };
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userEmail}:{apiKey}"));
            _webClient.Headers[HttpRequestHeader.Authorization] = $"Basic {credentials}";
            _webClient.Headers["Accept"] = "application/vnd.gathercontent.v0.5+json";
        }

        public string GetData(string urlPath)
        {
            string returnString;

            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.BaseAddress = _webClient.BaseAddress;
                    webClient.Headers[HttpRequestHeader.Authorization] =
                        _webClient.Headers[HttpRequestHeader.Authorization];
                    webClient.Headers[HttpRequestHeader.Accept] = _webClient.Headers[HttpRequestHeader.Accept];
                    returnString = webClient.DownloadString(urlPath);
                }
            }
            catch (WebException webException)
            {
                returnString = ((HttpWebResponse)webException.Response).StatusCode.ToString();
            }
            return returnString;
        }

        public async Task<HttpResponseMessage> GetDataAsync(string urlPath)
        {
            return await _httpClient.GetAsync(urlPath);
        }

        public string PostData(string urlPath, NameValueCollection dataPairs)
        {
            string result;

            try
            {
                _webClient.UploadValues(urlPath, dataPairs);
                result = "Accepted";
            }
            catch (WebException webException)
            {
                result = ((HttpWebResponse)webException.Response).StatusCode.ToString();
                Console.WriteLine(result);
            }

            return result;
        }

        public async Task<HttpResponseMessage> PostDataAsync(string url, Dictionary<string, string> payload)
        {
            return await _httpClient.PostAsync(url, new FormUrlEncodedContent(payload));
        }

      #region IDisposable Support

        // ReSharper disable once InconsistentNaming
        // ReSharper disable once RedundantDefaultMemberInitializer
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _webClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GC_RESTClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}