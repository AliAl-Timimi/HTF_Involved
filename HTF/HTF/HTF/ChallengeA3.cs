using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace HTF.HTF
{
    public class ChallengeA3
    {

        private class Directions
        {
            public string[] directions { get; set; }
        }

        private class Tiles
        {
            public int id { get; set; }
            public int direction { get; set; }
            public int x { get; set; }
            public int y { get; set; }
        }
        
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();
            var puzzleUrl = "api/path/1/hard/Sample";
            //var puzzleGetResponse = await _client.GetFromJsonAsync<List<>>(puzzleUrl);
        }

        private static async Task Init()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");
            var token =
                "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMzkiLCJuYmYiOjE2Mzg0Mzg5NTAsImV4cCI6MTYzODUyNTM1MCwiaWF0IjoxNjM4NDM4OTUwfQ.GiEzrIisgSuQjJ77Qb3rpSjBNqP22QoAdia0118itS6MipcTFIU5rvyY_aJnwOqmdX-Nc7zGQVTvl6atXEvmWQ";
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var startUrl = "api/path/1/hard/Start";
            var startResponse = await _client.GetAsync(startUrl);
        }
        
        //public static IEnumerable<int> GetAnswer()
        //{
            
        //}
    }
}