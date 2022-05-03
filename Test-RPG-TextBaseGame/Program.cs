using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test_RPG_TextBaseGame.Models;
using Test_RPG_TextBaseGame.Service;

namespace Test_RPG_TextBaseGame
{
    class Program
    {
        public PlayData Data { get; set; }
        public Program()
        {
            if (true)
            {
                Data = GameService.NewGame();
            }
        }

        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync()
        {
            GameService.StartGame(Data);

            await Task.Delay(100);
        }
    }
}
