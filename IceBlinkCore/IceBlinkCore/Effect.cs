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
    public class Effects
    {
        [XmlIgnore]
        public Game game;
        [XmlElement]
        public List<Effect> effectsList = new List<Effect>();

        public Effects()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveEffectsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Effects));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Effects file. Error: " + ex.Message);
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
        public Effects loadEffectsFile(string filename)
        {
            Effects toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Effects));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Effects)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Effects file. Error:\n{0}", ex.Message);
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
        public Effect getEffectByTag(string tag)
        {
            foreach (Effect ef in effectsList)
            {
                if (ef.EffectTag == tag) return ef;
            }
            return null;
        }
    }

    [Serializable]
    public class Effect
    {
        [XmlIgnore]
        public Game game;

        #region Fields        
        private string name = "newEffect";
        private string tag = "newEffectTag";
        private string tagOfSender = "senderTag";
        private string description = "";
        private string spriteFilename = "held.spt";
        private string category = "newCategory";
        private int durationInRounds = 0;
        private int currentDurationInRounds = 0;
        private int durationInUnits = 0;
        private int currentDurationInUnits = 0;
        private int startingTimeInUnits = 0;
        private int babModifier = 0;
        private int acModifier = 0;
        private int damageMeleeModifier = 0;
        private int damageRangedModifier = 0;
        private int damageReductionModifier = 0;
        private bool isStackableEffect = false;
        private bool isStackableDuration = false;
        private bool usedForUpdateStats = false;
        private string effectLetter = "";
        private Color effectLetterColor = Color.White;
        private ScriptSelectEditorReturnObject effectScript = new ScriptSelectEditorReturnObject();
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Determines if this effect is used specifically for modifying PC stats only")]
        public bool UsedForUpdateStats
        {
            get
            {
                return usedForUpdateStats;
            }
            set
            {
                usedForUpdateStats = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Should the effect be stackable, true = stackable")]
        public bool IsStackableEffect
        {
            get
            {
                return isStackableEffect;
            }
            set
            {
                isStackableEffect = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Should the effect duration be stackable, true = stackable")]
        public bool IsStackableDuration
        {
            get
            {
                return isStackableDuration;
            }
            set
            {
                isStackableDuration = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Effect")]
        public string EffectName
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The Letter/character to show on the PC portrait for effect notifications")]
        public string EffectLetter
        {
            get
            {
                return effectLetter;
            }
            set
            {
                effectLetter = value;
            }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The color of the Letter that will show on the PC portrait for effect notifications")]
        public Color EffectLetterColor
        {
            get
            {
                return effectLetterColor;
            }
            set
            {
                effectLetterColor = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Effect (Must be unique)")]
        public string EffectTag
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the Effect sender, the one who created the effect (Must be unique)"), ReadOnly(true)]
        public string TagOfSender
        {
            get
            {
                return tagOfSender;
            }
            set
            {
                tagOfSender = value;
            }
        }

        [XmlElement]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Detailed description of effect with some stats")]
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
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Category of the Effect (useful in scripting)")]
        public string EffectCategory
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
            }
        }
                
        [XmlElement]
        [CategoryAttribute("04 - No Longer Used"), DescriptionAttribute("How long the Effect lasts in rounds"), ReadOnly(true)]
        public int DurationInRounds
        {
            get
            {
                return durationInRounds;
            }
            set
            {
                durationInRounds = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("04 - No Longer Used"), DescriptionAttribute("How long the Effect has been going on so far in rounds"), ReadOnly(false)]
        public int CurrentDurationInRounds
        {
            get
            {
                return currentDurationInRounds;
            }
            set
            {
                currentDurationInRounds = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How long the Effect lasts in units of time")]
        public int DurationInUnits
        {
            get
            {
                return durationInUnits;
            }
            set
            {
                durationInUnits = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How long the Effect has been going on so far in units of time")]
        public int CurrentDurationInUnits
        {
            get
            {
                return currentDurationInUnits;
            }
            set
            {
                currentDurationInUnits = value;
            }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("At what time did the Effect begin, in units of time")]
        public int StartingTimeInUnits
        {
            get
            {
                return startingTimeInUnits;
            }
            set
            {
                startingTimeInUnits = value;
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

        [XmlElement]
        [CategoryAttribute("02 - Scripts"), DescriptionAttribute("fires on each round or turn")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject EffectScript
        {
            get { return effectScript; }
            set { effectScript = value; }
        }
        #endregion

        public Effect()
        {            
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            EffectScript.prntForm = pf;
        }
        public override string ToString()
        {
            return EffectName;
        }
        public Effect ShallowCopy()
        {
            return (Effect)this.MemberwiseClone();
        }
        public Effect DeepCopy()
        {
            Effect other = (Effect)this.MemberwiseClone();
            other.EffectScript = this.EffectScript.DeepCopy();
            return other;
        }
    }
}
