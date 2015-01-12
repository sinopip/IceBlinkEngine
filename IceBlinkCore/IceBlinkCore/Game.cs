using System;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Text;
using IceBlink;
using System.Threading;
using System.ComponentModel;
using System.Collections;
using IceBlinkToolset;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SharpDX.Direct3D9;
using SharpDX;
using Color = System.Drawing.Color;
using Rectangle = System.Drawing.Rectangle;
using System.IO.Compression;

namespace IceBlinkCore
{
    [Serializable]
    public class Game
    {
        public string IBVersion = "IceBlink v1.02";
        #region Properties
        //public Texture testMapTex; //testing toStream and fromStream
        [XmlIgnore]
        public Device device;
        [XmlIgnore]
        public Device combatDevice;
        [XmlIgnore]
        public Panel renderPanel;
        [XmlIgnore]
        public Panel combatRenderPanel;
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite areaSprite; //used for area map
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite smallSprite; //used for area map prop type sprites
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite projectileSprite; //used for all projctile sprites
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite combatSprite; //used for all combat sprites
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite targetMarkerSprite; //used for all targeting stuff (spells, weapons, etc.)
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite pcMoveRangeSprite;
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite pcAttackRangeSprite;
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite creatureMoveRangeSprite;
        [XmlIgnore]
        public SharpDX.Direct3D9.Sprite creatureAttackRangeSprite;
        [XmlIgnore]
        public List<SharpDX.Direct3D9.Sprite> pcSprites = new List<SharpDX.Direct3D9.Sprite>();
        [XmlIgnore]
        public List<SharpDX.Direct3D9.Sprite> pcCombatSprites = new List<SharpDX.Direct3D9.Sprite>();
        [XmlIgnore]
        public List<Texture> pcTextures = new List<Texture>();
        [XmlIgnore]
        public List<Texture> pcCombatTextures = new List<Texture>();
        [XmlIgnore]
        public List<Texture> propTextureList = new List<Texture>();
        [XmlIgnore]
        public List<string> propTextureStringList = new List<string>();
        [XmlIgnore]
        FontDescription fontDescription;
        [XmlIgnore]
        FontDescription fontShadowDescription;
        [XmlIgnore]
        SharpDX.Direct3D9.Font font;
        [XmlIgnore]
        SharpDX.Direct3D9.Font fontShadow;        
        [XmlIgnore]
        public bool userResized = false;
        [XmlIgnore]
        public bool userCombatResized = false;
        [XmlIgnore]
        public Form1 frm;
        [XmlElement]
        public int _squareSize = 64;
        [XmlElement]
        public int _numberOfSquares = 16;
        [XmlIgnore]
        public string mainDirectory;
        [XmlIgnore]
        private Graphics g_device;
        [XmlIgnore]
        private Bitmap g_surface;
        [XmlIgnore]
        private Graphics fText_device;
        [XmlIgnore]
        private Bitmap fText_surface;  
      
        [XmlIgnore]
        public Texture blackTile;
        [XmlIgnore]
        public Texture walkPass;
        [XmlIgnore]
        public Texture walkBlock;
        [XmlIgnore]
        public Texture LoSBlock;
        [XmlIgnore]
        public Texture c_walkPass;
        [XmlIgnore]
        public Texture c_walkBlock;
        [XmlIgnore]
        public Texture c_LoSBlock;
        [XmlIgnore]
        public Texture combatTurnMarker;
        [XmlIgnore]
        public Texture targetMarker;
        [XmlIgnore]
        public Texture pcAttackRangeMarker;
        [XmlIgnore]
        public Texture pcMoveRangeMarker;
        [XmlIgnore]
        public Texture creatureAttackRangeMarker;
        [XmlIgnore]
        public Texture creatureMoveRangeMarker;
        [XmlIgnore]
        public Texture pcDead;
        [XmlIgnore]
        public Texture held;
        [XmlIgnore]
        public Texture hitSymbol;
        [XmlIgnore]
        public Texture facingUpLeft;
        [XmlIgnore]
        public Texture facingUp;
        [XmlIgnore]
        public Texture facingUpRight;
        [XmlIgnore]
        public Texture facingLeft;
        [XmlIgnore]
        public Texture facingDownLeft;
        [XmlIgnore]
        public Texture facingDown;
        [XmlIgnore]
        public Texture facingDownRight;
        [XmlIgnore]
        public Texture facingRight;

        [XmlIgnore]
        public Bitmap g_blackTile;
        [XmlIgnore]
        public Bitmap g_walkPass;
        [XmlIgnore]
        public Bitmap g_walkBlock;
        [XmlIgnore]
        public Bitmap g_LoSBlock;
        [XmlIgnore]
        public Bitmap g_pcDead;
        [XmlIgnore]
        public Bitmap g_hitSymbol;
        [XmlIgnore]
        public Bitmap g_facingUpLeft;
        [XmlIgnore]
        public Bitmap g_facingUp;
        [XmlIgnore]
        public Bitmap g_facingUpRight;
        [XmlIgnore]
        public Bitmap g_facingLeft;
        [XmlIgnore]
        public Bitmap g_facingDownLeft;
        [XmlIgnore]
        public Bitmap g_facingDown;
        [XmlIgnore]
        public Bitmap g_facingDownRight;
        [XmlIgnore]
        public Bitmap g_facingRight;
        [XmlIgnore]
        public Bitmap currentMapBitmap;
        // * sinopip, 11.01.15
        //[XmlIgnore]
        //public Texture currentMapTexture;
        [XmlIgnore]
        public Bitmap mapbmp;
        [XmlIgnore]
        public List<List<Bitmap>> boardImages;
        [XmlIgnore]
        public List<List<Texture>> areaBoards;
		[XmlIgnore]
        public int boardSize = 2048; // * pixels square
		[XmlIgnore]
        public List<List<SharpDX.Direct3D9.Sprite>> areaSprites;
        [XmlIgnore]
        public int centerX; // * (not used yet)
        [XmlIgnore]
        public int centerY; // * (not used yet)
        [XmlIgnore]
        public int panelNbSquaresX;
        [XmlIgnore]
        public int panelNbSquaresY;
        // *        
        [XmlIgnore]
        private PictureBox g_pb;
        [XmlElement]
        private bool g_gameOver = false;
        [XmlElement]
        public Area currentArea = new Area();
        [XmlElement]
        public Module module = new Module();
        [XmlIgnore]
        public Sprite hero = new Sprite();
        [XmlIgnore]
        public List<Sprite> spriteList = new List<Sprite>();
        [XmlElement]
        public Point playerPosition = new Point(0,0);
        [XmlElement]
        public Point lastPlayerLocation = new Point(0,0);
        [XmlElement]
        public int partyGold = 0;
        [XmlElement]
        public PCs playerList = new PCs();
        [XmlElement]
        public int[] PartyCombatOrder = new int[] { 0, 1, 2, 3, 4, 5 };
        [XmlIgnore]
        public List<Item> partyInventoryList = new List<Item>();
        [XmlElement]
        public List<string> partyInventoryTagList = new List<string>();
        [XmlElement("PartyJournalQuests")]
        public Journal partyJournalQuests = new Journal();
        [XmlElement("PartyJournalCompleted")]
        public Journal partyJournalCompleted = new Journal();
        [XmlElement]
        public string partyJournalNotes = "";
        [XmlIgnore]
        private Random g_random;
        [XmlIgnore]
        public int selectedPartyLeader = 0;
        //[XmlIgnore]
        //public MageSpells g_mageSpells;

        #region Combat Properties
        [XmlIgnore]
        private Graphics gc_device;
        [XmlIgnore]
        public Bitmap gc_surface;
        [XmlIgnore]
        public Bitmap currentCombatMapBitmap;
        [XmlIgnore]
        public Texture currentCombatMapTexture;
        [XmlIgnore]
        public Bitmap currentCombatMapSnapshotBitmap;
        [XmlIgnore]
        public Bitmap currentCombatBackPropsMapBitmap;
        [XmlIgnore]
        public Bitmap currentCombatBackPropsGridMapBitmap;
        [XmlIgnore]
        private PictureBox gc_pb;
        [XmlElement]
        public Area currentCombatArea = new Area();
        [XmlElement]
        public Encounter currentEncounter = new Encounter();
        [XmlIgnore]
        public List<Sprite> spriteCombatList = new List<Sprite>();
        [XmlIgnore]
        public List<Sprite> spriteCombatProjectileList = new List<Sprite>();
        [XmlIgnore]
        public Sprite currentCombatProjectileSprite = new Sprite();
        [XmlIgnore]
        public Sprite currentCombatEndEffectSprite = new Sprite();
        [XmlIgnore]
        public Sprite combatTurnSelectionIcon;
        [XmlIgnore]
        public PC currentPcTurn = null;
        [XmlIgnore]
        public int currentPcTurnMovesMade = 0;
        [XmlIgnore]
        public Stopwatch animateWacth = new Stopwatch();
        [XmlIgnore]
        public Bool pcAttacking = false;
        [XmlIgnore]
        public int frameIndex = 0;
        [XmlIgnore]
        public List<Texture> projectileTextureList = new List<Texture>();
        [XmlIgnore]
        public List<string> projectileTextureStringList = new List<string>();
        [XmlIgnore]
        public List<Texture> effectTextureList = new List<Texture>();
        [XmlIgnore]
        public List<string> effectTextureStringList = new List<string>();
        [XmlIgnore]
        public List<ShadowTextObject> shadowCombatTextPool = new List<ShadowTextObject>();
        [XmlIgnore]
        FontDescription fontCombatDescription;
        [XmlIgnore]
        FontDescription fontCombatShadowDescription;
        [XmlIgnore]
        SharpDX.Direct3D9.Font fontCombat;
        [XmlIgnore]
        SharpDX.Direct3D9.Font fontShadowCombat; 
        #endregion

        [XmlElement]
        public bool addPCScriptFired = false;
        [XmlElement]
        public bool uncheckConvo = false;
        [XmlElement]
        public bool removeCreature = false;
        [XmlElement]
        public bool turnLoSBlockingOff = false;
        [XmlElement]
        public bool deleteItemUsedScript = false;
        [XmlElement]
        public int indexOfPCtoLastUseItem = 0;
        [XmlElement]
        public bool com_showGrid = true;
        [XmlElement]
        public bool com_showFacing = false;
        [XmlElement]
        public bool com_showRange = false;
        [XmlElement]
        public bool frm_showGrid = true;
        [XmlIgnore]
        public Bitmap currentBackMapBitmap;
        [XmlIgnore]
        public Bitmap currentBackMapFoWBitmap;
        [XmlIgnore]
        public Bitmap currentBackMapFoWPropsBitmap;
        [XmlIgnore]
        public Point upperLeftPixel;
        [XmlIgnore]
        public bool doOnce = false;
        [XmlIgnore]
        public List<ShadowTextObject> shadowTextPool = new List<ShadowTextObject>();
        [XmlIgnore]
        public Point mouseCombatLocation = new Point(0, 0);
        [XmlIgnore]
        public Point mouseMainMapLocation = new Point(0, 0);

        [XmlIgnore]
        public string parm1 = "";
        [XmlIgnore]
        public string parm2 = "";
        [XmlIgnore]
        public string parm3 = "";
        [XmlIgnore]
        public string parm4 = "";
        [XmlIgnore]
        public List<AssemblyObjects> assemblyObjList = new List<AssemblyObjects>();
        [XmlIgnore]
        public Creature scriptOwnerCreature = new Creature();
        [XmlIgnore]
        public Item scriptOwnerItem = new Item();
        [XmlIgnore]
        public Prop scriptOwnerProp = new Prop();
        [XmlIgnore]
        public int scriptOwnerIndexOfPC = 0;
        [XmlIgnore]
        public bool returnCheck = false;
        [XmlIgnore]
        public string returnSpriteFilename = "";
        [XmlIgnore]
        public bool canRender = true;
        #endregion

        public Graphics Device
        {
            get { return g_device; }
        }
        public Device DeviceDX9
        {
            get { return device; }
        }
        public Graphics DeviceCombat
        {
            get { return gc_device; }
        }
        public Game()
        {
            g_gameOver = false;
            g_random = new Random();
            //g_mageSpells = new MageSpells();
        }
        ~Game()
        {
            try
            {
                g_device.Dispose();
                g_surface.Dispose();
                g_pb.Dispose();
            }
            catch (Exception ex)
            {
                //this.errorLog("failed to dispose bitmap stuff: " + ex.ToString());
            }
            try
            {
                gc_device.Dispose();
                gc_surface.Dispose();
                gc_pb.Dispose();
            }
            catch (Exception ex)
            {
                //this.errorLog("failed to dispose combat bitmap stuff: " + ex.ToString());
            }
        }
        public void passRefs(Form1 f)
        {
            frm = f;
            _squareSize = frm.squareSize;
            _numberOfSquares = frm.numberOfSquares;
        }
        public void errorLog(string text)
        {
            if (mainDirectory == null) { mainDirectory = Directory.GetCurrentDirectory(); }
            using (StreamWriter writer = new StreamWriter(mainDirectory + "//debug.txt", true))
            {
                writer.Write(DateTime.Now + ": ");
                writer.WriteLine(text);
            }
        }
        public void saveGameFileOld(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Game));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Game file. Error: " + ex.Message);
                this.errorLog(ex.ToString());
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
        public void saveGameFile(string filename)
        {
            FileStream writer = null;
            //StreamWriter writer = null;
            try
            {
                writer = new FileStream(filename, FileMode.Create, FileAccess.Write);
                using (GZipStream gzStream = new GZipStream(writer, CompressionMode.Compress))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Game));
                    serializer.Serialize(gzStream, this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Game file. Error: " + ex.Message);
                this.errorLog(ex.ToString());
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
        public Game loadGameFileOld(string filename)
        {
            Game toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Game));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Game)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Save Game xml file. Error: " + ex.Message);
                this.errorLog(ex.ToString());
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
        public Game loadGameFile(string filename)
        {
            Game toReturn = null;
            //XmlSerializer serializer = new XmlSerializer(typeof(Game));
            FileStream myFileStream = null;

            try
            {
                myFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                using (Stream input = new GZipStream(myFileStream, CompressionMode.Decompress))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Game));
                    toReturn = (Game)serializer.Deserialize(input);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Save Game xml file. Error: " + ex.Message);
                this.errorLog(ex.ToString());
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
        public Bitmap LoadBitmap(string filename)
        {
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(filename);
            }
            catch (Exception ex)
            {
                this.errorLog(ex.ToString());
            }
            return bmp;
        }
        /// <summary>
        /// Used for generating a random number between 1 and some number.
        /// </summary>
        /// <param name="max">The maximum value that can be used (ex. Random(5); will return a number between 1-5 so 1, 2, 3, 4 or 5 are possible results).</param>
        /// <returns>"returns"</returns>
        public int Random(int max)
        {
            return Random(1, max);
        }
        /// <summary>
        /// Used for generating a random number between some number and some other number (max must be >= min).
        /// </summary>
        /// <param name="min"> The minimum value that can be found (ex. Random(5, 9); will return a number between 5-9 so 5, 6, 7, 8 or 9 are possible results).</param>
        /// <param name="max"> The maximum value that can be found (ex. Random(5, 9); will return a number between 5-9 so 5, 6, 7, 8 or 9 are possible results).</param>
        public int Random(int min, int max)
        {
            //A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue.
            return g_random.Next(min, max + 1);
        }
        public bool GameOver
        {
            get { return g_gameOver; }
            set { g_gameOver = value; }
        }
        public void DrawTextShadowOutline(PaintEventArgs e, int x, int y, int z, string text, int aShad, int aText, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                StringFormat strformat = new StringFormat();
                strformat.Alignment = StringAlignment.Near;
                strformat.LineAlignment = StringAlignment.Far;

                GraphicsPath path = new GraphicsPath();
                float emSize = e.Graphics.DpiY * fontPointSize / 72;
                path.AddString(text, font, (int)FontStyle.Regular, emSize, new Point(x, y + z), strformat);
                for (int i = 1; i < 6; ++i)
                {
                    Pen pen = new Pen(Color.FromArgb(aShad, shadowColor), i);
                    pen.LineJoin = LineJoin.Round;
                    e.Graphics.DrawPath(pen, path);
                    pen.Dispose();
                }

                SolidBrush brush = new SolidBrush(Color.FromArgb(aText, textColor));
                e.Graphics.FillPath(brush, path);

                path.Dispose();
                brush.Dispose();
            }
            catch
            {
                frm.floatyTextTimer.Stop();
                MessageBox.Show("Font does not work, try another");
                frm.floatyTextTimer.Start();
                this.module.ModuleTheme.ModuleFontName = "Microsoft Sans Serif";
                this.module.ModuleTheme.ModuleFontPointSize = 9.75f;
            }
        }
        public void DrawTextShadowOutline(Graphics g, int x, int y, int z, string text, int aShad, int aText, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            try
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                StringFormat strformat = new StringFormat();
                strformat.Alignment = StringAlignment.Near;
                strformat.LineAlignment = StringAlignment.Far;

                GraphicsPath path = new GraphicsPath();
                float emSize = g.DpiY * fontPointSize / 72;
                path.AddString(text, font, (int)FontStyle.Regular, emSize, new Point(x, y + z), strformat);
                for (int i = 1; i < 6; ++i)
                {
                    Pen pen = new Pen(Color.FromArgb(aShad, shadowColor), i);
                    pen.LineJoin = LineJoin.Round;
                    g.DrawPath(pen, path);
                    pen.Dispose();
                }

                SolidBrush brush = new SolidBrush(Color.FromArgb(aText, textColor));
                g.FillPath(brush, path);

                path.Dispose();
                brush.Dispose();
            }
            catch
            {
                frm.floatyTextTimer.Stop();
                MessageBox.Show("Font does not work, try another");
                frm.floatyTextTimer.Start();
                this.module.ModuleTheme.ModuleFontName = "Microsoft Sans Serif";
                this.module.ModuleTheme.ModuleFontPointSize = 9.75f;
            }
        }
        /*public void DrawTextShadowOutlineMainMap(int x, int y, int z, string text, int aShad, int aText, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            try
            {
                fText_device.SmoothingMode = SmoothingMode.AntiAlias;
                fText_device.InterpolationMode = InterpolationMode.HighQualityBicubic;

                StringFormat strformat = new StringFormat();
                strformat.Alignment = StringAlignment.Near;
                strformat.LineAlignment = StringAlignment.Far;

                GraphicsPath path = new GraphicsPath();
                float emSize = fText_device.DpiY * fontPointSize / 72;
                path.AddString(text, font, (int)FontStyle.Regular, emSize, new Point(x, y + z), strformat);
                for (int i = 1; i < 6; ++i)
                {
                    Pen pen = new Pen(Color.FromArgb(aShad, shadowColor), i);
                    pen.LineJoin = LineJoin.Round;
                    fText_device.DrawPath(pen, path);
                    pen.Dispose();
                }

                SolidBrush brush = new SolidBrush(Color.FromArgb(aText, textColor));
                fText_device.FillPath(brush, path);

                path.Dispose();
                brush.Dispose();

                Rectangle frame = new Rectangle(0, 0, 100, 300);
                //target location
                Rectangle target = new Rectangle(x, y + z, 100, 300);
                //draw sprite
                g_device.DrawImage((Image)fText_surface, target, frame, GraphicsUnit.Pixel);
                g_pb.Image = g_surface;
            }
            catch
            {
                frm.floatyTextTimer.Stop();
                MessageBox.Show("Font does not work, try another");
                frm.floatyTextTimer.Start();
                this.module.ModuleTheme.ModuleFontName = "Microsoft Sans Serif";
                this.module.ModuleTheme.ModuleFontPointSize = 9.75f;
            }
        }*/
        /*public void DrawFloatyText(string text, int x, int y, int timeLength, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            shadowTextPool.Add(new ShadowTextObject(text, x, y, timeLength, font, fontPointSize, textColor, shadowColor));
        }*/
        /*private void RotateFlipCreature(Bitmap bitmapOriginal, Creature crt)
        {
            if (crt.CharSprite.TopDown) //topdown sprite
            {
                if (crt.Facing == CharBase.facing.Up)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if ((crt.Facing == CharBase.facing.Right) || (crt.Facing == CharBase.facing.DownRight) || (crt.Facing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (crt.Facing == CharBase.facing.Down)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    //do nothing, already facing left
                }
            }
            else //front facing sprite
            {
                if ((crt.Facing == CharBase.facing.Right) || (crt.Facing == CharBase.facing.DownRight) || (crt.Facing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }
        private void RotateFlipPC(Bitmap bitmapOriginal, PC pc)
        {
            if (pc.CharSprite.TopDown) //topdown sprite
            {
                if (pc.Facing == CharBase.facing.Up)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if ((pc.Facing == CharBase.facing.Right) || (pc.Facing == CharBase.facing.DownRight) || (pc.Facing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (pc.Facing == CharBase.facing.Down)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    //do nothing, already facing left
                }
            }
            else //front facing sprite
            {
                if ((pc.Facing == CharBase.facing.Right) || (pc.Facing == CharBase.facing.DownRight) || (pc.Facing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }
        private void RotateFlipCmbCreature(Bitmap bitmapOriginal, Creature crt)
        {
            if (crt.CharSprite.TopDown) //topdown sprite
            {
                if (crt.CombatFacing == CharBase.facing.Up)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (crt.CombatFacing == CharBase.facing.Down)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    //do nothing, already facing left
                }
            }
            else //front facing sprite
            {
                if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }
        private void RotateFlipCmbPC(Bitmap bitmapOriginal, PC pc)
        {
            if (pc.CharSprite.TopDown) //topdown sprite
            {
                if (pc.CombatFacing == CharBase.facing.Up)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if ((pc.CombatFacing == CharBase.facing.Right) || (pc.CombatFacing == CharBase.facing.DownRight) || (pc.CombatFacing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                else if (pc.CombatFacing == CharBase.facing.Down)
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else
                {
                    //do nothing, already facing left
                }
            }
            else //front facing sprite
            {
                if ((pc.CombatFacing == CharBase.facing.Right) || (pc.CombatFacing == CharBase.facing.DownRight) || (pc.CombatFacing == CharBase.facing.UpRight))
                {
                    bitmapOriginal.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
            }
        }*/
        
        #region Script Stuff
        public void executeScript(string scriptPathFileName)
        {
            bool foundOne = false;
            Assembly compiledScript = null;
            string filename = Path.GetFileNameWithoutExtension(scriptPathFileName);
            foreach (AssemblyObjects ao in assemblyObjList)
            {
                if (ao.AssemblyFileName == filename)
                {
                    foundOne = true;
                    compiledScript = ao.AssemblyCompiled;
                    break;
                }
            }
            if (!foundOne)
            {
                string textReturn = readTextFile(scriptPathFileName);
                compiledScript = CompileCode(textReturn);
                AssemblyObjects newAO = new AssemblyObjects();
                newAO.AssemblyFileName = filename;
                newAO.AssemblyCompiled = compiledScript;
                assemblyObjList.Add(newAO);
            }

            if (compiledScript != null)
            {
                RunScript(compiledScript);
            }
        }
        public Assembly CompileCode(string code)
        {
            // Create a code provider             
            // This class implements the 'CodeDomProvider' class as its base. All of the current .Net languages (at least Microsoft ones)             
            // come with thier own implemtation, thus you can allow the user to use the language of thier choice (though i recommend that             
            // you don't allow the use of c++, which is too volatile for scripting use - memory leaks anyone?)             
            Microsoft.CSharp.CSharpCodeProvider csProvider = new Microsoft.CSharp.CSharpCodeProvider();
            // Setup our options             
            CompilerParameters options = new CompilerParameters();
            options.GenerateExecutable = false; // we want a Dll (or "Class Library" as its called in .Net)             
            options.GenerateInMemory = true; // Saves us from deleting the Dll when we are done with it, though you could set this to false and save start-up time by next time by not having to re-compile             
            // And set any others you want, there a quite a few, take some time to look through them all and decide which fit your application best!              
            // Add any references you want the users to be able to access, be warned that giving them access to some classes can allow             
            // harmful code to be written and executed. I recommend that you write your own Class library that is the only reference it allows             
            // thus they can only do the things you want them to.             
            // (though things like "System.Xml.dll" can be useful, just need to provide a way users can read a file to pass in to it)             
            // Just to avoid bloatin this example to much, we will just add THIS program to its references, that way we don't need another             
            // project to store the interfaces that both this class and the other uses. Just remember, this will expose ALL public classes to             
            // the "script"             
            options.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            options.ReferencedAssemblies.Add("system.dll");
            options.ReferencedAssemblies.Add("system.data.dll");
            options.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            options.ReferencedAssemblies.Add("System.Drawing.dll");
            //options.ReferencedAssemblies.Add("System.Drawing.Bitmap.dll");
            options.ReferencedAssemblies.Add("IceBlinkCore.dll");
            options.ReferencedAssemblies.Add("IceBlinkScriptFunctions.dll");
            options.ReferencedAssemblies.Add("IceBlink.exe");
            options.ReferencedAssemblies.Add("IceBlinkToolset.exe");
            // Compile our code             
            CompilerResults result;
            result = csProvider.CompileAssemblyFromSource(options, code);
            if (result.Errors.HasErrors)
            {
                // TODO: report back to the user that the script has errored
                StringBuilder sbErr;
                sbErr = new StringBuilder("Compiling file: ");
                sbErr.AppendFormat("\"{0}\"", "script.cs");
                sbErr.Append("\n\n");
                foreach (CompilerError err in result.Errors)
                {
                    sbErr.AppendFormat("{0} at line {1} column {2} ", err.ErrorText, err.Line, err.Column);
                    sbErr.Append("\n");
                }
                MessageBox.Show(sbErr.ToString(), "C#Script – Error");

                return null;
            }
            if (result.Errors.HasWarnings)
            {
                // TODO: tell the user about the warnings, might want to prompt them if they want to continue                 
                // runnning the "script"             
            }
            return result.CompiledAssembly;
        }
        public void RunScript(Assembly script)
        {
            try
            {
                object o = script.CreateInstance("IceBlink.IceBlinkScript");
                object[] parms = new object[] { frm.sf, parm1, parm2, parm3, parm4 };
                o.GetType().GetMethod("Script").Invoke(o, parms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.errorLog(ex.ToString());
            }
        }
        public string readTextFile(string filePath)
        {
            //filePath = @"C:\Documents and Settings\JSmith\My Documents\Visual Studio 2010\Projects\RunScript\RunScript\script2.cs";
            StreamReader streamReader = new StreamReader(filePath);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            return text;
        }
        #endregion

        #region Main Map Graphics
        public void initializeRenderPanel(Panel rp)
        {
            renderPanel = rp;
            createDevice();
            // * sinopip, 11.01.15
            panelNbSquaresX = renderPanel.Width / _squareSize;
            panelNbSquaresY = renderPanel.Height / _squareSize;
            // *
            /*
            try
            {
                device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
            catch
            {
                MessageBox.Show("Not able to use hardware vertex processing...using software instead");
                device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.SoftwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
            try
            {
                g_blackTile = new Bitmap("data\\graphics\\blackTile.png");
                g_walkPass = new Bitmap("data\\graphics\\walkPass.png");
                g_walkBlock = new Bitmap("data\\graphics\\walkBlock.png");
                g_LoSBlock = new Bitmap("data\\graphics\\LoSBlock.png");
                
                g_pcDead = new Bitmap("data\\graphics\\pcDead.png");
                g_hitSymbol = new Bitmap("data\\graphics\\hitSymbol.png");
                g_facingUp = new Bitmap("data\\graphics\\facingUp.png");
                g_facingUpRight = new Bitmap("data\\graphics\\facingUpRight.png");
                g_facingRight = new Bitmap("data\\graphics\\facingRight.png");
                g_facingDownRight = new Bitmap("data\\graphics\\facingDownRight.png");
                g_facingDown = new Bitmap("data\\graphics\\facingDown.png");
                g_facingDownLeft = new Bitmap("data\\graphics\\facingDownLeft.png");
                g_facingLeft = new Bitmap("data\\graphics\\facingLeft.png");
                g_facingUpLeft = new Bitmap("data\\graphics\\facingUpLeft.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load basic tile images: " + ex.ToString());
                this.errorLog(ex.ToString());
            }
            */
        }
        public void LoadSpriteTextures(string moduleFolderPath)
        {
            try
            {
                if (File.Exists(moduleFolderPath + "\\graphics\\blackTile.png"))
                {
                    blackTile = Texture.FromFile(device, moduleFolderPath + "\\graphics\\blackTile.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }
                else
                {
                    blackTile = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\blackTile.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }

                if (File.Exists(moduleFolderPath + "\\graphics\\walkPass.png"))
                {
                    walkPass = Texture.FromFile(device, moduleFolderPath + "\\graphics\\walkPass.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }
                else
                {
                    walkPass = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\walkPass.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }

                if (File.Exists(moduleFolderPath + "\\graphics\\walkBlock.png"))
                {
                    walkBlock = Texture.FromFile(device, moduleFolderPath + "\\graphics\\walkBlock.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }
                else
                {
                    walkBlock = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\walkBlock.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }

                if (File.Exists(moduleFolderPath + "\\graphics\\LoSBlock.png"))
                {
                    LoSBlock = Texture.FromFile(device, moduleFolderPath + "\\graphics\\LoSBlock.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }
                else
                {
                    LoSBlock = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\LoSBlock.png", 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load default tile textures: " + ex.ToString());
                this.errorLog("failed to load default tile textures: " + ex.ToString());
            }
            try
            {
            	// * sinopip, 11.01.15
            	//currentMapTexture = Texture.FromFile(device, mainDirectory + "\\modules\\" + module.ModuleFolderName + "\\areas\\" + currentArea.MapFileName, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
            	mapbmp = (Bitmap)Image.FromFile(mainDirectory + "\\modules\\" + module.ModuleFolderName + "\\areas\\" + currentArea.MapFileName);
            	boardImages = new List<List<Bitmap>>();
            	areaBoards = new List<List<Texture>>();
                // * tiles grouped as boards by "<nb squares on display> * <square size>", so it's manageable by DirectX
                int boardsCountX = Math.Max(1, (int)Math.Ceiling((1.0 * mapbmp.Width) / boardSize));
                int boardsCountY = Math.Max(1, (int)Math.Ceiling((1.0 * mapbmp.Height) / boardSize));
                for (int x=0; x < boardsCountX; x++)
                {
                	areaBoards.Add(new List<Texture>());
                	boardImages.Add(new List<Bitmap>());
                	areaSprites.Add(new List<SharpDX.Direct3D9.Sprite>());
                	for (int y = 0; y < boardsCountY; y++)
                	{
	     		       	areaSprites[x].Add(new SharpDX.Direct3D9.Sprite(device));
	     		       	string bmpfile;
	     		       	if (boardsCountX > 1 || boardsCountY > 1)
	     		       	{
	     		       		string path = mainDirectory + "\\modules\\" + module.ModuleFolderName + "\\areas\\" + currentArea.MapFileName.Substring(0,currentArea.MapFileName.Length-4);
	     		       		bmpfile = path + "\\" + currentArea.MapFileName.Substring(0,currentArea.MapFileName.Length-4)+"-"+x.ToString()+"-"+y.ToString()+currentArea.MapFileName.Substring(currentArea.MapFileName.Length-4);
	     		       	}
	     		       	else
							bmpfile = mainDirectory + "\\modules\\" + module.ModuleFolderName + "\\areas\\" + currentArea.MapFileName;
	     		       	boardImages[x].Add((Bitmap)Image.FromFile(bmpfile));
	     		       	areaBoards[x].Add(Texture.FromFile(device, bmpfile));
	                }
                } 
                // *
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load areaMap texture: " + ex.ToString());
                this.errorLog("failed to load areaMap texture: " + ex.ToString());
            }
            try
            {
                for (int index = 0; index < playerList.PCList.Count; index++)
                {
                    if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                    {
                        Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                        //var testTex = Texture.ToStream(pcTex, ImageFileFormat.Png); //tested and works
                        //testMapTex = Texture.FromStream(device, testTex);           //tested and works 
                        pcTextures.Add(pcTex);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                    {
                        Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                        pcTextures.Add(pcTex);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                    {
                        Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                        pcTextures.Add(pcTex);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                    {
                        Texture pcTex = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                        pcTextures.Add(pcTex);
                    }
                    else if (File.Exists(mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                    {
                        Texture pcTex = Texture.FromFile(device, mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                        pcTextures.Add(pcTex);
                    }
                    else
                    {
                        MessageBox.Show("failed to load PC SpriteStuff in LoadSpriteTextures()");
                    }
                }
                foreach (Creature crt in currentArea.AreaCreatureList.creatures)
                {
                    //crt.CharSprite.Texture = Texture.FromStream(device, crt.CharSprite.TextureStream);           //tested and works 
                    if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename))
                    {
                        crt.CharSprite.Texture = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename))
                    {
                        crt.CharSprite.Texture = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                    {
                        crt.CharSprite.Texture = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                    {
                        crt.CharSprite.Texture = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                    }
                    else if (File.Exists(mainDirectory + "\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                    {
                        crt.CharSprite.Texture = Texture.FromFile(device, mainDirectory + "\\tokens\\" + crt.CharSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                    }
                    else
                    {
                        MessageBox.Show("failed to load Creature SpriteStuff in LoadSpriteTextures()");
                    }
                    
                }
                foreach (Prop prp in currentArea.AreaPropList.propsList)
                {
                    if (propTextureStringList.Contains(prp.PropSprite.SpriteSheetFilename))
                    {
                        //prp.PropSprite.Texture = Texture.FromStream(device, prp.PropSprite.TextureStream);
                    }
                    else
                    {
                        //prp.PropSprite.Texture = Texture.FromStream(device, prp.PropSprite.TextureStream);
                        if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\props\\" + prp.PropSpriteFilename))
                        {
                            prp.PropSprite.Texture = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                            propTextureList.Add(prp.PropSprite.Texture);
                            propTextureStringList.Add(prp.PropSprite.SpriteSheetFilename);
                            //prp.PropSprite.TextureStream = Texture.ToStream(prp.PropSprite.Texture, ImageFileFormat.Png); //tested and works
                        }
                        else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + prp.PropSpriteFilename))
                        {
                            prp.PropSprite.Texture = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\" + prp.PropSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                            propTextureList.Add(prp.PropSprite.Texture);
                            propTextureStringList.Add(prp.PropSprite.SpriteSheetFilename);
                            //prp.PropSprite.TextureStream = Texture.ToStream(prp.PropSprite.Texture, ImageFileFormat.Png); //tested and works
                        }
                        else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\props\\" + prp.PropSpriteFilename))
                        {
                            prp.PropSprite.Texture = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                            propTextureList.Add(prp.PropSprite.Texture);
                            propTextureStringList.Add(prp.PropSprite.SpriteSheetFilename);
                            //prp.PropSprite.TextureStream = Texture.ToStream(prp.PropSprite.Texture, ImageFileFormat.Png); //tested and works
                        }
                        else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\" + prp.PropSpriteFilename))
                        {
                            prp.PropSprite.Texture = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\sprites\\" + prp.PropSprite.SpriteSheetFilename, 0, 0, 1, Usage.None, Format.Unknown, Pool.Default, Filter.None, Filter.None, 0);
                            propTextureList.Add(prp.PropSprite.Texture);
                            propTextureStringList.Add(prp.PropSprite.SpriteSheetFilename);
                            //prp.PropSprite.TextureStream = Texture.ToStream(prp.PropSprite.Texture, ImageFileFormat.Png); //tested and works
                        }
                        else
                        {
                            MessageBox.Show("failed to load Prop SpriteStuff in LoadSpriteTextures()");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load sprite textures: " + ex.ToString());
                this.errorLog("failed to load sprite textures: " + ex.ToString());
            }
        }
        private void LoadFontStuff()
        {
            // Initialize the Font
            fontDescription = new FontDescription()
            {
                Height = (int)(this.module.ModuleFontPointSize * this.module.ModuleFloatyFontScale),
                Italic = false,
                CharacterSet = FontCharacterSet.Ansi,
                FaceName = this.module.ModuleFontName,
                MipLevels = 1,
                OutputPrecision = FontPrecision.TrueType,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.ClearType,
                Weight = FontWeight.Bold
            };
            fontShadowDescription = new FontDescription()
            {
                Height = (int)(this.module.ModuleFontPointSize * this.module.ModuleFloatyFontScale),
                Italic = false,
                CharacterSet = FontCharacterSet.Ansi,
                FaceName = this.module.ModuleFontName,
                MipLevels = 1,
                OutputPrecision = FontPrecision.TrueType,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.ClearType,
                Weight = FontWeight.Bold
            };
            font = new SharpDX.Direct3D9.Font(device, fontDescription);
            fontShadow = new SharpDX.Direct3D9.Font(device, fontShadowDescription);
        }
        public void ChangePartySprite()
        {
            string moduleFolderPath = mainDirectory + "\\modules\\" + module.ModuleFolderName;
            pcTextures.Clear();
            for (int index = 0; index < playerList.PCList.Count; index++)
            {
                if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcTextures.Add(pcTex);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcTextures.Add(pcTex);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(device, moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcTextures.Add(pcTex);
                }
                else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(device, mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcTextures.Add(pcTex);
                }
                else if (File.Exists(mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(device, mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcTextures.Add(pcTex);
                }
                else
                {
                    MessageBox.Show("failed to load PC SpriteStuff in ChangePartySprite()");
                }
            }
        }
        public void newAreaInitializeGraphics()
        {
            try
            {
                //resetDevice();
                //device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
            catch
            {
                //MessageBox.Show("Not able to use hardware vertex processing...using software instead");
                //device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.SoftwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
            // * sinopip, 11.01.15
            //centerX = playerPosition.X;
            //centerY = playerPosition.Y;
            areaSprite = new SharpDX.Direct3D9.Sprite(device);
            areaSprites = new List<List<SharpDX.Direct3D9.Sprite>>();
            // *
            for (int index = 0; index < 6; index++) //Set at 6 snce the party size never goes above 6
            {
                SharpDX.Direct3D9.Sprite newSprite = new SharpDX.Direct3D9.Sprite(device);
                pcSprites.Add(newSprite);
            }
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                crt.CharSprite.DxSprite = new SharpDX.Direct3D9.Sprite(device);
            }
            smallSprite = new SharpDX.Direct3D9.Sprite(device);
            LoadSpriteTextures(mainDirectory + "\\modules\\" + module.ModuleFolderName);
            LoadFontStuff();
        }       
        public Point UpperLeftPixels()
        {
            Point upperLeftPixel = new Point();
            //determine location of player on map (x,y square)
            int pcx = playerPosition.X;
            int pcy = playerPosition.Y;
            //determine size of picture box (x,y squares)
            int rpx = renderPanel.Width / _squareSize;
            int rpy = renderPanel.Height / _squareSize;
            //determine size of map
            int mapTotalX = currentArea.MapSizeInPixels.Width;
            int mapTotalY = currentArea.MapSizeInPixels.Height;
            //determine what should be the upper left square
            int leftSquareX = pcx - (rpx / 2);
            int leftSquareY = pcy - (rpy / 2);
            //determine the upper most left pixel of upper left square, if less than (0,0), then set to (0,0)
            upperLeftPixel.X = leftSquareX * _squareSize;
            if (upperLeftPixel.X < 0) { upperLeftPixel.X = 0; }
            upperLeftPixel.Y = leftSquareY * _squareSize;
            if (upperLeftPixel.Y < 0) { upperLeftPixel.Y = 0; }
            //shift map so that centers around the PC icon
            if (upperLeftPixel.X > (mapTotalX - renderPanel.Width)) { upperLeftPixel.X = (mapTotalX - renderPanel.Width); }
            if (upperLeftPixel.Y > (mapTotalY - renderPanel.Height)) { upperLeftPixel.Y = (mapTotalY - renderPanel.Height); }
            //if pictureBox is larger than map size then place map starting at (0,0)
            if (renderPanel.Width > mapTotalX) { upperLeftPixel.X = 0; }
            if (renderPanel.Height > mapTotalY) { upperLeftPixel.Y = 0; }
            return upperLeftPixel;
        }        
        public void areaUpdate()
        {
            setExplored();
            setSpriteToAnimate();
            //if (frm_showGrid) { drawGrid(); }
            /*
            // grab image from stored bitmap
            Rectangle frame = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            Rectangle target = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            g_device.DrawImage((Image)currentBackMapFoWBitmap, target, frame, GraphicsUnit.Pixel);            
            long time1 = DateTime.Now.Ticks;
            //check for new visible squares and paint with currentBackMapBitmap
            DrawNewlyExploredSquares();
            setSpriteToAnimate();
            long time2 = DateTime.Now.Ticks;
            //draw all static props and save out bitmap for animated sprites to use as base
            drawStaticProps();
            resetCurrentBackMapFoWPropsBitmap();
            long time3 = DateTime.Now.Ticks;
            */
            /*
            frm.logMainText("DrawNewlyExploredSquares: " + ((time2 - time1)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("drawStaticProps: " + ((time3 - time2) / 10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            */
        }
        public void createDevice()
        {
            try
            {
                device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
            catch
            {
                //MessageBox.Show("Not able to use hardware vertex processing...using software instead");
                device = new Device(new Direct3D(), 0, DeviceType.Hardware, renderPanel.Handle, CreateFlags.SoftwareVertexProcessing, new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
            }
        }
        public void ResetMainMapAll(Panel rp)
        {
            disposeSpritesTextures();
            device.Dispose();
            initializeRenderPanel(rp);
            newAreaInitializeGraphics();
        }
        public void resetDevice()
        {
            //device.Dispose();
            //createDevice();
            //device.Reset(new PresentParameters(renderPanel.ClientSize.Width, renderPanel.ClientSize.Height));
        }
        public void disposeSpritesTextures()
        {
            if (device != null)
            {
                foreach (Texture pcTex in pcTextures)
                {
                    pcTex.Dispose();
                }
                pcTextures.Clear();
                foreach (Texture tp in propTextureList)
                {
                    tp.Dispose();
                }
                propTextureList.Clear();
                propTextureStringList.Clear();
                foreach (Creature crt in currentArea.AreaCreatureList.creatures)
                {
                    crt.CharSprite.Texture.Dispose();
                }
                // * sinopip, 11.01.15
                //currentMapTexture.Dispose();
                for (int x = 0; x < areaBoards.Count; x++)
                	for (int y=0; y < areaBoards[x].Count; y++)
                		areaBoards[x][y].Dispose();
                areaBoards.Clear();
                // *
                blackTile.Dispose();
                walkPass.Dispose();
                walkBlock.Dispose();
                LoSBlock.Dispose();
                foreach (Creature crt in currentArea.AreaCreatureList.creatures)
                {
                    crt.CharSprite.DxSprite.Dispose();
                }
                foreach (SharpDX.Direct3D9.Sprite spr in pcSprites)
                {
                    spr.Dispose();
                }
                pcSprites.Clear();
                smallSprite.Dispose();
                areaSprite.Dispose();
                // * sinopip, 11.01.15
	            for (int x = 0; x < areaSprites.Count; x++)
	            	for (int y = 0; y < areaSprites[x].Count; y++)
	            		areaSprites[x][y].Dispose();
	            areaSprites.Clear();
	            // *
                //resetDevice();
                //device.Dispose();
                //device = null;
            }
        }
        public void areaRenderAll()
        {
            if (canRender)
            {
                try
                {
                    canRender = false;
                    if (userResized) // If Form resized
                    {
                        disposeSpritesTextures();
                        resetDevice();
                        newAreaInitializeGraphics();
                        userResized = false;
                    }

                    device.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
                    device.BeginScene();
                    upperLeftPixel = UpperLeftPixels();

                    renderMainMap();
                    renderCreatures();
                    renderProps();
                    renderGrid();
                    renderFogOfWar();
                    renderPC();
                    renderText();
                    renderInfo();

                    device.EndScene();
                    device.Present();
                    canRender = true;
                }
                catch (SharpDXException sdx)
                {
                    if (sdx.Descriptor == SharpDX.Direct3D9.ResultCode.DeviceLost)
                    {
                        //Utilities.Sleep(TimeSpan.FromMilliseconds(100));
                        //IBMessageBox.Show(this, "Lost DX9 Rendering Device...resetting DX9 Device now");
                        try
                        {
                            frm.timer.Stop();
                            frm.AnimationTimer.Stop();
                            frm.realTimer.Stop();
                            frm.logText("Lost DX9 Rendering Device...now resetting device...", Color.Lime);
                            frm.logText(Environment.NewLine, Color.Lime);
                            ResetMainMapAll(renderPanel);
                        }
                        finally
                        {
                            frm.timer.Start();
                            frm.AnimationTimer.Start();
                            frm.realTimer.Start();
                            canRender = true;
                        }
                    }
                    errorLog(sdx.ToString());
                    canRender = true;
                }
                catch (NullReferenceException nre)
                {
                    try
                    {
                        frm.timer.Stop();
                        frm.AnimationTimer.Stop();
                        frm.realTimer.Stop();
                        Utilities.Sleep(TimeSpan.FromMilliseconds(500));
                        //frm.logText("Null Ref: Lost DX9 Rendering Device...now resetting device...", Color.Lime);
                        //frm.logText(Environment.NewLine, Color.Lime);
                        ResetMainMapAll(renderPanel);
                        errorLog(nre.ToString());
                    }
                    finally
                    {
                        frm.timer.Start();
                        frm.AnimationTimer.Start();
                        frm.realTimer.Start();
                        canRender = true;
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        frm.timer.Stop();
                        frm.AnimationTimer.Stop();
                        frm.realTimer.Stop();
                        frm.logText("Rendering Error...trying to reset device...", Color.Lime);
                        frm.logText(Environment.NewLine, Color.Lime);
                        ResetMainMapAll(renderPanel);
                        errorLog(ex.ToString());
                    }
                    finally
                    {
                        frm.timer.Start();
                        frm.AnimationTimer.Start();
                        frm.realTimer.Start();
                        canRender = true;
                    }
                }
                finally
                {
                    canRender = true;
                }
            }
        }
        public void areaPcAnimateRenderAll(int spx, int spy, int pcIndex, int frameIndex)
        {
            if (canRender)
            {
                try
                {
                    canRender = false;
                    device.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
                    device.BeginScene();
                    upperLeftPixel = UpperLeftPixels();

                    renderMainMap();
                    renderCreatures();
                    renderProps();
                    renderGrid();
                    renderFogOfWar();

                    #region Draw PC
                    if (pcTextures[selectedPartyLeader] != null)
                    {
                        int rowIndex = 2; //walking is on row 2
                        for (int index = 0; index < playerList.PCList.Count; index++)
                        {
                            int topLeftX = frameIndex * playerList.PCList[pcIndex].CharSprite.SpriteSize.Width;
                            int topLeftY = playerList.PCList[pcIndex].CharSprite.SpriteSize.Height * rowIndex;
                            SharpDX.Rectangle framePC = new SharpDX.Rectangle(topLeftX, topLeftY, topLeftX + playerList.PCList[pcIndex].CharSprite.SpriteSize.Width, topLeftY + playerList.PCList[pcIndex].CharSprite.SpriteSize.Height);
                            Point targetPC = new Point(spx - upperLeftPixel.X, spy - upperLeftPixel.Y);
                            int flip = 1; //-1 means face right, 1 means face left
                            int rotate = 0; //0=left, 90=up, 180=right, 270=down
                            if (playerList.PCList[pcIndex].CharSprite.TopDown) //topdown sprite
                            {
                                if (playerList.PCList[pcIndex].Facing == CharBase.facing.Up) { rotate = 90; }
                                else if ((playerList.PCList[pcIndex].Facing == CharBase.facing.Right) || (playerList.PCList[pcIndex].Facing == CharBase.facing.DownRight) || (playerList.PCList[pcIndex].Facing == CharBase.facing.UpRight)) { rotate = 180; }
                                else if (playerList.PCList[pcIndex].Facing == CharBase.facing.Down) { rotate = 270; }
                            }
                            else //front facing sprite
                            {
                                if ((playerList.PCList[pcIndex].Facing == CharBase.facing.Right) || (playerList.PCList[pcIndex].Facing == CharBase.facing.DownRight) || (playerList.PCList[pcIndex].Facing == CharBase.facing.UpRight)) { flip = -1; }
                            }
                            pcSprites[pcIndex].Begin(SpriteFlags.AlphaBlend);
                            SharpDX.Matrix mat = new SharpDX.Matrix();
                            mat = SharpDX.Matrix.Transformation2D(
                                    new Vector2(playerList.PCList[pcIndex].CharSprite.SpriteSize.Width / 2, playerList.PCList[pcIndex].CharSprite.SpriteSize.Height / 2),       //scaling center
                                    0.0f,                      //scaling rotation 
                                    new Vector2(flip * 1.0f, 1.0f),   //scaling
                                    new Vector2(playerList.PCList[pcIndex].CharSprite.SpriteSize.Width / 2, playerList.PCList[pcIndex].CharSprite.SpriteSize.Height / 2), //rotation center
                                    rotate,                      //rotation
                                    new Vector2(targetPC.X, targetPC.Y));  //translation
                            pcSprites[pcIndex].Transform = mat;
                            pcSprites[pcIndex].Draw(pcTextures[pcIndex], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                            pcSprites[pcIndex].End();
                        }
                    }
                    #endregion

                    renderText();
                    renderInfo();

                    device.EndScene();
                    device.Present();
                    canRender = true;
                }
                catch (Exception ex)
                {
                    errorLog(ex.ToString());
                    canRender = true;
                }
            }
        }
        private void renderMainMap()
        {
            // * sinopip, 11.01.15
            //areaSprite.Begin(SpriteFlags.AlphaBlend);
            //areaSprite.Draw(currentMapTexture, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, currentArea.MapSizeInPixels.Width, currentArea.MapSizeInPixels.Height), new Vector3(0, 0, 0), new Vector3(0 - upperLeftPixel.X, 0 - upperLeftPixel.Y, 0));
            //areaSprite.Draw(blankBackground, SharpDX.Color.White);
            //areaSprite.End();
            int leftx, topy, maxDisplayPosX, maxDisplayPosY;
			maxDisplayPosX = playerPosition.X;
			maxDisplayPosY = playerPosition.Y;
			maxDisplayPosX = Math.Min(maxDisplayPosX, mapbmp.Width/_squareSize - panelNbSquaresX/2 -1);
			maxDisplayPosY = Math.Min(maxDisplayPosY, mapbmp.Height/_squareSize - panelNbSquaresY/2 -1);
            for (int x = 0; x < areaBoards.Count; x++)
				for (int y = 0; y < areaBoards[x].Count; y++)
				{      
					    
            		leftx =
            			(- currentArea.MapSizeInSquares.Width + x * boardSize/_squareSize //panelNbSquaresX
            			+ (currentArea.MapSizeInSquares.Width - maxDisplayPosX)// - playerPosition.X)
            			+ panelNbSquaresX/2)
            			*_squareSize
            			;
            		topy = 
            			(- currentArea.MapSizeInSquares.Height + y * boardSize/_squareSize //panelNbSquaresY
            			+ (currentArea.MapSizeInSquares.Height - maxDisplayPosY)//- playerPosition.Y)
            			+ panelNbSquaresY/2)
            			*_squareSize
            			;
            		//
            		// * adjustment when only one board in X
            		if (areaBoards.Count == 1)
            			leftx = - upperLeftPixel.X;
            		// * first of many board adjustment in X
            		else if (x == 0)
            			if (maxDisplayPosX < panelNbSquaresX/2 || mapbmp.Width/_squareSize < panelNbSquaresX)
            			  leftx = 0;
            		//
            		// * adjustment when only one board in Y
            		if (areaBoards[x].Count == 1)
            			topy = - upperLeftPixel.Y;
            		// * or first of many board adjustment in Y
            		else if (y == 0)
            			if (maxDisplayPosY < panelNbSquaresY/2 || mapbmp.Height/_squareSize < panelNbSquaresY)
            			  topy = 0;
            		//
					areaSprites[x][y].Begin(SpriteFlags.AlphaBlend);
					/*areaSprites[x][y].Draw(areaBoards[x][y], SharpDX.Color.White, new SharpDX.Rectangle
					                       //(x*_numberOfSquares*_squareSize, y*_numberOfSquares*_squareSize, _numberOfSquares*_squareSize, _numberOfSquares*_squareSize)
					                       (0, 0, Math.Min(_numberOfSquares*_squareSize, (currentMapBitmap.Width-1)%(_numberOfSquares*_squareSize))
					                        , Math.Min(_numberOfSquares*_squareSize, (currentMapBitmap.Height-1)%(_numberOfSquares*_squareSize)))
					                       , new Vector3(0,0,0)
					                       , new Vector3((float)x*_numberOfSquares*_squareSize,(float)y*_numberOfSquares*_squareSize,0.0f));*/
					areaSprites[x][y].Draw(areaBoards[x][y], SharpDX.Color.White, null //new SharpDX.Rectangle
					                       //(0, 0, boardSize, boardSize)
					                       , new Vector3(0, 0, 0)
					                       , new Vector3((leftx), (topy), 0));
					areaSprites[x][y].End();
				}
            //areaSprite.End();
            //
        }
        private void renderCreatures()
        {
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                if ((crt.Visible) && (crt.Show) && (!crt.Animated))
                {
                    //target location
                    Point target = new Point(crt.MapLocation.X * _squareSize, crt.MapLocation.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (crt.CharSprite.TopDown) //topdown sprite
                    {
                        if (crt.Facing == CharBase.facing.Up)
                        {
                            rotate = 90;
                        }
                        else if ((crt.Facing == CharBase.facing.Right) || (crt.Facing == CharBase.facing.DownRight) || (crt.Facing == CharBase.facing.UpRight))
                        {
                            rotate = 180;
                        }
                        else if (crt.Facing == CharBase.facing.Down)
                        {
                            rotate = 270;
                        }
                        else
                        {
                            //do nothing, already facing left
                        }
                    }
                    else //front facing sprite
                    {
                        if ((crt.Facing == CharBase.facing.Right) || (crt.Facing == CharBase.facing.DownRight) || (crt.Facing == CharBase.facing.UpRight))
                        {
                            flip = -1;
                        }
                    }
                    crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                                                                0.0f,                      //scaling rotation 
                                                                new Vector2(flip * 1.0f, 1.0f),   //scaling
                                                                new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                                                                rotate,                      //rotation
                                                                new Vector2(0.0f, 0.0f));  //translation
                    crt.CharSprite.DxSprite.Transform = mat;

                    //smallSprite.Begin(SpriteFlags.AlphaBlend);
                    crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(flip * (target.X - upperLeftPixel.X), target.Y - upperLeftPixel.Y, 0));
                    crt.CharSprite.DxSprite.End();
                }
            }
        }
        private int GetTextureIndex(string filename)
        {
            int index = 0;
            foreach (string tex in propTextureStringList)
            {
                if (tex == filename) { return index; }
                index++;
            }
            return index;
        }
        private void renderProps()
        {
            foreach (Prop prp in currentArea.AreaPropList.propsList)
            {
                if ((prp.Visible) && (prp.Show) && (!prp.Animated))
                {
                    //target location
                    Point target = new Point(prp.Location.X * _squareSize, prp.Location.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height);
                    smallSprite.Begin(SpriteFlags.AlphaBlend);
                    //smallSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    smallSprite.Draw(propTextureList[GetTextureIndex(prp.PropSprite.SpriteSheetFilename)], SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    smallSprite.End();
                }
                if ((prp.Visible) && (prp.Show) && (prp.Animated))
                {
                    prp.PropSprite.MoveAnimation();
                    //target location
                    Point target = new Point(prp.Location.X * _squareSize, prp.Location.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(prp.PropSprite.oSourceRect.X, prp.PropSprite.oSourceRect.Y, prp.PropSprite.oSourceRect.X + prp.PropSprite.SpriteSize.Width, prp.PropSprite.oSourceRect.Y + prp.PropSprite.SpriteSize.Height);
                    smallSprite.Begin(SpriteFlags.AlphaBlend);
                    //smallSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    smallSprite.Draw(propTextureList[GetTextureIndex(prp.PropSprite.SpriteSheetFilename)], SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    smallSprite.End();
                }
            }
        }
        private void renderGrid()
        {
            if (frm_showGrid) //if show grid is turned on, draw grid squares
            {
                for (int x = 0; x < this.currentArea.MapSizeInSquares.Width; x++)
                {
                    for (int y = 0; y < this.currentArea.MapSizeInSquares.Height; y++)
                    {
                        if (currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].LoSBlocked)
                        {
                            smallSprite.Begin(SpriteFlags.AlphaBlend);
                            smallSprite.Draw(LoSBlock, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3((x * _squareSize) - upperLeftPixel.X, (y * _squareSize) - upperLeftPixel.Y, 0));
                            smallSprite.End();
                        }
                        if (currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].collidable)
                        {
                            smallSprite.Begin(SpriteFlags.AlphaBlend);
                            smallSprite.Draw(walkBlock, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3((x * _squareSize) - upperLeftPixel.X, (y * _squareSize) - upperLeftPixel.Y, 0));
                            smallSprite.End();
                        }
                        else
                        {
                            smallSprite.Begin(SpriteFlags.AlphaBlend);
                            smallSprite.Draw(walkPass, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3((x * _squareSize) - upperLeftPixel.X, (y * _squareSize) - upperLeftPixel.Y, 0));
                            smallSprite.End();
                        }
                    }
                }
            }
        }
        private void renderFogOfWar()
        {
            for (int x = 0; x < this.currentArea.MapSizeInSquares.Width; x++)
            {
                for (int y = 0; y < this.currentArea.MapSizeInSquares.Height; y++)
                {
                    if (!currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].visible)
                    {
                        smallSprite.Begin(SpriteFlags.AlphaBlend);
                        smallSprite.Draw(blackTile, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3((x * _squareSize) - upperLeftPixel.X, (y * _squareSize) - upperLeftPixel.Y, 0));
                        smallSprite.End();
                    }
                }
            }
        }
        private void renderPC()
        {
            if (pcTextures[selectedPartyLeader] != null)
            {
                SharpDX.Rectangle framePC = new SharpDX.Rectangle(0, 0, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height);
                Point targetPC = new Point(playerPosition.X * _squareSize, playerPosition.Y * _squareSize);
                int flip = 1; //-1 means face right, 1 means face left
                int rotate = 0; //0=left, 90=up, 180=right, 270=down
                if (playerList.PCList[selectedPartyLeader].CharSprite.TopDown) //topdown sprite
                {
                    if (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.Up)
                    {
                        rotate = 90;
                    }
                    else if ((playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.Right) || (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.DownRight) || (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.UpRight))
                    {
                        rotate = 180;
                    }
                    else if (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.Down)
                    {
                        rotate = 270;
                    }
                    else
                    {
                        //do nothing, already facing left
                    }
                }
                else //front facing sprite
                {
                    if ((playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.Right) || (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.DownRight) || (playerList.PCList[selectedPartyLeader].Facing == CharBase.facing.UpRight))
                    {
                        flip = -1;
                    }
                }
                pcSprites[selectedPartyLeader].Begin(SpriteFlags.AlphaBlend);
                SharpDX.Matrix mat = new SharpDX.Matrix();
                mat = SharpDX.Matrix.Transformation2D(new Vector2(playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width / 2, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height / 2),       //scaling center
                                                            0.0f,                      //scaling rotation 
                                                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                                                            new Vector2(playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width / 2, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height / 2), //rotation center
                                                            rotate,                      //rotation
                                                            new Vector2(0.0f, 0.0f));  //translation
                pcSprites[selectedPartyLeader].Transform = mat;
                pcSprites[selectedPartyLeader].Draw(pcTextures[selectedPartyLeader], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(flip * (targetPC.X - upperLeftPixel.X), targetPC.Y - upperLeftPixel.Y, 0));
                pcSprites[selectedPartyLeader].End();
            }
        }
        public void renderInfo()
        {
            //draw Prop floaty info text
            foreach (Prop prp in currentArea.AreaPropList.propsList)
            {
                if ((mouseMainMapLocation.X == prp.Location.X) && (mouseMainMapLocation.Y == prp.Location.Y))
                {
                    frm.sf.passParameterScriptObject = prp;
                    frm.doScriptBasedOnFilename("dsAdventureMapInfoData.cs", "", "", "", "");
                    frm.sf.passParameterScriptObject = null;
                }
            }
            //draw Creature floaty info text
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                if ((mouseMainMapLocation.X == crt.MapLocation.X) && (mouseMainMapLocation.Y == crt.MapLocation.Y))
                {
                    frm.sf.passParameterScriptObject = crt;
                    frm.doScriptBasedOnFilename("dsAdventureMapInfoData.cs", "", "", "", "");
                    frm.sf.passParameterScriptObject = null;
                }
            }
        }
        private void renderText()
        {
            try
            {
                if (shadowTextPool.Count > 0)
                {
                    //adjust the lifetime timer of each floatytext object
                    doFloatyTextTimer();
                    //adjust the alpha of each floatytext object based on fade in or out
                    doFloatyTextFades();
                    //iterate through all floatytext objects and draw them
                    foreach (ShadowTextObject to in shadowTextPool)
                    {
                        DrawTextShadowOutlineMainMap(to.X, to.Y, to.Z, to.Text, to.AlphaShadow, to.AlphaText, to.TextColor, to.ShadowColor);
                    }                    
                }
            }
            catch (Exception ex)
            {
                errorLog(ex.ToString());
            }
        }
        private void doFloatyTextTimer()
        {
            //used to determine the fade in and out start times and the speed to float up
            foreach (ShadowTextObject to in shadowTextPool)
            {
                to.Timer++;
                to.Z = -(to.Timer / to.FloatSpeed);
                if (to.Timer <= 1)
                {
                    to.FadeIn = true;
                    to.FadeOut = false;
                }
                if (to.Timer > to.TimeLength)
                {
                    to.FadeOut = true;
                    to.FadeIn = false;
                }
            }
            for (int i = shadowTextPool.Count - 1; i >= 0; i--)
            {
                if (shadowTextPool[i].Timer > shadowTextPool[i].TimeLength + 30)
                {
                    shadowTextPool.RemoveAt(i);
                }
            }
        }
        private void doFloatyTextFades()
        {
            //controls the fade in and out
            foreach (ShadowTextObject to in shadowTextPool)
            {
                if (to.FadeIn)
                {
                    to.AlphaShadow += 25;
                    if (to.AlphaShadow > 255)
                        to.AlphaShadow = 255;
                    to.AlphaText += 25;
                    if (to.AlphaText > 255)
                        to.AlphaText = 255;
                }
                if (to.FadeOut)
                {
                    to.AlphaShadow -= 10;
                    if (to.AlphaShadow < 0)
                        to.AlphaShadow = 0;
                    to.AlphaText -= 10;
                    if (to.AlphaText < 0)
                        to.AlphaText = 0;
                }
            }
        }
        public void DrawTextShadowOutlineMainMap(int x, int y, int z, string text, int aShad, int aText, Color textColor, Color shadowColor)
        {
            try
            {
                //text = "DX9 Text Testing!";
                if (text != "")
                {
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x - 1 - upperLeftPixel.X, y - 1 + z - upperLeftPixel.Y, x - 1 - upperLeftPixel.X + 300, y - 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x - 1 - upperLeftPixel.X, y + 0 + z - upperLeftPixel.Y, x - 1 - upperLeftPixel.X + 300, y + 0 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x - 1 - upperLeftPixel.X, y + 1 + z - upperLeftPixel.Y, x - 1 - upperLeftPixel.X + 300, y + 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x + 0 - upperLeftPixel.X, y + 1 + z - upperLeftPixel.Y, x + 0 - upperLeftPixel.X + 300, y + 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x + 0 - upperLeftPixel.X, y - 1 + z - upperLeftPixel.Y, x + 0 - upperLeftPixel.X + 300, y - 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x + 1 - upperLeftPixel.X, y - 1 + z - upperLeftPixel.Y, x + 1 - upperLeftPixel.X + 300, y - 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x + 1 - upperLeftPixel.X, y + 0 + z - upperLeftPixel.Y, x + 1 - upperLeftPixel.X + 300, y + 0 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    fontShadow.DrawText(null, text, new SharpDX.Rectangle(x + 1 - upperLeftPixel.X, y + 1 + z - upperLeftPixel.Y, x + 1 - upperLeftPixel.X + 300, y + 1 + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                    font.DrawText(null, text, new SharpDX.Rectangle(x - upperLeftPixel.X, y + z - upperLeftPixel.Y, x - upperLeftPixel.X + 300, y + z - upperLeftPixel.Y + 1000), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(textColor.R, textColor.G, textColor.B, (byte)aText));
                }
            }
            catch
            {
                MessageBox.Show("Font does not work, try another");
                this.module.ModuleTheme.ModuleFontName = "Microsoft Sans Serif";
                this.module.ModuleTheme.ModuleFontPointSize = 9.75f;
            }
        }
        public void DrawFloatyText(string text, int x, int y, int timeLength, Color textColor, Color shadowColor)
        {
            shadowTextPool.Add(new ShadowTextObject(text, x, y, timeLength, textColor, shadowColor));
        }
        public void DrawFloatyText(string text, int x, int y, int timeLength, int floatSpeed, Color textColor, Color shadowColor)
        {
            shadowTextPool.Add(new ShadowTextObject(text, x, y, timeLength, floatSpeed, textColor, shadowColor));
        }
        private void setExplored()
        {
            // set current position to visible
            currentArea.TileMapList[playerPosition.Y * this.currentArea.MapSizeInSquares.Width + playerPosition.X].visible = true;
            // set tiles to visible around the PC
            for (int x = playerPosition.X - currentArea.VISIBLE_DISTANCE; x <= playerPosition.X + currentArea.VISIBLE_DISTANCE; x++)
            {
                for (int y = playerPosition.Y - currentArea.VISIBLE_DISTANCE; y <= playerPosition.Y + currentArea.VISIBLE_DISTANCE; y++)
                {
                    int xx = x;
                    int yy = y;
                    if (xx < 1) { xx = 0; }
                    if (xx > (this.currentArea.MapSizeInSquares.Width - 1)) { xx = (this.currentArea.MapSizeInSquares.Width - 1); }
                    if (yy < 1) { yy = 0; }
                    if (yy > (this.currentArea.MapSizeInSquares.Height - 1)) { yy = (this.currentArea.MapSizeInSquares.Height - 1); }
                    //Point firstLosSquare = FirstLoSBlockedSquareFound(playerPosition, new Point(xx, yy));
                    //if ((IsVisibleLineOfSight(playerPosition, new Point(x,y))) || (frm.sf.CalcDistance(playerPosition, new Point(x,y)) < 2))
                    //if ((firstLosSquare == new Point(-1,-1)) || (firstLosSquare == new Point(xx, yy)))
                    if (IsLineOfSightForEachCorner(playerPosition, new Point(xx, yy)))
                    {
                        currentArea.TileMapList[yy * this.currentArea.MapSizeInSquares.Width + xx].visible = true;
                    }
                }
            }
        }
        private void setSpriteToAnimate()
        {
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                if (currentArea.TileMapList[crt.MapLocation.Y * this.currentArea.MapSizeInSquares.Width + crt.MapLocation.X].visible == true)
                {
                    crt.Visible = true;
                }
                else
                {
                    crt.Visible = false;
                }
            }
            foreach (Prop prp in currentArea.AreaPropList.propsList)
            {
                if (currentArea.TileMapList[prp.Location.Y * this.currentArea.MapSizeInSquares.Width + prp.Location.X].visible == true)
                {
                    prp.Visible = true;
                }
                else
                {
                    prp.Visible = false;
                }
            }
        }
        public bool IsLineOfSightForEachCorner(Point s, Point e)
        {
            int spacer = 5;
            Point start = new Point((s.X * _squareSize) + (_squareSize / 2), (s.Y * _squareSize) + (_squareSize / 2));
            // top left
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize - spacer, e.Y * _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + spacer, e.Y * _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize - spacer, e.Y * _squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + spacer, e.Y * _squareSize + spacer), e)) { return true; } 
            // top right
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize - spacer, e.Y * _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize + spacer, e.Y * _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize - spacer, e.Y * _squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize + spacer, e.Y * _squareSize + spacer), e)) { return true; }
            // bottom left
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize - spacer, e.Y * _squareSize + _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + spacer, e.Y * _squareSize + _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize - spacer, e.Y * _squareSize + _squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + spacer, e.Y * _squareSize + _squareSize + spacer), e)) { return true; }
            // bottom right
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize - spacer, e.Y * _squareSize + _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize + spacer, e.Y * _squareSize + _squareSize - spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize - spacer, e.Y * _squareSize + _squareSize + spacer), e)) { return true; }
            if (IsVisibleLineOfSight(start, new Point(e.X * _squareSize + _squareSize + spacer, e.Y * _squareSize + _squareSize + spacer), e)) { return true; }
                       
            return false;
        }
        public bool IsVisibleLineOfSight(Point s, Point e, Point endSquare)
        {
            // Bresenham Line algorithm
            // Creates a line from Begin to End starting at (x0,y0) and ending at (x1,y1)
            // where x0 less than x1 and y0 less than y1
            // AND line is less steep than it is wide (dx less than dy)    
            //Point start = new Point((s.X * _squareSize) + (_squareSize / 2), (s.Y * _squareSize) + (_squareSize / 2));
            //Point end = new Point((e.X * _squareSize) + (_squareSize / 2), (e.Y * _squareSize) + (_squareSize / 2));
            Point start = s;
            Point end = e;
            int deltax = Math.Abs(end.X - start.X);
            int deltay = Math.Abs(end.Y - start.Y);
            int ystep = 10;
            int xstep = 10;
            int gridx = 0;
            int gridy = 0;
            int gridXdelayed = s.X;
            int gridYdelayed = s.Y;

            #region low angle version
            if (deltax > deltay) //Low Angle line
            {
                Point nextPoint = start;
                int error = deltax / 2;

                if (end.Y < start.Y) { ystep = -1 * ystep; } //down and right or left

                if (end.X > start.X) //down and right
                {
                    for (int x = start.X; x <= end.X; x += xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        
                        if ((currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked) || (new Point(gridXdelayed,gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
                else //down and left
                {
                    for (int x = start.X; x >= end.X; x -= xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if ((currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked) || (new Point(gridXdelayed,gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
            }
            #endregion

            #region steep version
            else //Low Angle line
            {
                Point nextPoint = start;
                int error = deltay / 2;

                if (end.X < start.X) { xstep = -1 * xstep; } //up and right or left

                if (end.Y > start.Y) //up and right
                {
                    for (int y = start.Y; y <= end.Y; y += ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if ((currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked) || (new Point(gridXdelayed,gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
                else //up and right
                {
                    for (int y = start.Y; y >= end.Y; y -= ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if ((currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked) || (new Point(gridXdelayed,gridYdelayed) == endSquare))
                        {
                            return false;
                        }
                        gridXdelayed = gridx;
                        gridYdelayed = gridy;
                    }
                }
            }
            #endregion

            return true;
        }
        public Point FirstLoSBlockedSquareFound(Point s, Point e)
        {
            // Bresenham Line algorithm
            // Creates a line from Begin to End starting at (x0,y0) and ending at (x1,y1)
            // where x0 less than x1 and y0 less than y1
            // AND line is less steep than it is wide (dx less than dy)    
            Point start = new Point((s.X * _squareSize) + (_squareSize / 2), (s.Y * _squareSize) + (_squareSize / 2));
            Point end = new Point((e.X * _squareSize) + (_squareSize / 2), (e.Y * _squareSize) + (_squareSize / 2));
            int deltax = Math.Abs(end.X - start.X);
            int deltay = Math.Abs(end.Y - start.Y);
            int ystep = 10;
            int xstep = 10;
            int gridx = 0;
            int gridy = 0;

            #region low angle version
            if (deltax > deltay) //Low Angle line
            {
                Point nextPoint = start;
                int error = deltax / 2;

                if (end.Y < start.Y) { ystep = -1 * ystep; } //down and right or left

                if (end.X > start.X) //down and right
                {
                    for (int x = start.X; x <= end.X; x += xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if (currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked)
                        {
                            return new Point(gridx, gridy);
                        }
                    }
                }
                else //down and left
                {
                    for (int x = start.X; x >= end.X; x -= xstep)
                    {
                        nextPoint.X = x;
                        error -= deltay;
                        if (error < 0)
                        {
                            nextPoint.Y += ystep;
                            error += deltax;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if (currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked)
                        {
                            return new Point(gridx, gridy);
                        }
                    }
                }
            }
            #endregion

            #region steep version
            else //Low Angle line
            {
                Point nextPoint = start;
                int error = deltay / 2;

                if (end.X < start.X) { xstep = -1 * xstep; } //up and right or left

                if (end.Y > start.Y) //up and right
                {
                    for (int y = start.Y; y <= end.Y; y += ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if (currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked)
                        {
                            return new Point(gridx, gridy);
                        }
                    }
                }
                else //up and right
                {
                    for (int y = start.Y; y >= end.Y; y -= ystep)
                    {
                        nextPoint.Y = y;
                        error -= deltax;
                        if (error < 0)
                        {
                            nextPoint.X += xstep;
                            error += deltay;
                        }
                        //do your checks here for LoS blocking
                        gridx = nextPoint.X / _squareSize;
                        gridy = nextPoint.Y / _squareSize;
                        if (currentArea.TileMapList[gridy * currentArea.MapSizeInSquares.Width + gridx].LoSBlocked)
                        {
                            return new Point(gridx, gridy);
                        }
                    }
                }
            }
            #endregion

            return new Point(-1,-1);
        }
        /*public void viewUpdate()
        {
            //set area explored
            setExplored();
            //erase old location (use grid map or prop map?)
            //eraseLocation();
            //place token on new location (use grid map or prop map?)
            //draw fog of war
            drawFogOfWar();
            Update();
        }*/
        /*private void eraseLocation()
        {
            //source image
            Rectangle frame = new Rectangle(lastPlayerLocation.X * _squareSize, lastPlayerLocation.Y * _squareSize, _squareSize, _squareSize);

            //target location
            Rectangle target = new Rectangle(lastPlayerLocation.X * _squareSize, lastPlayerLocation.Y * _squareSize, _squareSize, _squareSize);
            
            //erase sprite
            if (frm_showGrid) //if show grid is turned on, draw grid squares
            {
                g_device.DrawImage((Image)currentBackMapFoWBitmap, target, frame, GraphicsUnit.Pixel);
            }
            else
            {
                g_device.DrawImage((Image)currentBackMapBitmap, target, frame, GraphicsUnit.Pixel);
            }
            g_pb.Image = g_surface;
        }*/
        /*public void areaUpdateAll()
        {
            // grab image from stored bitmap
            Rectangle frame = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            Rectangle target = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            g_device.DrawImage((Image)currentMapBitmap, target, frame, GraphicsUnit.Pixel);
            long time1 = DateTime.Now.Ticks;
            setExplored();
            long time2 = DateTime.Now.Ticks;
            setSpriteToAnimate();
            long time3 = DateTime.Now.Ticks;            
            if (frm_showGrid)
                { drawGrid(); }
            long time4 = DateTime.Now.Ticks;
            resetCurrentBackMapBitmap();
            long time5 = DateTime.Now.Ticks;
            drawFogOfWar();
            long time6 = DateTime.Now.Ticks;
            resetCurrentBackMapFoWBitmap();
            long time7 = DateTime.Now.Ticks;
            areaUpdate();
            /*
            frm.logMainText("setExplored: " + ((time2 - time1)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("setSpriteToAnimate: " + ((time3 - time2)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("drawGrid: " + ((time4 - time3)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("resetCurrentBackMapBitmap: " + ((time5 - time4)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("drawFogOfWar: " + ((time6 - time5)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("resetCurrentBackMapFoWBitmap: " + ((time7 - time6)/10000).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
        }
        */
        /*public void initializeGraphics(PictureBox pb)
       {
           g_device = null;
           g_surface = null;
           g_pb = null;
           fText_device = null;
           fText_surface = null;

           //create a picturebox
           g_pb = pb;
                                  
           //create graphics device
           g_surface = new Bitmap(800, 800);
           g_pb.Image = g_surface;
           g_device = Graphics.FromImage(g_surface);
           fText_surface = new Bitmap(100, 300);
           fText_device = Graphics.FromImage(g_surface);
            
           try
           {
               g_blackTile = new Bitmap("data\\graphics\\blackTile.png");
               g_walkPass = new Bitmap("data\\graphics\\walkPass.png");
               g_walkBlock = new Bitmap("data\\graphics\\walkBlock.png");
               g_LoSBlock = new Bitmap("data\\graphics\\LoSBlock.png");
               g_pcDead = new Bitmap("data\\graphics\\pcDead.png");
               g_hitSymbol = new Bitmap("data\\graphics\\hitSymbol.png");
               g_facingUp = new Bitmap("data\\graphics\\facingUp.png");
               g_facingUpRight = new Bitmap("data\\graphics\\facingUpRight.png");
               g_facingRight = new Bitmap("data\\graphics\\facingRight.png");
               g_facingDownRight = new Bitmap("data\\graphics\\facingDownRight.png");
               g_facingDown = new Bitmap("data\\graphics\\facingDown.png");
               g_facingDownLeft = new Bitmap("data\\graphics\\facingDownLeft.png");
               g_facingLeft = new Bitmap("data\\graphics\\facingLeft.png");
               g_facingUpLeft = new Bitmap("data\\graphics\\facingUpLeft.png");
           }
           catch (Exception ex)
           {
               MessageBox.Show("failed to load basic tile images: " + ex.ToString());
               this.errorLog(ex.ToString());
           }
       }
       */
        /*public void newAreaInitGraphics(PictureBox pb)
        {
            g_device = null;
            g_surface = null;
            g_pb = null;
            fText_device = null;
            fText_surface = null;

            //create a picturebox
            g_pb = pb;

            //create graphics device
            g_surface = new Bitmap(currentMapBitmap.Width, currentMapBitmap.Height);
            g_pb.Image = g_surface;
            g_device = Graphics.FromImage(g_surface);
            fText_surface = new Bitmap(100, 300);
            fText_device = Graphics.FromImage(g_surface);

            // grab image from stored bitmap
            Rectangle frame = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            Rectangle target = new Rectangle(0, 0, currentMapBitmap.Width, currentMapBitmap.Height);
            g_device.DrawImage((Image)currentMapBitmap, target, frame, GraphicsUnit.Pixel);
            currentBackMapBitmap = (Bitmap)g_surface.Clone();
            bool getGridSetting = frm_showGrid;
            frm_showGrid = true;
            drawGrid();
            currentBackMapFoWBitmap = (Bitmap)g_surface.Clone();
            frm_showGrid = getGridSetting;
        }
        */
        /*public void Update()
        {
            long time1 = DateTime.Now.Ticks;
            upperLeftPixel = UpperLeftPixels();
            long time2 = DateTime.Now.Ticks;
            Bitmap b2 = (Bitmap)g_surface.Clone();
            Rectangle r1 = new Rectangle(upperLeftPixel.X, upperLeftPixel.Y, g_pb.Width, g_pb.Height);            
            g_device.DrawImage((Image)b2, 0, 0, r1, GraphicsUnit.Pixel);
            g_pb.Image = g_surface;
            b2.Dispose();
            long time3 = DateTime.Now.Ticks;
            /*
            frm.logMainText("UpperLeftPixels: " + (time2 - time1).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            frm.logMainText("RestOfUpdate: " + (time3 - time2).ToString(), Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
            
        }*/
        /*
        private void resetCurrentBackMapBitmap()
        {
            if (currentBackMapBitmap != null)
            {
                currentBackMapBitmap.Dispose();
                currentBackMapBitmap = null;
            }
            if (currentBackMapBitmap == null)
            {
                currentBackMapBitmap = (Bitmap)g_surface.Clone();
            }
        }
        private void resetCurrentBackMapFoWBitmap()
        {
            if (currentBackMapFoWBitmap != null)
            {
                currentBackMapFoWBitmap.Dispose();
                currentBackMapFoWBitmap = null;
            }
            if (currentBackMapFoWBitmap == null)
            {
                currentBackMapFoWBitmap = (Bitmap)g_surface.Clone();
            }
        }
        private void resetCurrentBackMapFoWPropsBitmap()
        {
            if (currentBackMapFoWPropsBitmap != null)
            {
                currentBackMapFoWPropsBitmap.Dispose();
                currentBackMapFoWPropsBitmap = null;
            }
            if (currentBackMapFoWPropsBitmap == null)
            {
                currentBackMapFoWPropsBitmap = (Bitmap)g_surface.Clone();
            }
        }        
        private void DrawNewlyExploredSquares()
        {
            currentArea.VISIBLE_DISTANCE = 10; //for testing purposes
            //iterate through all squares around the PC visible area
            for (int x = playerPosition.X - currentArea.VISIBLE_DISTANCE; x <= playerPosition.X + currentArea.VISIBLE_DISTANCE; x++)
            {
                for (int y = playerPosition.Y - currentArea.VISIBLE_DISTANCE; y <= playerPosition.Y + currentArea.VISIBLE_DISTANCE; y++)
                {
                    int xx = x;
                    int yy = y;
                    if (xx < 1) { xx = 0; }
                    if (xx > (this.currentArea.MapSizeInSquares.Width - 1)) { xx = (this.currentArea.MapSizeInSquares.Width - 1); }
                    if (yy < 1) { yy = 0; }
                    if (yy > (this.currentArea.MapSizeInSquares.Height - 1)) { yy = (this.currentArea.MapSizeInSquares.Height - 1); }
                    //if newly discovered, draw stuff
                    if (currentArea.TileMapList[yy * this.currentArea.MapSizeInSquares.Width + xx].visible != true)
                    {                     
                        //draw square from currentBackMapBitmap
                        int dx = xx * currentArea.TileSize;
                        int dy = yy * currentArea.TileSize;
                        Rectangle src = new Rectangle(dx, dy, _squareSize, _squareSize);                        
                        g_device.DrawImage((Image)currentBackMapBitmap, dx, dy, src, GraphicsUnit.Pixel);
                        //set square to visible
                        currentArea.TileMapList[yy * this.currentArea.MapSizeInSquares.Width + xx].visible = true;
                    }
                }
            }
            resetCurrentBackMapFoWBitmap();
        }        
        private void drawStaticProps()
        {
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                if ((crt.Visible) && (!crt.Animated))
                {
                    //draw all the prop sprites that are static
                    RenderCreatureSpriteStatic(crt);
                }
            }
            foreach (Prop prp in currentArea.AreaPropList.propsList)
            {
                if ((prp.Visible) && (!prp.Animated))
                {
                    //draw all the prop sprites that are static
                    RenderPropSpriteStatic(prp);
                }
            }
        }         
        private void drawGrid()
        {
            if (frm_showGrid) //if show grid is turned on, draw grid squares
            {
                for (int x = 0; x < this.currentArea.MapSizeInSquares.Width; x++)
                {
                    for (int y = 0; y < this.currentArea.MapSizeInSquares.Height; y++)
                    {
                        if (currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].LoSBlocked)
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            g_device.DrawImage(g_LoSBlock, target, src, GraphicsUnit.Pixel);
                        }
                        if (currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].collidable)
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            g_device.DrawImage(g_walkBlock, target, src, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            g_device.DrawImage(g_walkPass, target, src, GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }
        private void drawFogOfWar()
        {
            for (int x = 0; x < this.currentArea.MapSizeInSquares.Width; x++)
            {
                for (int y = 0; y < this.currentArea.MapSizeInSquares.Height; y++)
                {
                    if (!currentArea.TileMapList[y * this.currentArea.MapSizeInSquares.Width + x].visible)
                    {
                        Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                        int dx = x * currentArea.TileSize;
                        int dy = y * currentArea.TileSize;
                        g_device.DrawImage(g_blackTile, dx, dy, src, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        public void spritePcDraw(int spx, int spy, int spriteListIndex)
        {
            PC pc_pt = playerList.PCList[spriteListIndex];
            //source image
            Rectangle frame = new Rectangle(0, 0, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx, spy, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //draw sprite
            using (Bitmap bframe = pc_pt.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
            {
                RotateFlipPC(bframe, pc_pt);
                //g_device.DrawImage(playerList.PCList[spriteListIndex].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                g_device.DrawImage((Image)bframe, target, frame, GraphicsUnit.Pixel);
            }
            
        }
        public void spritePcDrawFrame(int spx, int spy, int spriteListIndex, int frameIndex, int sleep)
        {
            PC pc_pt = playerList.PCList[spriteListIndex];
            //need to get sprite location and then subtract the shift from origin
            //Point offsetSpritePixelLocation = new Point(0, 0);
            //offsetSpritePixelLocation.X = (currentArea.spriteAreaList[count].Location.X * _squareSize) - upperLeftPixel.X;
            //offsetSpritePixelLocation.Y = (currentArea.spriteAreaList[count].Location.Y * _squareSize) - upperLeftPixel.Y;
                    
            //source image
            Rectangle frame = new Rectangle((frameIndex * _squareSize), _squareSize*2, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx - upperLeftPixel.X, spy - upperLeftPixel.Y, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //draw sprite
            using (Bitmap bframe = pc_pt.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
            {
                RotateFlipPC(bframe, pc_pt);
                //g_device.DrawImage(playerList.PCList[spriteListIndex].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                g_device.DrawImage((Image)bframe, target, new Rectangle(0, 0, _squareSize, _squareSize), GraphicsUnit.Pixel);                
            }
            
            g_pb.Image = g_surface;
            Application.DoEvents();
            Thread.Sleep(sleep);            
        }
        public void spriteErasePcDraw(int spx, int spy, int spriteListIndex)
        {
            //source image
            Rectangle frame = new Rectangle(spx, spy, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx - upperLeftPixel.X, spy - upperLeftPixel.Y, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //erase sprite
            if (frm_showGrid) //if show grid is turned on, draw grid squares
            {
                g_device.DrawImage((Image)currentBackMapFoWBitmap, target, frame, GraphicsUnit.Pixel);
            }
            else
            {
                g_device.DrawImage((Image)currentBackMapBitmap, target, frame, GraphicsUnit.Pixel);
            }
            g_pb.Image = g_surface;
        }        
        */
        #endregion

        #region Combat Map Graphics
        public void InitializeCombatRenderPanel(Panel rp)
        {
            combatRenderPanel = rp;
            //resize renderPanel to be area size
            createCombatDevice();
            /*try
            {
                combatDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, combatRenderPanel.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(combatRenderPanel.ClientSize.Width, combatRenderPanel.ClientSize.Height));
            }
            catch
            {
                //MessageBox.Show("Not able to use hardware vertex processing...using software instead");
                combatDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, combatRenderPanel.Handle, CreateFlags.SoftwareVertexProcessing, new PresentParameters(combatRenderPanel.ClientSize.Width, combatRenderPanel.ClientSize.Height));
            }*/
            combatSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            targetMarkerSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            pcMoveRangeSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            pcAttackRangeSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            creatureMoveRangeSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            creatureAttackRangeSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            projectileSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            for (int index = 0; index < playerList.PCList.Count; index++)
            {
                SharpDX.Direct3D9.Sprite newSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
                pcCombatSprites.Add(newSprite);
            }
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                crt.CharSprite.DxSprite = new SharpDX.Direct3D9.Sprite(combatDevice);
            }
            LoadCombatSpriteTextures(mainDirectory + "\\modules\\" + module.ModuleFolderName);
            LoadCombatFontStuff();
        }
        public void createCombatDevice()
        {
            try
            {
                combatDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, combatRenderPanel.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(combatRenderPanel.ClientSize.Width, combatRenderPanel.ClientSize.Height));
            }
            catch
            {
                //MessageBox.Show("Not able to use hardware vertex processing...using software instead");
                combatDevice = new Device(new Direct3D(), 0, DeviceType.Hardware, combatRenderPanel.Handle, CreateFlags.SoftwareVertexProcessing, new PresentParameters(combatRenderPanel.ClientSize.Width, combatRenderPanel.ClientSize.Height));
            }
        }
        public void ResetCombatMapAll(Panel rp)
        {
            DisposeCombatSpritesTextures();
            combatDevice.Dispose();
            InitializeCombatRenderPanel(rp);
        }
        public void LoadCombatSpriteTextures(string moduleFolderPath)
        {
            if (File.Exists(moduleFolderPath + "\\graphics\\walkPass.png"))
            { 
                c_walkPass = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\walkPass.png"); 
            }
            else 
            { 
                c_walkPass = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\walkPass.png"); 
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\walkBlock.png"))
            {
                c_walkBlock = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\walkBlock.png");
            }
            else
            {
                c_walkBlock = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\walkBlock.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\LoSBlock.png"))
            {
                c_LoSBlock = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\LoSBlock.png");
            }
            else
            {
                c_LoSBlock = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\LoSBlock.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\held.png"))
            {
                held = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\held.png");
            }
            else
            {
                held = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\held.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\pcAttackRange.png"))
            {
                pcAttackRangeMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\pcAttackRange.png");
            }
            else
            {
                pcAttackRangeMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\pcAttackRange.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\pcMoveRange.png"))
            {
                pcMoveRangeMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\pcMoveRange.png");
            }
            else
            {
                pcMoveRangeMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\pcMoveRange.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\turnMarker.png"))
            {
                combatTurnMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\turnMarker.png");
            }
            else
            {
                combatTurnMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\turnMarker.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\creatureAttackRange.png"))
            {
                creatureAttackRangeMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\creatureAttackRange.png");
            }
            else
            {
                creatureAttackRangeMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\creatureAttackRange.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\creatureMoveRange.png"))
            {
                creatureMoveRangeMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\creatureMoveRange.png");
            }
            else
            {
                creatureMoveRangeMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\creatureMoveRange.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\targetMarker.png"))
            {
                targetMarker = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\targetMarker.png");
            }
            else
            {
                targetMarker = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\targetMarker.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\pcDead.png"))
            {
                pcDead = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\pcDead.png");
            }
            else
            {
                pcDead = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\pcDead.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\hitSymbol.png"))
            {
                hitSymbol = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\hitSymbol.png");
            }
            else
            {
                hitSymbol = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\hitSymbol.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingUp.png"))
            {
                facingUp = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingUp.png");
            }
            else
            {
                facingUp = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingUp.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingUpRight.png"))
            {
                facingUpRight = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingUpRight.png");
            }
            else
            {
                facingUpRight = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingUpRight.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingRight.png"))
            {
                facingRight = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingRight.png");
            }
            else
            {
                facingRight = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingRight.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingDownRight.png"))
            {
                facingDownRight = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingDownRight.png");
            }
            else
            {
                facingDownRight = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingDownRight.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingDown.png"))
            {
                facingDown = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingDown.png");
            }
            else
            {
                facingDown = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingDown.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingDownLeft.png"))
            {
                facingDownLeft = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingDownLeft.png");
            }
            else
            {
                facingDownLeft = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingDownLeft.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingLeft.png"))
            {
                facingLeft = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingLeft.png");
            }
            else
            {
                facingLeft = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingLeft.png");
            }

            if (File.Exists(moduleFolderPath + "\\graphics\\facingUpLeft.png"))
            {
                facingUpLeft = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\facingUpLeft.png");
            }
            else
            {
                facingUpLeft = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\facingUpLeft.png");
            }

            currentCombatMapTexture = Texture.FromFile(combatDevice, mainDirectory + "\\modules\\" + module.ModuleFolderName + "\\areas\\" + currentCombatArea.MapFileName);

            for (int index = 0; index < playerList.PCList.Count; index++)
            {
                if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    //var testTex = Texture.ToStream(pcTex, ImageFileFormat.Png); //tested and works
                    //testMapTex = Texture.FromStream(device, testTex);           //tested and works 
                    pcCombatTextures.Add(pcTex);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcCombatTextures.Add(pcTex);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcCombatTextures.Add(pcTex);
                }
                else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcCombatTextures.Add(pcTex);
                }
                else if (File.Exists(mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename))
                {
                    Texture pcTex = Texture.FromFile(combatDevice, mainDirectory + "\\tokens\\" + playerList.PCList[index].CharSprite.SpriteSheetFilename);
                    pcCombatTextures.Add(pcTex);
                }
                else
                {
                    MessageBox.Show("failed to load PC SpriteStuff");
                }
            }
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                //crt.CharSprite.SpriteSize = new Size(64, 64);
                if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Texture = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Texture = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Texture = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Texture = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(mainDirectory + "\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Texture = Texture.FromFile(combatDevice, mainDirectory + "\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else
                {
                    MessageBox.Show("failed to load Creature SpriteStuff");
                }
            }
            foreach (Prop prp in currentEncounter.EncounterPropList.propsList)
            {
                //prp.PropSprite.SpriteSize = new Size(64, 64);
                if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\props\\" + prp.PropSpriteFilename))
                {
                    prp.PropSprite.Texture = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename);
                }
                else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + prp.PropSpriteFilename))
                {
                    prp.PropSprite.Texture = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\" + prp.PropSprite.SpriteSheetFilename);
                }
                else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\props\\" + prp.PropSpriteFilename))
                {
                    prp.PropSprite.Texture = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename);
                }
                else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\" + prp.PropSpriteFilename))
                {
                    prp.PropSprite.Texture = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\" + prp.PropSprite.SpriteSheetFilename);
                }
                else
                {
                    MessageBox.Show("failed to load Prop SpriteStuff");
                }
            }
            foreach (PC pc in playerList.PCList)
            {
                foreach (Effect ef in pc.EffectsList.effectsList)
                {
                    if (ef.SpriteFilename != "none")
                    {
                        LoadCombatEffectTextures(mainDirectory + "\\modules\\" + module.ModuleFolderName, LoadSprite(this,ef), ef);
                    }
                }
            }
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                foreach (Effect ef in crt.EffectsList.effectsList)
                {
                    if (ef.SpriteFilename != "none")
                    {
                        LoadCombatEffectTextures(mainDirectory + "\\modules\\" + module.ModuleFolderName, LoadSprite(this, ef), ef);
                    }
                }
            }
        }
        public static Sprite LoadSprite(Game game, Effect ef)
        {
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
            else { return null; }
            return newSprite;
        }
        private void LoadCombatFontStuff()
        {
            // Initialize the Font
            fontCombatDescription = new FontDescription()
            {
                Height = (int)(this.module.ModuleFontPointSize * this.module.ModuleFloatyFontScale),
                Italic = false,
                CharacterSet = FontCharacterSet.Ansi,
                FaceName = this.module.ModuleFontName,
                MipLevels = 1,
                OutputPrecision = FontPrecision.TrueType,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.ClearType,
                Weight = FontWeight.Bold
            };
            fontCombatShadowDescription = new FontDescription()
            {
                Height = (int)(this.module.ModuleFontPointSize * this.module.ModuleFloatyFontScale),
                Italic = false,
                CharacterSet = FontCharacterSet.Ansi,
                FaceName = this.module.ModuleFontName,
                MipLevels = 1,
                OutputPrecision = FontPrecision.TrueType,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.ClearType,
                Weight = FontWeight.Bold
            };
            fontCombat = new SharpDX.Direct3D9.Font(combatDevice, fontCombatDescription);
            fontShadowCombat = new SharpDX.Direct3D9.Font(combatDevice, fontCombatShadowDescription);
        }
        public void DisposeCombatSpritesTextures()
        {            
            combatSprite.Dispose();
            targetMarkerSprite.Dispose();
            pcMoveRangeSprite.Dispose();
            pcAttackRangeSprite.Dispose();
            creatureMoveRangeSprite.Dispose();
            creatureAttackRangeSprite.Dispose();
            projectileSprite.Dispose();
            c_walkPass.Dispose();
            c_walkBlock.Dispose();
            c_LoSBlock.Dispose();
            combatTurnMarker.Dispose();
            pcAttackRangeMarker.Dispose();
            pcMoveRangeMarker.Dispose();
            creatureAttackRangeMarker.Dispose();
            creatureMoveRangeMarker.Dispose();
            targetMarker.Dispose();            
            pcDead.Dispose();
            hitSymbol.Dispose();
            facingUp.Dispose();
            facingUpRight.Dispose();
            facingRight.Dispose();
            facingDownRight.Dispose();
            facingDown.Dispose();
            facingDownLeft.Dispose();
            facingLeft.Dispose();
            facingUpLeft.Dispose();

            foreach (SharpDX.Direct3D9.Sprite spr in pcCombatSprites)
            {
                spr.Dispose();
            }
            pcCombatSprites.Clear();
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                crt.CharSprite.DxSprite.Dispose();
            }

            currentCombatMapTexture.Dispose();
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                crt.CharSprite.Texture.Dispose();
            }
            foreach (Prop prp in currentEncounter.EncounterPropList.propsList)
            {
                prp.PropSprite.Texture.Dispose();
            }
            foreach (Texture pcTex in pcCombatTextures)
            {
                pcTex.Dispose();
            }
            pcCombatTextures.Clear();
            foreach (Texture tp in projectileTextureList)
            {
                tp.Dispose();
            }
            projectileTextureList.Clear();
            projectileTextureStringList.Clear();
            effectTextureList.Clear();
            effectTextureStringList.Clear();
            combatDevice.Dispose();
        }
        public void CombatAreaRenderAll()
        {
            try
            {
                if (userCombatResized) // If Form resized
                {
                    DisposeCombatSpritesTextures();
                    InitializeCombatRenderPanel(combatRenderPanel);
                    userCombatResized = false;
                }
                combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
                combatDevice.BeginScene();
                renderCombatMainMap();
                renderCombatHighlights();
                renderCombatCreatures();
                renderCombatProps();
                renderCombatGrid();
                renderCombatPCs();
                renderTargeting();
                renderCombatText();
                renderCombatInfo();

                combatDevice.EndScene();
                combatDevice.Present();
            }
            catch (SharpDXException sdx)
            {
                if (sdx.Descriptor == SharpDX.Direct3D9.ResultCode.DeviceLost)
                {
                    //Utilities.Sleep(TimeSpan.FromMilliseconds(100));
                    //IBMessageBox.Show(this, "Lost DX9 Rendering Device...resetting DX9 Device now");
                    try
                    {
                        frm.currentCombat.combatTimer.Stop();
                        frm.currentCombat.logText("Combat: Lost DX9 Rendering Device...now resetting device...", Color.Lime);
                        frm.currentCombat.logText(Environment.NewLine, Color.Lime);
                        ResetCombatMapAll(combatRenderPanel);
                    }
                    finally
                    {
                        frm.currentCombat.combatTimer.Start();
                    }
                }
                errorLog(sdx.ToString());
                canRender = true;
            }
            catch (NullReferenceException nre)
            {
                try
                {
                    frm.currentCombat.combatTimer.Stop();
                    Utilities.Sleep(TimeSpan.FromMilliseconds(500));
                    //frm.currentCombat.logText("Null Ref: Lost DX9 Rendering Device...now resetting device...", Color.Lime);
                    //frm.currentCombat.logText(Environment.NewLine, Color.Lime);
                    ResetCombatMapAll(combatRenderPanel);
                    errorLog(nre.ToString());
                }
                finally
                {
                    frm.currentCombat.combatTimer.Start();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    frm.currentCombat.combatTimer.Stop();
                    frm.currentCombat.logText("Rendering Error...trying to reset device...", Color.Lime);
                    frm.currentCombat.logText(Environment.NewLine, Color.Lime);
                    ResetCombatMapAll(combatRenderPanel);
                    errorLog(ex.ToString());
                }
                finally
                {
                    frm.currentCombat.combatTimer.Start();
                }
            }
        }
        public void CombatAreaPcAnimateRenderAll(int pcIndex, int frameIndex, int rowIndex)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            renderCombatHighlights();            
            renderCombatCreatures();
            renderCombatProps();
            renderCombatGrid();

            #region Draw PC
            if (pcCombatTextures[selectedPartyLeader] != null)
            {
                for (int index = 0; index < playerList.PCList.Count; index++)
                {
                    if (index == pcIndex)
                    {
                        int topLeftX = frameIndex * playerList.PCList[pcIndex].CharSprite.SpriteSize.Width;
                        int topLeftY = playerList.PCList[pcIndex].CharSprite.SpriteSize.Height * rowIndex;
                        SharpDX.Rectangle framePC = new SharpDX.Rectangle(topLeftX, topLeftY, topLeftX + playerList.PCList[pcIndex].CharSprite.SpriteSize.Width, topLeftY + playerList.PCList[pcIndex].CharSprite.SpriteSize.Height);
                        //SharpDX.Rectangle framePC = new SharpDX.Rectangle(0, 0, playerList.PCList[index].CharSprite.SpriteSize.Width, playerList.PCList[index].CharSprite.SpriteSize.Height);
                        Point targetPC = new Point(playerList.PCList[pcIndex].CombatLocation.X * _squareSize, playerList.PCList[pcIndex].CombatLocation.Y * _squareSize);
                        int flip = 1; //-1 means face right, 1 means face left
                        int rotate = 0; //0=left, 90=up, 180=right, 270=down
                        if (playerList.PCList[pcIndex].CharSprite.TopDown) //topdown sprite
                        {
                            if (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.Up) { rotate = 90; }
                            else if ((playerList.PCList[pcIndex].CombatFacing == CharBase.facing.Right) || (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                            else if (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.Down) { rotate = 270; }
                        }
                        else //front facing sprite
                        {
                            if ((playerList.PCList[pcIndex].CombatFacing == CharBase.facing.Right) || (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[pcIndex].CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                        }
                        pcCombatSprites[pcIndex].Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(playerList.PCList[pcIndex].CharSprite.SpriteSize.Width / 2, playerList.PCList[pcIndex].CharSprite.SpriteSize.Height / 2),       //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(flip * 1.0f, 1.0f),   //scaling
                                new Vector2(playerList.PCList[pcIndex].CharSprite.SpriteSize.Width / 2, playerList.PCList[pcIndex].CharSprite.SpriteSize.Height / 2), //rotation center
                                rotate,                      //rotation
                                new Vector2(targetPC.X, targetPC.Y));  //translation
                        pcCombatSprites[pcIndex].Transform = mat;
                        pcCombatSprites[pcIndex].Draw(pcCombatTextures[pcIndex], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        pcCombatSprites[pcIndex].End();
                    }
                    else
                    {
                        SharpDX.Rectangle framePC = new SharpDX.Rectangle(0, 0, playerList.PCList[index].CharSprite.SpriteSize.Width, playerList.PCList[index].CharSprite.SpriteSize.Height);
                        Point targetPC = new Point(playerList.PCList[index].CombatLocation.X * _squareSize, playerList.PCList[index].CombatLocation.Y * _squareSize);
                        int flip = 1; //-1 means face right, 1 means face left
                        int rotate = 0; //0=left, 90=up, 180=right, 270=down
                        if (playerList.PCList[index].CharSprite.TopDown) //topdown sprite
                        {
                            if (playerList.PCList[index].CombatFacing == CharBase.facing.Up) { rotate = 90; }
                            else if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                            else if (playerList.PCList[index].CombatFacing == CharBase.facing.Down) { rotate = 270; }
                        }
                        else //front facing sprite
                        {
                            if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                        }
                        pcCombatSprites[index].Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2),       //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(flip * 1.0f, 1.0f),   //scaling
                                new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2), //rotation center
                                rotate,                      //rotation
                                new Vector2(targetPC.X, targetPC.Y));  //translation
                        pcCombatSprites[index].Transform = mat;
                        pcCombatSprites[index].Draw(pcCombatTextures[index], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        if (playerList.PCList[index].Status == CharBase.charStatus.Held)
                        {
                            pcCombatSprites[index].Draw(held, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        }
                        if (playerList.PCList[index].Status == CharBase.charStatus.Dead)
                        {
                            pcCombatSprites[index].Draw(pcDead, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        }
                        pcCombatSprites[index].End();
                    }
                }
            }
            #endregion

            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void CombatAreaCreatureAnimateRenderAll(Creature currentCrt, int frameIndex, int rowIndex)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            renderCombatHighlights();            
            //renderCombatCreatures();
            renderCombatProps();
            renderCombatGrid();
            renderCombatPCs();

            #region Animate Creature Attack
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                if (crt == currentCrt)
                {
                    //source image
                    int topLeftX = frameIndex * crt.CharSprite.SpriteSize.Width;
                    int topLeftY = crt.CharSprite.SpriteSize.Height * rowIndex;
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(topLeftX, topLeftY, topLeftX + crt.CharSprite.SpriteSize.Width, topLeftY + crt.CharSprite.SpriteSize.Height);
                    //target location
                    Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                    //SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (crt.CharSprite.TopDown) //topdown sprite
                    {
                        if (crt.CombatFacing == CharBase.facing.Up) { rotate = 90; }
                        else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                        else if (crt.CombatFacing == CharBase.facing.Down) { rotate = 270; }
                    }
                    else //front facing sprite
                    {
                        if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                    }
                    crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                            0.0f,                      //scaling rotation 
                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                            rotate,                      //rotation
                            new Vector2(target.X, target.Y));  //translation
                    crt.CharSprite.DxSprite.Transform = mat;
                    crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    crt.CharSprite.DxSprite.End();
                }
                else
                {
                    if (crt.HP > 0)
                    {
                        //source image
                        SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                        //target location
                        Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                        int flip = 1; //-1 means face right, 1 means face left
                        int rotate = 0; //0=left, 90=up, 180=right, 270=down
                        if (crt.CharSprite.TopDown) //topdown sprite
                        {
                            if (crt.CombatFacing == CharBase.facing.Up) { rotate = 90; }
                            else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                            else if (crt.CombatFacing == CharBase.facing.Down) { rotate = 270; }
                        }
                        else //front facing sprite
                        {
                            if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                        }

                        crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(flip * 1.0f, 1.0f),   //scaling
                                new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                                rotate,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        crt.CharSprite.DxSprite.Transform = mat;
                        crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        if (crt.Status == CharBase.charStatus.Held)
                        {
                            crt.CharSprite.DxSprite.Draw(held, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        }
                        crt.CharSprite.DxSprite.End();
                        combatSprite.Begin(SpriteFlags.AlphaBlend);
                        if (this.com_showFacing)
                        {
                            if (crt.CombatFacing == CharBase.facing.Up) { combatSprite.Draw(facingUp, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.UpRight) { combatSprite.Draw(facingUpRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.Right) { combatSprite.Draw(facingRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.DownRight) { combatSprite.Draw(facingDownRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.Down) { combatSprite.Draw(facingDown, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.DownLeft) { combatSprite.Draw(facingDownLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.Left) { combatSprite.Draw(facingLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else if (crt.CombatFacing == CharBase.facing.UpLeft) { combatSprite.Draw(facingUpLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                            else { } //didn't find one
                        }
                        combatSprite.End();
                    }
                }
            }
            #endregion

            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void CombatAreaHitSymbolOnCreatureRenderAll(Creature currentCrt)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            renderCombatHighlights();
            renderCombatCreatures();
            #region Draw Hit Symbol
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                if (crt == currentCrt)
                {
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                    //target location
                    Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (crt.CharSprite.TopDown) //topdown sprite
                    {
                        if (crt.CombatFacing == CharBase.facing.Up) { rotate = 90; }
                        else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                        else if (crt.CombatFacing == CharBase.facing.Down) { rotate = 270; }
                    }
                    else //front facing sprite
                    {
                        if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                    }
                    crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                            0.0f,                      //scaling rotation 
                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                            rotate,                      //rotation
                            new Vector2(target.X, target.Y));  //translation
                    crt.CharSprite.DxSprite.Transform = mat;
                    //crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    crt.CharSprite.DxSprite.Draw(hitSymbol, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    crt.CharSprite.DxSprite.End();
                }
            }
            #endregion
            renderCombatProps();
            renderCombatGrid();
            renderCombatPCs();
            /*
            #region Draw Hit Symbol
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                //source image
                SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                //target location
                Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                int flip = 1; //-1 means face right, 1 means face left
                int rotate = 0; //0=left, 90=up, 180=right, 270=down
                if (crt.CharSprite.TopDown) //topdown sprite
                {
                    if (crt.CombatFacing == CharBase.facing.Up) { rotate = 90; }
                    else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                    else if (crt.CombatFacing == CharBase.facing.Down) { rotate = 270; }
                }
                else //front facing sprite
                {
                    if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                }
                crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                SharpDX.Matrix mat = new SharpDX.Matrix();
                mat = SharpDX.Matrix.Transformation2D(
                        new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                        0.0f,                      //scaling rotation 
                        new Vector2(flip * 1.0f, 1.0f),   //scaling
                        new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                        rotate,                      //rotation
                        new Vector2(target.X, target.Y));  //translation
                crt.CharSprite.DxSprite.Transform = mat;
                crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                if (crt == currentCrt)
                {
                    crt.CharSprite.DxSprite.Draw(hitSymbol, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                }
                crt.CharSprite.DxSprite.End();
            }
            #endregion
            */
            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void CombatAreaHitSymbolOnPcRenderAll(PC pc)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            renderCombatHighlights();
            renderCombatCreatures();
            renderCombatProps();
            renderCombatGrid();
            //renderCombatPCs();

            #region Draw Hit Symbol
            if (pcCombatTextures[selectedPartyLeader] != null)
            {
                for (int index = 0; index < playerList.PCList.Count; index++)
                {
                    SharpDX.Rectangle framePC = new SharpDX.Rectangle(0, 0, playerList.PCList[index].CharSprite.SpriteSize.Width, playerList.PCList[index].CharSprite.SpriteSize.Height);
                    Point targetPC = new Point(playerList.PCList[index].CombatLocation.X * _squareSize, playerList.PCList[index].CombatLocation.Y * _squareSize);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (playerList.PCList[index].CharSprite.TopDown) //topdown sprite
                    {
                        if (playerList.PCList[index].CombatFacing == CharBase.facing.Up) { rotate = 90; }
                        else if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Down) { rotate = 270; }
                    }
                    else //front facing sprite
                    {
                        if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                    }
                    pcCombatSprites[index].Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(
                            new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2),       //scaling center
                            0.0f,                      //scaling rotation 
                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                            new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2), //rotation center
                            rotate,                      //rotation
                            new Vector2(targetPC.X, targetPC.Y));  //translation
                    pcCombatSprites[index].Transform = mat;
                    if (playerList.PCList[index] == currentPcTurn)
                    {
                        pcCombatSprites[index].Draw(combatTurnMarker, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    }
                    pcCombatSprites[index].Draw(pcCombatTextures[index], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));

                    if (playerList.PCList[index].Status == CharBase.charStatus.Dead)
                    {
                        pcCombatSprites[index].Draw(pcDead, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    }
                    if (playerList.PCList[index] == pc)
                    {
                        pcCombatSprites[index].Draw(hitSymbol, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    }
                    pcCombatSprites[index].End();
                    combatSprite.Begin(SpriteFlags.AlphaBlend);
                    if (this.com_showFacing)
                    {
                        if (playerList.PCList[index].CombatFacing == CharBase.facing.Up) { combatSprite.Draw(facingUp, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight) { combatSprite.Draw(facingUpRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Right) { combatSprite.Draw(facingRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) { combatSprite.Draw(facingDownRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Down) { combatSprite.Draw(facingDown, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.DownLeft) { combatSprite.Draw(facingDownLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Left) { combatSprite.Draw(facingLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.UpLeft) { combatSprite.Draw(facingUpLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else { } //didn't find one
                    }
                    combatSprite.End();
                }
            }
            #endregion
            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void LoadCombatProjectileTextures(string moduleFolderPath, Sprite projSprite)
        {
            try
            {
                if (projectileTextureStringList.Contains(projSprite.SpriteSheetFilename))
                {
                    //already in the list so don't need to add
                }
                else
                {
                    if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\FXs\\" + projSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\FXs\\" + projSprite.SpriteSheetFilename);
                        projectileTextureList.Add(newTex);
                        projectileTextureStringList.Add(projSprite.SpriteSheetFilename);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + projSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\" + projSprite.SpriteSheetFilename);
                        projectileTextureList.Add(newTex);
                        projectileTextureStringList.Add(projSprite.SpriteSheetFilename);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + projSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + projSprite.SpriteSheetFilename);
                        projectileTextureList.Add(newTex);
                        projectileTextureStringList.Add(projSprite.SpriteSheetFilename);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\" + projSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\" + projSprite.SpriteSheetFilename);
                        projectileTextureList.Add(newTex);
                        projectileTextureStringList.Add(projSprite.SpriteSheetFilename);
                    }
                    else
                    {
                        MessageBox.Show("didn't find the projectile texture in the designated folders");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load projectile texture: " + ex.ToString());
                this.errorLog(ex.ToString());
            }
        }
        private int GetProjTextureIndex(string filename)
        {
            int index = 0;
            foreach (string tex in projectileTextureStringList)
            {
                if (tex == filename) { return index; }
                index++;
            }
            return index;
        }
        public void LoadCombatEffectTextures(string moduleFolderPath, Sprite effectSprite, Effect effect)
        {
            try
            {
                if (effectTextureStringList.Contains(effect.SpriteFilename))
                {
                    //already in the list so don't need to add
                }
                else
                {
                    if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\FXs\\" + effectSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\FXs\\" + effectSprite.SpriteSheetFilename);
                        effectTextureList.Add(newTex);
                        effectTextureStringList.Add(effect.SpriteFilename);
                    }
                    else if (File.Exists(moduleFolderPath + "\\graphics\\sprites\\" + effectSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, moduleFolderPath + "\\graphics\\sprites\\" + effectSprite.SpriteSheetFilename);
                        effectTextureList.Add(newTex);
                        effectTextureStringList.Add(effect.SpriteFilename);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + effectSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\FXs\\" + effectSprite.SpriteSheetFilename);
                        effectTextureList.Add(newTex);
                        effectTextureStringList.Add(effect.SpriteFilename);
                    }
                    else if (File.Exists(mainDirectory + "\\data\\graphics\\sprites\\" + effectSprite.SpriteSheetFilename))
                    {
                        Texture newTex = Texture.FromFile(combatDevice, mainDirectory + "\\data\\graphics\\sprites\\" + effectSprite.SpriteSheetFilename);
                        effectTextureList.Add(newTex);
                        effectTextureStringList.Add(effect.SpriteFilename);
                    }
                    else
                    {
                        MessageBox.Show("didn't find the effect texture in the designated folders");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load effect texture: " + ex.ToString());
                this.errorLog(ex.ToString());
            }
        }
        private int GetEffectTextureIndex(string filename)
        {
            int index = 0;
            foreach (string tex in effectTextureStringList)
            {
                if (tex == filename) { return index; }
                index++;
            }
            return index;
        }
        public void CombatAreaProjectileRenderAll(Sprite projSprite, Point location, float angle, int frameIndex)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            //renderCombatHighlights();
            renderCombatCreatures();
            renderCombatProps();
            renderCombatGrid();
            renderCombatPCs();

            #region Draw Projectile
            int topLeft = frameIndex * projSprite.SpriteSize.Width;

            SharpDX.Rectangle frame = new SharpDX.Rectangle(topLeft, 0, topLeft + projSprite.SpriteSize.Width, projSprite.SpriteSize.Height);
            
            Point target = new Point(location.X, location.Y);

            projectileSprite.Begin(SpriteFlags.AlphaBlend);
            SharpDX.Matrix mat = new SharpDX.Matrix();
            mat = SharpDX.Matrix.Transformation2D(
                    new Vector2(0.0f, 0.0f),           //scaling center
                    0.0f,                              //scaling rotation 
                    new Vector2(1.0f, 1.0f),           //scaling
                    new Vector2(projSprite.SpriteSize.Width / 2, projSprite.SpriteSize.Height / 2), //rotation center
                    angle,                             //rotation
                    new Vector2(target.X - projSprite.SpriteSize.Width / 2, target.Y - projSprite.SpriteSize.Height / 2));  //translation
            projectileSprite.Transform = mat;
            projectileSprite.Draw(projectileTextureList[GetProjTextureIndex(projSprite.SpriteSheetFilename)], SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            projectileSprite.End();
            #endregion
            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void CombatAreaEndEffectRenderAll(Sprite endEffectSprite, Point location, int frameIndex)
        {
            combatDevice.Clear(ClearFlags.Target, SharpDX.Color.Black, 1.0f, 0);
            combatDevice.BeginScene();
            renderCombatMainMap();
            renderCombatCreatures();
            renderCombatProps();
            renderCombatGrid();
            renderCombatPCs();

            #region Draw End Effect
            int topLeft = frameIndex * endEffectSprite.SpriteSize.Width;

            SharpDX.Rectangle frame = new SharpDX.Rectangle(topLeft, 0, topLeft + endEffectSprite.SpriteSize.Width, endEffectSprite.SpriteSize.Height);

            Point target = new Point(location.X, location.Y);

            projectileSprite.Begin(SpriteFlags.AlphaBlend);
            SharpDX.Matrix mat = new SharpDX.Matrix();
            mat = SharpDX.Matrix.Transformation2D(
                    new Vector2(0.0f, 0.0f),           //scaling center
                    0.0f,                              //scaling rotation 
                    new Vector2(1.0f, 1.0f),           //scaling
                    new Vector2(0.0f, 0.0f),           //rotation center
                    0.0f,                              //rotation
                    new Vector2(target.X, target.Y));  //translation
            projectileSprite.Transform = mat;
            projectileSprite.Draw(projectileTextureList[GetProjTextureIndex(endEffectSprite.SpriteSheetFilename)], SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            projectileSprite.End();
            #endregion
            renderCombatText();
            renderCombatInfo();
            combatDevice.EndScene();
            combatDevice.Present();
        }
        public void renderCombatMainMap()
        {
            combatSprite.Begin(SpriteFlags.AlphaBlend);
            combatSprite.Draw(currentCombatMapTexture, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, currentCombatArea.MapSizeInPixels.Width, currentCombatArea.MapSizeInPixels.Height), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
            combatSprite.End();
        }
        public void renderCombatHighlights()
        {
            //draw PC highlights (move range)
            if ((com_showRange) && (currentPcTurn != null)) //always draw current pc if checked box
            {
                SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                Point target = new Point(currentPcTurn.CombatLocation.X * _squareSize, currentPcTurn.CombatLocation.Y * _squareSize);
                int scaling = (2 * (currentPcTurn.MoveDistance - currentPcTurnMovesMade)) + 1;
                pcMoveRangeSprite.Begin(SpriteFlags.AlphaBlend);
                SharpDX.Matrix mat = new SharpDX.Matrix();
                mat = SharpDX.Matrix.Transformation2D(
                        new Vector2(currentPcTurn.CharSprite.SpriteSize.Width / 2, currentPcTurn.CharSprite.SpriteSize.Height / 2), //scaling center
                        0.0f,                      //scaling rotation 
                        new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                        new Vector2(0.0f, 0.0f), //rotation center
                        0.0f,                      //rotation
                        new Vector2(target.X, target.Y));  //translation
                pcMoveRangeSprite.Transform = mat;
                pcMoveRangeSprite.Draw(pcMoveRangeMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                pcMoveRangeSprite.End();
            }
            //draw PC highlights (attack range)
            if ((com_showRange) && (currentPcTurn != null)) //always draw current pc if checked box
            {
                SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                Point target = new Point(currentPcTurn.CombatLocation.X * _squareSize, currentPcTurn.CombatLocation.Y * _squareSize);
                int scaling = (2 * (currentPcTurn.MainHand.ItemAttackRange)) + 1;
                pcMoveRangeSprite.Begin(SpriteFlags.AlphaBlend);
                SharpDX.Matrix mat = new SharpDX.Matrix();
                mat = SharpDX.Matrix.Transformation2D(
                        new Vector2(currentPcTurn.CharSprite.SpriteSize.Width / 2, currentPcTurn.CharSprite.SpriteSize.Height / 2), //scaling center
                        0.0f,                      //scaling rotation 
                        new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                        new Vector2(0.0f, 0.0f), //rotation center
                        0.0f,                      //rotation
                        new Vector2(target.X, target.Y));  //translation
                pcMoveRangeSprite.Transform = mat;
                pcMoveRangeSprite.Draw(pcAttackRangeMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                pcMoveRangeSprite.End();
            }
            //draw Creature highlights
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                if ((com_showRange) && (crt.HP > 0))
                {
                    if ((mouseCombatLocation.X == crt.CombatLocation.X) && (mouseCombatLocation.Y == crt.CombatLocation.Y))
                    {
                        //draw Creature highlights (move range)
                        SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                        Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                        int scaling = (2 * crt.MoveDistance) + 1;
                        creatureMoveRangeSprite.Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(_squareSize / 2, _squareSize / 2), //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                                new Vector2(0.0f, 0.0f),   //rotation center
                                0.0f,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        creatureMoveRangeSprite.Transform = mat;
                        creatureMoveRangeSprite.Draw(creatureMoveRangeMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        creatureMoveRangeSprite.End();

                        //draw Creature highlights (attack range)
                        frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                        target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                        scaling = (2 * crt.AttackRange) + 1;
                        creatureAttackRangeSprite.Begin(SpriteFlags.AlphaBlend);
                        mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(_squareSize / 2, _squareSize / 2), //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                                new Vector2(0.0f, 0.0f), //rotation center
                                0.0f,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        creatureAttackRangeSprite.Transform = mat;
                        creatureAttackRangeSprite.Draw(creatureAttackRangeMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        creatureAttackRangeSprite.End();
                    }
                }
            }
        }
        public void renderCombatInfo()
        {
            //draw PC floaty info text
            foreach (PC pc in this.playerList.PCList)
            {
                if ((mouseCombatLocation.X == pc.CombatLocation.X) && (mouseCombatLocation.Y == pc.CombatLocation.Y))
                {
                    frm.sf.passParameterScriptObject = pc;
                    frm.doScriptBasedOnFilename("dsCombatInfoMapData.cs", "", "", "", "");
                    frm.sf.passParameterScriptObject = null;
                }
            }
            //draw Creature floaty info text
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                if (crt.HP > 0)
                {
                    if ((mouseCombatLocation.X == crt.CombatLocation.X) && (mouseCombatLocation.Y == crt.CombatLocation.Y))
                    {
                        frm.sf.passParameterScriptObject = crt;
                        frm.doScriptBasedOnFilename("dsCombatInfoMapData.cs", "", "", "", "");
                        frm.sf.passParameterScriptObject = null;
                    }
                }
            }
        }
        public void renderTargeting()
        {
            if (currentPcTurn != null) //always draw current pc if checked box
            {
                if (frm.currentCombat.rangedItem)
                {
                    int dist = frm.currentCombat.calcDistance(mouseCombatLocation, currentPcTurn.CombatLocation);
                    if (currentPcTurn.MainHand.ItemAttackRange >= dist) // check to see if selected is in range
                    {
                        //TODO draw line for LoS
                        //frm.currentCombat.IsVisibleLineOfSight(currentPcTurn.CombatLocation, mouseCombatLocation);
                        SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                        Point target = new Point(mouseCombatLocation.X * _squareSize, mouseCombatLocation.Y * _squareSize);
                        int scaling = (2 * 0) + 1; //0 means one square AoE                        
                        targetMarkerSprite.Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(_squareSize / 2, _squareSize / 2), //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                                new Vector2(0.0f, 0.0f), //rotation center
                                0.0f,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        targetMarkerSprite.Transform = mat;
                        targetMarkerSprite.Draw(targetMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        targetMarkerSprite.End();
                    }
                }

                if (frm.currentCombat.rangedSpell)
                {
                    int dist = frm.currentCombat.calcDistance(mouseCombatLocation, currentPcTurn.CombatLocation);
                    if (frm.currentCombat.currentSpell.Range >= dist) // check to see if selected is in range
                    {
                        //TODO draw line for LoS
                        //frm.currentCombat.IsVisibleLineOfSight(currentPcTurn.CombatLocation, mouseCombatLocation);
                        SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                        Point target = new Point(mouseCombatLocation.X * _squareSize, mouseCombatLocation.Y * _squareSize);
                        int scaling = (2 * frm.currentCombat.currentSpell.AoeRadiusOrLength) + 1; //0 means one square AoE                        
                        targetMarkerSprite.Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(_squareSize / 2, _squareSize / 2), //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                                new Vector2(0.0f, 0.0f), //rotation center
                                0.0f,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        targetMarkerSprite.Transform = mat;
                        targetMarkerSprite.Draw(targetMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        targetMarkerSprite.End();
                    }
                }

                if (frm.currentCombat.rangedTrait)
                {
                    int dist = frm.currentCombat.calcDistance(mouseCombatLocation, currentPcTurn.CombatLocation);
                    if (frm.currentCombat.currentTrait.Range >= dist) // check to see if selected is in range
                    {
                        //TODO draw line for LoS
                        //frm.currentCombat.IsVisibleLineOfSight(currentPcTurn.CombatLocation, mouseCombatLocation);
                        SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, _squareSize, _squareSize);
                        Point target = new Point(mouseCombatLocation.X * _squareSize, mouseCombatLocation.Y * _squareSize);
                        int scaling = (2 * frm.currentCombat.currentTrait.AoeRadiusOrLength) + 1; //0 means one square AoE                        
                        targetMarkerSprite.Begin(SpriteFlags.AlphaBlend);
                        SharpDX.Matrix mat = new SharpDX.Matrix();
                        mat = SharpDX.Matrix.Transformation2D(
                                new Vector2(_squareSize / 2, _squareSize / 2), //scaling center
                                0.0f,                      //scaling rotation 
                                new Vector2(scaling * 1.0f, scaling * 1.0f),   //scaling
                                new Vector2(0.0f, 0.0f), //rotation center
                                0.0f,                      //rotation
                                new Vector2(target.X, target.Y));  //translation
                        targetMarkerSprite.Transform = mat;
                        targetMarkerSprite.Draw(targetMarker, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        targetMarkerSprite.End();
                    }
                }
            }
        }
        public void renderCombatCreatures()
        {
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                if ((!crt.Animated) && (crt.Show) && (crt.HP > 0))
                {
                    //target location
                    Point target = new Point(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (crt.CharSprite.TopDown) //topdown sprite
                    {
                        if (crt.CombatFacing == CharBase.facing.Up) { rotate = 90; }
                        else if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                        else if (crt.CombatFacing == CharBase.facing.Down) { rotate = 270; }
                    }
                    else //front facing sprite
                    {
                        if ((crt.CombatFacing == CharBase.facing.Right) || (crt.CombatFacing == CharBase.facing.DownRight) || (crt.CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                    }
                    
                    crt.CharSprite.DxSprite.Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2),       //scaling center
                            0.0f,                      //scaling rotation 
                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                            new Vector2(crt.CharSprite.SpriteSize.Width / 2, crt.CharSprite.SpriteSize.Height / 2), //rotation center
                            rotate,                      //rotation
                            new Vector2(target.X, target.Y));  //translation
                    crt.CharSprite.DxSprite.Transform = mat;
                    crt.CharSprite.DxSprite.Draw(crt.CharSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    //if (crt.Status == CharBase.charStatus.Held)
                    //{
                    //    crt.CharSprite.DxSprite.Draw(held, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    //}
                    foreach (Effect ef in crt.EffectsList.effectsList)
                    {
                        if (ef.SpriteFilename != "none")
                        {
                            crt.CharSprite.DxSprite.Draw(effectTextureList[GetEffectTextureIndex(ef.SpriteFilename)], SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        }
                    }
                    crt.CharSprite.DxSprite.End();
                    combatSprite.Begin(SpriteFlags.AlphaBlend);
                    if (this.com_showFacing)
                    {
                        if (crt.CombatFacing == CharBase.facing.Up) { combatSprite.Draw(facingUp, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.UpRight) { combatSprite.Draw(facingUpRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.Right) { combatSprite.Draw(facingRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.DownRight) { combatSprite.Draw(facingDownRight, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.Down) { combatSprite.Draw(facingDown, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.DownLeft) { combatSprite.Draw(facingDownLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.Left) { combatSprite.Draw(facingLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else if (crt.CombatFacing == CharBase.facing.UpLeft) { combatSprite.Draw(facingUpLeft, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0)); }
                        else { } //didn't find one
                    }
                    combatSprite.End();
                }
            }
        }
        public void renderCombatProps()
        {
            foreach (Prop prp in currentEncounter.EncounterPropList.propsList)
            {
                if ((!prp.Animated) && (prp.Show))
                {
                    //target location
                    Point target = new Point(prp.Location.X * _squareSize, prp.Location.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(0, 0, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height);
                    combatSprite.Begin(SpriteFlags.AlphaBlend);
                    //combatSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    combatSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0));
                    combatSprite.End();
                }
                if ((prp.Animated) && (prp.Show))
                {
                    prp.PropSprite.MoveAnimation();
                    //target location
                    Point target = new Point(prp.Location.X * _squareSize, prp.Location.Y * _squareSize);
                    //source image
                    SharpDX.Rectangle frame = new SharpDX.Rectangle(prp.PropSprite.oSourceRect.X, prp.PropSprite.oSourceRect.Y, prp.PropSprite.oSourceRect.X + prp.PropSprite.SpriteSize.Width, prp.PropSprite.oSourceRect.Y + prp.PropSprite.SpriteSize.Height);
                    combatSprite.Begin(SpriteFlags.AlphaBlend);
                    //combatSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X - upperLeftPixel.X, target.Y - upperLeftPixel.Y, 0));
                    combatSprite.Draw(prp.PropSprite.Texture, SharpDX.Color.White, frame, new Vector3(0, 0, 0), new Vector3(target.X, target.Y, 0));
                    combatSprite.End();
                }
            }
        }
        public void renderCombatGrid()
        {
            if (com_showGrid) //if show grid is turned on, draw grid squares
            {
                for (int x = 0; x < this.currentCombatArea.MapSizeInSquares.Width; x++)
                {
                    for (int y = 0; y < this.currentCombatArea.MapSizeInSquares.Height; y++)
                    {
                        if (currentCombatArea.TileMapList[y * this.currentCombatArea.MapSizeInSquares.Width + x].LoSBlocked)
                        {
                            combatSprite.Begin(SpriteFlags.AlphaBlend);
                            combatSprite.Draw(c_LoSBlock, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3(x * _squareSize, y * _squareSize, 0));
                            combatSprite.End();
                        }
                        if (currentCombatArea.TileMapList[y * this.currentCombatArea.MapSizeInSquares.Width + x].collidable)
                        {
                            combatSprite.Begin(SpriteFlags.AlphaBlend);
                            combatSprite.Draw(c_walkBlock, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3(x * _squareSize, y * _squareSize, 0));
                            combatSprite.End();
                        }
                        else
                        {
                            combatSprite.Begin(SpriteFlags.AlphaBlend);
                            combatSprite.Draw(c_walkPass, SharpDX.Color.White, new SharpDX.Rectangle(0, 0, _squareSize, _squareSize), new Vector3(0, 0, 0), new Vector3(x * _squareSize, y * _squareSize, 0));
                            combatSprite.End();
                        }
                    }
                }
            }
        }
        public void renderCombatPCs()
        {
            if (pcCombatTextures[selectedPartyLeader] != null)
            {
                for (int index = 0; index < playerList.PCList.Count; index++)
                {
                    SharpDX.Rectangle framePC = new SharpDX.Rectangle(0, 0, playerList.PCList[index].CharSprite.SpriteSize.Width, playerList.PCList[index].CharSprite.SpriteSize.Height);
                    Point targetPC = new Point(playerList.PCList[index].CombatLocation.X * _squareSize, playerList.PCList[index].CombatLocation.Y * _squareSize);
                    int flip = 1; //-1 means face right, 1 means face left
                    int rotate = 0; //0=left, 90=up, 180=right, 270=down
                    if (playerList.PCList[index].CharSprite.TopDown) //topdown sprite
                    {
                        if (playerList.PCList[index].CombatFacing == CharBase.facing.Up) { rotate = 90; }
                        else if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { rotate = 180; }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Down) { rotate = 270; }
                    }
                    else //front facing sprite
                    {
                        if ((playerList.PCList[index].CombatFacing == CharBase.facing.Right) || (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) || (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight)) { flip = -1; }
                    }
                    pcCombatSprites[index].Begin(SpriteFlags.AlphaBlend);
                    SharpDX.Matrix mat = new SharpDX.Matrix();
                    mat = SharpDX.Matrix.Transformation2D(
                            new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2),       //scaling center
                            0.0f,                      //scaling rotation 
                            new Vector2(flip * 1.0f, 1.0f),   //scaling
                            new Vector2(playerList.PCList[index].CharSprite.SpriteSize.Width / 2, playerList.PCList[index].CharSprite.SpriteSize.Height / 2), //rotation center
                            rotate,                      //rotation
                            new Vector2(targetPC.X, targetPC.Y));  //translation
                    pcCombatSprites[index].Transform = mat;
                    if (playerList.PCList[index] == currentPcTurn)
                    {
                        pcCombatSprites[index].Draw(combatTurnMarker, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    }
                    pcCombatSprites[index].Draw(pcCombatTextures[index], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    //if (playerList.PCList[index].Status == CharBase.charStatus.Held)
                    //{
                    //    pcCombatSprites[index].Draw(held, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    //}
                    foreach (Effect ef in playerList.PCList[index].EffectsList.effectsList)
                    {
                        if (ef.SpriteFilename != "none")
                        {
                            pcCombatSprites[index].Draw(effectTextureList[GetEffectTextureIndex(ef.SpriteFilename)], SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                        }
                    }
                    if (playerList.PCList[index].Status == CharBase.charStatus.Dead)
                    {
                        pcCombatSprites[index].Draw(pcDead, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(0, 0, 0));
                    }
                    pcCombatSprites[index].End();
                    combatSprite.Begin(SpriteFlags.AlphaBlend);
                    if (this.com_showFacing)
                    {
                        if (playerList.PCList[index].CombatFacing == CharBase.facing.Up) { combatSprite.Draw(facingUp, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.UpRight) { combatSprite.Draw(facingUpRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Right) { combatSprite.Draw(facingRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.DownRight) { combatSprite.Draw(facingDownRight, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Down) { combatSprite.Draw(facingDown, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.DownLeft) { combatSprite.Draw(facingDownLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.Left) { combatSprite.Draw(facingLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else if (playerList.PCList[index].CombatFacing == CharBase.facing.UpLeft) { combatSprite.Draw(facingUpLeft, SharpDX.Color.White, framePC, new Vector3(0, 0, 0), new Vector3(targetPC.X, targetPC.Y, 0)); }
                        else { } //didn't find one
                    }
                    combatSprite.End();
                }
            } 
        }
        private void renderCombatText()
        {
            try
            {
                if (shadowCombatTextPool.Count > 0)
                {
                    //adjust the lifetime timer of each floatytext object
                    doCombatFloatyTextTimer();
                    //adjust the alpha of each floatytext object based on fade in or out
                    doCombatFloatyTextFades();
                    //iterate through all floatytext objects and draw them
                    foreach (ShadowTextObject to in shadowCombatTextPool)
                    {
                        DrawCombatTextShadowOutlineMainMap(to.X, to.Y, to.Z, to.Text, to.AlphaShadow, to.AlphaText, to.TextColor, to.ShadowColor);
                    }
                }
            }
            catch (Exception ex)
            {
                errorLog(ex.ToString());
            }
        }
        private void doCombatFloatyTextTimer()
        {
            //used to determine the fade in and out start times and the speed to float up
            foreach (ShadowTextObject to in shadowCombatTextPool)
            {
                to.Timer++;
                to.Z = -(to.Timer / to.FloatSpeed);
                if (to.Timer <= 1)
                {
                    to.FadeIn = true;
                    to.FadeOut = false;
                }
                if (to.Timer > to.TimeLength)
                {
                    to.FadeOut = true;
                    to.FadeIn = false;
                }
            }
            for (int i = shadowCombatTextPool.Count - 1; i >= 0; i--)
            {
                if (shadowCombatTextPool[i].Timer > shadowCombatTextPool[i].TimeLength + 30)
                {
                    shadowCombatTextPool.RemoveAt(i);
                }
            }
        }
        private void doCombatFloatyTextFades()
        {
            //controls the fade in and out
            foreach (ShadowTextObject to in shadowCombatTextPool)
            {
                if (to.FadeIn)
                {
                    to.AlphaShadow += 25;
                    if (to.AlphaShadow > 255)
                        to.AlphaShadow = 255;
                    to.AlphaText += 25;
                    if (to.AlphaText > 255)
                        to.AlphaText = 255;
                }
                if (to.FadeOut)
                {
                    to.AlphaShadow -= 10;
                    if (to.AlphaShadow < 0)
                        to.AlphaShadow = 0;
                    to.AlphaText -= 10;
                    if (to.AlphaText < 0)
                        to.AlphaText = 0;
                }
            }
        }
        public void DrawCombatTextShadowOutlineMainMap(int x, int y, int z, string text, int aShad, int aText, Color textColor, Color shadowColor)
        {
            try
            {
                int xWidth = 300; // was 300
                int yHeight = 1000; //was 1000
                //text = "DX9 Text Testing!";
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x - 1, y - 1 + z, x - 1 + xWidth, y - 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x - 1, y + 0 + z, x - 1 + xWidth, y + 0 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x - 1, y + 1 + z, x - 1 + xWidth, y + 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x + 0, y + 1 + z, x + 0 + xWidth, y + 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x + 0, y - 1 + z, x + 0 + xWidth, y - 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x + 1, y - 1 + z, x + 1 + xWidth, y - 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x + 1, y + 0 + z, x + 1 + xWidth, y + 0 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontShadowCombat.DrawText(null, text, new SharpDX.Rectangle(x + 1, y + 1 + z, x + 1 + xWidth, y + 1 + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(shadowColor.R, shadowColor.G, shadowColor.B, (byte)aShad));
                fontCombat.DrawText(null, text, new SharpDX.Rectangle(x, y + z, x + xWidth, y + z + yHeight), FontDrawFlags.Center | FontDrawFlags.NoClip | FontDrawFlags.WordBreak, new SharpDX.Color(textColor.R, textColor.G, textColor.B, (byte)aText));
            }
            catch
            {
                MessageBox.Show("Font does not work, try another");
                this.module.ModuleTheme.ModuleFontName = "Microsoft Sans Serif";
                this.module.ModuleTheme.ModuleFontPointSize = 9.75f;
            }
        }
        public void DrawCombatFloatyText(string text, int x, int y, int timeLength, Color textColor, Color shadowColor)
        {
            shadowCombatTextPool.Add(new ShadowTextObject(text, x, y, timeLength, textColor, shadowColor));
        }
        public void DrawCombatFloatyText(string text, int x, int y, int timeLength, int floatSpeed, Color textColor, Color shadowColor)
        {
            shadowCombatTextPool.Add(new ShadowTextObject(text, x, y, timeLength, floatSpeed, textColor, shadowColor));
        }
        const float Rad2Deg = (float)(180.0 / Math.PI);
        public float AngleRad(Point start, Point end)
        {
            return (float)(-1 * ((Math.Atan2(start.Y - end.Y, end.X - start.X)) - (Math.PI) / 2));
        }

        /*public Point UpperLeftPixelsCombat()
        {
            Point upperLeftPixel = new Point();
            //determine location of player on map (x,y square)
            int pcx = playerPosition.X;
            int pcy = playerPosition.Y;
            //determine size of picture box (x,y squares)
            int rpx = renderPanel.Width / _squareSize;
            int rpy = renderPanel.Height / _squareSize;
            //int pbx = g_pb.Width / _squareSize;
            //int pby = g_pb.Height / _squareSize;
            //frm.logMainText("pbX = " + pbx.ToString() + "  pbY = " + pby.ToString(), Color.Black);
            //frm.logMainText(Environment.NewLine, Color.Black);
            //determine size of map
            int mapTotalX = currentArea.MapSizeInPixels.Width;
            int mapTotalY = currentArea.MapSizeInPixels.Height;
            //frm.logMainText("mapTotalX = " + mapTotalX.ToString() + "  mapTotalY = " + mapTotalY.ToString(), Color.Black);
            //frm.logMainText(Environment.NewLine, Color.Black);
            //determine what should be the upper left square
            int leftSquareX = pcx - (rpx / 2);
            int leftSquareY = pcy - (rpy / 2);
            //frm.logMainText("leftSquareX = " + leftSquareX.ToString() + "  leftSquareY = " + leftSquareY.ToString(), Color.Black);
            //frm.logMainText(Environment.NewLine, Color.Black);
            //determine the upper most left pixel of upper left square
            //if less than (0,0), then set to (0,0)
            upperLeftPixel.X = leftSquareX * _squareSize;
            if (upperLeftPixel.X < 0) { upperLeftPixel.X = 0; }
            upperLeftPixel.Y = leftSquareY * _squareSize;
            if (upperLeftPixel.Y < 0) { upperLeftPixel.Y = 0; }
            //shift map so that centers around the PC icon
            if (upperLeftPixel.X > (mapTotalX - renderPanel.Width)) { upperLeftPixel.X = (mapTotalX - renderPanel.Width); }
            if (upperLeftPixel.Y > (mapTotalY - renderPanel.Height)) { upperLeftPixel.Y = (mapTotalY - renderPanel.Height); }
            //if pictureBox is larger than map size then place map starting at (0,0)
            if (renderPanel.Width > mapTotalX) { upperLeftPixel.X = 0; }
            if (renderPanel.Height > mapTotalY) { upperLeftPixel.Y = 0; }
            //frm.logMainText("upperLeftPixel.X = " + upperLeftPixel.X.ToString() + "  upperLeftPixel.Y = " + upperLeftPixel.Y.ToString(), Color.Black);
            //frm.logMainText(Environment.NewLine, Color.Black);
            return upperLeftPixel;
        }        */
        /*public void AreaCombatUpdate()
        {
            //setCombatSpriteToAnimate();
        }*/
        /*
        private void SetCombatSpriteToAnimate()
        {
            foreach (Creature crt in currentArea.AreaCreatureList.creatures)
            {
                if (currentArea.TileMapList[crt.MapLocation.Y * this.currentArea.MapSizeInSquares.Width + crt.MapLocation.X].visible == true)
                {
                    crt.Visible = true;
                }
                else
                {
                    crt.Visible = false;
                }
            }
            foreach (Prop prp in currentArea.AreaPropList.propsList)
            {
                if (currentArea.TileMapList[prp.Location.Y * this.currentArea.MapSizeInSquares.Width + prp.Location.X].visible == true)
                {
                    prp.Visible = true;
                }
                else
                {
                    prp.Visible = false;
                }
            }
        }        
        public void initializeCombatGraphics(PictureBox pbc)
        {
            gc_device = null;
            gc_surface = null;
            gc_pb = null;

            //create a picturebox
            gc_pb = pbc;

            //create graphics device
            gc_surface = new Bitmap(currentCombatMapBitmap.Width, currentCombatMapBitmap.Height);
            gc_pb.Image = gc_surface;
            gc_device = Graphics.FromImage(gc_surface);

            try
            {
                g_blackTile = new Bitmap("data\\graphics\\blackTile.png");
                g_walkPass = new Bitmap("data\\graphics\\walkPass.png");
                g_walkBlock = new Bitmap("data\\graphics\\walkBlock.png");
                g_LoSBlock = new Bitmap("data\\graphics\\LoSBlock.png");
                g_pcDead = new Bitmap("data\\graphics\\pcDead.png");
                g_hitSymbol = new Bitmap("data\\graphics\\hitSymbol.png");
                g_facingUp = new Bitmap("data\\graphics\\facingUp.png");
                g_facingUpRight = new Bitmap("data\\graphics\\facingUpRight.png");
                g_facingRight = new Bitmap("data\\graphics\\facingRight.png");
                g_facingDownRight = new Bitmap("data\\graphics\\facingDownRight.png");
                g_facingDown = new Bitmap("data\\graphics\\facingDown.png");
                g_facingDownLeft = new Bitmap("data\\graphics\\facingDownLeft.png");
                g_facingLeft = new Bitmap("data\\graphics\\facingLeft.png");
                g_facingUpLeft = new Bitmap("data\\graphics\\facingUpLeft.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load basic tile images: " + ex.ToString());
                this.errorLog(ex.ToString());
            }
        }
        public void UpdateCombat()
        {
            //refresh the drawing surface
            gc_pb.Image = gc_surface;
        }
        public void areaCombatUpdate()
        {
            // grab image from stored bitmap
            Rectangle frame = new Rectangle(0, 0, currentCombatMapBitmap.Width, currentCombatMapBitmap.Height);
            Rectangle target = new Rectangle(0, 0, currentCombatMapBitmap.Width, currentCombatMapBitmap.Height);
            gc_device.DrawImage((Image)currentCombatMapBitmap, target, frame, GraphicsUnit.Pixel);
            
            drawCombatCreatures();
            drawCombatProps();
            currentCombatBackPropsMapBitmap = (Bitmap)gc_surface.Clone();
            drawCombatGrid();
            currentCombatBackPropsGridMapBitmap = (Bitmap)gc_surface.Clone();
            //drawCombatTilemap();
        }        
        private void drawCombatCreatures()
        {
            foreach (Creature crt in currentEncounter.EncounterCreatureList.creatures)
            {
                try
                {
                    //draw all the prop sprites that are static
                    //target location
                    Rectangle target = new Rectangle(crt.CombatLocation.X * _squareSize, crt.CombatLocation.Y * _squareSize, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                    //source image
                    Rectangle frame = new Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height); //draw first frame as the static sprite
                    //draw sprite using static frame
                    using (Bitmap bframe = crt.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
                    {
                        RotateFlipCmbCreature(bframe, crt);
                        //gc_device.DrawImage((Image)crt.CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                        gc_device.DrawImage((Image)bframe, target, frame, GraphicsUnit.Pixel);
                    }
                    if (this.com_showFacing)
                    {
                        if (crt.CombatFacing == CharBase.facing.Up) { gc_device.DrawImage(g_facingUp, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.UpRight) { gc_device.DrawImage(g_facingUpRight, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.Right) { gc_device.DrawImage(g_facingRight, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.DownRight) { gc_device.DrawImage(g_facingDownRight, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.Down) { gc_device.DrawImage(g_facingDown, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.DownLeft) { gc_device.DrawImage(g_facingDownLeft, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.Left) { gc_device.DrawImage(g_facingLeft, target, frame, GraphicsUnit.Pixel); }
                        else if (crt.CombatFacing == CharBase.facing.UpLeft) { gc_device.DrawImage(g_facingUpLeft, target, frame, GraphicsUnit.Pixel); }
                        else { } //didn't find one
                    }
                }
                catch (OutOfMemoryException)
                {
                    //MessageBox.Show("This PC/Creature's sprite sheet size does not match the number of animation frames chosen in the sprite file");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Drawing Creature: " + ex.ToString());
                    this.errorLog(ex.ToString());
                }
            }
        }
        private void drawCombatProps()
        {
            foreach (Prop prp in currentEncounter.EncounterPropList.propsList)
            {
                //draw all the prop sprites that are static
                //target location
                Rectangle target = new Rectangle(prp.Location.X * _squareSize, prp.Location.Y * _squareSize, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height);
                //source image
                Rectangle frame = new Rectangle(0, 0, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height); //draw first frame as the static sprite
                //draw sprite using static frame
                gc_device.DrawImage((Image)prp.PropSprite.Image, target, frame, GraphicsUnit.Pixel);
            }
        }
        private void drawCombatGrid()
        {
            if (com_showGrid) //if show grid is turned on, draw grid squares
            {
                for (int x = 0; x < this.currentCombatArea.MapSizeInSquares.Width; x++)
                {
                    for (int y = 0; y < this.currentCombatArea.MapSizeInSquares.Height; y++)
                    {
                        if (currentCombatArea.TileMapList[y * this.currentCombatArea.MapSizeInSquares.Width + x].LoSBlocked)
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            gc_device.DrawImage(g_LoSBlock, target, src, GraphicsUnit.Pixel);
                        }
                        if (currentCombatArea.TileMapList[y * this.currentCombatArea.MapSizeInSquares.Width + x].collidable)
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            gc_device.DrawImage(g_walkBlock, target, src, GraphicsUnit.Pixel);
                        }
                        else
                        {
                            Rectangle src = new Rectangle(0, 0, _squareSize, _squareSize);
                            int dx = x * _squareSize;
                            int dy = y * _squareSize;
                            Rectangle target = new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize);
                            gc_device.DrawImage(g_walkPass, target, src, GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }
        public void spriteCreatureCombatDraw(int spx, int spy, Creature crt, int frameIndex, int rowIndex, int sleep)
        {
            try
            {
                //source image
                Rectangle frame = new Rectangle((frameIndex * crt.CharSprite.SpriteSize.Width), 
                                                 crt.CharSprite.SpriteSize.Height * rowIndex, 
                                                 crt.CharSprite.SpriteSize.Width, 
                                                 crt.CharSprite.SpriteSize.Height);
                //target location
                Rectangle target = new Rectangle(spx, spy, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
                //draw sprite
                using (Bitmap bframe = crt.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
                {
                    RotateFlipCmbCreature(bframe, crt);
                    gc_device.DrawImage((Image)bframe, target, new Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height), GraphicsUnit.Pixel);
                }
                UpdateCombat();
                Application.DoEvents();
                Thread.Sleep(sleep);
            }
            catch (OutOfMemoryException)
            {
                //MessageBox.Show("This PC/Creature's sprite sheet size does not match the number of animation frames chosen in the sprite file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Drawing Creature: " + ex.ToString());
                this.errorLog(ex.ToString());
            }
        }
        public void spriteEraseCreatureCombatDraw(int spx, int spy, Creature crt)
        {
            //source image
            Rectangle frame = new Rectangle(spx, spy, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx, spy, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
            //draw sprite
            gc_device.DrawImage((Image)currentCombatMapBitmap, target, frame, GraphicsUnit.Pixel);
        }
        public void spritePcCombatDraw(int spx, int spy, int spriteListIndex)
        {
            PC pc_pt = new PC();
            pc_pt.passRefs(this, null);
            pc_pt = playerList.PCList[spriteListIndex];
            //source image
            Rectangle frame = new Rectangle(0, 0, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx, spy, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //draw sprite
            using (Bitmap bframe = pc_pt.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
            {
                RotateFlipCmbPC(bframe, pc_pt);
                //gc_device.DrawImage(playerList.PCList[spriteListIndex].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                gc_device.DrawImage((Image)bframe, target, frame, GraphicsUnit.Pixel);
            }            
            //draw a dead overlay on dead PCs            
            if (pc_pt.Status == PC.charStatus.Dead)
            {
                gc_device.DrawImage(g_pcDead, target, frame, GraphicsUnit.Pixel);
            }
            if (this.com_showFacing)
            {
                if (pc_pt.CombatFacing == CharBase.facing.Up) { gc_device.DrawImage(g_facingUp, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.UpRight) { gc_device.DrawImage(g_facingUpRight, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.Right) { gc_device.DrawImage(g_facingRight, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.DownRight) { gc_device.DrawImage(g_facingDownRight, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.Down) { gc_device.DrawImage(g_facingDown, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.DownLeft) { gc_device.DrawImage(g_facingDownLeft, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.Left) { gc_device.DrawImage(g_facingLeft, target, frame, GraphicsUnit.Pixel); }
                else if (pc_pt.CombatFacing == CharBase.facing.UpLeft) { gc_device.DrawImage(g_facingUpLeft, target, frame, GraphicsUnit.Pixel); }
                else { } //didn't find one
            }
        }
        public void spritePcCombatDraw(int spx, int spy, PC pc, int frameIndex, int rowIndex, int sleep)
        {
            //PC pc_pt = playerList.PCList[spriteListIndex];
            //source image
            Rectangle frame = new Rectangle((frameIndex * _squareSize), pc.CharSprite.SpriteSize.Height * rowIndex, pc.CharSprite.SpriteSize.Width, pc.CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx, spy, pc.CharSprite.SpriteSize.Width, pc.CharSprite.SpriteSize.Height);
            //draw sprite
            using (Bitmap bframe = pc.CharSprite.Image.Clone(frame, PixelFormat.Format32bppPArgb))
            {
                RotateFlipCmbPC(bframe, pc);
                //gc_device.DrawImage(playerList.PCList[spriteListIndex].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                gc_device.DrawImage((Image)bframe, target, new Rectangle(0,0,_squareSize,_squareSize), GraphicsUnit.Pixel);
                //gc_device.DrawImage((Image)bframe, target, frame, GraphicsUnit.Pixel);
            }
            UpdateCombat();
            Application.DoEvents();
            Thread.Sleep(sleep);
        }
        public void spriteErasePcCombatDraw(int spx, int spy, int spriteListIndex)
        {
            //source image
            Rectangle frame = new Rectangle(spx, spy, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(spx, spy, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Width, playerList.PCList[spriteListIndex].CharSprite.SpriteSize.Height);
            //draw sprite
            gc_device.DrawImage((Image)currentCombatMapBitmap, target, frame, GraphicsUnit.Pixel);
        }
        public void spriteCombatDraw(int cspx, int cspy, int spriteListIndex)
        {
            //source image
            Rectangle frame = new Rectangle(0, 0, spriteCombatList[spriteListIndex].SpriteSize.Width, spriteCombatList[spriteListIndex].SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(cspx, cspy, spriteCombatList[spriteListIndex].SpriteSize.Width, spriteCombatList[spriteListIndex].SpriteSize.Height);
            //draw sprite
            gc_device.DrawImage(spriteCombatList[spriteListIndex].Image, target, frame, GraphicsUnit.Pixel);
        }
        public void spriteCombatTurnSelectorDraw(int cspx, int cspy)
        {
            //source image
            Rectangle frame = new Rectangle(0, 0, combatTurnSelectionIcon.SpriteSize.Width, combatTurnSelectionIcon.SpriteSize.Height);
            //target location
            Rectangle target = new Rectangle(cspx, cspy, combatTurnSelectionIcon.SpriteSize.Width, combatTurnSelectionIcon.SpriteSize.Height);
            //draw sprite
            gc_device.DrawImage(combatTurnSelectionIcon.Image, target, frame, GraphicsUnit.Pixel);
        }
        public void drawHitSymbol(int gridx, int gridy)
        {
            //source image
            Rectangle frame = new Rectangle(0, 0, _squareSize, _squareSize);
            //target location
            Rectangle target = new Rectangle(gridx * _squareSize, gridy * _squareSize, _squareSize, _squareSize);
            gc_device.DrawImage(g_hitSymbol, target, frame, GraphicsUnit.Pixel);
        }
        public void drawSelectionBox(int gridx, int gridy, int radius)
        {            
            //draw selection box around tile
            int dx = gridx * _squareSize - _squareSize * radius;
            int dy = gridy * _squareSize - _squareSize * radius;
            int dia = (radius * _squareSize * 2 + _squareSize) - 2;
            Pen pen = new Pen(Color.DarkMagenta, 2);
            Rectangle rect = new Rectangle(dx + 1, dy + 1, dia, dia);
            gc_device.DrawRectangle(pen, rect);
        }
        public void drawProjectileBitmap(int projx, int projy, float ang, int frameIndex, int sleep)
        {
            Bitmap projFrame = currentFrame(frameIndex);
            projFrame = rotateImage(projFrame, ang);
            //source image
            //Rectangle frame = new Rectangle((frameIndex * _squareSize), 0, _squareSize, _squareSize);
            Rectangle frame = new Rectangle(0, 0, _squareSize, _squareSize);
            //target location
            Rectangle target = new Rectangle(projx - (_squareSize / 2), projy - (_squareSize / 2), _squareSize, _squareSize);
            //draw sprite
            gc_device.DrawImage((Image)projFrame, target, frame, GraphicsUnit.Pixel);       
            Application.DoEvents();
            Thread.Sleep(sleep);
            //projFrame.Dispose();
        }
        public void eraseProjectileBitmap(int projx, int projy)
        {
            //source image
            Rectangle frame = new Rectangle(projx - (_squareSize / 2), projy - (_squareSize / 2), _squareSize, _squareSize);
            //target location
            Rectangle target = new Rectangle(projx - (_squareSize / 2), projy - (_squareSize / 2), _squareSize, _squareSize);
            //draw sprite
            gc_device.DrawImage((Image)currentCombatMapSnapshotBitmap, target, frame, GraphicsUnit.Pixel);
        }
        public void drawEndEffectBitmap(int CornerX, int CornerY, int frameWidth, int frameHeight, int frameIndex, int sleep)
        {
            Bitmap effectFrame = currentEndEffectFrame(frameIndex, frameWidth, frameHeight);
            //source image
            Rectangle frame = new Rectangle(0, 0, frameWidth, frameHeight);
            //target location
            Rectangle target = new Rectangle(CornerX, CornerY, frameWidth, frameHeight);
            //draw sprite
            gc_device.DrawImage((Image)effectFrame, target, frame, GraphicsUnit.Pixel);
            Application.DoEvents();
            Thread.Sleep(sleep);
        }
        public void eraseEndEffectBitmap(int CornerX, int CornerY, int frameWidth, int frameHeight)
        {
            //source image
            Rectangle frame = new Rectangle(CornerX, CornerY, frameWidth, frameHeight);
            //target location
            Rectangle target = new Rectangle(CornerX, CornerY, frameWidth, frameHeight);
            //draw sprite
            gc_device.DrawImage((Image)currentCombatMapSnapshotBitmap, target, frame, GraphicsUnit.Pixel);
        }
        public void drawMoveToSquares(PC pc, int radius)
        {
            if (com_showRange)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(50, 0, 255, 0));
                for (int x = pc.CombatLocation.X - radius; x <= pc.CombatLocation.X + radius; x++)
                {
                    for (int y = pc.CombatLocation.Y - radius; y <= pc.CombatLocation.Y + radius; y++)
                    {
                        gc_device.FillRectangle(myBrush, new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize));
                    }
                }
                myBrush.Dispose();
            }
        }
        public void drawAttackRangeSquares(PC pc, int radius)
        {
            if (com_showRange)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(50, 0, 0, 255));
                for (int x = pc.CombatLocation.X - radius; x <= pc.CombatLocation.X + radius; x++)
                {
                    for (int y = pc.CombatLocation.Y - radius; y <= pc.CombatLocation.Y + radius; y++)
                    {
                        gc_device.FillRectangle(myBrush, new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize));
                    }
                }
                myBrush.Dispose();
            }
        }
        public void drawCrtMoveToSquares(Creature crt, int radius)
        {
            if (com_showRange)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(50, 255, 0, 0));
                for (int x = crt.CombatLocation.X - radius; x <= crt.CombatLocation.X + radius; x++)
                {
                    for (int y = crt.CombatLocation.Y - radius; y <= crt.CombatLocation.Y + radius; y++)
                    {
                        gc_device.FillRectangle(myBrush, new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize));
                    }
                }
                myBrush.Dispose();
            }
        }
        public void drawCrtAttackRangeSquares(Creature crt, int radius)
        {
            if (com_showRange)
            {
                System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Color.FromArgb(50, 255, 255, 0));
                for (int x = crt.CombatLocation.X - radius; x <= crt.CombatLocation.X + radius; x++)
                {
                    for (int y = crt.CombatLocation.Y - radius; y <= crt.CombatLocation.Y + radius; y++)
                    {
                        gc_device.FillRectangle(myBrush, new Rectangle(x * _squareSize, y * _squareSize, _squareSize, _squareSize));
                    }
                }
                myBrush.Dispose();
            }
        }
        */
        /*
        Bitmap returnBitmap;
        Bitmap returnFrameBitmap;
        Bitmap returnEndEffectFrameBitmap;
        
        /// <summary>
        /// Calculates angle in radians between two points and x-axis.
        /// Pay attention: changing the sign of Y-coordinates causes a
        /// transformation of the fourth to the first quadrant because
        /// .NET coordinate system is not the same as mathematical ones.
        /// </summary>
        public float Angle(Point start, Point end)
        {
            return (float)(-1 * ((Math.Atan2(start.Y - end.Y, end.X - start.X) * Rad2Deg) - 90));
        }
        private Bitmap currentFrame(int frameIndex)
        {
            //create a new empty bitmap to hold rotated image
            if (returnFrameBitmap != null)
            {
                returnFrameBitmap.Dispose();
                returnFrameBitmap = null;
            }
            if (returnFrameBitmap == null)
            {
                returnFrameBitmap = new Bitmap(_squareSize, _squareSize);
            }
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnFrameBitmap))
            {
                Rectangle frame = new Rectangle((frameIndex * _squareSize), 0, _squareSize, _squareSize);
                Rectangle target = new Rectangle(0, 0, _squareSize, _squareSize);
                g.DrawImage(currentCombatProjectileSprite.Image, target, frame, GraphicsUnit.Pixel);
            }
            return returnFrameBitmap;
        }
        private Bitmap currentEndEffectFrame(int frameIndex, int frameWidth, int frameHeight)
        {
            //create a new empty bitmap to hold rotated image
            if (returnEndEffectFrameBitmap != null)
            {
                returnEndEffectFrameBitmap.Dispose();
                returnEndEffectFrameBitmap = null;
            }
            if (returnEndEffectFrameBitmap == null)
            {
                returnEndEffectFrameBitmap = new Bitmap(frameWidth, frameHeight);
            }
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnEndEffectFrameBitmap))
            {
                Rectangle frame = new Rectangle((frameIndex * frameWidth), 0, frameWidth, frameHeight);
                Rectangle target = new Rectangle(0, 0, frameWidth, frameHeight);
                g.DrawImage(currentCombatEndEffectSprite.Image, target, frame, GraphicsUnit.Pixel);
            }
            return returnEndEffectFrameBitmap;
        }
        private Bitmap rotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            if (returnBitmap != null)
            {
                returnBitmap.Dispose();
                returnBitmap = null;
            }
            if (returnBitmap == null)
            {
                returnBitmap = new Bitmap(b.Width, b.Height);
            }
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
        */
        #endregion

        #region Animation Stuff
        [XmlIgnore]
        private int renderCalls = 0;
        [XmlIgnore]
        private long time = 0;
        [XmlIgnore]
        public List<string> requestRenderingList = new List<string>();

        public int GetFPS()
        {
            if (renderCalls != 0 && DateTime.Now.Ticks != time)
            {
                int result = Convert.ToInt32(10000000 / ((DateTime.Now.Ticks - time) / renderCalls));
                renderCalls = 0;
                return result;
            }
            else return 0;
        }
        public void RenderingLoop()
        {
            //used to calculate FPS as a performance monitor
            if (renderCalls == 0)
                time = DateTime.Now.Ticks;
            renderCalls++;
            //did we have any request in a meantime?
//            if (requestRenderingList.Count > 0)
//            {
                //use sprite as clip
//                RenderEachClipped();
//            }
        }        
        public void RenderEachClipped()
        {           
            #region PROPS
            //draw clips for erase
            for (int count = 0; count < currentArea.AreaPropList.propsList.Count; count++)
            {
                if (requestRenderingList.Contains(currentArea.AreaPropList.propsList[count].PropTag))
                {
                    //need to get sprite location and then subtract the shift from origin
                    Point offsetSpritePixelLocation = new Point(0, 0);
                    offsetSpritePixelLocation.X = (currentArea.AreaPropList.propsList[count].Location.X * _squareSize) - upperLeftPixel.X;
                    offsetSpritePixelLocation.Y = (currentArea.AreaPropList.propsList[count].Location.Y * _squareSize) - upperLeftPixel.Y;
                    //source image
                    Rectangle frame = new Rectangle(currentArea.AreaPropList.propsList[count].Location.X * _squareSize, 
                                                    currentArea.AreaPropList.propsList[count].Location.Y * _squareSize, 
                                                    currentArea.AreaPropList.propsList[count].PropSprite.SpriteSize.Width, 
                                                    currentArea.AreaPropList.propsList[count].PropSprite.SpriteSize.Height);
                    //target location
                    Rectangle target = new Rectangle(offsetSpritePixelLocation.X, offsetSpritePixelLocation.Y,
                                                    currentArea.AreaPropList.propsList[count].PropSprite.SpriteSize.Width, 
                                                    currentArea.AreaPropList.propsList[count].PropSprite.SpriteSize.Height);
                    //erase sprite
                    //if (frm_showGrid)
                    //{
                        g_device.DrawImage((Image)currentBackMapFoWPropsBitmap, target, frame, GraphicsUnit.Pixel);
                    //}
                    //else
                    //{
                    //    g_device.DrawImage((Image)currentBackMapBitmap, target, frame, GraphicsUnit.Pixel);
                    //}
                }
            }
            //draw next frame
            for (int count = 0; count < currentArea.AreaPropList.propsList.Count; count++)
            {
                if (requestRenderingList.Contains(currentArea.AreaPropList.propsList[count].PropTag))
                {
                    Prop prp = currentArea.AreaPropList.propsList[count];
                    Point offsetSpritePixelLocation = new Point(0, 0);
                    offsetSpritePixelLocation.X = (prp.Location.X * _squareSize) - upperLeftPixel.X;
                    offsetSpritePixelLocation.Y = (prp.Location.Y * _squareSize) - upperLeftPixel.Y;
                    //target location
                    Rectangle target = new Rectangle(offsetSpritePixelLocation.X, 
                                                    offsetSpritePixelLocation.Y,
                                                    prp.PropSprite.SpriteSize.Width, 
                                                    prp.PropSprite.SpriteSize.Height);
                    //source image
                    Rectangle frame = new Rectangle(prp.PropSprite.oSourceRect.X, 
                                                    prp.PropSprite.oSourceRect.Y, 
                                                    prp.PropSprite.SpriteSize.Width, 
                                                    prp.PropSprite.SpriteSize.Height);
                    //draw sprite next frame
                    g_device.DrawImage((Image)currentArea.AreaPropList.propsList[count].PropSprite.Image, target, frame, GraphicsUnit.Pixel);
                    //if Player is here, draw player on top
                    if ((playerPosition.X == prp.Location.X) && (playerPosition.Y == prp.Location.Y))                    
                    //if (isOnAnimatedProp(prp))
                    {
                        //source image
                        frame = new Rectangle(0, 0, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height);
                        target = new Rectangle(offsetSpritePixelLocation.X,
                                               offsetSpritePixelLocation.Y,
                                               playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width,
                                               playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height);
                        g_device.DrawImage(playerList.PCList[selectedPartyLeader].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                    }
                }
            }
            //spriteErasePcDraw(playerPosition.X * _squareSize, playerPosition.Y * _squareSize, 0);
            //Point offsetPcSpritePixelLocation = new Point(0, 0);
            //offsetPcSpritePixelLocation.X = (playerPosition.X * _squareSize) - upperLeftPixel.X;
            //offsetPcSpritePixelLocation.Y = (playerPosition.Y * _squareSize) - upperLeftPixel.Y;
            //spritePcDraw(offsetPcSpritePixelLocation.X * _squareSize, offsetPcSpritePixelLocation.Y * _squareSize, 0);
            #endregion

            #region CREATURES
            //draw clips for erase
            for (int count = 0; count < currentArea.AreaCreatureList.creatures.Count; count++)
            {
                if (requestRenderingList.Contains(currentArea.AreaCreatureList.creatures[count].Tag))
                {
                    Creature crt = currentArea.AreaCreatureList.creatures[count];
                    //need to get sprite location and then subtract the shift from origin
                    Point offsetSpritePixelLocation = new Point(0, 0);
                    offsetSpritePixelLocation.X = (crt.MapLocation.X * _squareSize) - upperLeftPixel.X;
                    offsetSpritePixelLocation.Y = (crt.MapLocation.Y * _squareSize) - upperLeftPixel.Y;
                    //source image
                    Rectangle frame = new Rectangle(crt.MapLocation.X * _squareSize,
                                                    crt.MapLocation.Y * _squareSize,
                                                    crt.CharSprite.SpriteSize.Width,
                                                    crt.CharSprite.SpriteSize.Height);
                    //target location
                    Rectangle target = new Rectangle(offsetSpritePixelLocation.X, 
                                                    offsetSpritePixelLocation.Y,
                                                    crt.CharSprite.SpriteSize.Width,
                                                    crt.CharSprite.SpriteSize.Height);
                    //erase sprite
                    //if (frm_showGrid)
                    //{
                        g_device.DrawImage((Image)currentBackMapFoWPropsBitmap, target, frame, GraphicsUnit.Pixel);
                    //}
                    //else
                    //{
                    //    g_device.DrawImage((Image)currentBackMapBitmap, target, frame, GraphicsUnit.Pixel);
                    //}
                }
            }
            //draw next frame
            for (int count = 0; count < currentArea.AreaCreatureList.creatures.Count; count++)
            {
                if (requestRenderingList.Contains(currentArea.AreaCreatureList.creatures[count].Tag))
                {
                    Creature crt = currentArea.AreaCreatureList.creatures[count];
                    Point offsetSpritePixelLocation = new Point(0, 0);
                    offsetSpritePixelLocation.X = (crt.MapLocation.X * _squareSize) - upperLeftPixel.X;
                    offsetSpritePixelLocation.Y = (crt.MapLocation.Y * _squareSize) - upperLeftPixel.Y;
                    //target location
                    Rectangle target = new Rectangle(offsetSpritePixelLocation.X, 
                                                    offsetSpritePixelLocation.Y, 
                                                    crt.CharSprite.SpriteSize.Width,
                                                    crt.CharSprite.SpriteSize.Height);
                    //source image
                    Rectangle frame = new Rectangle(crt.CharSprite.oSourceRect.X, 
                                                    crt.CharSprite.oSourceRect.Y,
                                                    crt.CharSprite.SpriteSize.Width,
                                                    crt.CharSprite.SpriteSize.Height);
                    //draw sprite next frame
                    g_device.DrawImage((Image)crt.CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                    //if Player is here, draw player on top
                    if ((playerPosition.X == crt.MapLocation.X) && (playerPosition.Y == crt.MapLocation.Y))
                    {
                        //source image
                        frame = new Rectangle(0, 0, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Width, playerList.PCList[selectedPartyLeader].CharSprite.SpriteSize.Height);
                        g_device.DrawImage(playerList.PCList[selectedPartyLeader].CharSprite.Image, target, frame, GraphicsUnit.Pixel);
                    }
                }
            }
            #endregion

            //clear it up
            requestRenderingList.Clear();            
            g_pb.Image = g_surface;
        }
        public bool isOnAnimatedProp(Prop prp)
        {
            int px = prp.Location.X;
            int py = prp.Location.Y;
            for (int x = px; x < px + 5; x++)
            {
                for (int y = py; y < py + 5; y++)
                {
                    if (playerPosition == new Point(x, y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void UpdateAnimated()
        {
            if (currentArea != null)
            {
                for (int count = 0; count < currentArea.AreaPropList.propsList.Count; count++)
                {
                    if ((currentArea.AreaPropList.propsList[count].Animated) && (currentArea.AreaPropList.propsList[count].Visible))
                    {
                        if (currentArea.AreaPropList.propsList[count].PropSprite.MoveAnimation())
                        {
                            RequestPropRendering(count);
                        }
                    }
                }
                for (int count = 0; count < currentArea.AreaCreatureList.creatures.Count; count++)
                {
                    if ((currentArea.AreaCreatureList.creatures[count].Animated) && (currentArea.AreaCreatureList.creatures[count].Visible))
                    {
                        if (currentArea.AreaCreatureList.creatures[count].CharSprite.MoveAnimation())
                        {
                            RequestCreatureRendering(count);
                        }
                    }
                }
            }
        }
        public void RequestAll()
        {
            for (int count = 0; count < currentArea.AreaPropList.propsList.Count; count++)
            {
                requestRenderingList.Add(currentArea.AreaPropList.propsList[count].PropTag);
            }
            for (int count = 0; count < currentArea.AreaCreatureList.creatures.Count; count++)
            {
                requestRenderingList.Add(currentArea.AreaCreatureList.creatures[count].Tag);
            }
        }
        public bool RequestPropRendering(int index)
        {
            if (requestRenderingList.Contains(currentArea.AreaPropList.propsList[index].PropTag))
            {
                return false;
            }
            requestRenderingList.Add(currentArea.AreaPropList.propsList[index].PropTag);
            return true;
        }
        public bool RequestCreatureRendering(int index)
        {
            if (requestRenderingList.Contains(currentArea.AreaCreatureList.creatures[index].Tag))
            {
                return false;
            }
            requestRenderingList.Add(currentArea.AreaCreatureList.creatures[index].Tag);
            return true;
        }
        public void RenderCreatureSpriteStatic(Creature crt)
        {
            //target location
            Rectangle target = new Rectangle(crt.MapLocation.X * _squareSize, crt.MapLocation.Y * _squareSize, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height);
            //source image
            Rectangle frame = new Rectangle(0, 0, crt.CharSprite.SpriteSize.Width, crt.CharSprite.SpriteSize.Height); //draw first frame as the static sprite
            //draw sprite using static frame
            g_device.DrawImage((Image)crt.CharSprite.Image, target, frame, GraphicsUnit.Pixel);                
        }
        public void RenderPropSpriteStatic(Prop prp)
        {
            //target location
            Rectangle target = new Rectangle(prp.Location.X * _squareSize, prp.Location.Y * _squareSize, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height);
            //source image
            Rectangle frame = new Rectangle(0, 0, prp.PropSprite.SpriteSize.Width, prp.PropSprite.SpriteSize.Height); //draw first frame as the static sprite
            //draw sprite using static frame
            g_device.DrawImage((Image)prp.PropSprite.Image, target, frame, GraphicsUnit.Pixel);
        }
        #endregion
    }

    public class TexturePair
    {
        private string filename;
        private Texture texture;

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        public Texture Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public TexturePair()
        {            
        }
    }
}

