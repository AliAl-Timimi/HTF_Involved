using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class ChallengeA2
    {
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();
            var puzzleUrl = "api/path/1/medium/Puzzle";
            var puzzleGetResponse = await _client.GetFromJsonAsync<Dictionary<string, int>>(puzzleUrl);
            var answer = GetAnswer(puzzleGetResponse.ElementAt(0).Value, puzzleGetResponse.ElementAt(1).Value);
            var puzzlePostResponse = await _client.PostAsJsonAsync(puzzleUrl, answer.ToArray());
            var response = await puzzlePostResponse.Content.ReadAsStringAsync();
            Console.WriteLine(response);
        }

        private static async Task Init()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://involved-htf-challenge.azurewebsites.net");
            var token =
                "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMzkiLCJuYmYiOjE2Mzg0Mzg5NTAsImV4cCI6MTYzODUyNTM1MCwiaWF0IjoxNjM4NDM4OTUwfQ.GiEzrIisgSuQjJ77Qb3rpSjBNqP22QoAdia0118itS6MipcTFIU5rvyY_aJnwOqmdX-Nc7zGQVTvl6atXEvmWQ";
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var startUrl = "api/path/1/medium/Start";
            var startResponse = await _client.GetAsync(startUrl);
        }

        public static IEnumerable<int> GetAnswer(int i, int j)
        {
            Console.WriteLine(i + " " + j);
            List<int> floorList = new() {i};
            var steps = 1;
            
            for (var k = steps; i < j; k++)
            {
                if (i + k != j && i + k + (k + 1) > j)
                {
                    i -= k;
                    floorList.Add(i);
                }
                else
                {
                    i += k;
                    floorList.Add(i);
                }
            }

            foreach (var floor in floorList)
            {
                Console.WriteLine(floor);
            }
            return floorList;
        }
    }
}