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
    public class Props
    {
        [XmlIgnore]
        public Game game;

        [XmlArrayItem("PropsList")]
        public List<Prop> propsList = new List<Prop>();

        public Props()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void savePropsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Props));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Props file. Error: " + ex.Message);
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
        public Props loadPropsFile(string filename)
        {
            Props toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Props));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Props)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Props file. Error:\n{0}", ex.Message);
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
        public Prop getPropByName(string name)
        {
            foreach (Prop it in propsList)
            {
                if (it.PropName == name) return it;
            }
            return null;
        }
        public Prop getPropByTag(string tag)
        {
            foreach (Prop it in propsList)
            {
                if (it.PropTag == tag) return it;
            }
            return null;
        }
        public Prop getPropByResRef(string resref)
        {
            foreach (Prop it in propsList)
            {
                if (it.PropResRef == resref) return it;
            }
            return null;
        }
    }

    [Serializable]
    public class Prop
    {
        [XmlIgnore]
        public Game game;

        #region Fields
        private Sprite propSprite = new Sprite();
        private string propSpriteFilename = "blank.spt";
        private string propName = "newProp"; //can be unique
        private string propNameWithNotes = "newPropNameWithNotes";
        private string mouseOverText = "";
        private string propTag = "newPropTag"; //must be unique for all placed objects
        private string propResRef = "newPropResRef"; //must be different from all other blueprints
        private string p_parentNodeName = "New Category"; // value type
        private bool animated = false; //true = animated, false = static
        private bool show = true; //true = show, false = hide (can be used to temporarily hide something)
        private bool visible = false; //if the image is within the LoS and in the visibility range
        private bool looping = false; //true = looping, false = one time through then stop
        private bool hasCollision = true;
        private bool propContainerChk = false;
        private string propContainerTag = ""; //if prop has inventory, this is the tag of the container
        private bool propConversationChk = false;
        private string propConversationTag = ""; //if prop has a conversation, this is the tag of the conversation
        private bool trapped = false;
        private bool locked = false;
        private string keyTag = "";
        private Point location = new Point(0, 0);
        private int fps = 30;
        private int idleFPS = 15;
        private int attackingFPS = 15;
        private int walkingFPS = 15;
        private int idleDelay = 2000;
        private ScriptSelectEditorReturnObject onOpen = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onClose = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onCollision = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onEnter = new ScriptSelectEditorReturnObject();
        private List<LocalInt> propLocalInts = new List<LocalInt>();
        private List<LocalString> propLocalStrings = new List<LocalString>();
        #endregion

        #region Properties
        [XmlIgnore]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute(""), ReadOnly(true), Browsable(false)]
        public Sprite PropSprite
        {
            get { return propSprite; }
            set { propSprite = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("name of the prop (doesn't need to be unique)")]
        public string PropName
        {
            get { return propName; }
            set { propName = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the prop that shows up in the toolset list but not in the game engine")]
        public string PropNameWithNotes
        {
            get
            {
                if ((propNameWithNotes == "newPropNameWithNotes") && (propName != "newProp"))
                {
                    propNameWithNotes = propName;
                }
                return propNameWithNotes;
            }
            set { propNameWithNotes = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The text to display when player mouses over the Prop on the adventure maps")]
        public string MouseOverText
        {
            get { return mouseOverText; }
            set { mouseOverText = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("this must be unique")]
        public string PropTag
        {
            get { return propTag; }
            set { propTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Resource Reference name of the Prop used for updating all placed objects that share the same identifier (must be unique from other blueprints")]
        public string PropResRef
        {
            get { return propResRef; }
            set { propResRef = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Category that this Prop belongs to")]
        public string PropCategoryName
        {
            get
            {
                return p_parentNodeName;
            }
            set
            {
                p_parentNodeName = value;
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("Filename for the prop's sprite"), ReadOnly(true)]
        public string PropSpriteFilename
        {
            get { return propSpriteFilename; }
            set { propSpriteFilename = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("true = animated, false = static")]
        public bool Animated
        {
            get { return animated; }
            set { animated = value; }
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
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("true = continuous loop, false = plays through animation only once")]
        public bool Looping
        {
            get { return looping; }
            set { looping = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop has collision; if false, is walkable")]
        public bool HasCollision
        {
            get { return hasCollision; }
            set { hasCollision = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop has a container attached to it")]
        public bool PropContainerChk
        {
            get { return propContainerChk; }
            set { propContainerChk = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the container in the container list to use with this prop")]
        public string PropContainerTag
        {
            get { return propContainerTag; }
            set { propContainerTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop has a trap currently activated")]
        public bool PropTrapped
        {
            get { return trapped; }
            set { trapped = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop is locked")]
        public bool PropLocked
        {
            get { return locked; }
            set { locked = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("To open this lock you need a key with this Tag")]
        public string PropKeyTag
        {
            get { return keyTag; }
            set { keyTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, this prop has a conversation or narration attached to it")]
        public bool PropConversationChk
        {
            get { return propConversationChk; }
            set { propConversationChk = value; }
        }
        [XmlElement]
        [Browsable(true), TypeConverter(typeof(ConversationConverter))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the conversation or narration attached to it")]
        public string PropConversationTag
        {
            get { return propConversationTag; }
            set { propConversationTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("location on the map"), ReadOnly(true), Browsable(false)]
        public Point Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                PropSprite.Location = value;
                propSprite.oDestRect = new Rectangle(location.X, location.Y, propSprite.SpriteSize.Width, propSprite.SpriteSize.Height);
            }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("")]
        public int FPS
        {
            get { return fps; }
            set { fps = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("")]
        public int IdleFPS
        {
            get { return idleFPS; }
            set { idleFPS = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("")]
        public int AttackingFPS
        {
            get { return attackingFPS; }
            set { attackingFPS = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("")]
        public int WalkingFPS
        {
            get { return walkingFPS; }
            set { walkingFPS = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Sprite"), DescriptionAttribute("")]
        public int IdleDelay
        {
            get { return idleDelay; }
            set { idleDelay = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires before opening container")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnOpen
        {
            get { return onOpen; }
            set { onOpen = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires after opening container")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnClose
        {
            get { return onClose; }
            set { onClose = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires when collision with Prop is detected")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnCollision
        {
            get { return onCollision; }
            set { onCollision = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Scripts"), DescriptionAttribute("fires upon entering the same square as the Prop")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnEnter
        {
            get { return onEnter; }
            set { onEnter = value; }
        }
        [XmlArrayItem("PropLocalInts")]
        public List<LocalInt> PropLocalInts
        {
            get { return propLocalInts; }
            set { propLocalInts = value; }
        }
        [XmlArrayItem("PropLocalStrings")]
        public List<LocalString> PropLocalStrings
        {
            get { return propLocalStrings; }
            set { propLocalStrings = value; }
        }
        private List<LocalObject> propLocalObjects = new List<LocalObject>();
        [XmlElement]
        public List<LocalObject> PropLocalObjects
        {
            get { return propLocalObjects; }
            set { propLocalObjects = value; }
        }
        #endregion

        public Prop()
        {
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            OnOpen.prntForm = pf;
            OnClose.prntForm = pf;
            OnCollision.prntForm = pf;
            OnEnter.prntForm = pf;
        }
        public void LoadPropSprite(string path, string sprtFilename)
        {
            this.PropSprite = PropSprite.loadSpriteFile(path + "\\" + sprtFilename);
        }
        public void LoadPropSpriteBitmap(string path, string bitmapFilename)
        {
            this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(path + "\\" + bitmapFilename);
        }
        public void LoadSpriteStuff(string path, int i)
        {
            //can probably delete this method now...replaced with LoadPropSpriteStuff
            this.PropSprite = PropSprite.loadSpriteFile(path + "\\" + this.PropSpriteFilename);
            this.PropSprite.passRefs(game);
            this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(path + "\\" + this.PropSprite.SpriteSheetFilename);
        }
        public void LoadPropSpriteStuff(string moduleFolderPath)
        {           
            if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                //this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                //this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                //this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                //this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
            }
            else
            {
                MessageBox.Show("failed to load prop SpriteStuff");
            }
        }
        public void LoadPropSpriteStuffForTS(string moduleFolderPath)
        {
            if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(moduleFolderPath + "\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\props\\" + this.PropSprite.SpriteSheetFilename);
            }
            else if (File.Exists(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSpriteFilename))
            {
                this.PropSprite = PropSprite.loadSpriteFile(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSpriteFilename);
                this.PropSprite.passRefs(game);
                this.PropSprite.Image = PropSprite.LoadSpriteSheetBitmap(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
                //this.PropSprite.TextureStream = PropSprite.LoadTextureStream(game.mainDirectory + "\\data\\graphics\\sprites\\" + this.PropSprite.SpriteSheetFilename);
            }
            else
            {
                MessageBox.Show("failed to load prop SpriteStuff");
            }
        }
        public Prop ShallowCopy()
        {
            return (Prop)this.MemberwiseClone();
        }
        public Prop DeepCopy()
        {
            Prop other = (Prop)this.MemberwiseClone();
            other.PropSprite = this.PropSprite.DeepCopy();
            other.Location = new Point(this.Location.X, this.Location.Y);
            other.OnClose = this.OnClose.DeepCopy();
            other.OnCollision = this.OnCollision.DeepCopy();
            other.OnOpen = this.OnOpen.DeepCopy();
            other.PropLocalInts = new List<LocalInt>();
            foreach (LocalInt l in this.PropLocalInts)
            {
                LocalInt Lint = new LocalInt();
                Lint.Key = l.Key;
                Lint.Value = l.Value;
                other.PropLocalInts.Add(Lint);
            }
            other.PropLocalStrings = new List<LocalString>();
            foreach (LocalString l in this.PropLocalStrings)
            {
                LocalString Lstr = new LocalString();
                Lstr.Key = l.Key;
                Lstr.Value = l.Value;
                other.PropLocalStrings.Add(Lstr);
            }
            return other;
        }
    }

    [Serializable]
    public class PropRefs
    {
        private string propName = "";
        private string mouseOverText = "";
        private string propTag = "";
        private string propResRef = "";
        private string propContainerTag = "";
        private bool propContainerChk = false;
        private string propKeyTag = "";
        private bool propLockedChk = false;
        private bool propTrappedChk = false;

        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string PropName
        {
            get { return propName; }
            set { propName = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The text to display when player mouses over the Prop on the adventure maps")]
        public string MouseOverText
        {
            get { return mouseOverText; }
            set { mouseOverText = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the prop reference (Must be unique)")]
        public string PropTag
        {
            get { return propTag; }
            set { propTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string PropResRef
        {
            get { return propResRef; }
            set { propResRef = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the container in the container list to use with this prop")]
        public string PropContainerTag
        {
            get { return propContainerTag; }
            set { propContainerTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop has a container attached to it")]
        public bool PropContainerChk
        {
            get { return propContainerChk; }
            set { propContainerChk = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Tag of the key needed to open lock")]
        public string PropKeyTag
        {
            get { return propKeyTag; }
            set { propKeyTag = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop is locked")]
        public bool PropLockedChk
        {
            get { return propLockedChk; }
            set { propLockedChk = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("if true, the prop is trapped")]
        public bool PropTrappedChk
        {
            get { return propTrappedChk; }
            set { propTrappedChk = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public Point PropStartLocation;

        public PropRefs()
        {
        }

        public PropRefs DeepCopy()
        {
            PropRefs other = (PropRefs)this.MemberwiseClone();
            return other;
        }
    }    
}
