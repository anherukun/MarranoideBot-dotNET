using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_RPG_TextBaseGame.Models
{
    class GameObject
    {
        public string SystemName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TGameObject { get; set; }
        public int MaxStack { get; set; }
        public List<Buff> Buffs { get; set; }
    }

    class TGameObject {
        public const string Weapon = "weapon";
        public const string Armor = "armor";
        public const string Consumable = "consumable";
    }
}
