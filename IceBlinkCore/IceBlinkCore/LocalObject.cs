using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class LocalObject
    {
        private string l_key;
        private object l_object;

        [XmlElement]
        public string Key
        {
            get { return l_key; }
            set { l_key = value; }
        }        
        [XmlElement]
        public object Object
        {
            get { return l_object; }
            set { l_object = value; }
        }

        public LocalObject()
        {
        }
    }
}
