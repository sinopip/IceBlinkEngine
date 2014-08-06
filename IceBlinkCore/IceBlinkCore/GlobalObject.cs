using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class GlobalObject
    {
        private string g_key;
        private object g_object;

        [XmlElement]
        public string Key
        {
            get { return g_key; }
            set { g_key = value; }
        }        
        [XmlElement]
        public object Object
        {
            get { return g_object; }
            set { g_object = value; }
        }

        public GlobalObject()
        {
        }
    }
}
