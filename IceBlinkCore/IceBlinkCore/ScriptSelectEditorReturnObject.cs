using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ScriptSelectEditorReturnObject
    {
        [XmlIgnore]
        public ParentForm prntForm;

        private string filenameOrTag = "none";
        private string parm1 = "none";
        private string parm2 = "none";
        private string parm3 = "none";
        private string parm4 = "none";

        [XmlElement]
        [DescriptionAttribute("Filename or Tag of the Event Type"), ReadOnly(true)]
        public string FilenameOrTag
        {
            get { return filenameOrTag; }
            set { filenameOrTag = value; }
        }
        [XmlElement]
        [DescriptionAttribute("Parameter for the Script chosen if Event Type is Script"), ReadOnly(true)]
        public string Parm1
        {
            get { return parm1; }
            set { parm1 = value; }
        }
        [XmlElement]
        [DescriptionAttribute("Parameter for the Script chosen if Event Type is Script"), ReadOnly(true)]
        public string Parm2
        {
            get { return parm2; }
            set { parm2 = value; }
        }
        [XmlElement]
        [DescriptionAttribute("Parameter for the Script chosen if Event Type is Script"), ReadOnly(true)]
        public string Parm3
        {
            get { return parm3; }
            set { parm3 = value; }
        }
        [XmlElement]
        [DescriptionAttribute("Parameter for the Script chosen if Event Type is Script"), ReadOnly(true)]
        public string Parm4
        {
            get { return parm4; }
            set { parm4 = value; }
        }

        public ScriptSelectEditorReturnObject()
        {
        }
        public override string ToString()
        {
            return FilenameOrTag;
        }
        public ScriptSelectEditorReturnObject DeepCopy()
        {
            ScriptSelectEditorReturnObject other = (ScriptSelectEditorReturnObject)this.MemberwiseClone();
            return other;
        }
    }
}
