using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PetAdoptionCRM.Models
{
    public class Breed
    {
        public int Breed_id { get; set; }
        public string name { get; set; }

        public static List<Breed> GetBreeds(Species species)
        {
            var client = new RestClient("http://api.petfinder.com/");
            var request = new RestRequest("breed.list?format=json&animal=" + species + "key=" + EnvironmentVariables.PetFinderKey + "&callback=?", Method.GET);
            //request.AddHeader("User-Agent", "alexandraholcombe");
            //request.AddHeader("Accept", "application/json");
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var BreedList = JsonConvert.DeserializeObject<List<Breed>>(jsonResponse["results"].ToString());
            return BreedList;
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}