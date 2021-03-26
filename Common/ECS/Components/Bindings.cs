using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Common.ECS.Components
{
    public struct Bindings
    {
        public Dictionary<string, int> Pairs { get; private set; }

        public Bindings(bool _){
            Pairs = new Dictionary<string, int>();
            InitializeBindings();
        }

        void InitializeBindings(){
            var json = File.ReadAllText("C:\\Users\\UserName\\Desktop\\byBullet\\Content\\Json\\Bindings.json");

            var objects = JObject.Parse(json);
            var list = objects.AsJEnumerable();
            foreach (var item in list)
            {
                Pairs.Add(item.First.Path, item.First.Value<int>());
            }
        }
    }
}