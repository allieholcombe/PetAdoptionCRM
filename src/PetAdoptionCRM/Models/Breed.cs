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
        public int Id { get; set; }
        public string Name { get; set; }

        //public static List<Breed> GetBreeds(Species species)
        //{
        //    var client = new RestClient("http://api.petfinder.com/");
        //    var request1 = new RestRequest("breed.list?format=json&animal=" + "dog" + "&key=" + EnvironmentVariables.PetFinderKey + "&callback=?", Method.GET);
        //    var request2 = new RestRequest("breed.list?format=json&animal=" + "cat" + "&key=" + EnvironmentVariables.PetFinderKey + "&callback=?", Method.GET);
        //    var request3 = new RestRequest("breed.list?format=json&animal=" + "bird" + "&key=" + EnvironmentVariables.PetFinderKey + "&callback=?", Method.GET);
        //    var response1 = new RestResponse();
        //    var response2 = new RestResponse();
        //    var response3 = new RestResponse();
        //    Task.Run(async () =>
        //    {
        //        response1 = await GetResponseContentAsync(client, request1) as RestResponse;
        //        response2 = await GetResponseContentAsync(client, request2) as RestResponse;
        //        response3 = await GetResponseContentAsync(client, request3) as RestResponse;
        //    }).Wait();
        //    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response1.Content.Substring(2, response1.Content.Length-4));
        //    var BreedList = JsonConvert.DeserializeObject<List<Breed>>(jsonResponse["petfinder"].ToString());
        //    return BreedList;
        //}
        //public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        //{
        //    var tcs = new TaskCompletionSource<IRestResponse>();
        //    theClient.ExecuteAsync(theRequest, response => {
        //        tcs.SetResult(response);
        //    });
        //    return tcs.Task;
        //}

    }
}