using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class ChallengeB2
    {
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();

            try
            {
                var puzzleUrl = "api/path/2/medium/Puzzle";
                var puzzleGetResponse = await _client.GetStringAsync(puzzleUrl);
                Console.WriteLine(puzzleGetResponse);
                var puzzleAnswer = GetAnswer(puzzleGetResponse);
                Console.WriteLine(puzzleAnswer);
                var puzzlePostResponse = await _client.PostAsJsonAsync(puzzleUrl, puzzleAnswer);
                var puzzlePostResponseValue = await puzzlePostResponse.Content.ReadAsStringAsync();
                Console.WriteLine(puzzlePostResponseValue);
                
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
            Dictionary<string, int> pastPatterns = new ();
            int repeats;
            string possiblePattern;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 2; j + i < input.Length; j++)
                {
                    possiblePattern = input.Substring(i, j);
                    repeats = 0;
                    for (int k = 0; k <= input.Length-possiblePattern.Length; k++)
                    {
                        if (input.Substring(k, possiblePattern.Length) == possiblePattern) 
                            repeats++;
                    }
                    if (repeats > 1 && !pastPatterns.ContainsKey(possiblePattern))
                        pastPatterns.Add(possiblePattern, repeats);
                }
            }

            string pattern="";
            int reps = 0;
            foreach (var i in pastPatterns)
            {
                if (i.Value > reps)
                {
                    reps = i.Value;
                    pattern = i.Key;
                }
            }

            return int.Parse(pastPatterns.Count + pattern);
        }
    }
}