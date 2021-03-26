using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Common.ECS.Components
{
    public struct Controller
    {
        public Dictionary<string, bool> Flags { get; private set; }

        public Controller(bool _){
            Flags = new Dictionary<string, bool>();
            InitializeFlags();
        }

        void InitializeFlags(){ //may replace it by getting the Binding component from world and reading pairs from it
            var json = File.ReadAllText("C:\\Users\\UserName\\Desktop\\byBullet\\Content\\Json\\Bindings.json");

            var objects = JObject.Parse(json);
            var list = objects.AsJEnumerable();
            foreach (var item in list)
            {
                Flags.Add(item.First.Path, false);
            }
        }

        public void SetFlag(string _key, bool _value){
            Flags[_key] = _value;
        }
    }
}