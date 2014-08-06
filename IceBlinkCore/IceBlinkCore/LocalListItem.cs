using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IceBlinkCore
{
    [Serializable]
    public class LocalListItem
    {
        private string name;
        private string notes;

        [XmlElement]
        public string LocalName
        {
            get { return name; }
            set { name = value; }
        }

        [XmlElement]
        public string LocalNotes
        {
            get { return notes; }
            set { notes = value; }
        }

        public LocalListItem()
        {
        }
    }
}
