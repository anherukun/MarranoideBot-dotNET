using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_RPG_TextBaseGame.Models
{
    class Dialog
    {
        public string Text { get; set; }
        public List<Action> Actions { get; set; }
        public List<Option> Options { get; set; }
    }
}
