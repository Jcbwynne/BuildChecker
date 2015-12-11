using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp
{
    public class Champions
    {
        public string type { get; set; }
        public string version { get; set; }
        public Dictionary<string, dynamic> data { get; set; }
    }

    [Serializable]
    public class Champion : IComparable<Champion>
    {
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public Stats stats { get; set; }

        public int CompareTo(Champion other)
        {
            return name.CompareTo(other.name);
        }
    }

    [Serializable]
    public class Stats
    {
        public string armor { get; set; }
        public string armorperlevel { get; set; }
        public string attackdamage { get; set; }
        public string attackdamageperlevel { get; set; }
        public string attackrange { get; set; }
        public string attackspeedoffset { get; set; }
        public string attackspeedperlevel { get; set; }
        public string crit { get; set; }
        public string critperlevel { get; set; }
        public string hp { get; set; }
        public string hpperlevel { get; set; }
        public string hpregen { get; set; }
        public string hpregenperlevel { get; set; }
        public string movespeed { get; set; }
        public string mp { get; set; }
        public string mpperlevel { get; set; }
        public string mpregen { get; set; }
        public string mpregenperlevel { get; set; }
        public string spellblock { get; set; }
        public string spellblockperlevel { get; set; }
    }
    
}