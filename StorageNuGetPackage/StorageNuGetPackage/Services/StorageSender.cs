using Newtonsoft.Json;
using RestSharp;
using StorageNuGetPackage.Sender;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageNuGetPackage.Services
{
    public class StorageSender : IStorageSender
    {



        public string _connectionString = "https://localhost:5001/Storage";

        public StorageSender(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Task<string> SaveRecord(Person p)
        {
            var client = new RestClient(_connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //var body = $"{{'name':{p.Name},'lastName': {p.LastName},'agre':{p.Agre}, 'programmingOrientation':{p.ProgrammingOrientation}}}";
            var body = JsonConvert.SerializeObject(p);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return Task.FromResult(response.Content.ToString());
        }
    }
}
