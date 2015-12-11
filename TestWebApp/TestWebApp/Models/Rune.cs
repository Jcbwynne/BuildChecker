using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApp
{
    [Serializable]
    public class Rune
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public RuneTierInfo rune { get; set; }
    }

    [Serializable]
    public class RuneObject
    {
        public dynamic type { get; set; }
        public dynamic version { get; set; }
        public dynamic data { get; set; }
    }

    [Serializable]
    public class RuneTierInfo
    {
        public string isRune { get; set; }
        public string tier { get; set; }
        public string type { get; set; }
    }
}