using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp
{
    [Serializable]
    public class Mastery
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string masteryTree { get; set; }
    }

    [Serializable]
    public class MasteryObject
    {
        public dynamic type { get; set; }
        public dynamic version { get; set; }
        public dynamic data { get; set; }
    }
}