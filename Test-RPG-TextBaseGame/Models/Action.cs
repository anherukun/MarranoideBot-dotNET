using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_RPG_TextBaseGame.Models
{
    class Action
    {
        public string Taction { get; set; }
        public string Value { get; set; }
        public int? Quantity { get; set; }
    }

    class TAction
    {
        public const string SAVE = "SAVE";
        public const string GODIALOG = "GODIALOG";
        public const string TAKEOBJECT = "TAKEOBJECT";
        public const string EXITGAME = "EXITGAME";
        public const string INVENTORY = "INVENTORY";
        public const string USEOBJECT = "USEOBJECT";
    }
}
