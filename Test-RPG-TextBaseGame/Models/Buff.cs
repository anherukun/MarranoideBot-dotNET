using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_RPG_TextBaseGame.Models
{
    class Buff
    {
        public string Name { get; set; }
        public int value { get; set; }
    }

    class TBuffs {
        public const string Defense = "defense";
        public const string Damage = "damage";
        public const string MagicalPower = "magicalPower";
        public const string MagicalDefense = "magicalDefense";
    }
}
