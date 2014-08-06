using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class LocalInt
    {
        private string g_key;
        private int g_value;

        [XmlElement]
        public string Key
        {
            get { return g_key; }
            set { g_key = value; }
        }
        [XmlElement]
        public int Value
        {
            get { return g_value; }
            set { g_value = value; }
        }

        public LocalInt()
        {
        }
    }
}
