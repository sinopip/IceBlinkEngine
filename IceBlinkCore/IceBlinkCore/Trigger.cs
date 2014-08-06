using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using IceBlink;
using IceBlinkToolset;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace IceBlinkCore
{
    [Serializable]
    public class Triggers
    {
        [XmlIgnore]
        public Game game;

        [XmlArrayItem("TriggersList")]
        public List<Trigger> triggersList = new List<Trigger>();

        public Triggers()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        /*public void saveTriggersFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Triggers));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Triggers file. Error: " + ex.Message);
                game.errorLog(ex.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                writer = null;
            }
        }
        public Triggers loadTriggersFile(string filename)
        {
            Triggers toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Triggers));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Triggers)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Triggers file. Error:\n{0}", ex.Message);
                game.errorLog(ex.ToString());
            }
            finally
            {
                if (myFileStream != null)
                {
                    myFileStream.Close();
                }
            }
            return toReturn;
        }*/
        public Trigger getTriggerByTag(string tag)
        {
            foreach (Trigger it in triggersList)
            {
                if (it.TriggerTag == tag) return it;
            }
            return null;
        }
    }

    [Serializable]
    public class Trigger
    {
        [XmlIgnore]
        public Game game;
        [XmlIgnore]
        public ParentForm prntForm;
        [XmlIgnore]
        public Area currentArea;

        public enum TriggerType
        {
            None = 0,
            Script = 1,
            Encounter = 2,
            Conversation = 3,
            Narration = 4,
            Transition = 5,
            Container = 6,
            Shop = 7
        }

        #region Fields
        private string triggerTag = "newTrigger"; //must be unique
        private Color triggerColor = Color.White; //color used for this trigger outline in the toolset
        private int triggerZorder = 0; //"Z" order for triggers that overlap, set to 0 as default, lower number happens first
        private bool enabled = true;
        private bool doOnceOnly = false;
        private List<Point> triggerSquaresList = new List<Point>();
        private bool enabledEvent1 = true;        
        private bool enabledEvent2 = true;
        private bool enabledEvent3 = true;
        private bool enabledEvent4 = true;
        private bool enabledEvent5 = true;
        private bool enabledEvent6 = true;
        private bool doOnceOnlyEvent1 = false;
        private bool doOnceOnlyEvent2 = false;
        private bool doOnceOnlyEvent3 = false;
        private bool doOnceOnlyEvent4 = false;
        private bool doOnceOnlyEvent5 = false;
        private bool doOnceOnlyEvent6 = false;
        private TriggerType eventType1 = TriggerType.None;        
        private TriggerType eventType2 = TriggerType.None;
        private TriggerType eventType3 = TriggerType.None;
        private TriggerType eventType4 = TriggerType.None;
        private TriggerType eventType5 = TriggerType.None;
        private TriggerType eventType6 = TriggerType.None;
        private EventObjEditorReturnObject parameters1 = new EventObjEditorReturnObject();
        private EventObjEditorReturnObject parameters2 = new EventObjEditorReturnObject();
        private EventObjEditorReturnObject parameters3 = new EventObjEditorReturnObject();
        private EventObjEditorReturnObject parameters4 = new EventObjEditorReturnObject();
        private EventObjEditorReturnObject parameters5 = new EventObjEditorReturnObject();
        private EventObjEditorReturnObject parameters6 = new EventObjEditorReturnObject();
        #endregion
        //have a list of events based on the order set in toolset
        //event options (script, encounter, container, conversation, traps, transitions)
        //have a "Z" order for triggers that overlap, set to 0 as default, lower number happens first
        #region Properties
        [XmlElement]
        [CategoryAttribute("0 - Main"), DescriptionAttribute("Tag of the Trigger (Must be unique)")]
        public string TriggerTag
        {
            get { return triggerTag; }
            set { triggerTag = value; }
        }
        [XmlElement(Type=typeof(XmlColor))]
        [CategoryAttribute("0 - Main"), DescriptionAttribute("Color used for this trigger outline on the map in the toolset")]
        public Color TriggerColor
        {
            get { return triggerColor; }
            set { triggerColor = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("\"Z\" order for triggers that overlap, set to 0 as default, lower number happens first")]
        public int TriggerZorder
        {
            get { return triggerZorder; }
            set { triggerZorder = value; }
        }
        [XmlElement]
        [CategoryAttribute("0 - Main"), DescriptionAttribute("Used to Enable or Disable the trigger")]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        [XmlElement]
        [CategoryAttribute("0 - Main"), DescriptionAttribute("Only allow the Trigger to function one time then disable it")]
        public bool DoOnceOnly
        {
            get { return doOnceOnly; }
            set { doOnceOnly = value; }
        }
        [XmlElement]
        [CategoryAttribute("0 - Main"), DescriptionAttribute("List of all the squares that this Trigger covers"), ReadOnly(true)]
        public List<Point> TriggerSquaresList
        {
            get { return triggerSquaresList; }
            set { triggerSquaresList = value; }
        }
        [XmlElement]
        [CategoryAttribute("1 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent1
        {
            get { return doOnceOnlyEvent1; }
            set { doOnceOnlyEvent1 = value; }
        }
        [XmlElement]
        [CategoryAttribute("1 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent1
        {
            get { return enabledEvent1; }
            set { enabledEvent1 = value; }
        }
        [XmlElement]
        [CategoryAttribute("1 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType1
        {
            get { return eventType1; }
            set 
            {
                eventType1 = value;
                Parameters1.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("1 - Event"),DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters1
        {
            get { return parameters1; }
            set { parameters1 = value; }
        }
        [XmlElement]
        [CategoryAttribute("2 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent2
        {
            get { return doOnceOnlyEvent2; }
            set { doOnceOnlyEvent2 = value; }
        }
        [XmlElement]
        [CategoryAttribute("2 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent2
        {
            get { return enabledEvent2; }
            set { enabledEvent2 = value; }
        }
        [XmlElement]
        [CategoryAttribute("2 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType2
        {
            get { return eventType2; }
            set
            {
                eventType2 = value;
                Parameters2.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("2 - Event"), DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters2
        {
            get { return parameters2; }
            set { parameters2 = value; }
        }
        [XmlElement]
        [CategoryAttribute("3 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent3
        {
            get { return doOnceOnlyEvent3; }
            set { doOnceOnlyEvent3 = value; }
        }
        [XmlElement]
        [CategoryAttribute("3 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent3
        {
            get { return enabledEvent3; }
            set { enabledEvent3 = value; }
        }
        [XmlElement]
        [CategoryAttribute("3 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType3
        {
            get { return eventType3; }
            set
            {
                eventType3 = value;
                Parameters3.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("3 - Event"), DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters3
        {
            get { return parameters3; }
            set { parameters3 = value; }
        }
        [XmlElement]
        [CategoryAttribute("4 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent4
        {
            get { return doOnceOnlyEvent4; }
            set { doOnceOnlyEvent4 = value; }
        }
        [XmlElement]
        [CategoryAttribute("4 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent4
        {
            get { return enabledEvent4; }
            set { enabledEvent4 = value; }
        }
        [XmlElement]        
        [CategoryAttribute("4 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType4
        {
            get { return eventType4; }
            set
            {
                eventType4 = value;
                Parameters4.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("4 - Event"), DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters4
        {
            get { return parameters4; }
            set { parameters4 = value; }
        }
        [XmlElement]
        [CategoryAttribute("5 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent5
        {
            get { return doOnceOnlyEvent5; }
            set { doOnceOnlyEvent5 = value; }
        }
        [XmlElement]
        [CategoryAttribute("5 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent5
        {
            get { return enabledEvent5; }
            set { enabledEvent5 = value; }
        }
        [XmlElement]
        [CategoryAttribute("5 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType5
        {
            get { return eventType5; }
            set
            {
                eventType5 = value;
                Parameters5.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("5 - Event"), DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters5
        {
            get { return parameters5; }
            set { parameters5 = value; }
        }
        [XmlElement]
        [CategoryAttribute("6 - Event"), DescriptionAttribute("Only allow the Event to function one time then disable it")]
        public bool DoOnceOnlyEvent6
        {
            get { return doOnceOnlyEvent6; }
            set { doOnceOnlyEvent6 = value; }
        }
        [XmlElement]
        [CategoryAttribute("6 - Event"), DescriptionAttribute("Used to Enable or Disable the Event")]
        public bool EnabledEvent6
        {
            get { return enabledEvent6; }
            set { enabledEvent6 = value; }
        }
        [XmlElement]
        [CategoryAttribute("6 - Event"), DescriptionAttribute("Type of event that will be triggered at this point in the order of events")]
        public TriggerType EventType6
        {
            get { return eventType6; }
            set
            {
                eventType6 = value;
                Parameters6.EventType = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("6 - Event"), DescriptionAttribute("Parameters for the Event Type chosen (click the drop down arrow to edit parameters)")]
        [Editor(typeof(EventObjectSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public EventObjEditorReturnObject Parameters6
        {
            get { return parameters6; }
            set { parameters6 = value; }
        }
        #endregion

        public Trigger()
        {            
        }
        public void passRefs(Game g, ParentForm pf, Area ca)
        {
            game = g;
            prntForm = pf;
            currentArea = ca;
            Parameters1.prntForm = prntForm;
            Parameters2.prntForm = prntForm;
            Parameters3.prntForm = prntForm;
            Parameters4.prntForm = prntForm;
            Parameters5.prntForm = prntForm;
            Parameters6.prntForm = prntForm;
            Parameters1.currentArea = currentArea;
            Parameters2.currentArea = currentArea;
            Parameters3.currentArea = currentArea;
            Parameters4.currentArea = currentArea;
            Parameters5.currentArea = currentArea;
            Parameters6.currentArea = currentArea;
        }
    }
}
