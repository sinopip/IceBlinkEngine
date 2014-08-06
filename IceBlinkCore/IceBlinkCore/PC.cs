using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using IceBlink;
using System.IO;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class PCs
    {
        [XmlArrayItem("PlayerCharacters")]
        public List<PC> PCList = new List<PC>();
        [XmlIgnore]
        public Game game;

        public PCs()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void savePCsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PCs));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save PCs file. Error: " + ex.Message);
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
        public PCs loadPCsFile(string filename)
        {
            PCs toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(PCs));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (PCs)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml PCs file. Error:\n{0}", ex.Message);
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
    }

    [Serializable]
    public class PC : CharBase
    {
        [XmlIgnore]
        public Bitmap portraitBitmapG;
        [XmlIgnore]
        public Bitmap portraitBitmapM;
        [XmlIgnore]
        public Bitmap portraitBitmapS;
        [XmlElement]
        public string PortraitFileG = "blank.png"; //portrait filename
        [XmlElement]
        public string PortraitFileM = "blank.png"; //portrait filename
        [XmlElement]
        public string PortraitFileS = "blank.png"; //portrait filename
        [XmlElement]
        public int XP = 0;
        [XmlElement]
        public int XPNeeded = 0;        

        public PC() : base()
        {
            this.OnAttack.FilenameOrTag = "pcOnAttack.cs";
            this.OnDeath.FilenameOrTag = "pcOnDeath.cs";
            this.OnEndCombatTurn.FilenameOrTag = "pcOnEndCombatTurn.cs";
            this.OnHeartBeat.FilenameOrTag = "pcOnHeartBeat.cs";
            this.OnHit.FilenameOrTag = "pcOnHit.cs";
            this.OnPerception.FilenameOrTag = "pcOnPerception.cs";
            this.OnStartCombatTurn.FilenameOrTag = "pcOnStartCombatTurn.cs";
        }
        public void passRefs(ParentForm pf)
        {
            this.OnAttack.prntForm = pf;
            this.OnDeath.prntForm = pf;
            this.OnEndCombatTurn.prntForm = pf;
            this.OnHeartBeat.prntForm = pf;
            this.OnHit.prntForm = pf;
            this.OnPerception.prntForm = pf;
            this.OnStartCombatTurn.prntForm = pf;
        }
        public void savePCFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(PC));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save PC file. Error: " + ex.Message);
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
        public PC loadPCFile(string filename)
        {
            PC toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(PC));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (PC)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml PC file. Error:\n{0}", ex.Message);
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
        public Bitmap LoadCharacterPortraitBitmapG(string filename)
        {
            // Sets up an image object to be displayed.
            if (portraitBitmapG != null)
            {
                portraitBitmapG.Dispose();
            }
            portraitBitmapG = new Bitmap(filename);
            return portraitBitmapG;
        }
        public Bitmap LoadCharacterPortraitBitmapM(string filename)
        {
            // Sets up an image object to be displayed.
            if (portraitBitmapM != null)
            {
                portraitBitmapM.Dispose();
            }
            portraitBitmapM = new Bitmap(filename);
            return portraitBitmapM;
        }
        public Bitmap LoadCharacterPortraitBitmapS(string filename)
        {
            // Sets up an image object to be displayed.
            if (portraitBitmapS != null)
            {
                portraitBitmapS.Dispose();
            }
            portraitBitmapS = new Bitmap(filename);
            return portraitBitmapS;
        }
        public void LoadAllPortraits(string moduleFolderPath)
        {
            if (File.Exists(moduleFolderPath + "\\portraits\\" + this.PortraitFileL))
            {
                if (portraitBitmapL != null)
                {
                    portraitBitmapL.Dispose();
                }
                portraitBitmapL = new Bitmap(moduleFolderPath + "\\portraits\\" + this.PortraitFileL);
            }
            else if (File.Exists(game.mainDirectory + "\\portraits\\" + this.PortraitFileL))
            {
                if (portraitBitmapL != null)
                {
                    portraitBitmapL.Dispose();
                }
                portraitBitmapL = new Bitmap(game.mainDirectory + "\\portraits\\" + this.PortraitFileL);
            }
            else
            {
                MessageBox.Show("failed to load portraits in LoadAllPortraits()");
                game.errorLog("failed to load portraits in LoadAllPortraits()...failed to load the following portrait: " + this.PortraitFileL);
            }
        }
        public Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            //a holder for the result
            Bitmap result = new Bitmap(width, height);
            // set the resolutions the same to avoid cropping due to resolution differences
            result.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //use a graphics object to draw the resized image into the bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                //set the resize quality modes to high quality
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //draw the image into the target bitmap
                graphics.DrawImage(image, 0, 0, result.Width, result.Height);
            }

            //return the resulting bitmap
            return result;
        }
        public void LoadAllPcStuff(string moduleFolderPath)
        {
            try
            {
                //TODO check module folder as well
                if (File.Exists(moduleFolderPath + "\\portraits\\" + this.PortraitFileL))
                {
                    //this.portraitBitmapG = this.LoadCharacterPortraitBitmapG(moduleFolderPath + "\\portraits\\" + this.PortraitFileG);
                    this.portraitBitmapL = this.LoadCharacterPortraitBitmapL(moduleFolderPath + "\\portraits\\" + this.PortraitFileL);
                    this.portraitBitmapM = ResizeImage(this.portraitBitmapL, 64, 100);
                    if (File.Exists(moduleFolderPath + "\\portraits\\" + this.PortraitFileS))
                    {
                        this.portraitBitmapS = this.LoadCharacterPortraitBitmapS(moduleFolderPath + "\\portraits\\" + this.PortraitFileS);
                    }
                    else
                    {
                        this.portraitBitmapS = ResizeImage(this.portraitBitmapL, 36, 58);
                    }
                    //this.portraitBitmapM = this.LoadCharacterPortraitBitmapM(moduleFolderPath + "\\portraits\\" + this.PortraitFileM);
                    //this.portraitBitmapS = this.LoadCharacterPortraitBitmapS(moduleFolderPath + "\\portraits\\" + this.PortraitFileS);
                    this.LoadSpriteStuff(moduleFolderPath);
                }
                else if (File.Exists(game.mainDirectory + "\\portraits\\" + this.PortraitFileL))
                {
                    //this.portraitBitmapG = this.LoadCharacterPortraitBitmapG(game.mainDirectory + "\\portraits\\" + this.PortraitFileG);
                    this.portraitBitmapL = this.LoadCharacterPortraitBitmapL(game.mainDirectory + "\\portraits\\" + this.PortraitFileL);
                    this.portraitBitmapM = ResizeImage(this.portraitBitmapL, 64, 100);
                    if (File.Exists(moduleFolderPath + "\\portraits\\" + this.PortraitFileS))
                    {
                        this.portraitBitmapS = this.LoadCharacterPortraitBitmapS(game.mainDirectory + "\\portraits\\" + this.PortraitFileS);
                    }
                    else
                    {
                        this.portraitBitmapS = ResizeImage(this.portraitBitmapL, 36, 58);
                    }                    
                    //this.portraitBitmapM = this.LoadCharacterPortraitBitmapM(game.mainDirectory + "\\portraits\\" + this.PortraitFileM);
                    //this.portraitBitmapS = this.LoadCharacterPortraitBitmapS(game.mainDirectory + "\\portraits\\" + this.PortraitFileS);
                    this.LoadSpriteStuff(moduleFolderPath);
                }
                else
                {
                    MessageBox.Show("failed to load portraits in LoadAllPortraits()");
                    game.errorLog("failed to load portraits in LoadAllPortraits()...failed to load the following portrait: " + this.PortraitFileL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to load PC stuff: " + ex.ToString());
            }
        }
        public bool IsReadyToAdvanceLevel()
        {
            XPNeeded = this.Class.XpTable[this.ClassLevel];
            if (this.XP >= XPNeeded)
            {
                return true;
            }
            return false;
        }
        public void LevelUp()
        {
            // change level by one, level++
            this.ClassLevel++;
            // UpdateStats
            this.HP += this.Class.HpPerLevelUp + ((this.Constitution - 10) / 2);
            this.SP += this.Class.SpPerLevelUp + ((this.Intelligence - 10) / 2);

            /*if (this.Class == charClass.Fighter)
            {
                this.HP += 10 + ((this.Constitution - 10) / 2);
            }
            if (this.Class == charClass.Wizard)
            {
                this.HP += 4 + ((this.Constitution - 10) / 2);
                this.SP += 20 + ((this.Intelligence - 10) / 2);
            }*/
        }
    }
}
