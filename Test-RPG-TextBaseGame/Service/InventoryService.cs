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
        public static void Add(string systemName, int quantity, ref PlayData playData)
        {
            if (!ExistItem(systemName, playData))
                playData.Player.Inventory.Add(new InventoryObject()
                {
                    Object = playData.GlobalObjects.Find(x => x.SystemName == systemName),
                    Quantity = quantity
                });
            else
            {
                playData.Player.Inventory[GetIndexOfAvailiableStack(systemName, playData)].Quantity += quantity;
            }
        }

        private static int GetIndexOfAvailiableStack(string systemName, PlayData playData) {
            var items = playData.Player.Inventory;

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Object.SystemName == systemName && items[i].Quantity < items[i].Object.MaxStack)
                    return i;
            }

            throw new Exception("Elemento no enconrtado en el inventario");
        }

        public static bool ExistItem(string systemName, PlayData playData)
        {
            return playData.Player.Inventory.Exists(x => x.Object.SystemName == systemName);
        }
    }
}