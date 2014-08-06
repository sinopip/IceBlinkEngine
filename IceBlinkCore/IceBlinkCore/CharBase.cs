using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using IceBlink;
using System.ComponentModel;
using IceBlinkToolset;
using System.IO;

namespace IceBlinkCore
{
    [Serializable]
    public class CharBase
    {

        public enum gender
        {
            Male = 0,
            Female = 1,
        }
        public enum charStatus
        {
            Alive = 0,
            Dead = 1,
            Immobilized = 2,
            Held = 3,
            Sleeping = 4
        }
        public enum CharacterAttribute
        {
            Strength = 0,
            Dexterity = 1,
            Constitution = 2,
            Intelligence = 3,
            Wisdom = 4,
            Charisma = 5
        }
        public enum AlignmentGoodEvil
        {
            Good = 0,
            Neutral = 1,
            Evil = 2
        }
        public enum AlignmentLawChaos
        {
            Lawful = 0,
            Neutral = 1,
            Chaotic = 2
        }
        public enum SavingThrow
        {
            Fortitude = 0,
            Will = 1,
            Reflex = 2
        }
        public enum facing
        {
            UpLeft = 0,
            Up = 1,
            UpRight = 2,
            Right = 3,
            DownRight = 4,
            Down = 5,
            DownLeft = 6,
            Left = 7
        }

        #region Fields
        private Sprite char_Sprite = new Sprite();
        private string char_spriteFilename = "blank.spt";
        private string char_name = "newCreature";
        private string nameWithNotes = "newCreatureNameWithNotes";
        private string mouseOverText = "";
        private string char_tag = "newTag";
        private string char_resref = "newResRef";
        private string raceTag = "";
        private Race char_Race = new Race();
        private string classTag = "";
        private PlayerClass char_Class = new PlayerClass();
        private List<string> knownSpellsTags = new List<string>();
        private Spells char_KnownSpellsList = new Spells();
        private List<string> knownTraitsTags = new List<string>();
        private Traits char_KnownTraitsList = new Traits();
        private List<SkillRefs> knownSkillRefsTags = new List<SkillRefs>();
        private Skills char_KnownSkillsList = new Skills();
        private Effects char_EffectsList = new Effects();
        private int char_classLevel = 1;
        private gender char_gender;
        private AlignmentGoodEvil char_alignGE = AlignmentGoodEvil.Neutral;
        private AlignmentLawChaos char_alignLC = AlignmentLawChaos.Neutral;
        private charStatus char_status = charStatus.Alive;
        private facing char_facing = facing.Left;
        private facing char_combatFacing = facing.Left;
        private string char_portraitFileL = "blank.png";
        private int char_baseFortitude = 0;
        private int char_baseWill = 0;
        private int char_baseReflex = 0;
        private int char_fortitude = 0;
        private int char_will = 0;
        private int char_reflex = 0;        
        private int char_strength = 10;
        private int char_dexterity = 10;
        private int char_constitution = 10;
        private int char_intelligence = 10;
        private int char_wisdom = 10;
        private int char_charisma = 10;
        private int char_baseStr = 10;
        private int char_baseDex = 10;
        private int char_baseCon = 10;
        private int char_baseInt = 10;
        private int char_baseWis = 10;
        private int char_baseCha = 10;
        private int char_ACBase = 10;
        private int char_AC = 10;
        private int char_classBonus = 0;
        private int char_baseAttBonus = 1;
        private int char_baseAttBonusAdders = 0;
        private int char_totalDamageReduction = 0;
        private int char_size = 1;
        private int char_funds = 0;
        private int char_hp = 10;
        private int char_hpMax = 10;
        private int char_sp = 50;
        private int char_spMax = 50;
        private int char_moveDistance = 5;
        private int char_baseMoveDistance = 5;
        private int perceptionRange = 5;
        private bool char_ConversationChk = false;
        private string char_ConversationTag = "none";
        private bool show = true; //true = show, false = hide (can be used to temporarily hide something)
        private bool visible = false; //if the image is within the LoS and in the visibility range
        private bool animated = false; //true = animated, false = static
        private bool hasCollision = true;
        private string char_HeadTag = "";
        private string char_NeckTag = "";
        private string char_BodyTag = "";
        private string char_MainHandTag = "";
        private string char_OffHandTag = "";
        private string char_Ring1Tag = "";
        private string char_Ring2Tag = "";
        private string char_FeetTag = "";
        private Item char_Head;
        private Item char_Neck;
        private Item char_Body;
        private Item char_MainHand;
        private Item char_OffHand;
        private Item char_Ring1;
        private Item char_Ring2;
        private Item char_Feet;
        private ScriptSelectEditorReturnObject onHeartBeat = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onPerception = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onStartCombatTurn = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onAttack = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onEndCombatTurn = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onHit = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onDeath = new ScriptSelectEditorReturnObject();
        private int damageTypeResistanceTotalBludgeoning = 0;
        private int damageTypeResistanceTotalPiercing = 0;
        private int damageTypeResistanceTotalSlashing = 0;
        private int damageTypeResistanceTotalAcid = 0;
        private int damageTypeResistanceTotalCold = 0;
        private int damageTypeResistanceTotalElectricity = 0;
        private int damageTypeResistanceTotalFire = 0;
        private int damageTypeResistanceTotalLight = 0;
        private int damageTypeResistanceTotalSonic = 0;
        private int damageTypeResistanceTotalMagic = 0;
        private int damageTypeResistanceTotalPoison = 0;
        #endregion

        #region Properties
        [XmlIgnore]
        public Game game;
        [XmlIgnore]
        public Bitmap portraitBitmapL;
        [XmlIgnore]
        public Bitmap iconBitmap;
        [XmlIgnore]
        public Bitmap currentIconBitmap;
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public Sprite CharSprite
        {
            get { return char_Sprite; }
            set { char_Sprite = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the creature that shows up in the game engine")]
        public string Name
        {
            get{return char_name;}
            set{char_name = value;}
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the creature that shows up in the toolset list but not in the game engine")]
        public string NameWithNotes
        {
            get 
            {
                if ((nameWithNotes == "newCreatureNameWithNotes") && (char_name != "newCreature"))
                {
                    nameWithNotes = char_name;
                }
                return nameWithNotes; 
            }
            set { nameWithNotes = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The text to display when player mouses over the NPC/Creature on the adventure maps")]
        public string MouseOverText
        {
            get { return mouseOverText; }
            set { mouseOverText = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the creature (Must be unique)")]
        public string Tag
        {
            get { return char_tag; }
            set { char_tag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Resource Reference name of the creature used for updating all placed objects that share the same identifier (must be unique from other blueprints")]
        public string ResRef
        {
            get { return char_resref; }
            set { char_resref = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true), Browsable(false)]
        public string ClassTag
        {
            get { return classTag; }
            set { classTag = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Class of the creature"), Browsable(false)]
        public PlayerClass Class
        {
            get { return char_Class; }
            set { char_Class = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true), Browsable(false)]
        public string RaceTag
        {
            get { return raceTag; }
            set { raceTag = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Race of the creature"), Browsable(false)]
        public Race Race
        {
            get { return char_Race; }
            set { char_Race = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalPoison
        {
            get { return damageTypeResistanceTotalPoison; }
            set { damageTypeResistanceTotalPoison = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalMagic
        {
            get { return damageTypeResistanceTotalMagic; }
            set { damageTypeResistanceTotalMagic = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalBludgeoning
        {
            get { return damageTypeResistanceTotalBludgeoning; }
            set { damageTypeResistanceTotalBludgeoning = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalPiercing
        {
            get { return damageTypeResistanceTotalPiercing; }
            set { damageTypeResistanceTotalPiercing = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalSlashing
        {
            get { return damageTypeResistanceTotalSlashing; }
            set { damageTypeResistanceTotalSlashing = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalAcid
        {
            get { return damageTypeResistanceTotalAcid; }
            set { damageTypeResistanceTotalAcid = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalCold
        {
            get { return damageTypeResistanceTotalCold; }
            set { damageTypeResistanceTotalCold = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalElectricity
        {
            get { return damageTypeResistanceTotalElectricity; }
            set { damageTypeResistanceTotalElectricity = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalFire
        {
            get { return damageTypeResistanceTotalFire; }
            set { damageTypeResistanceTotalFire = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalLight
        {
            get { return damageTypeResistanceTotalLight; }
            set { damageTypeResistanceTotalLight = value; }
        }
        [XmlElement]
        [CategoryAttribute("00 - Resistance Modifiers"), DescriptionAttribute("Damage resistance value (default is to use -100 to 100 as a percentage of immunity, damage multiplied by percentage so 0 = full damage, 100 = no damage, -100 = double damage)"), Browsable(false)]
        public int DamageTypeResistanceTotalSonic
        {
            get { return damageTypeResistanceTotalSonic; }
            set { damageTypeResistanceTotalSonic = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Alignment on the Good-Evil axis")]
        public AlignmentGoodEvil AlignGoodEvil
        {
            get { return char_alignGE; }
            set { char_alignGE = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Alignment on the Law-Chaos axis")]
        public AlignmentLawChaos AlignLawChaos
        {
            get { return char_alignLC; }
            set { char_alignLC = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true), Browsable(false)]
        public List<string> KnownSpellsTags
        {
            get { return knownSpellsTags; }
            set { knownSpellsTags = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("List of known spells"), Browsable(false)]
        public Spells KnownSpellsList
        {
            get { return char_KnownSpellsList; }
            set { char_KnownSpellsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true), Browsable(false)]
        public List<string> KnownTraitsTags
        {
            get { return knownTraitsTags; }
            set { knownTraitsTags = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("List of known traits"), Browsable(false)]
        public Traits KnownTraitsList
        {
            get { return char_KnownTraitsList; }
            set { char_KnownTraitsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("List of effects currently applied (dynamic pool)"), ReadOnly(true), Browsable(false)]
        public Effects EffectsList
        {
            get { return char_EffectsList; }
            set { char_EffectsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true), Browsable(false)]
        public List<SkillRefs> KnownSkillRefsTags
        {
            get { return knownSkillRefsTags; }
            set { knownSkillRefsTags = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("List of known skills"), Browsable(false)]
        public Skills KnownSkillsList
        {
            get { return char_KnownSkillsList; }
            set { char_KnownSkillsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Class Level of the creature")]
        public int ClassLevel
        {
            get { return char_classLevel; }
            set { char_classLevel = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Gender of the creature")]
        public gender Gender
        {
            get { return char_gender; }
            set { char_gender = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Current status of the creature")]
        public charStatus Status
        {
            get { return char_status; }
            set { char_status = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Facing on main maps"), ReadOnly(true), Browsable(false)]
        public facing Facing
        {
            get { return char_facing; }
            set { char_facing = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Facing during combat"), ReadOnly(true), Browsable(false)]
        public facing CombatFacing
        {
            get { return char_combatFacing; }
            set { char_combatFacing = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Size of Sprite, 1=64x64, 2=128x128, 3=192x192")]
        public int Size
        {
            get { return char_size; }
            set { char_size = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), DescriptionAttribute("Filename for the creature's portrait"), ReadOnly(true), Browsable(false)]
        public string PortraitFileL
        {
            get { return char_portraitFileL; }
            set { char_portraitFileL = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), DescriptionAttribute("Filename for the creature's icon"), ReadOnly(true), Browsable(false)]
        public string SpriteFilename
        {
            get { return char_spriteFilename; }
            set { char_spriteFilename = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("fortitude value after bonuses"), ReadOnly(true)]
        public int Fortitude
        {
            get { return char_fortitude; }
            set { char_fortitude = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("will value after bonuses"), ReadOnly(true)]
        public int Will
        {
            get { return char_will; }
            set { char_will = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("reflex value after bonuses"), ReadOnly(true)]
        public int Reflex
        {
            get { return char_reflex; }
            set { char_reflex = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base fortitude value before any bonuses")]
        public int BaseFortitude
        {
            get { return char_baseFortitude; }
            set
            {
                char_baseFortitude = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base will value before any bonuses")]
        public int BaseWill
        {
            get { return char_baseWill; }
            set
            {
                char_baseWill = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base reflex value before any bonuses")]
        public int BaseReflex
        {
            get { return char_baseReflex; }
            set
            {
                char_baseReflex = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("strength value after bonuses"), ReadOnly(true)]
        public int Strength //strength
        {
            get { return char_strength; }
            set { char_strength = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("dexterity value after bonuses"), ReadOnly(true)]
        public int Dexterity //dexterity
        {
            get { return char_dexterity; }
            set { char_dexterity = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("constitution value after bonuses"), ReadOnly(true)]
        public int Constitution //constitution
        {
            get { return char_constitution; }
            set { char_constitution = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("intelligence value after bonuses"), ReadOnly(true)]
        public int Intelligence //intelligence
        {
            get { return char_intelligence; }
            set { char_intelligence = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("wisdom value after bonuses"), ReadOnly(true)]
        public int Wisdom //wisdom
        {
            get { return char_wisdom; }
            set { char_wisdom = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("charisma value after bonuses"), ReadOnly(true)]
        public int Charisma //charisma
        {
            get { return char_charisma; }
            set { char_charisma = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base strength value before any bonuses")]
        public int BaseStr //strength base
        {
            get { return char_baseStr; }
            set 
            { 
                char_baseStr = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base dexterity value before any bonuses")]
        public int BaseDex //dexterity base
        {
            get { return char_baseDex; }
            set 
            { 
                char_baseDex = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base constitution value before any bonuses")]
        public int BaseCon //constitution base
        {
            get { return char_baseCon; }
            set 
            { 
                char_baseCon = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base intelligence value before any bonuses")]
        public int BaseInt //intelligence base
        {
            get { return char_baseInt; }
            set 
            { 
                char_baseInt = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base wisdom value before any bonuses")]
        public int BaseWis //wisdom base
        {
            get { return char_baseWis; }
            set 
            { 
                char_baseWis = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Attributes"), DescriptionAttribute("base charisma value before any bonuses")]
        public int BaseCha //charisma base
        {
            get { return char_baseCha; }
            set 
            { 
                char_baseCha = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("base AC before any bonuses (natural AC)")]
        public int ACBase
        {
            get { return char_ACBase; }
            set 
            { 
                char_ACBase = value;
                UpdateSimpleStats();
            }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Armor Class after bonuses"), ReadOnly(true)]
        public int AC
        {
            get { return char_AC; }
            set { char_AC = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Class Bonus"), Browsable(false)]
        public int ClassBonus
        {
            get { return char_classBonus; }
            set { char_classBonus = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Base Attack Bonus"), ReadOnly(true)]
        public int BaseAttBonus
        {
            get { return char_baseAttBonus; }
            set { char_baseAttBonus = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Base Attack Bonus total adders from Traits, effects, skills, etc."), ReadOnly(true)]
        public int BaseAttBonusAdders
        {
            get { return char_baseAttBonusAdders; }
            set { char_baseAttBonusAdders = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Total damage reduction from items, traits, effects, skills, etc."), ReadOnly(true)]
        public int TotalDamageReduction
        {
            get { return char_totalDamageReduction; }
            set { char_totalDamageReduction = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Current amount of funds/money/credits/gp")]
        public int Funds
        {
            get { return char_funds; }
            set { char_funds = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Current amount of Hitpoints")]
        public int HP
        {
            get { return char_hp; }
            set { char_hp = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Maximum amount of Hitpoints")]
        public int HPMax
        {
            get { return char_hpMax; }
            set { char_hpMax = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Current amount of spell/stamina points")]
        public int SP
        {
            get { return char_sp; }
            set { char_sp = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Stats"), DescriptionAttribute("Maximum amount of spell/stamina points")]
        public int SPMax
        {
            get { return char_spMax; }
            set { char_spMax = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Number of spaces that they can move in combat including modifiers...used for PCs only"), ReadOnly(true)]
        public int MoveDistance
        {
            get { return char_moveDistance; }
            set { char_moveDistance = value; }
        }
        [XmlElement]
        [CategoryAttribute("86 - No Longer Used"), DescriptionAttribute("Use CreatureMoveDistance instead")]
        public int MoveDistanceBase
        {
            get { return char_baseMoveDistance; }
            set { char_baseMoveDistance = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Perception range based on number of spaces, useful in scripts.")]
        public int PerceptionRange
        {
            get { return perceptionRange; }
            set { perceptionRange = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("")]
        public bool ConversationChk
        {
            get { return char_ConversationChk; }
            set { char_ConversationChk = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("")]
        [Browsable(true)]
        [TypeConverter(typeof(ConversationConverter))]
        public string ConversationTag
        {
            get { return char_ConversationTag; }
            set { char_ConversationTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("true = show, false = hide (can be used to temporarily hide something)")]
        public bool Show
        {
            get { return show; }
            set { show = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if the image is within the LoS and in the visibility range")]
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("true = animated, false = static")]
        public bool Animated
        {
            get { return animated; }
            set { animated = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("")]
        public bool HasCollision
        {
            get { return hasCollision; }
            set { hasCollision = value; }
        }
        //Inventory Stuff
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string HeadTag
        {
            get { return char_HeadTag; }
            set { char_HeadTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string NeckTag
        {
            get { return char_NeckTag; }
            set { char_NeckTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string BodyTag
        {
            get { return char_BodyTag; }
            set { char_BodyTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string MainHandTag
        {
            get { return char_MainHandTag; }
            set { char_MainHandTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string OffHandTag
        {
            get { return char_OffHandTag; }
            set { char_OffHandTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string Ring1Tag
        {
            get { return char_Ring1Tag; }
            set { char_Ring1Tag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string Ring2Tag
        {
            get { return char_Ring2Tag; }
            set { char_Ring2Tag = value; }
        }
        [XmlElement]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public string FeetTag
        {
            get { return char_FeetTag; }
            set { char_FeetTag = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Head
        {
            get { return char_Head; }
            set { char_Head = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Neck
        {
            get { return char_Neck; }
            set { char_Neck = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Body
        {
            get { return char_Body; }
            set { char_Body = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item MainHand
        {
            get { return char_MainHand; }
            set { char_MainHand = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item OffHand
        {
            get { return char_OffHand; }
            set { char_OffHand = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Ring1
        {
            get { return char_Ring1; }
            set { char_Ring1 = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Ring2
        {
            get { return char_Ring2; }
            set { char_Ring2 = value; }
        }
        [XmlIgnore]
        [CategoryAttribute("06 - Equiped"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Item Feet
        {
            get { return char_Feet; }
            set { char_Feet = value; }
        }
        [XmlElement]
        [CategoryAttribute("07 - Scripts"), DescriptionAttribute("fires at the beginning of each move on area maps (not combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnHeartBeat
        {
            get { return onHeartBeat; }
            set { onHeartBeat = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires when an object enters this creatures perception range (not combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnPerception
        {
            get { return onPerception; }
            set { onPerception = value; }
        }
        [XmlElement]
        [CategoryAttribute("07 - Scripts"), DescriptionAttribute("fires at beginning of creature's combat turn")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnStartCombatTurn
        {
            get { return onStartCombatTurn; }
            set { onStartCombatTurn = value; }
        }
        [XmlElement]
        [CategoryAttribute("07 - Scripts"), DescriptionAttribute("fires when the PC/Creature attempts to make an attack (physical, spell, trait, etc.)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnAttack
        {
            get { return onAttack; }
            set { onAttack = value; }
        }
        [XmlElement]
        [CategoryAttribute("07 - Scripts"), DescriptionAttribute("fires at end of creature's combat turn")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnEndCombatTurn
        {
            get { return onEndCombatTurn; }
            set { onEndCombatTurn = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires when the creature is hit in combat")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnHit
        {
            get { return onHit; }
            set { onHit = value; }
        }
        [XmlElement]
        [CategoryAttribute("07 - Scripts"), DescriptionAttribute("fires when the creature is killed in combat")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnDeath
        {
            get { return onDeath; }
            set { onDeath = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), DescriptionAttribute("Starting location in combat"), ReadOnly(true)]
        public Point CombatLocation; //grid location in combat
        /*{
            get { return char_combatLocation; }
            set { char_combatLocation = value; }
        }*/
        [XmlElement]
        [CategoryAttribute("Misc"), DescriptionAttribute("current location on current area map"), ReadOnly(true)]
        public Point MapLocation; //grid location in current area map
        /*{
            get { return char_mapLocation; }
            set { char_mapLocation = value; }
        }*/

        // need to add item inventory for each character
        [XmlArrayItem("CharInventory")]
        public List<Item> charInventoryList = new List<Item>();

        private List<LocalInt> charLocalInts = new List<LocalInt>();
        [XmlArrayItem("CharLocalInts")]
        [CategoryAttribute("Locals"), DescriptionAttribute("Superseded by saved game values. if a Local in the saved game does not exist in the newer toolset list, the saved game Local will be added to the loaded game list.")]
        public List<LocalInt> CharLocalInts
        {
            get { return charLocalInts; }
            set { charLocalInts = value; }
        }
        private List<LocalString> charLocalStrings = new List<LocalString>();
        [XmlArrayItem("CharLocalStrings")]
        [CategoryAttribute("Locals"), DescriptionAttribute("Superseded by saved game values. if a Local in the saved game does not exist in the newer toolset list, the saved game Local will be added to the loaded game list.")]
        public List<LocalString> CharLocalStrings
        {
            get { return charLocalStrings; }
            set { charLocalStrings = value; }
        }
        private List<LocalObject> charLocalObjects = new List<LocalObject>();
        [XmlElement]
        public List<LocalObject> CharLocalObjects
        {
            get { return charLocalObjects; }
            set { charLocalObjects = value; }
        }
        private List<LocalInt> charAdditionalPropertyInts = new List<LocalInt>();
        [XmlArrayItem("CharAdditionalPropertyInts")]
        [CategoryAttribute("Locals"), DescriptionAttribute("These will override any values in saved games")]
        public List<LocalInt> CharAdditionalPropertyInts
        {
            get { return charAdditionalPropertyInts; }
            set { charAdditionalPropertyInts = value; }
        }
        private List<LocalString> charAdditionalPropertyStrings = new List<LocalString>();
        [XmlArrayItem("CharAdditionalPropertyStrings")]
        [CategoryAttribute("Locals"), DescriptionAttribute("These will override any values in saved games")]
        public List<LocalString> CharAdditionalPropertyStrings
        {
            get { return charAdditionalPropertyStrings; }
            set { charAdditionalPropertyStrings = value; }
        }
        #endregion

        public CharBase()
        {            
            char_gender = gender.Male;
            //char_class = charClass.Fighter;
            char_status = charStatus.Alive;
            char_Head = new Item();
            char_Neck = new Item();
            char_Body = new Item();
            char_MainHand = new Item();
            char_OffHand = new Item();
            char_Ring1 = new Item();
            char_Ring2 = new Item();
            char_Feet = new Item();
            CombatLocation = new Point(0, 0);
            MapLocation = new Point(0, 0);
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            OnHeartBeat.prntForm = pf;
            OnPerception.prntForm = pf;
            OnStartCombatTurn.prntForm = pf;
            OnAttack.prntForm = pf;
            OnEndCombatTurn.prntForm = pf;
            OnHit.prntForm = pf;
            OnDeath.prntForm = pf;
        }                
        public Bitmap LoadCharacterPortraitBitmapL(string filename)
        {
            // Sets up an image object to be displayed.
            if (portraitBitmapL != null)
            {
                portraitBitmapL.Dispose();
            }
            portraitBitmapL = new Bitmap(filename);
            return portraitBitmapL;
        }        
        public Bitmap LoadCharacterIconBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (iconBitmap != null)
            {
                iconBitmap.Dispose();
            }
            iconBitmap = new Bitmap(filename);
            return iconBitmap;
        }        
        public void LoadCharacterSprite(string path, string sprtFilename)
        {
            this.CharSprite = CharSprite.loadSpriteFile(path + "\\" + sprtFilename);
        }
        public void LoadCharacterSpriteBitmap(string path, string bitmapFilename)
        {
            this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(path + "\\" + bitmapFilename);
        }
        public void LoadSpriteStuff(string moduleFolderPath)
        {
            if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + this.SpriteFilename))
            {
                this.CharSprite = CharSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + this.SpriteFilename);
                this.CharSprite.passRefs(game);
                this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + this.CharSprite.SpriteSheetFilename);
                //this.CharSprite.TextureStream = CharSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + this.CharSprite.SpriteSheetFilename);
            }
            else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + this.SpriteFilename))
            {
                this.CharSprite = CharSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + this.SpriteFilename);
                this.CharSprite.passRefs(game);
                this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + this.CharSprite.SpriteSheetFilename);
                //this.CharSprite.TextureStream = CharSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + this.CharSprite.SpriteSheetFilename);
            }
            else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + this.SpriteFilename))
            {
                this.CharSprite = CharSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + this.SpriteFilename);
                this.CharSprite.passRefs(game);
                this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + this.CharSprite.SpriteSheetFilename);
                //this.CharSprite.TextureStream = CharSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + this.CharSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + this.SpriteFilename))
            {
                this.CharSprite = CharSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + this.SpriteFilename);
                this.CharSprite.passRefs(game);
                this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + this.CharSprite.SpriteSheetFilename);
                //this.CharSprite.TextureStream = CharSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + this.CharSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\tokens\\" + this.SpriteFilename))
            {
                this.CharSprite = CharSprite.loadSpriteFile(game.mainDirectory + "\\tokens\\" + this.SpriteFilename);
                this.CharSprite.passRefs(game);
                this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\tokens\\" + this.CharSprite.SpriteSheetFilename);
                //this.CharSprite.TextureStream = CharSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + this.CharSprite.SpriteSheetFilename);
            }
            else
            {
                MessageBox.Show("failed to load SpriteStuff in LoadSpriteStuff()");
                game.errorLog("failed to load SpriteStuff in LoadSpriteStuff()...failed to load the following sprite: " + this.SpriteFilename);
            }
        }
        public void LoadSpriteStuff(string path, string sprtFilename, string bitmapFilename)
        {
            this.CharSprite = CharSprite.loadSpriteFile(path + "\\" + sprtFilename);
            this.CharSprite.passRefs(game);
            this.CharSprite.Image = CharSprite.LoadSpriteSheetBitmap(path + "\\" + bitmapFilename);
        }
        /*public void UpdateStatsOld()
        {
            if (this.char_race == race.Human)
            {
                this.char_strength = this.char_baseStr + 0;
                this.char_dexterity = this.char_baseDex + 0;
                this.char_constitution = this.char_baseCon + 0;
                this.char_intelligence = this.char_baseInt + 0;
                this.char_wisdom = this.char_baseWis + 0;
                this.char_charisma = this.char_baseCha + 0;
            }
            if (this.char_race == race.Dwarf)
            {
                this.char_strength = this.char_baseStr + 2;
                this.char_dexterity = this.char_baseDex - 2;
                this.char_constitution = this.char_baseCon + 2;
                this.char_intelligence = this.char_baseInt + 0;
                this.char_wisdom = this.char_baseWis + 0;
                this.char_charisma = this.char_baseCha - 2;
            }
            if (this.char_race == race.Elf)
            {
                this.char_strength = this.char_baseStr - 2;
                this.char_dexterity = this.char_baseDex + 2;
                this.char_constitution = this.char_baseCon - 2;
                this.char_intelligence = this.char_baseInt + 2;
                this.char_wisdom = this.char_baseWis + 0;
                this.char_charisma = this.char_baseCha + 0;
            }
            if (this.char_class == charClass.Fighter)
            {
                this.char_sp = 0;
                this.char_spMax = 0;
                this.char_baseAttBonus = this.char_classLevel;
                this.char_hpMax = this.char_classLevel * (10 + ((this.char_constitution - 10) / 2));
                if (this.char_hp > this.char_hpMax)
                {
                    this.char_hp = this.char_hpMax;
                }
            }
            if (this.char_class == charClass.Wizard)
            {
                // need to have this based on level somehow                
                this.char_spMax = this.char_classLevel * (20 + ((this.char_intelligence - 10) / 2));
                this.char_baseAttBonus = (int)((double)this.char_classLevel * 0.5);
                this.char_hpMax = this.char_classLevel * (4 + ((this.char_constitution - 10) / 2));
                if (this.char_hp > this.char_hpMax)
                {
                    this.char_hp = this.char_hpMax;
                }
            }
            int modifier = (this.char_dexterity - 10) / 2;
            int armBonus = 0;
            int armDamRed = 0;
            if (this.Body != null)
            {
                armBonus = this.Body.ItemArmorBonus;
                armDamRed = this.Body.ItemDamageReduction;
            }
            char_AC = this.char_ACBase + modifier + armBonus;
        }*/
        public void UpdateStats(ScriptFunctions sf)
        {
            Stats.UpdateStats(this, sf);
            /*
            //used at level up, doPcTurn, open inventory, etc.
            this.char_strength = this.char_baseStr + this.char_Race.StrMod;
            this.char_dexterity = this.char_baseDex + this.char_Race.DexMod;
            this.char_constitution = this.char_baseCon + this.char_Race.ConMod;
            this.char_intelligence = this.char_baseInt + this.char_Race.IntMod;
            this.char_wisdom = this.char_baseWis + this.char_Race.WisMod;
            this.char_charisma = this.char_baseCha + this.char_Race.ChaMod;
                        
            int cMod = (this.char_constitution - 10) / 2;
            int iMod = (this.char_intelligence - 10) / 2;
            this.char_spMax = this.char_Class.StartingSP + iMod + ((this.char_classLevel - 1) * (this.char_Class.SpPerLevelUp + iMod));
            this.char_baseAttBonus = (int)((double)this.char_classLevel * this.char_Class.BabMultiplier) + CalcBABAdders();
            this.char_hpMax = this.char_Class.StartingHP + cMod + ((this.char_classLevel - 1) * (this.char_Class.HpPerLevelUp + cMod));
            if (this.char_hp > this.char_hpMax)
            {
                this.char_hp = this.char_hpMax;
            }
            
            int dMod = (this.char_dexterity - 10) / 2;
            int armBonus = 0;
            int acMods = 0;
            int armDamRed = 0;
            int damRedMods = 0;
            armBonus = CalcArmorBonuses();
            armDamRed = CalcDamReduction();
            damRedMods = CalcDamRedModifiers();
            acMods = CalcACModifiers();
            this.TotalDamageReduction = armDamRed + damRedMods;
            this.char_AC = this.char_ACBase + dMod + armBonus + acMods;
            */
        }
        public void UpdateSimpleStats()
        {
            Stats.UpdateSimpleStats(this);
            /*
            //used when updating properties after change to a property in the toolset
            this.char_fortitude = this.char_baseFortitude + (this.char_constitution - 10) / 2;
            this.char_will = this.char_baseWill + (this.char_wisdom - 10) / 2;
            this.char_reflex = this.char_baseReflex + (this.char_dexterity - 10) / 2;
            this.char_strength = this.char_baseStr + this.char_Race.StrMod;
            this.char_dexterity = this.char_baseDex + this.char_Race.DexMod;
            this.char_constitution = this.char_baseCon + this.char_Race.ConMod;
            this.char_intelligence = this.char_baseInt + this.char_Race.IntMod;
            this.char_wisdom = this.char_baseWis + this.char_Race.WisMod;
            this.char_charisma = this.char_baseCha + this.char_Race.ChaMod;
            this.char_baseAttBonus = (int)((double)this.char_classLevel * this.char_Class.BabMultiplier) + CalcBABAdders();
            
            int dMod = (this.char_dexterity - 10) / 2;
            int armBonus = 0;
            int armDamRed = 0;
            //if (this.Body != null)
            //{
                armBonus = CalcArmorBonuses();
                armDamRed = CalcDamReduction();
            //}
            this.TotalDamageReduction = armDamRed;
            this.char_AC = this.char_ACBase + dMod + armBonus;
            */
        }
        /*public int CalcBABAdders()
        {
            int adder = 0;
            foreach (Trait tr in KnownTraitsList.traitList)
            {
                adder += tr.BABModifier;
            }
            foreach (Effect ef in EffectsList.effectsList)
            {
                adder += ef.BABModifier;
            }
            return adder;
        }*/
        /*public int CalcACModifiers()
        {
            int adder = 0;
            foreach (Trait tr in KnownTraitsList.traitList)
            {
                adder += tr.ACModifier;
            }
            foreach (Effect ef in EffectsList.effectsList)
            {
                adder += ef.ACModifier;
            }
            return adder;
        }*/
        /*public int CalcDamRedModifiers()
        {
            int adder = 0;
            foreach (Trait tr in KnownTraitsList.traitList)
            {
                adder += tr.DamageReductionModifier;
            }
            foreach (Effect ef in EffectsList.effectsList)
            {
                adder += ef.DamageReductionModifier;
            }
            return adder;
        }*/
        /*public int CalcArmorBonuses()
        {
            int armBonuses = 0;
            armBonuses += this.Head.ItemArmorBonus;
            armBonuses += this.Neck.ItemArmorBonus;
            armBonuses += this.Body.ItemArmorBonus;
            armBonuses += this.MainHand.ItemArmorBonus;
            armBonuses += this.OffHand.ItemArmorBonus;
            armBonuses += this.Ring1.ItemArmorBonus;
            armBonuses += this.Ring2.ItemArmorBonus;
            armBonuses += this.Feet.ItemArmorBonus;
            return armBonuses;
        }*/
        /*public int CalcDamReduction()
        {
            int armBonuses = 0;
            armBonuses += this.Head.ItemDamageReduction;
            armBonuses += this.Neck.ItemDamageReduction;
            armBonuses += this.Body.ItemDamageReduction;
            armBonuses += this.MainHand.ItemDamageReduction;
            armBonuses += this.OffHand.ItemDamageReduction;
            armBonuses += this.Ring1.ItemDamageReduction;
            armBonuses += this.Ring2.ItemDamageReduction;
            armBonuses += this.Feet.ItemDamageReduction;
            return armBonuses;
        }*/
        public bool IsInEffectList(string effectTag)
        {
            foreach (Effect ef in this.EffectsList.effectsList)
            {
                if (ef.EffectTag == effectTag)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddEffect(Effect ef, bool MainMap)
        {
            this.EffectsList.effectsList.Add(ef);

            Sprite newSprite = new Sprite();
            newSprite.passRefs(game);
            if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else { return; }
            if (!MainMap)
            {
                game.LoadCombatEffectTextures(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName, newSprite, ef);
            }
        }
        public void AddEffectByTag(string effectTag)
        {
            Effect ef = game.module.ModuleEffectsList.getEffectByTag(effectTag).DeepCopy();
            ef.StartingTimeInUnits = game.module.WorldTime;
            //stackable effect and duration (just add effect to list)
            if (ef.IsStackableEffect)
            {
                //add to the list
                AddEffect(ef, false);
            }
            //stackable duration (add to list if not there, if there add to duration)
            else if ((!ef.IsStackableEffect) && (ef.IsStackableDuration))
            {
                if (!IsInEffectList(effectTag)) //Not in list so add to list
                {
                    AddEffect(ef, false);
                }
                else //is in list so add durations together
                {
                    Effect e = this.EffectsList.getEffectByTag(effectTag);
                    e.DurationInUnits += ef.DurationInUnits;
                }
            }
            //none stackable (add to list if not there)
            else if ((!ef.IsStackableEffect) && (!ef.IsStackableDuration))
            {
                if (!IsInEffectList(effectTag)) //Not in list so add to list
                {
                    AddEffect(ef, false);
                }
                else //is in list so reset duration
                {
                    Effect e = this.EffectsList.getEffectByTag(effectTag);
                    e.StartingTimeInUnits = game.module.WorldTime;
                    e.CurrentDurationInUnits = 0;
                }
            }

            /*
            this.EffectsList.effectsList.Add(ef);
            
            Sprite newSprite = new Sprite();
            newSprite.passRefs(game);
            if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else { return; }
            game.LoadCombatEffectTextures(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName, newSprite, ef);
            */
        }
        public void AddEffectByObject(Effect effect)
        {
            Effect ef = effect.DeepCopy();
            ef.StartingTimeInUnits = game.module.WorldTime;
            //stackable effect and duration (just add effect to list)
            if (ef.IsStackableEffect)
            {
                //add to the list
                AddEffect(ef, false);
            }
            //stackable duration (add to list if not there, if there add to duration)
            else if ((!ef.IsStackableEffect) && (ef.IsStackableDuration))
            {
                if (!IsInEffectList(ef.EffectTag)) //Not in list so add to list
                {
                    AddEffect(ef, false);
                }
                else //is in list so add durations together
                {
                    Effect e = this.EffectsList.getEffectByTag(ef.EffectTag);
                    e.DurationInUnits += ef.DurationInUnits;
                }
            }
            //none stackable (add to list if not there)
            else if ((!ef.IsStackableEffect) && (!ef.IsStackableDuration))
            {
                if (!IsInEffectList(ef.EffectTag)) //Not in list so add to list
                {
                    AddEffect(ef, false);
                }
                else //is in list so reset duration
                {
                    Effect e = this.EffectsList.getEffectByTag(ef.EffectTag);
                    e.StartingTimeInUnits = game.module.WorldTime;
                    e.CurrentDurationInUnits = 0;
                }
            }
        }
        public void AddEffectOnMainMapByTag(string effectTag)
        {
            Effect ef = game.module.ModuleEffectsList.getEffectByTag(effectTag).DeepCopy();
            ef.StartingTimeInUnits = game.module.WorldTime;
            //stackable effect and duration (just add effect to list)
            if ((ef.IsStackableEffect) && (ef.IsStackableDuration))
            {
                //add to the list
                AddEffect(ef, true);
            }
            //stackable duration (add to list if not there, if there add to duration)
            else if ((!ef.IsStackableEffect) && (ef.IsStackableDuration))
            {
                if (!IsInEffectList(effectTag)) //Not in list so add to list
                {
                    AddEffect(ef, true);
                }
                else //is in list so add durations together
                {
                    Effect e = this.EffectsList.getEffectByTag(effectTag);
                    e.DurationInUnits += ef.DurationInUnits;
                }
            }
            //none stackable (add to list if not there)
            else if ((!ef.IsStackableEffect) && (!ef.IsStackableDuration))
            {
                if (!IsInEffectList(effectTag)) //Not in list so add to list
                {
                    AddEffect(ef, true);
                }
                else //is in list so reset duration
                {
                    Effect e = this.EffectsList.getEffectByTag(effectTag);
                    e.StartingTimeInUnits = game.module.WorldTime;
                    e.CurrentDurationInUnits = 0;
                }
            }
            /*
            this.EffectsList.effectsList.Add(ef);

            Sprite newSprite = new Sprite();
            newSprite.passRefs(game);
            if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename))
            {
                newSprite = newSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\" + ef.SpriteFilename);
                newSprite.passRefs(game);
            }
            else { return; }
            */
        }
        public void AddEffectOnMainMapByObject(Effect effect)
        {
            Effect ef = effect.DeepCopy();
            ef.StartingTimeInUnits = game.module.WorldTime;
            //stackable effect and duration (just add effect to list)
            if (ef.IsStackableEffect)
            {
                //add to the list
                AddEffect(ef, true);
            }
            //stackable duration (add to list if not there, if there add to duration)
            else if ((!ef.IsStackableEffect) && (ef.IsStackableDuration))
            {
                if (!IsInEffectList(ef.EffectTag)) //Not in list so add to list
                {
                    AddEffect(ef, true);
                }
                else //is in list so add durations together
                {
                    Effect e = this.EffectsList.getEffectByTag(ef.EffectTag);
                    e.DurationInUnits += ef.DurationInUnits;
                }
            }
            //none stackable (add to list if not there)
            else if ((!ef.IsStackableEffect) && (!ef.IsStackableDuration))
            {
                if (!IsInEffectList(ef.EffectTag)) //Not in list so add to list
                {
                    AddEffect(ef, true);
                }
                else //is in list so reset duration
                {
                    Effect e = this.EffectsList.getEffectByTag(ef.EffectTag);
                    e.StartingTimeInUnits = game.module.WorldTime;
                    e.CurrentDurationInUnits = 0;
                }
            }
        }
    }
}
