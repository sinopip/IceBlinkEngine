using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class GlobalListItem
    {
        private string name;
        private string notes;

        [XmlElement]
        public string GlobalName
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement]
        public string GlobalNotes
        {
            get { return notes; }
            set { notes = value; }
        }

        public GlobalListItem()
        {
        }
    }
}
