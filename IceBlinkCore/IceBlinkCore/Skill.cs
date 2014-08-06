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

namespace IceBlinkCore
{
    [Serializable]
    public class Skills
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public BindingList<Skill> skillsList = new BindingList<Skill>();

        public Skills()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveSkillsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Skills));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Skills file. Error: " + ex.Message);
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
        public Skills loadSkillsFile(string filename)
        {
            Skills toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Skills));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Skills)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Skills file. Error:\n{0}", ex.Message);
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
        public Skill getSkillByTag(string tag)
        {
            foreach (Skill ts in skillsList)
            {
                if (ts.SkillTag == tag) return ts;
            }
            return null;
        }
    }

    [Serializable]
    public class Skill : INotifyPropertyChanged
    {
        [XmlIgnore]
        public Game game;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Fields        
        private string name = "newSkill"; //item name
        private string tag = "newSkillTag"; //item unique tag name
        private string description = "";
        private UsableInSituation useableInSituation = UsableInSituation.Always;
        private int baseValue = 0;
        private int ranks = 0;
        private int modifiers = 0;
        private int maxRanksAtLevel = 4;
        private int totalRanks = 0;
        private CharBase.CharacterAttribute attributeForBonus = CharBase.CharacterAttribute.Strength;
        private int ranksAssigned = 0;
        private int pointsPerRank = 1;
        private ScriptSelectEditorReturnObject skillScript = new ScriptSelectEditorReturnObject();
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Skill")]
        public string SkillName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;                
                this.NotifyPropertyChanged("SkillName");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Skill (Must be unique)")]
        public string SkillTag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
                this.NotifyPropertyChanged("SkillTag");
            }
        }

        [XmlElement]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of skill and its use")]
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                this.NotifyPropertyChanged("Description");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("When can this be used: Always means that it can be used in combat and on the main maps, Passive means that it is always on and doesn't need to be activated.")]
        public UsableInSituation UseableInSituation
        {
            get { return useableInSituation; }
            set 
            {
                useableInSituation = value;
                this.NotifyPropertyChanged("UseableInSituation");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("This is the base value for this skill, typically is 0")]
        public int BaseValue
        {
            get
            {
                return baseValue;
            }
            set
            {
                baseValue = value;
                this.NotifyPropertyChanged("BaseValue");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("This is the current amount of ranks in this skill without modifiers")]
        public int Ranks
        {
            get
            {
                return ranks;
            }
            set
            {
                ranks = value;
                this.NotifyPropertyChanged("Ranks");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Sum of all modifiers to be applied to Ranks (calculated)")]
        public int Modifiers
        {
            get
            {
                return modifiers;
            }
            set
            {
                modifiers = value;
                this.NotifyPropertyChanged("Modifiers");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Maximium Ranks at current level not counting modifiers (calculated)")]
        public int MaxRanksAtLevel
        {
            get
            {
                return maxRanksAtLevel;
            }
            set
            {
                maxRanksAtLevel = value;
                this.NotifyPropertyChanged("MaxRanksAtLevel");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("This is the total amount of ranks in this skill with modifiers")]
        public int TotalRanks
        {
            get
            {
                return totalRanks;
            }
            set
            {
                totalRanks = value;
                this.NotifyPropertyChanged("TotalRanks");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The attribute used for bonuses")]
        public CharBase.CharacterAttribute AttributeForBonus
        {
            get
            {
                return attributeForBonus;
            }
            set
            {
                attributeForBonus = value;
                this.NotifyPropertyChanged("AttributeForBonus");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("These are the total points choosen by the player at current level up")]
        public int RanksAssigned
        {
            get
            {
                return ranksAssigned;
            }
            set
            {
                ranksAssigned = value;
                this.NotifyPropertyChanged("RanksAssigned");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Amount of points you must spend to increase one rank")]
        public int PointsPerRank
        {
            get
            {
                return pointsPerRank;
            }
            set
            {
                pointsPerRank = value;
                this.NotifyPropertyChanged("PointsPerRank");
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("the script to use for this Skill (if any)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject SkillScript
        {
            get { return skillScript; }
            set { skillScript = value; }
        }
        #endregion

        public Skill()
        {
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            SkillScript.prntForm = pf;
        }
        public override string ToString()
        {
            return SkillName;
        }
        public void reCalculate(PC pc)
        {
            if (AttributeForBonus == CharBase.CharacterAttribute.Strength)
                Modifiers = (pc.Strength - 10) / 2;
            if (AttributeForBonus == CharBase.CharacterAttribute.Dexterity)
                Modifiers = (pc.Dexterity - 10) / 2;
            if (AttributeForBonus == CharBase.CharacterAttribute.Constitution)
                Modifiers = (pc.Constitution - 10) / 2;
            if (AttributeForBonus == CharBase.CharacterAttribute.Intelligence)
                Modifiers = (pc.Intelligence - 10) / 2;
            if (AttributeForBonus == CharBase.CharacterAttribute.Wisdom)
                Modifiers = (pc.Wisdom - 10) / 2;
            if (AttributeForBonus == CharBase.CharacterAttribute.Charisma)
                Modifiers = (pc.Charisma - 10) / 2;
            TotalRanks = Ranks + Modifiers;
        }
        public Skill ShallowCopy()
        {
            return (Skill)this.MemberwiseClone();
        }
        public Skill DeepCopy()
        {
            Skill other = (Skill)this.MemberwiseClone();
            other.SkillScript = this.SkillScript.DeepCopy();
            return other;
        }
    }

    [Serializable]
    public class SkillRefs
    {
        private string skillName = "";
        private string skillTag = "";
        private int skillRanks = 0;

        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string SkillTag
        {
            get { return skillTag; }
            set { skillTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public int SkillRanks
        {
            get { return skillRanks; }
            set { skillRanks = value; }
        }
        
        public SkillRefs()
        {
        }
    }  
}
