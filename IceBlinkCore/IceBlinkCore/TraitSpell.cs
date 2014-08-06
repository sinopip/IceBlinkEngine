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
    /*[Serializable]
    public class TraitSpells
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public List<TraitSpell> traitSpellList = new List<TraitSpell>();

        public TraitSpells()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveTraitSpellsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(TraitSpells));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save TraitSpells file. Error: " + ex.Message);
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
        public TraitSpells loadTraitSpellsFile(string filename)
        {
            TraitSpells toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(TraitSpells));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (TraitSpells)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml TraitSpells file. Error:\n{0}", ex.Message);
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
        public TraitSpell getTraitSpellByTag(string tag)
        {
            foreach (TraitSpell ts in traitSpellList)
            {
                if (ts.TraitSpellTag == tag) return ts;
            }
            return null;
        }
    }*/

    /*[Serializable]
    public class TraitSpell
    {
        [XmlIgnore]
        public Game game;

        public enum AoEShape
        {
            Square = 0,
            Cone = 1,
            Line = 2
        }
        public enum EffectType
        {
            Damage = 0, //usually persistent and negative for effect target
            Heal = 1,   //usually persistent and positive for effect target
            Buff = 2,   //usually temporary and positive for effect target
            Debuff = 3  //usually temporary and negative for effect target
        }

        #region Fields        
        private string name = "newTS"; //item name
        private string tag = "newTSTag"; //item unique tag name
        private string description = "";
        private int costSP = 0;
        private bool targetIsPC = false;
        private EffectType tsEffectType = EffectType.Damage;
        private AoEShape aoeShape = AoEShape.Square;
        private int aoeRadiusOrLength = 0;
        private int range = 0;
        private int damageNumDice = 0; //number of dice to roll for damage
        private int damageDie = 0; //type of dice to roll for damage
        private int damageDieAdder = 0; //add to damage per die (2d4 + 1 where 1 is the adder)
        private int healNumDice = 0; //number of dice to roll for heal
        private int healDie = 0; //type of dice to roll for heal
        private int healDieAdder = 0; //add to heal per die (2d4 + 1 where 1 is the adder)
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Trait/Spell")]
        public string TraitSpellName
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Trait/Spell (Must be unique)")]
        public string TraitSpellTag
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of trait/spell with some stats and cost as well")]
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How much SP this Trait/Spell costs")]
        public int CostSP
        {
            get
            {
                return costSP;
            }
            set
            {
                costSP = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("If true, target is a PC; else, target is a creature")]
        public bool TargetIsPC
        {
            get
            {
                return targetIsPC;
            }
            set
            {
                targetIsPC = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("the shape of the Area of Effect")]
        public AoEShape AoeShape
        {
            get
            {
                return aoeShape;
            }
            set
            {
                aoeShape = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("the radius or length of the AoE")]
        public int AoeRadiusOrLength
        {
            get
            {
                return aoeRadiusOrLength;
            }
            set
            {
                aoeRadiusOrLength = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("the range allowed to the center or beginning of the AoE")]
        public int Range
        {
            get
            {
                return range;
            }
            set
            {
                range = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("damage = persistent, negative; heal = persistent, positive; buff = temporary, positive; debuff = temporary, negative")]
        public EffectType TsEffectType
        {
            get
            {
                return tsEffectType;
            }
            set
            {
                tsEffectType = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("number of dice to roll")]
        public int DamageNumDice
        {
            get
            {
                return damageNumDice;
            }
            set
            {
                damageNumDice = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("type of dice to roll")]
        public int DamageDie
        {
            get
            {
                return damageDie;
            }
            set
            {
                damageDie = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("add to roll per die (ex. 2d4 + 1 where 1 is the adder)")]
        public int DamageDieAdder
        {
            get
            {
                return damageDieAdder;
            }
            set
            {
                damageDieAdder = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("number of dice to roll")]
        public int HealNumDice
        {
            get
            {
                return healNumDice;
            }
            set
            {
                healNumDice = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("type of dice to roll")]
        public int HealDie
        {
            get
            {
                return healDie;
            }
            set
            {
                healDie = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("add to roll per die (ex. 2d4 + 1 where 1 is the adder)")]
        public int HealDieAdder
        {
            get
            {
                return healDieAdder;
            }
            set
            {
                healDieAdder = value;
            }
        }
        #endregion

        public TraitSpell()
        {            
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public override string ToString()
        {
            return TraitSpellName;
        }
        public TraitSpell ShallowCopy()
        {
            return (TraitSpell)this.MemberwiseClone();
        }
        public TraitSpell DeepCopy()
        {
            TraitSpell other = (TraitSpell)this.MemberwiseClone();
            //other.IdInfo = new IdInfo(this.IdInfo.IdNumber);
            return other;
        }
    }*/
}
