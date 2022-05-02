using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test_RPG_TextBaseGame.Models
{
    class GameService
    {
        public static void StartGame(PlayData data)
        {
            bool inGame = true;
            do
            {
                if (data.Game.Dialogs.First(x => x.ID == data.CurrentDialog).Actions != null)
                    DoActions(data.Game.Dialogs.First(x => x.ID == data.CurrentDialog).Actions, data);

                PrintDialog(data.Game.Dialogs.First(x => x.ID == data.CurrentDialog));

                if (data.Game.Dialogs.First(x => x.ID == data.CurrentDialog).Options != null)
                    ShowOptions(data.Game.Dialogs.First(x => x.ID == data.CurrentDialog), data);
            }
            while (inGame);
        }

        public static PlayData NewGame()
        {
            using (StreamReader file = File.OpenText($"{AppContext.BaseDirectory}Assets/GameHistory.json"))
            {
                string s = file.ReadToEnd();

                try
                {
                    PlayData data = new PlayData();
                    data.Game.Dialogs = new List<Dialog>(JsonConvert.DeserializeObject<List<Dialog>>(s));
                    return data;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
            }
        }

        public static void PrintDialog(Dialog d)
        {
            Console.WriteLine(d.Text);
        }

        private static bool ShowOptions(Dialog d, PlayData data)
        {
            string response = "";
            Console.WriteLine("De las siguentes opciones:");

            for (int i = 0; i < d.Options.Count; i++)
            {
                Console.WriteLine($"[{i}] - {d.Options[i].Label}");
            }
            Console.Write("Tu respuesta es: ");
            response = Console.ReadLine();

            if (response.Trim() != "")
                for (int i = 0; i < d.Options.Count; i++)
                {
                    if (i == int.Parse(response))
                        return DoActions(d.Options[i].Actions, data);
                }

            return false;
        }

        private static bool DoActions(List<Action> actions, PlayData data)
        {
            foreach (var item in actions)
            {
                switch (item.Taction)
                {
                    case TAction.SAVE:
                        return true;
                    case TAction.EXITGAME:
                        return false;
                    case TAction.GODIALOG:
                        data.CurrentDialog = item.Value;
                        return true;
                    case TAction.TAKEOBJECT:
                        return true;
                    case TAction.USEOBJECT:
                        return true;
                    case TAction.INVENTORY:
                        return true;
                }
            }
            return false;
        }

        private static void DoActions()
        {
            // throw new NotImplementedException();
        }
    }
}