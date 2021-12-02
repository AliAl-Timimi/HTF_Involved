using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class ChallengeA1
    {
        private static HttpClient _client;

        public static async Task Run()
        {
            await Init();
            var puzzleUrl = "api/path/1/easy/Puzzle";
            var puzzleGetResponse = await _client.GetFromJsonAsync<List<int>>(puzzleUrl);
            var answer = Decode(puzzleGetResponse.AsEnumerable());
            Console.WriteLine(answer);
            var puzzlePostResponse = await _client.PostAsJsonAsync(puzzleUrl, answer);
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
            var startUrl = "api/path/1/easy/Start";
            var startResponse = await _client.GetAsync(startUrl);
        }

        private static int Decode(IEnumerable<int> list)
        {
            int sum = 0;
            int sumOfParts;
            foreach (var i in list)
            {
                sum += i;
            }

            do
            {
                sumOfParts = 0;
                while (sum > 0)
                {
                    sumOfParts += sum % 10;
                    sum /= 10;
                }
                sum = sumOfParts;
            } while (sumOfParts > 9);

            return sumOfParts;
        }
    }
}