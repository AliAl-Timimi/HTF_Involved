using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class ChallengeB3
    {
        /*
        private interface ICeasar
        {
            public string key { get; set; }
        }

        private class Cipher : ICeasar
        {
            public string[] cipher { get; set; }

            public Cipher(string key, string[] cipher)
            {
                
            }
        }

        private class Grid : ICeasar
        {
            
        }
        */
        
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();

            try
            {
                var puzzleUrl = "api/path/2/hard/simple";
                //var puzzleGetResponse = await _client.GetFromJsonAsync<Dictionary<Dictionary<string, List<T>>>>(puzzleUrl);
                //Console.WriteLine(puzzleGetResponse);
                //var puzzleAnswer = GetAnswer(puzzleGetResponse);
                //Console.WriteLine(puzzleAnswer);
                //var puzzlePostResponse = await _client.PostAsJsonAsync(puzzleUrl, puzzleAnswer);
                //var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();
                //Console.WriteLine(puzzlePostResponseValue);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async Task Init()
        {
            try
            {
                _client = new HttpClient();
                _client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");
                var token =
                    "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMzkiLCJuYmYiOjE2Mzg0Mzg5ODEsImV4cCI6MTYzODUyNTM4MSwiaWF0IjoxNjM4NDM4OTgxfQ.xwSrPtL_5imiki-_37XAU0jvUB8O0DZjW7UIPkWF2gvnRqbz0-RfnryJOzWCjBwz3fJGDqqq-AHQvnzvDTNQNA";
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var startUrl = "api/path/2/medium/Start";
                var startResponse = await _client.GetAsync(startUrl);
            }
            catch (Exception ignored)
            {
            }
        }

        private static int GetAnswer(string input)
        {
            return 0;
        }
    }
}