using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class GlobalString
    {
        [XmlIgnore]
        public Game game;

        private string g_key;
        [XmlElement]
        public string Key
        {
            get { return g_key; }
            set { g_key = value; }
        }

        private string g_value;
        [XmlElement]
        public string Value
        {
            get { return g_value; }
            set { g_value = value; }
        }

        public GlobalString()
        {
        }

        public void passRefs(Game g)
        {
            game = g;
        }
    }
}
