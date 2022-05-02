using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Test_RPG_TextBaseGame.Models;

namespace Test_RPG_TextBaseGame
{
    class Program
    {

        static void Main(string[] args)
        {
            GameHistory history = new GameHistory();

            using (StreamReader file = File.OpenText($"{AppContext.BaseDirectory}Assets/GameHistory.json"))
            {

                string s = file.ReadToEnd();

                try
                {
                    history.Dialogs = JsonConvert.DeserializeObject<List<Dialog>>(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Console.WriteLine($"Hello World! {AppContext.BaseDirectory}");
        }
    }
}
