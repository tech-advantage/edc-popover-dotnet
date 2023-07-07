using NLog;
using RestSharp;
using System;

namespace edc_popover_dotnet.src.internalImpl
{
    public class HttpRestRequestImpl : IHttpRestRequest
    {
        private readonly static Logger _logger = LogManager.GetCurrentClassLogger();

        void IHttpRestRequest.PostData(string url, string routePath, string data)
        {
            Uri uri = new Uri(url);
            string baseUrl = uri.GetLeftPart(UriPartial.Authority);

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(routePath).AddJsonBody(data);
            client.Post(request);

            int numericStatusCode = (int)client.Post(request).StatusCode;

            if (numericStatusCode != 200)
            {
                _logger.Error("HTTP request failed with status code: " + numericStatusCode);
                throw new Exception("HTTP request failed with status code: " + numericStatusCode);
            }
            
            _logger.Info("Request " + request + " has been sent succesfully");
        }
    }
}
