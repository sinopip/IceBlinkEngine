using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.IO;
using IceBlink;
using System.ComponentModel;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class Area
    {
        [XmlIgnore]
        public Game game;
        //[XmlIgnore]
        //public int VISIBLE_DISTANCE = 2;

        #region Fields
        private string a_fileName = "";
        private string a_mapFileName = "";
        private int a_tileSize = 50;
        private int timePerMove = 6;
        private string areaMusic = "none";
        private int areaMusicDelay = 0;
        private int areaMusicDelayRandomAdder = 0;
        private string areaSounds = "none";
        private int areaSoundsDelay = 0;
        private int areaSoundsDelayRandomAdder = 0;
        private bool restingAllowed = false;
        private List<Sprite> spriteAreaList = new List<Sprite>();
        private List<Tile> a_tilemap = new List<Tile>();
        private List<PropRefs> areaPropRefsList = new List<PropRefs>();
        private List<string> initialAreaPropTagsList = new List<string>();
        private Props areaPropList = new Props();
        private List<CreatureRefs> areaCreatureRefsList = new List<CreatureRefs>();
        private List<string> initialAreaCreatureTagsList = new List<string>();
        private Creatures areaCreatureList = new Creatures();
        private Triggers areaTriggerList = new Triggers();
        private ScriptSelectEditorReturnObject onHeartBeat = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onEnter = new ScriptSelectEditorReturnObject();
        private ScriptSelectEditorReturnObject onExit = new ScriptSelectEditorReturnObject();
        private int areaVisibleDistance = 2;
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string AreaFileName
        {
            get { return a_fileName; }
            set { a_fileName = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), ReadOnly(true)]
        public string MapFileName
        {
            get { return a_mapFileName; }
            set { a_mapFileName = value; }
        }
        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SoundConverter))]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Filename of music for the area (include extension)")]
        public string AreaMusic
        {
            get { return areaMusic; }
            set { areaMusic = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Delay between replaying music (in milliseconds)")]
        public int AreaMusicDelay
        {
            get { return areaMusicDelay; }
            set { areaMusicDelay = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Add a random amount of delay (between 0 and this value) to the AreaMusicDelay value (in milliseconds)")]
        public int AreaMusicDelayRandomAdder
        {
            get { return areaMusicDelayRandomAdder; }
            set { areaMusicDelayRandomAdder = value; }
        }
        [XmlElement]
        [Browsable(true), TypeConverter(typeof(SoundConverter))]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Filename of sounds for the area (include extension)")]
        public string AreaSounds
        {
            get { return areaSounds; }
            set { areaSounds = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Delay between replaying area sounds (in milliseconds)")]
        public int AreaSoundsDelay
        {
            get { return areaSoundsDelay; }
            set { areaSoundsDelay = value; }
        }
        [XmlElement]
        [CategoryAttribute("02 - Music/Sounds"), DescriptionAttribute("Add a random amount of delay (between 0 and this value) to the AreaSoundsDelay value (in milliseconds)")]
        public int AreaSoundsDelayRandomAdder
        {
            get { return areaSoundsDelayRandomAdder; }
            set { areaSoundsDelayRandomAdder = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("true = Can rest anywhere in this area, false = Can only rest in designated squares if they exist")]
        public bool RestingAllowed
        {
            get { return restingAllowed; }
            set { restingAllowed = value; }
        }
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("How far you can normally see in this area (radius in squares)")]
        public int VISIBLE_DISTANCE
        {
            get { return areaVisibleDistance; }
            set { areaVisibleDistance = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true)]
        public Size MapSizeInPixels = new Size(0, 0);
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true)]
        public Size MapSizeInSquares = new Size(0, 0);
        [XmlElement]
        [CategoryAttribute("Misc"), Browsable(false)]
        public int TileSize
        {
            get { return a_tileSize; }
            set { a_tileSize = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), DescriptionAttribute("How much time units elapses per square move on this map")]
        public int TimePerMove
        {
            get { return timePerMove; }
            set { timePerMove = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<Sprite> SpriteAreaList
        {
            get { return spriteAreaList; }
            set { spriteAreaList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<Tile> TileMapList
        {
            get { return a_tilemap; }
            set { a_tilemap = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<PropRefs> AreaPropRefsList
        {
            get { return areaPropRefsList; }
            set { areaPropRefsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<string> InitialAreaPropTagsList
        {
            get { return initialAreaPropTagsList; }
            set { initialAreaPropTagsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public Props AreaPropList
        {
            get { return areaPropList; }
            set { areaPropList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<CreatureRefs> AreaCreatureRefsList
        {
            get { return areaCreatureRefsList; }
            set { areaCreatureRefsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public List<string> InitialAreaCreatureTagsList
        {
            get { return initialAreaCreatureTagsList; }
            set { initialAreaCreatureTagsList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public Creatures AreaCreatureList
        {
            get { return areaCreatureList; }
            set { areaCreatureList = value; }
        }
        [XmlElement]
        [CategoryAttribute("Misc"), ReadOnly(true), Browsable(false)]
        public Triggers AreaTriggerList
        {
            get { return areaTriggerList; }
            set { areaTriggerList = value; }
        }
        [XmlElement]
        [CategoryAttribute("03 - Scripts"), DescriptionAttribute("fires at the beginning of each move on area maps (not combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnHeartBeat
        {
            get { return onHeartBeat; }
            set { onHeartBeat = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires upon entering the area (not combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnEnter
        {
            get { return onEnter; }
            set { onEnter = value; }
        }
        [XmlElement]
        [CategoryAttribute("99 - Not Implemented Yet"), DescriptionAttribute("fires upon exiting the area (not combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnExit
        {
            get { return onExit; }
            set { onExit = value; }
        }
        #endregion

        private List<LocalInt> areaLocalInts = new List<LocalInt>();
        [XmlArrayItem("AreaLocalInts")]
        public List<LocalInt> AreaLocalInts
        {
            get { return areaLocalInts; }
            set { areaLocalInts = value; }
        }
        private List<LocalString> areaLocalStrings = new List<LocalString>();
        [XmlArrayItem("AreaLocalStrings")]
        public List<LocalString> AreaLocalStrings
        {
            get { return areaLocalStrings; }
            set { areaLocalStrings = value; }
        }
        private List<LocalObject> areaLocalObjects = new List<LocalObject>();
        [XmlElement]
        public List<LocalObject> AreaLocalObjects
        {
            get { return areaLocalObjects; }
            set { areaLocalObjects = value; }
        }

        public Area()
        {
            a_tileSize = 64;
        }
        public void passRefs(Game g, int widthInSquares, int heightInSquares)
        {
            game = g;   
            int tileSize = game._squareSize;
            MapSizeInSquares = new Size(widthInSquares, heightInSquares);
            MapSizeInPixels = new Size(widthInSquares * tileSize, heightInSquares * tileSize);
        }
        public void passEventRefs(ParentForm pf)
        {
            OnHeartBeat.prntForm = pf;
            OnEnter.prntForm = pf;
            OnExit.prntForm = pf;
        }
        public void saveAreaFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Area));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save tilemap. Error: " + ex.Message);
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
        public Area loadAreaFile(string filename)
        {
            Area toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Area));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Area)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml file. Error:\n{0}", ex.Message);
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
        /*public int GetPassable(int directionMoving, int playerXPosition, int playerYPosition)
        {
            if (directionMoving == 0) { return a_tilemap[playerYPosition * 16 + playerXPosition].tilePassN; }
            else if (directionMoving == 1) { return a_tilemap[playerYPosition * 16 + playerXPosition].tilePassE; }
            else if (directionMoving == 2) { return a_tilemap[playerYPosition * 16 + playerXPosition].tilePassS; }
            else if (directionMoving == 3) { return a_tilemap[playerYPosition * 16 + playerXPosition].tilePassW; }
            else return 0;
        }*/
        public bool GetBlocked(int directionMoving, int playerXPosition, int playerYPosition)
        {
            if (directionMoving == 0) { return a_tilemap[(playerYPosition-1) * game.currentArea.MapSizeInSquares.Width + playerXPosition].collidable; }
            else if (directionMoving == 1) { return a_tilemap[playerYPosition * game.currentArea.MapSizeInSquares.Width + (playerXPosition + 1)].collidable; }
            else if (directionMoving == 2) { return a_tilemap[(playerYPosition + 1) * game.currentArea.MapSizeInSquares.Width + playerXPosition].collidable; }
            else if (directionMoving == 3) { return a_tilemap[playerYPosition * game.currentArea.MapSizeInSquares.Width + (playerXPosition - 1)].collidable; }
            else return true;
        }
        public bool GetBlocked(int playerXPosition, int playerYPosition)
        {
            foreach (Prop prp in AreaPropList.propsList)
            {
                if ((prp.Location.X == playerXPosition) && (prp.Location.Y == playerYPosition) && (prp.HasCollision))
                {
                    return true; //can't walk on Prop
                }
            }
            foreach (Creature crt in AreaCreatureList.creatures)
            {
                if ((crt.MapLocation.X == playerXPosition) && (crt.MapLocation.Y == playerYPosition) && (crt.HasCollision))
                {
                    return true; //can't walk on creature or NPC
                }
            }
            if (a_tilemap[(playerYPosition) * game.currentArea.MapSizeInSquares.Width + playerXPosition].collidable == true)
            {
                return true;
            }            
            return false;
        }
        public bool GetPropConversable(int playerFutureXPosition, int playerFutureYPosition)
        {
            foreach (Prop prp in AreaPropList.propsList)
            {
                if ((prp.Location.X == playerFutureXPosition) && (prp.Location.Y == playerFutureYPosition) && (prp.PropConversationChk))
                {
                    return true; //launch a conversation with the Prop
                }
            }
            return false;
        }
        public bool GetCreatureConversable(int playerFutureXPosition, int playerFutureYPosition)
        {
            foreach (Creature crt in AreaCreatureList.creatures)
            {
                if ((crt.MapLocation.X == playerFutureXPosition) && (crt.MapLocation.Y == playerFutureYPosition) && (crt.ConversationChk))
                {
                    return true; //launch a conversation with the creature
                }
            }
            return false;
        }
        public Tile getTile(int x, int y)
        {
            return getTile(y * game.currentArea.MapSizeInSquares.Width + x);
        }
        public Tile getCombatTile(int x, int y)
        {
            return getTile(y * game.currentCombatArea.MapSizeInSquares.Width + x);
        }
        public Tile getTile(int index)
        {
            return a_tilemap[index];
        }
        public Prop getPropByTag(string tag)
        {
            foreach (Prop prp in AreaPropList.propsList)
            {
                if (prp.PropTag == tag) return prp;
            }
            return null;
        }
        public Prop getPropByLocation(int x, int y)
        {
            foreach (Prop prp in AreaPropList.propsList)
            {
                if ((prp.Location.X == x) && (prp.Location.Y == y)) return prp;
            }
            return null;
        }
        public Creature getCreatureByTag(string tag)
        {
            foreach (Creature crt in AreaCreatureList.creatures)
            {
                if (crt.Tag == tag) return crt;
            }
            return null;
        }
        public Creature getCreatureByLocation(int x, int y)
        {
            foreach (Creature crt in AreaCreatureList.creatures)
            {
                if ((crt.MapLocation.X == x) && (crt.MapLocation.Y == y)) return crt;
            }
            return null;
        }
        public Trigger getTriggerByTag(string tag)
        {
            foreach (Trigger t in AreaTriggerList.triggersList)
            {
                if (t.TriggerTag == tag) return t;
            }
            return null;
        }
        public Trigger getTriggerByLocation(int x, int y)
        {
            foreach (Trigger t in game.currentArea.AreaTriggerList.triggersList)
            {
                foreach (Point p in t.TriggerSquaresList)
                {
                    if ((p.X == x) && (p.Y == y))
                    {
                        return t;
                    }
                }
            }
            return null;
        }
        public Trigger getCombatTriggerByTag(string tag)
        {
            foreach (Trigger t in game.currentCombatArea.AreaTriggerList.triggersList)
            {
                if (t.TriggerTag == tag) return t;
            }
            return null;
        }
        public Trigger getCombatTriggerByLocation(int x, int y)
        {
            foreach (Trigger t in game.currentCombatArea.AreaTriggerList.triggersList)
            {
                foreach (Point p in t.TriggerSquaresList)
                {
                    if ((p.X == x) && (p.Y == y))
                    {
                        return t;
                    }
                }
            }
            return null;
        }
    }

    [Serializable]
    public class Tile
    {
        private bool losBlocked = false;

        [XmlElement]
        public bool collidable;
        [XmlElement]
        public bool LoSBlocked
        {
            get { return losBlocked; }
            set { losBlocked = value; }
        }
        [XmlElement]
        public bool visible;

        public Tile()
        {
        }
    }
}
