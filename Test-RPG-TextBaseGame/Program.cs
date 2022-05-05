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
            var listofgames = GameService.GetListOfGames();
            for (int i = 0; i < listofgames.Count; i++)
            {
                Console.WriteLine($"[{i}] - {listofgames[i].GameName} - {listofgames[i].Description}");
            }

            Console.WriteLine("Selecciona un juego para iniciar: ");

            var s = Console.ReadLine();
            var o = -1;
            if (int.TryParse(s, out o))
            {
                Data = GameService.NewGame(listofgames[o]);
            }
            else
                Console.WriteLine("Opcion incorrecta, terminando proceso");
        }

        public static Task Main(string[] args) => new Program().MainAsync();

        public async Task MainAsync()
        {
            if (Data != null)
                GameService.StartGame(Data);

            await Task.Delay(100);
        }
    }
}
