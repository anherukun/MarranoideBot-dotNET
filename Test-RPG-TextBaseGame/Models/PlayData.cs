using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test_RPG_TextBaseGame.Models
{
    class PlayData
    {
        public string PlayDataID { get; set; }
        public Player Player { get; set; } = new Player();
        public string CurrentDialog { get; set; } = "A0";
        public GameHistory Game { get; set; } = new GameHistory();
    }
}
