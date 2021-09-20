using Newtonsoft.Json;
using RestSharp;
using StorageNuGetPackage.Receiver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageNuGetPackage.Services
{
    public class StorageReceiver : IStorageReceiver<Person>
    {

        public string _connectionString = "https://localhost:5001/Storage";

        public StorageReceiver(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<IEnumerable<Person>> GetAllPersons()
        {
            var client = new RestClient(_connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var responseCOntent = JsonConvert.DeserializeObject<IEnumerable<Person>>(response.Content);
            return Task.FromResult(responseCOntent);
        }
    }
}
