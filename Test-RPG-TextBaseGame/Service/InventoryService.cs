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
    class InventoryService
    {
        public static void Add(string systemName, int quantity, PlayData playData)
        {
            playData.Player.Inventory.Add(new InventoryObject()
            {
                Object = playData.GlobalObjects.Find(x => x.SystemName == systemName),
                Quantity = quantity
            });
        }
    }
}