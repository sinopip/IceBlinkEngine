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
    public class Traits
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public List<Trait> traitList = new List<Trait>();

        public Traits()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveTraitsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Traits));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Traits file. Error: " + ex.Message);
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
        public Traits loadTraitsFile(string filename)
        {
            Traits toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Traits));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Traits)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Traits file. Error:\n{0}", ex.Message);
                //game.errorLog(ex.ToString());
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
        public Trait getTraitByTag(string tag)
        {
            foreach (Trait ts in traitList)
            {
                if (ts.TraitTag == tag) return ts;
            }
            return null;
        }
        public Trait getTraitByName(string name)
        {
            foreach (Trait ts in traitList)
            {
                if (ts.TraitName == name) return ts;
            }
            return null;
        }
    }

    [Serializable]
    public class Trait
    {
        [XmlIgnore]
        public Game game;

        #region Fields        
        private string name = "newTrait"; //item name
        private string tag = "newTraitTag"; //item unique tag name
        private string description = "";
        private UsableInSituation useableInSituation = UsableInSituation.Always;
        private string spriteFilename = "heal.spt";
        private string spriteEndingFilename = "heal1x1End.spt";
        private string traitStartSound = "none";
        private string traitEndSound = "none";
        private int costSP = 0;
        private bool targetIsPC = false;
        private bool targetIsSelf = false;
        private bool targetIsPointLocation = false;
        private TargetType traitTargetType = TargetType.Enemy;
        private Spell.EffectType traitEffectType = Spell.EffectType.Damage;
        private Spell.AoEShape aoeShape = Spell.AoEShape.Square;
        private int aoeRadiusOrLength = 0;
        private int range = 0;
        private int babModifier = 0;
        private int acModifier = 0;
        private int damageMeleeModifier = 0;
        private int damageRangedModifier = 0;
        private int damageReductionModifier = 0;
        private int damageNumDice = 0; //number of dice to roll for damage
        private int damageDie = 0; //type of dice to roll for damage
        private int damageDieAdder = 0; //add to damage per die (2d4 + 1 where 1 is the adder)
        private int healNumDice = 0; //number of dice to roll for heal
        private int healDie = 0; //type of dice to roll for heal
        private int healDieAdder = 0; //add to heal per die (2d4 + 1 where 1 is the adder)
        private ScriptSelectEditorReturnObject traitScript = new ScriptSelectEditorReturnObject();
        #endregion

        #region Properties  
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Trait")]
        public string TraitName
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Trait (Must be unique)")]
        public string TraitTag
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of trait with some stats and cost as well")]
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("When can this be used: Always means that it can be used in combat and on the main maps, Passive means that it is always on and doesn't need to be activated.")]
        public UsableInSituation UseableInSituation
        {
            get { return useableInSituation; }
            set { useableInSituation = value; }
        }

        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SpriteConverter))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Sprite to use for the effect (Sprite Filename with extension)")]
        public string SpriteFilename
        {
            get
            {
                return spriteFilename;
            }
            set
            {
                spriteFilename = value;
            }
        }

        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SpriteConverter))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Sprite to use for the ending effect (Sprite Filename with extension)")]
        public string SpriteEndingFilename
        {
            get
            {
                return spriteEndingFilename;
            }
            set
            {
                spriteEndingFilename = value;
            }
        }

        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SoundConverter))]
        [CategoryAttribute("01- Main"), DescriptionAttribute("Filename of sound to play when the trait starts (include extension)")]
        public string TraitStartSound
        {
            get { return traitStartSound; }
            set { traitStartSound = value; }
        }

        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SoundConverter))]
        [CategoryAttribute("01- Main"), DescriptionAttribute("Filename of sound to play when the trait ends (include extension)")]
        public string TraitEndSound
        {
            get { return traitEndSound; }
            set { traitEndSound = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How much SP this Trait costs")]
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
        [CategoryAttribute("04 - No Longer Used"), DescriptionAttribute("No longer used. Use SpellTargetType instead")]
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
        [CategoryAttribute("04 - No Longer Used"), DescriptionAttribute("No longer used. Use SpellTargetType instead")]
        public bool TargetIsSelf
        {
            get
            {
                return targetIsSelf;
            }
            set
            {
                targetIsSelf = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - No Longer Used"), DescriptionAttribute("No longer used. Use SpellTargetType instead")]
        public bool TargetIsPointLocation
        {
            get
            {
                return targetIsPointLocation;
            }
            set
            {
                targetIsPointLocation = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("The type of target for this trait")]
        public TargetType TraitTargetType
        {
            get
            {
                return traitTargetType;
            }
            set
            {
                traitTargetType = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("02 - Target"), DescriptionAttribute("the shape of the Area of Effect"), Browsable(false)]
        public Spell.AoEShape AoeShape
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("adds or subtracts from BAB")]
        public int BABModifier
        {
            get { return babModifier; }
            set { babModifier = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("adds or subtracts from Armor Class")]
        public int ACModifier
        {
            get { return acModifier; }
            set { acModifier = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("adds or subtracts from damage done by a melee attack")]
        public int DamageMeleeModifier
        {
            get { return damageMeleeModifier; }
            set { damageMeleeModifier = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("adds or subtracts from damage done by a ranged attack")]
        public int DamageRangedModifier
        {
            get { return damageRangedModifier; }
            set { damageRangedModifier = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("adds or subtracts from damage reduction")]
        public int DamageReductionModifier
        {
            get { return damageReductionModifier; }
            set { damageReductionModifier = value; }
        }

        #region Not Used Any More
        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("damage = persistent, negative; heal = persistent, positive; buff = temporary, positive; debuff = temporary, negative"), Browsable(false)]
        public Spell.EffectType TraitEffectType
        {
            get
            {
                return traitEffectType;
            }
            set
            {
                traitEffectType = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("number of dice to roll"), Browsable(false)]
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("type of dice to roll"), Browsable(false)]
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("add to roll per die (ex. 2d4 + 1 where 1 is the adder)"), Browsable(false)]
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("number of dice to roll"), Browsable(false)]
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("type of dice to roll"), Browsable(false)]
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
        [CategoryAttribute("03 - Effect"), DescriptionAttribute("add to roll per die (ex. 2d4 + 1 where 1 is the adder)"), Browsable(false)]
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

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("the script to use for this Trait")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject TraitScript
        {
            get { return traitScript; }
            set { traitScript = value; }
        }
        #endregion

        public Trait()
        {            
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            TraitScript.prntForm = pf;
        }
        public override string ToString()
        {
            return TraitName;
        }
        public Trait ShallowCopy()
        {
            return (Trait)this.MemberwiseClone();
        }
        public Trait DeepCopy()
        {
            Trait other = (Trait)this.MemberwiseClone();
            other.TraitScript = this.TraitScript.DeepCopy();
            return other;
        }
    }
}
