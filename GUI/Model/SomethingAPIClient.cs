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

        public SomethingAPIClient()
        {
            _client = new RestClient("http://localhost:57383");
        }

        public async Task<IEnumerable<Something>> GetSomething()
        {
            var request = new RestRequest("api/something", DataFormat.Json);

            return await _client.GetAsync<List<Something>>(request);
        }

        public async Task<Something> PostSomething(Something something)
        {
            var body = JsonConvert.SerializeObject(something);

            var request = new RestRequest("api/something", Method.POST, DataFormat.Json);            
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);

            var resp = await _client.PostAsync< Something>(request);

            return resp;
        }

        public async Task DeleteSomething(Something something)
        {
            var body = JsonConvert.SerializeObject(something);

            var request = new RestRequest("api/something", Method.DELETE, DataFormat.Json);
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);

            IRestResponse response = await _client.ExecuteAsync(request);
        }
    }
}
