using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class ChallengeB1
    {
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();

            try
            {
             
                var sampleUrl = "api/path/2/easy/Sample";
                var sampleGetResponse = await _client.GetFromJsonAsync<Dictionary<string, string>>(sampleUrl);
                var sampleAnswer = GetAnswer(sampleGetResponse);
                var samplePostResponse = await _client.PostAsJsonAsync(sampleUrl, sampleAnswer);
                var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
                Console.WriteLine(samplePostResponseValue);
                
                
                var puzzleUrl = "api/path/2/easy/Puzzle";
                var puzzleGetResponse = await _client.GetFromJsonAsync<Dictionary<string,string>>(puzzleUrl);

                var puzzleAnswer = GetAnswer(puzzleGetResponse);
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
                var startUrl = "api/path/2/easy/Start";
                var startResponse = await _client.GetAsync(startUrl);
            }
            catch (Exception ignored)
            {
            }
        }

        private static double GetAnswer(Dictionary<string, string> sample)
        {
            List<DateTime> dates = new();
            var day = 0;
            var month = 0;
            var year = 0;
            var sec = 0;
            var min = 0;
            var hr = 0;
            foreach (var i in sample)
            {
                string val = i.Value;
                while(val.Length != 0)
                {
                    string value = val.Substring(0, 4);
                    if (value.Contains("MM"))
                    {
                        month = int.Parse(value.Replace("M", ""));
                        val = val.Remove(0, 4);
                    }
                    else if (value.Contains("DD"))
                    {
                        day = int.Parse(value.Replace("D", ""));
                        val = val.Remove(0, 4);
                    }
                    else if (value.Contains("mm"))
                    {
                        min = int.Parse(value.Replace("m", ""));
                        val = val.Remove(0, 4);
                    }
                    else if (value.Contains("ss"))
                    {
                        sec = int.Parse(value.Replace("s", ""));
                        val = val.Remove(0, 4);
                    }
                    else if (value.Contains("hh"))
                    {
                        hr = int.Parse(value.Replace("h", ""));
                        val = val.Remove(0, 4);
                    }
                    else
                    {
                        year = int.Parse(value);
                        val = val.Remove(0, 8);
                    }
                }

                dates.Add(new DateTime(year, month, day, hr, min, sec));
            }

            if (dates[1] > dates[0]) return (dates[1] - dates[0]).TotalSeconds;
            return (dates[0] - dates[1]).TotalSeconds;
        }
    }
}