using API.Model.Data;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GUI.Model
{
    public class SomethingAPIClient
    {
        RestClient _client;

        public SomethingAPIClient(string url)
        {
            _client = new RestClient(url);
        }

        public async Task<IEnumerable<Something>> GetSomething()
        {
            var request = new RestRequest(ApiClientConstants.SomethingApi, DataFormat.Json);

            return await _client.GetAsync<List<Something>>(request);
        }

        public async Task<Something> PostSomething(Something something)
        {
            var body = JsonConvert.SerializeObject(something);

            var request = new RestRequest(ApiClientConstants.SomethingApi, Method.POST, DataFormat.Json);            
            request.AddParameter(ApiClientConstants.JsonParameter, body, ParameterType.RequestBody);

            var resp = await _client.PostAsync< Something>(request);

            return resp;
        }

        public async Task DeleteSomething(Something something)
        {
            var body = JsonConvert.SerializeObject(something);

            var request = new RestRequest(ApiClientConstants.SomethingApi, Method.DELETE, DataFormat.Json);
            request.AddParameter(ApiClientConstants.JsonParameter, body, ParameterType.RequestBody);

            await _client.ExecuteAsync(request);
        }

        public async Task UpdateSomething(Something something)
        {
            var body = JsonConvert.SerializeObject(something);

            var request = new RestRequest(ApiClientConstants.SomethingApi, Method.PUT, DataFormat.Json);
            request.AddParameter(ApiClientConstants.JsonParameter, body, ParameterType.RequestBody);

            await _client.ExecuteAsync(request);
        }
    }
}
