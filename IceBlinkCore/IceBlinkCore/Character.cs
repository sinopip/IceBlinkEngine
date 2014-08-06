using System;
using System.Collections.Generic;
using System.Xml;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using IceBlink;

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
        public int char_xp;
        [XmlElement]
        public int char_xpNeeded;
        
        public PC() : base()
        {
            char_portraitFileG = "blank.png";
            char_portraitFileM = "blank.png";
            char_portraitFileS = "blank.png";
            char_xp = 0;
            char_xpNeeded = 0;
        }

        public Bitmap LoadCharacterPortraitBitmapG (string filename)
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

        public bool IsReadyToAdvanceLevel(XPTable xpTable)
        {
            // check to see what class
            if (this.char_class == charClass.Fighter)
            {
                // check to see if current XP is greater than needed for next level
                // if so return true
                char_xpNeeded = xpTable.Fighter[this.char_classLevel];
                if (this.char_xp >= char_xpNeeded)
                {
                    return true;
                }                
            }
            if (this.char_class == charClass.Wizard)
            {
                // check to see if current XP is greater than needed for next level
                // if so return true
                char_xpNeeded = xpTable.Mage[this.char_classLevel];
                if (this.char_xp >= char_xpNeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public void LevelUp()
        {
            // change level by one, level++
            this.char_classLevel++;
            // UpdateStats
            if (this.char_class == charClass.Fighter)
            {
                this.char_hp += 10 + ((this.char_constitution - 10) / 2);
            }
            if (this.char_class == charClass.Wizard)
            {
                this.char_hp += 4 + ((this.char_constitution - 10) / 2);
                this.char_sp += 20 + ((this.char_intelligence - 10) / 2);
            }
        }
    }
}
