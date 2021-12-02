using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HTF.HTF
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            await ChallengeA1.Run();
            await ChallengeA2.Run();
            await ChallengeB1.Run();
            await ChallengeB2.Run();
            //await ChallengeA3.Run();
            //await ChallengeB3.Run();
        }

        
    }
}