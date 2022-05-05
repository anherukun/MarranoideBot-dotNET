using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test_RPG_TextBaseGame.Models;
using Action = Test_RPG_TextBaseGame.Models.Action;

namespace Test_RPG_TextBaseGame.Service
{
    class GameService
    {
        public static List<GameData> GetListOfGames()
        {
            List<GameData> gameDatas;
             using (StreamReader file = File.OpenText($"{AppContext.BaseDirectory}Assets/GamesData.json"))
            {
                string s = file.ReadToEnd();

                try
                {
                    gameDatas = new List<GameData>(JsonConvert.DeserializeObject<List<GameData>>(s));
                    return gameDatas;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }
        public static void StartGame(PlayData data)
        {
            bool inGame = true;
            do
            {
                PrintDialog(data.Game.Dialogs.First(x => x.ID == data.CurrentDialog));

                if (data.Game.Dialogs.First(x => x.ID == data.CurrentDialog).Options != null)
                {
                    ShowOptions(data.Game.Dialogs.First(x => x.ID == data.CurrentDialog), data);

                    var response = ReadResponse();
                    var option = 0;
                    if (int.TryParse(response, out option))
                    {
                        Console.WriteLine(DoActions(ref data, option));
                        Console.ReadLine();
                    }
                }

                foreach (var item in data.Player.Inventory)
                {
                    Console.WriteLine($"Item de inventario: {item.Object.Name}, cantidad: {item.Quantity} ");
                    Console.ReadLine();
                }
            }
            while (inGame);
        }

        public static PlayData NewGame(GameData gameData)
        {
            PlayData data = new PlayData();

            using (StreamReader file = File.OpenText($"{AppContext.BaseDirectory}{gameData.GameHistoryPath}"))
            {
                string s = file.ReadToEnd();

                try
                {
                    data.Game.Dialogs = new List<Dialog>(JsonConvert.DeserializeObject<List<Dialog>>(s));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }

            using (StreamReader file = File.OpenText($"{AppContext.BaseDirectory}{gameData.GameObjectPath}"))
            {
                string s = file.ReadToEnd();

                try
                {
                    data.GlobalObjects = new List<GameObject>(JsonConvert.DeserializeObject<List<GameObject>>(s));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }

            return data;
        }

        public static void PrintDialog(Dialog d)
        {
            Console.Clear();
            Console.WriteLine(d.Text);
        }

        private static void ShowOptions(Dialog d, PlayData data)
        {
            Console.WriteLine("De las siguentes opciones:");

            for (int i = 0; i < d.Options.Count; i++)
            {
                Console.WriteLine($"[{i}] - {d.Options[i].Label}");
            }
        }

        private static string ReadResponse()
        {
            Console.Write("Tu respuesta es: ");
            return Console.ReadLine();
        }

        private static string DoActions(ref PlayData data, int o)
        {
            var currentDialog = data.CurrentDialog;
            var response = "";
            for (int i = 0; i < data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions.Count(); i++)
            {
                switch (data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions[i].Taction)
                {
                    case TAction.GODIALOG:
                        data.CurrentDialog = data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions[i].Value;
                        response = "...";
                        break;
                    case TAction.TAKEOBJECT:
                        InventoryService.Add(data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions[i].Value, data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions[i].Quantity.Value, ref data);
                        response += $"Objetos obtenidos... {data.Game.Dialogs.First(x => x.ID == currentDialog).Options[o].Actions[i].Value}\n";
                        break;
                    case TAction.USEOBJECT:
                        response = $"Haz utilizado el objeto: ";
                        break;
                }
            }
            return response;
        }
    }
}