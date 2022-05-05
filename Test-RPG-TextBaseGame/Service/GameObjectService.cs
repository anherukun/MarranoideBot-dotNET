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
    class GameObjectService
    {
        public static GameObject Get(string systemName, List<GameObject> GlobalObjects) {
            return GlobalObjects.First(x => x.SystemName == systemName);
        }
    }
}