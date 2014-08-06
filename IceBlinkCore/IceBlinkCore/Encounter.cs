using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using IceBlink;
using System.ComponentModel;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class Encounters
    {
        [XmlArrayItem("Encounters")]
        public List<Encounter> encounters = new List<Encounter>();
        [XmlIgnore]
        public Game game;

        public Encounters()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveEncountersFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Encounters));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Encounters file. Error: " + ex.Message);
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
        public Encounters loadEncountersFile(string filename)
        {
            Encounters toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Encounters));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Encounters)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Encounters file. Error:\n{0}", ex.Message);
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
        }
        public Encounter getEncounter(string name)
        {
            foreach (Encounter encounter in encounters)
            {
                if (encounter.EncounterName == name) return encounter;
            }
            return null;
        }
    }

    [Serializable]
    public class Encounter
    {
        [XmlIgnore]
        public Game game;

        private string encounterName = "newEncounter";
        private string encounterLevelFilename = "";
        private string encounterMapFilename = "";
        private int timePerRound = 6;
        private bool encounterActive = true;
        private List<PropRefs> encounterPropRefsList = new List<PropRefs>();
        private Props encounterPropList = new Props();
        private List<CreatureRefs> encounterCreatureRefsList = new List<CreatureRefs>();
        private Creatures encounterCreatureList = new Creatures();
        private Triggers encounterTriggerList = new Triggers();
        private List<string> encounterInventoryTagList = new List<string>();
        private List<Item> encounterInventoryList = new List<Item>();
        private ScriptSelectEditorReturnObject onStartCombatRound = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onEndCombat = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onFleeCombat = new ScriptSelectEditorReturnObject();

        #region Properties
        [XmlElement]
        [CategoryAttribute("02 - Main"), DescriptionAttribute("How much time units elapses per round in this encounter")]
        public int TimePerRound
        {
            get { return timePerRound; }
            set { timePerRound = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public string EncounterName
        {
            get { return encounterName; }
            set { encounterName = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public string EncounterLevelFilename
        {
            get { return encounterLevelFilename; }
            set { encounterLevelFilename = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public string EncounterMapFilename
        {
            get { return encounterMapFilename; }
            set { encounterMapFilename = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public bool EncounterActive
        {
            get { return encounterActive; }
            set { encounterActive = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public List<Point> EncounterPcStartLocations = new List<Point>();
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public List<PropRefs> EncounterPropRefsList
        {
            get { return encounterPropRefsList; }
            set { encounterPropRefsList = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public Props EncounterPropList
        {
            get { return encounterPropList; }
            set { encounterPropList = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public List<CreatureRefs> EncounterCreatureRefsList
        {
            get { return encounterCreatureRefsList; }
            set { encounterCreatureRefsList = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public Creatures EncounterCreatureList
        {
            get { return encounterCreatureList; }
            set { encounterCreatureList = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public Triggers EncounterTriggerList
        {
            get { return encounterTriggerList; }
            set { encounterTriggerList = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public List<string> EncounterInventoryTagList
        {
            get { return encounterInventoryTagList; }
            set { encounterInventoryTagList = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("02 - Main"), ReadOnly(true)]
        public List<Item> EncounterInventoryList
        {
            get { return encounterInventoryList; }
            set { encounterInventoryList = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Scripts"), DescriptionAttribute("fires at the beginning of each combat round")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnStartCombatRound
        {
            get { return onStartCombatRound; }
            set { onStartCombatRound = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Scripts"), DescriptionAttribute("fires at the end of each combat round")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnEndCombat
        {
            get { return onEndCombat; }
            set { onEndCombat = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Scripts"), DescriptionAttribute("fires upon clicking the Run Away button")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnFleeCombat
        {
            get { return onFleeCombat; }
            set { onFleeCombat = value; }
        }
        //[XmlElement]
        //public Point EncounterPcRetreatLocation = new Point();
        #endregion

        public Encounter()
        {
            this.OnFleeCombat.FilenameOrTag = "encOnFleeCombat.cs";
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            OnStartCombatRound.prntForm = pf;
            OnEndCombat.prntForm = pf;
            OnFleeCombat.prntForm = pf;
        }
        public override string ToString()
        {
            return EncounterName;
        }
        public Encounter DeepCopy()
        {
            Encounter other = (Encounter)this.MemberwiseClone();

            other.EncounterPcStartLocations = new List<Point>();
            foreach (Point pnt in this.EncounterPcStartLocations)
            {
                other.EncounterPcStartLocations.Add(pnt);
            }

            other.EncounterPropRefsList = new List<PropRefs>();
            foreach (PropRefs pref in this.EncounterPropRefsList)
            {
                PropRefs p = pref.DeepCopy();
                other.EncounterPropRefsList.Add(p);
            }
            other.EncounterPropList = new Props();

            other.EncounterCreatureRefsList = new List<CreatureRefs>();
            foreach (CreatureRefs cref in this.EncounterCreatureRefsList)
            {
                CreatureRefs c = cref.DeepCopy();
                other.EncounterCreatureRefsList.Add(c);
            }
            other.EncounterCreatureList = new Creatures();

            other.encounterTriggerList = new Triggers();

            other.EncounterInventoryTagList = new List<string>();
            foreach (string str in this.EncounterInventoryTagList)
            {
                other.EncounterInventoryTagList.Add(str);
            }

            other.encounterInventoryList = new List<Item>();
            
            other.OnStartCombatRound = this.OnStartCombatRound.DeepCopy();
            other.OnEndCombat = this.OnEndCombat.DeepCopy();
            other.OnFleeCombat = this.OnFleeCombat.DeepCopy();

            return other;
        }
    }    
}
