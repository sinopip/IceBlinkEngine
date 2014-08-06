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

namespace IceBlinkCore
{
    [Serializable]
    public class PlayerClasses
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public List<PlayerClass> playerClassList = new List<PlayerClass>();

        public PlayerClasses()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void savePlayerClassesFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PlayerClasses));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save PlayerClasses file. Error: " + ex.Message);
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
        public PlayerClasses loadPlayerClassesFile(string filename)
        {
            PlayerClasses toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(PlayerClasses));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (PlayerClasses)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml PlayerClasses file. Error:\n{0}", ex.Message);
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
        public PlayerClass getPlayerClassByTag(string tag)
        {
            foreach (PlayerClass ts in playerClassList)
            {
                if (ts.PlayerClassTag == tag) return ts;
            }
            return null;
        }
    }

    [Serializable]
    public class PlayerClass
    {
        [XmlIgnore]
        public Game game;

        #region Fields        
        private string name = "newClass"; //item name
        private string tag = "newClassTag"; //item unique tag name
        private string description = "";
        private int startingHP = 10;
        private int startingSP = 20;
        private int hpPerLevelUp = 10;
        private int spPerLevelUp = 20;
        private double babMultiplier = 1;
        private List<int> babTable = new List<int>();
        private List<int> baseFortitudeAtLevel = new List<int>();
        private List<int> baseWillAtLevel = new List<int>();
        private List<int> baseReflexAtLevel = new List<int>();
        private List<int> skillPointsToSpendAtLevelTable = new List<int>();
        private List<int> spellPointsToSpendAtLevelTable = new List<int>();
        private List<int> traitPointsToSpendAtLevelTable = new List<int>();
        private int skillPointsToSpendAtLevelOne = 8;
        private int skillPointsToSpendAtLevelUp = 2;
        private int traitPointsToSpendAtLevelOne = 2;
        private int traitPointsToSpendAtLevelUp = 1;
        private int spellPointsToSpendAtLevelOne = 2;
        private int spellPointsToSpendAtLevelUp = 2;
        private List<int> xpTable = new List<int>();
        private List<string> itemsAllowed = new List<string>();
        private SortableBindingList<SkillAllowed> skillsAllowed = new SortableBindingList<SkillAllowed>();
        private SortableBindingList<TraitAllowed> traitsAllowed = new SortableBindingList<TraitAllowed>();
        private SortableBindingList<SpellAllowed> spellsAllowed = new SortableBindingList<SpellAllowed>();
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("Base Attack Bonus at Level Table")]
        public List<int> BabTable
        {
            get { return babTable; }
            set { babTable = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("Skill points to spend at Level Table")]
        public List<int> SkillPointsToSpendAtLevelTable
        {
            get { return skillPointsToSpendAtLevelTable; }
            set { skillPointsToSpendAtLevelTable = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("Spell points to spend at Level Table")]
        public List<int> SpellPointsToSpendAtLevelTable
        {
            get { return spellPointsToSpendAtLevelTable; }
            set { spellPointsToSpendAtLevelTable = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("Trait points to spend at Level Table")]
        public List<int> TraitPointsToSpendAtLevelTable
        {
            get { return traitPointsToSpendAtLevelTable; }
            set { traitPointsToSpendAtLevelTable = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the PlayerClass")]
        public string PlayerClassName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the PlayerClass (Must be unique)")]
        public string PlayerClassTag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
            }
        }

        [XmlElement]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of class")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("HP received at the first level")]
        public int StartingHP
        {
            get
            {
                return startingHP;
            }
            set
            {
                startingHP = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("SP received at the first level")]
        public int StartingSP
        {
            get
            {
                return startingSP;
            }
            set
            {
                startingSP = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("HP received at each level up after level one")]
        public int HpPerLevelUp
        {
            get
            {
                return hpPerLevelUp;
            }
            set
            {
                hpPerLevelUp = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("SP received at each level up after level one")]
        public int SpPerLevelUp
        {
            get
            {
                return spPerLevelUp;
            }
            set
            {
                spPerLevelUp = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Base Attack Bonus multiplier, BAB is rounded up to nearest integer (BAB = ClassLevel * BabMultiplier)")]
        public double BabMultiplier
        {
            get
            {
                return babMultiplier;
            }
            set
            {
                babMultiplier = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("BaseFortitude Table")]
        public List<int> BaseFortitudeAtLevel
        {
            get
            {
                return baseFortitudeAtLevel;
            }
            set
            {
                baseFortitudeAtLevel = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("BaseWill Table")]
        public List<int> BaseWillAtLevel
        {
            get
            {
                return baseWillAtLevel;
            }
            set
            {
                baseWillAtLevel = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("BaseReflex Table")]
        public List<int> BaseReflexAtLevel
        {
            get
            {
                return baseReflexAtLevel;
            }
            set
            {
                baseReflexAtLevel = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Skill Points the class receives at level one to spend")]
        public int SkillPointsToSpendAtLevelOne
        {
            get
            {
                return skillPointsToSpendAtLevelOne;
            }
            set
            {
                skillPointsToSpendAtLevelOne = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Skill Points the class receives at level up to spend")]
        public int SkillPointsToSpendAtLevelUp
        {
            get
            {
                return skillPointsToSpendAtLevelUp;
            }
            set
            {
                skillPointsToSpendAtLevelUp = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Trait Points the class receives at level one to spend")]
        public int TraitPointsToSpendAtLevelOne
        {
            get
            {
                return traitPointsToSpendAtLevelOne;
            }
            set
            {
                traitPointsToSpendAtLevelOne = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Trait Points the class receives at level up to spend")]
        public int TraitPointsToSpendAtLevelUp
        {
            get
            {
                return traitPointsToSpendAtLevelUp;
            }
            set
            {
                traitPointsToSpendAtLevelUp = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Spell Points the class receives at level one to spend")]
        public int SpellPointsToSpendAtLevelOne
        {
            get
            {
                return spellPointsToSpendAtLevelOne;
            }
            set
            {
                spellPointsToSpendAtLevelOne = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Not Used Anymore"), DescriptionAttribute("Spell Points the class receives at level up to spend")]
        public int SpellPointsToSpendAtLevelUp
        {
            get
            {
                return spellPointsToSpendAtLevelUp;
            }
            set
            {
                spellPointsToSpendAtLevelUp = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Stat Development"), DescriptionAttribute("XP Table")]
        public List<int> XpTable
        {
            get
            {
                return xpTable;
            }
            set
            {
                xpTable = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Allowed"), DescriptionAttribute("A list of items that the class can use"), Browsable(false), ReadOnly(true)]
        public List<string> ItemsAllowed
        {
            get
            {
                return itemsAllowed;
            }
            set
            {
                itemsAllowed = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Allowed"), DescriptionAttribute("A list of skills that the class can use"), Browsable(false), ReadOnly(true)]
        public SortableBindingList<SkillAllowed> SkillsAllowed
        {
            get
            {
                return skillsAllowed;
            }
            set
            {
                skillsAllowed = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Allowed"), DescriptionAttribute("A list of traits that the class can use"), Browsable(false), ReadOnly(true)]
        public SortableBindingList<TraitAllowed> TraitsAllowed
        {
            get
            {
                return traitsAllowed;
            }
            set
            {
                traitsAllowed = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Allowed"), DescriptionAttribute("A list of spells that the class can use"), Browsable(false), ReadOnly(true)]
        public SortableBindingList<SpellAllowed> SpellsAllowed
        {
            get
            {
                return spellsAllowed;
            }
            set
            {
                spellsAllowed = value;
            }
        }
        #endregion

        public PlayerClass()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void setupXpTable()
        {
            XpTable = new List<int> { 0, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000 };
        }
        public void setupSavingThrowTables()
        {
            BaseFortitudeAtLevel = new List<int> { 0, 2, 3, 3, 4, 4, 5, 5, 6 };
            BaseWillAtLevel = new List<int> { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
            BaseReflexAtLevel = new List<int> { 0, 0, 0, 1, 1, 1, 2, 2, 2 };
        }
        public void setupTables()
        {
            BabTable = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            SkillPointsToSpendAtLevelTable = new List<int> { 0, 8, 2, 2, 2, 2, 2, 2, 2 };
            SpellPointsToSpendAtLevelTable = new List<int> { 0, 2, 1, 1, 1, 1, 1, 1, 1 };
            TraitPointsToSpendAtLevelTable = new List<int> { 0, 2, 1, 1, 1, 1, 1, 1, 1 };
        }
        public override string ToString()
        {
            return PlayerClassName;
        }
        public TraitAllowed getTraitAllowedByTag(string tag)
        {
            foreach (TraitAllowed ta in this.TraitsAllowed)
            {
                if (ta.Tag == tag) return ta;
            }
            return null;
        }
        public SpellAllowed getSpellAllowedByTag(string tag)
        {
            foreach (SpellAllowed sa in this.SpellsAllowed)
            {
                if (sa.Tag == tag) return sa;
            }
            return null;
        }
        public PlayerClass ShallowCopy()
        {
            return (PlayerClass)this.MemberwiseClone();
        }
        public PlayerClass DeepCopy()
        {
            PlayerClass other = (PlayerClass)this.MemberwiseClone();
            other.ItemsAllowed = new List<string>();
            foreach (string s in this.ItemsAllowed)
            {
                other.ItemsAllowed.Add(s);
            }
            other.SkillsAllowed = new SortableBindingList<SkillAllowed>();
            foreach (SkillAllowed s in this.SkillsAllowed)
            {
                SkillAllowed sa = s.DeepCopy();
                other.SkillsAllowed.Add(sa);
            }
            other.TraitsAllowed = new SortableBindingList<TraitAllowed>();
            foreach (TraitAllowed s in this.TraitsAllowed)
            {
                TraitAllowed sa = s.DeepCopy();
                other.TraitsAllowed.Add(sa);
            }
            other.SpellsAllowed = new SortableBindingList<SpellAllowed>();
            foreach (SpellAllowed s in this.SpellsAllowed)
            {
                SpellAllowed sa = s.DeepCopy();
                other.SpellsAllowed.Add(sa);
            }
            other.XpTable = new List<int>();
            for (int i = 0; i < this.XpTable.Count; i++)
            {
                other.XpTable.Add(this.xpTable[i]);
            }
            return other;
        }
    }

    [Serializable]
    public class SkillAllowed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool allow = false;
        private string name = "";
        private string tag = "";
        private int pointsPerRank = 0;
        private int maxRanksAtLevelOne = 4;
        private int maxRanksAtLevelUp = 2;
        
        [XmlElement]
        public bool Allow
        {
            get { return allow; }
            set
            {
                allow = value;
                this.NotifyPropertyChanged("Allow");
            }
        }
        [XmlElement]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
        [XmlElement]
        public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                this.NotifyPropertyChanged("Tag");
            }
        }
        [XmlElement]
        public int PointsPerRank
        {
            get { return pointsPerRank; }
            set
            {
                pointsPerRank = value;
                this.NotifyPropertyChanged("PointsPerRank");
            }
        }
        [XmlElement]
        public int MaxRanksAtLevelOne
        {
            get { return maxRanksAtLevelOne; }
            set
            {
                maxRanksAtLevelOne = value;
                this.NotifyPropertyChanged("MaxRanksAtLevelOne");
            }
        }
        [XmlElement]
        public int MaxRanksAtLevelUp
        {
            get { return maxRanksAtLevelUp; }
            set
            {
                maxRanksAtLevelUp = value;
                this.NotifyPropertyChanged("MaxRanksAtLevelUp");
            }
        }
        
        public SkillAllowed()
        {
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public SkillAllowed DeepCopy()
        {
            SkillAllowed other = (SkillAllowed)this.MemberwiseClone();
            return other;
        }
    }    

    [Serializable]
    public class TraitAllowed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name = "";
        private string tag = "";
        private int atWhatLevelIsAvailable = 0;
        private bool automaticallyLearned = false;
        private bool needsSpecificTrainingToLearn = false;
        private bool allow = false;

        [XmlElement]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
        [XmlElement]
        public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                this.NotifyPropertyChanged("Tag");
            }
        }
        [XmlElement]
        public int AtWhatLevelIsAvailable
        {
            get { return atWhatLevelIsAvailable; }
            set
            {
                atWhatLevelIsAvailable = value;
                this.NotifyPropertyChanged("AtWhatLevelIsAvailable");
            }
        }
        [XmlElement]
        public bool AutomaticallyLearned
        {
            get { return automaticallyLearned; }
            set
            {
                automaticallyLearned = value;
                this.NotifyPropertyChanged("AutomaticallyLearned");
            }
        }
        [XmlElement]
        public bool NeedsSpecificTrainingToLearn
        {
            get { return needsSpecificTrainingToLearn; }
            set
            {
                needsSpecificTrainingToLearn = value;
                this.NotifyPropertyChanged("NeedsSpecificTrainingToLearn");
            }
        }
        [XmlElement]
        public bool Allow
        {
            get { return allow; }
            set
            {
                allow = value;
                this.NotifyPropertyChanged("Allow");
            }
        }

        public TraitAllowed()
        {
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public TraitAllowed DeepCopy()
        {
            TraitAllowed other = (TraitAllowed)this.MemberwiseClone();
            return other;
        }
    }

    [Serializable]
    public class SpellAllowed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name = "";
        private string tag = "";
        private int atWhatLevelIsAvailable = 0;
        private bool automaticallyLearned = false;
        private bool needsSpecificTrainingToLearn = false;
        private bool allow = false;

        [XmlElement]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
        [XmlElement]
        public string Tag
        {
            get { return tag; }
            set
            {
                tag = value;
                this.NotifyPropertyChanged("Tag");
            }
        }
        [XmlElement]
        public int AtWhatLevelIsAvailable
        {
            get { return atWhatLevelIsAvailable; }
            set
            {
                atWhatLevelIsAvailable = value;
                this.NotifyPropertyChanged("AtWhatLevelIsAvailable");
            }
        }
        [XmlElement]
        public bool AutomaticallyLearned
        {
            get { return automaticallyLearned; }
            set
            {
                automaticallyLearned = value;
                this.NotifyPropertyChanged("AutomaticallyLearned");
            }
        }
        [XmlElement]
        public bool NeedsSpecificTrainingToLearn
        {
            get { return needsSpecificTrainingToLearn; }
            set
            {
                needsSpecificTrainingToLearn = value;
                this.NotifyPropertyChanged("NeedsSpecificTrainingToLearn");
            }
        }
        [XmlElement]
        public bool Allow
        {
            get { return allow; }
            set
            {
                allow = value;
                this.NotifyPropertyChanged("Allow");
            }
        }

        public SpellAllowed()
        {
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public SpellAllowed DeepCopy()
        {
            SpellAllowed other = (SpellAllowed)this.MemberwiseClone();
            return other;
        }
    }
}
