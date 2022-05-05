using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_RPG_TextBaseGame.Models
{
    class Player
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Zenny { get; set; }
        public List<InventoryObject> Inventory { get; set; } = new List<InventoryObject>();
    }
}
