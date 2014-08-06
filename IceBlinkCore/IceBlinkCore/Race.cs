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
    public class Races
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public List<Race> racesList = new List<Race>();

        public Races()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveRacesFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Races));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Races file. Error: " + ex.Message);
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
        public Races loadRacesFile(string filename)
        {
            Races toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Races));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Races)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Races file. Error:\n{0}", ex.Message);
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
        public Race getRaceByTag(string tag)
        {
            foreach (Race ts in racesList)
            {
                if (ts.RaceTag == tag) return ts;
            }
            return null;
        }
    }

    [Serializable]
    public class Race
    {
        [XmlIgnore]
        public Game game;

        #region Fields        
        private string name = "newRace"; //item name
        private string tag = "newRaceTag"; //item unique tag name
        private string description = "";
        private int strMod = 0;
        private int dexMod = 0;
        private int conMod = 0;
        private int intMod = 0;
        private int wisMod = 0;
        private int chaMod = 0;
        private int damageTypeResistanceValueBludgeoning = 0;
        private int damageTypeResistanceValuePiercing = 0;
        private int damageTypeResistanceValueSlashing = 0;
        private int damageTypeResistanceValueAcid = 0;
        private int damageTypeResistanceValueCold = 0;
        private int damageTypeResistanceValueElectricity = 0;
        private int damageTypeResistanceValueFire = 0;
        private int damageTypeResistanceValueLight = 0;
        private int damageTypeResistanceValueSonic = 0;
        private int damageTypeResistanceValueMagic = 0;
        private int damageTypeResistanceValuePoison = 0;
        private int moveDistanceLightArmor = 6;
        private int moveDistanceMediumHeavyArmor = 4;
        private List<string> classesAllowed = new List<string>();
        private SortableBindingList<TraitAllowed> traitsAllowed = new SortableBindingList<TraitAllowed>();
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValuePoison
        {
            get { return damageTypeResistanceValuePoison; }
            set { damageTypeResistanceValuePoison = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueMagic
        {
            get { return damageTypeResistanceValueMagic; }
            set { damageTypeResistanceValueMagic = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueBludgeoning
        {
            get { return damageTypeResistanceValueBludgeoning; }
            set { damageTypeResistanceValueBludgeoning = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValuePiercing
        {
            get { return damageTypeResistanceValuePiercing; }
            set { damageTypeResistanceValuePiercing = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueSlashing
        {
            get { return damageTypeResistanceValueSlashing; }
            set { damageTypeResistanceValueSlashing = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueAcid
        {
            get { return damageTypeResistanceValueAcid; }
            set { damageTypeResistanceValueAcid = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueCold
        {
            get { return damageTypeResistanceValueCold; }
            set { damageTypeResistanceValueCold = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueElectricity
        {
            get { return damageTypeResistanceValueElectricity; }
            set { damageTypeResistanceValueElectricity = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueFire
        {
            get { return damageTypeResistanceValueFire; }
            set { damageTypeResistanceValueFire = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueLight
        {
            get { return damageTypeResistanceValueLight; }
            set { damageTypeResistanceValueLight = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)")]
        public int DamageTypeResistanceValueSonic
        {
            get { return damageTypeResistanceValueSonic; }
            set { damageTypeResistanceValueSonic = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Race")]
        public string RaceName
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Race (Must be unique)")]
        public string RaceTag
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of race")]
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
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int StrMod
        {
            get
            {
                return strMod;
            }
            set
            {
                strMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int DexMod
        {
            get
            {
                return dexMod;
            }
            set
            {
                dexMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int ConMod
        {
            get
            {
                return conMod;
            }
            set
            {
                conMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int IntMod
        {
            get
            {
                return intMod;
            }
            set
            {
                intMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int WisMod
        {
            get
            {
                return wisMod;
            }
            set
            {
                wisMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Attribute Modifiers"), DescriptionAttribute("modifier to the PC's base attribute")]
        public int ChaMod
        {
            get
            {
                return chaMod;
            }
            set
            {
                chaMod = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How far this race can move in one turn of combat with no armor or light armor (measured in squares)")]
        public int MoveDistanceLightArmor
        {
            get
            {
                return moveDistanceLightArmor;
            }
            set
            {
                moveDistanceLightArmor = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How far this race can move in one turn of combat with medium or heavy armor (measured in squares)")]
        public int MoveDistanceMediumHeavyArmor
        {
            get
            {
                return moveDistanceMediumHeavyArmor;
            }
            set
            {
                moveDistanceMediumHeavyArmor = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Restrictions"), DescriptionAttribute("A list of classes that the race can learn"), Browsable(false)]
        public List<string> ClassesAllowed
        {
            get
            {
                return classesAllowed;
            }
            set
            {
                classesAllowed = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - Racial Traits"), DescriptionAttribute("A list of racial traits"), Browsable(false), ReadOnly(true)]
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
        #endregion

        public Race()
        {            
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public override string ToString()
        {
            return RaceName;
        }
        public Race ShallowCopy()
        {
            return (Race)this.MemberwiseClone();
        }
        public Race DeepCopy()
        {
            Race other = (Race)this.MemberwiseClone();
            other.ClassesAllowed = new List<string>();
            foreach (string s in this.ClassesAllowed)
            {
                other.ClassesAllowed.Add(s);
            }
            other.TraitsAllowed = new SortableBindingList<TraitAllowed>();
            foreach (TraitAllowed s in this.TraitsAllowed)
            {
                TraitAllowed sa = s.DeepCopy();
                other.TraitsAllowed.Add(sa);
            }
            return other;
        }
    }
}
