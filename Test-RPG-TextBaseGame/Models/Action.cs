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
        public static string SAVE = "SAVE";
        public static string GODIALOG = "GODIALOG";
        public static string TAKEOBJECT = "TAKEOBJECT";
    }
}
