using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class GlobalInt
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

        private int g_value;
        [XmlElement]
        public int Value
        {
            get { return g_value; }
            set { g_value = value; }
        }

        public GlobalInt()
        {
        }

        public void passRefs(Game g)
        {
            game = g;
        }
    }
}
