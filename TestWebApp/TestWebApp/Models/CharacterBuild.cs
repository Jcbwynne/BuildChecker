using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp
{
    [Serializable]
    public class CharacterBuild
    {
        public Champion champion { get; set; }
        public List<ItemData> items { get; set; }
        public List<Mastery> masteries { get; set; }
        public List<Rune> runes { get; set; }
        public string abilitypower { get; set; }

        public int level { get; set; }
        
        public void GetItemModifiers()
        {
            List<string> modifiers = new List<string>();
            foreach(ItemData item in items)
            {
                foreach(string modifier in item.modifier)
                {
                    modifiers.Add(modifier);
                }
            }
        }
    }  
}