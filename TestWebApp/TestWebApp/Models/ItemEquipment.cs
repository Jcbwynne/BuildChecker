using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp
{
    public class ItemEquipment
    {

    }

    [Serializable]
    public class ItemGroup
    {
        public string group { get; set; }
        public List<ItemData> itemList { get; set; }
    }

    [Serializable]
    public class ItemCallObject
    {
        public string type { get; set; }
        public string version { get; set; }
        public dynamic basic { get; set; }
        public dynamic data { get; set; }
    }

    [Serializable]
    public class ItemBasic
    {
        public dynamic id { get; set; }
        public dynamic name { get; set; }
        public dynamic group { get; set; }
        public dynamic description { get; set; }
        public dynamic sanitizedDescription { get; set; }
        public dynamic colloq { get; set; }
        public dynamic plaintext { get; set; }
        public dynamic consumed { get; set; } //maybe bool
        public dynamic stacks { get; set; }
        public dynamic depth { get; set; }
        public dynamic consumeOnFull { get; set; } //possibly bool
        public dynamic from { get; set; }
        public dynamic into { get; set; }
        public dynamic specialRecipe { get; set; }
        public dynamic inStore { get; set; } //maybe bool
        public dynamic hideFromAll { get; set; } //maybe bool
        public dynamic requiredChampion { get; set; }
        public dynamic tags { get; set; }
        public dynamic maps { get; set; }
        public dynamic image { get; set; }
        public dynamic stats { get; set; }
		public dynamic gold { get; set; }
        public dynamic rune { get; set; }
    }

    [Serializable]
    public class ItemData
    {
        public string id { get; set; }
        public string name { get; set; }
        public dynamic group { get; set; }
        public string description { get; set; }
        public dynamic plaintext { get; set; }
        public string unique { get; set; }
        public List<string> modifier { get; set; }
        public dynamic maps { get; set; }
        public string gold { get; set; }
        public string depth { get; set; }
        public List<string> from { get; set; }
    }

    [Serializable]
    public class ItemModifier
    {
        public string itemName { get; set; }
        public string modifier { get; set; }
        public float floatModifier { get; set; }
        public string statmMdified { get; set; }
    }
}