﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Marvin.StreamExtensions;
using WebService.Responses;

namespace WebService
{
    public interface IWebServiceClient
    {
        Task<PostCode> FetchPostCodeAsync(string postcode, string houseNumber);
    }

    public class WebServiceClient : IWebServiceClient
    {
        private readonly HttpClient httpClient; 

        public WebServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
            this.httpClient.BaseAddress = new System.Uri("https://gmx7qarj73.execute-api.eu-west-1.amazonaws.com/v1/");
            this.httpClient.DefaultRequestHeaders.Clear();
            this.httpClient.DefaultRequestHeaders.Add(name: "Accept", value: "application/json");
            this.httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        }

        public async Task<PostCode> FetchPostCodeAsync(string postCode, string houseNumber)
        {
            // Build house number query parameter
            var houseNumberQuery = string.IsNullOrEmpty(houseNumber)
                ? string.Empty
                : $"&housenumber={houseNumber}";
            // Build request uri
            var requestUri = $"lookup?postcode={postCode}{houseNumberQuery}";
            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: requestUri);
            // TODO Pull cancellation token to method signature
            var cancellationToken = new CancellationToken();
            using (var response = await this.httpClient.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead,
              cancellationToken))
            {
                // Read content as stream to be faster
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                return stream.ReadAndDeserializeFromJson<PostCode>();
            }
        }
    }
}
