using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using IceBlink;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace IceBlinkCore
{
    [Serializable]
    public class Theme
    {
        [XmlIgnore]
        public Game game;

        #region Fields
        private Color titleForeColor = Color.BlueViolet;
        private Color titleShadowColor = Color.Black;
        private string titleText = "Module Title";
        private Color ibBorderOutsideColor = Color.DarkGray;
        private Color ibBorderMiddleColor = Color.Red;
        private Color ibBorderInsideColor = Color.DimGray;
        private Color groupBoxBackGroundColor = Color.LightSlateGray;
        private Color groupBoxBorderColor = Color.Red;
        private Color headerForeColor = Color.Red;
        private Color headerShadowColor = Color.Black;
        private string moduleFontName = "Arial"; // "Micorsoft Sans Serif";
        private float moduleFontPointSize = 9.0f; // 9.75f;
        private float moduleFontScale = 1.0f; // 1.0f;
        private Font moduleFont;
        private Color standardBackColor = Color.Green;
        private Color standardTextColor = Color.Black;
        private Color convoBackColor = Color.Black;
        private Color convoTextColor = Color.Red;
        private Bitmap standardThemeBitmap;
        private Bitmap standardLoadScreen;
        private Bitmap btnInventoryBitmap;
        private Bitmap btnJournalBitmap;
        private Bitmap btnSettingsBitmap;
        private Bitmap btnRestBitmap;
        private Bitmap chkGridBitmap;
        #endregion

        #region Properties
        [XmlElement]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the title of the title bar")]
        public string TitleText
        {
            get { return titleText; }
            set { titleText = value; }
        }
        
        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the title text color")]
        public Color TitleForeColor
        {
            get { return titleForeColor; }
            set { titleForeColor = value; }
        }
        
        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the title shadow color")]
        public Color TitleShadowColor
        {
            get { return titleShadowColor; }
            set { titleShadowColor = value; }
        }
        
        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the border outside color")]
        public Color IBBorderOutsideColor
        {
            get { return ibBorderOutsideColor; }
            set { ibBorderOutsideColor = value; }
        }
        
        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the border middle color")]
        public Color IBBorderMiddleColor
        {
            get { return ibBorderMiddleColor; }
            set { ibBorderMiddleColor = value; }
        }
        
        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("01 - Title Bar"), DescriptionAttribute("Gets or sets the border inside color")]
        public Color IBBorderInsideColor
        {
            get { return ibBorderInsideColor; }
            set { ibBorderInsideColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("02 - Group Box"), DescriptionAttribute("Gets or sets the groupbox background color")]
        public Color GroupBoxBackGroundColor
        {
            get { return groupBoxBackGroundColor; }
            set { groupBoxBackGroundColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("02 - Group Box"), DescriptionAttribute("Gets or sets the groupbox border color")]
        public Color GroupBoxBorderColor
        {
            get { return groupBoxBorderColor; }
            set { groupBoxBorderColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("02 - Group Box"), DescriptionAttribute("Gets or sets the groupbox header's forecolor")]
        public Color HeaderForeColor
        {
            get { return this.headerForeColor; }
            set { this.headerForeColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("02 - Group Box"), DescriptionAttribute("Gets or sets the groupbox header's shadow color")]
        public Color HeaderShadowColor
        {
            get { return this.headerShadowColor; }
            set { this.headerShadowColor = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Font"), DescriptionAttribute("Font Name (must be exact) to use as the module's default Font"), ReadOnly(true)]
        public string ModuleFontName
        {
            get { return moduleFontName; }
            set { moduleFontName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Font"), DescriptionAttribute("Font Point Size (float value) to use as the module's default Font size"), ReadOnly(true)]
        public float ModuleFontPointSize
        {
            get { return moduleFontPointSize; }
            set { moduleFontPointSize = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Font"), DescriptionAttribute("Font scale for floaty text")]
        public float ModuleFontScale
        {
            get { return moduleFontScale; }
            set { moduleFontScale = value; }
        }

        [XmlIgnore]
        [CategoryAttribute("03 - Font"), DescriptionAttribute("Font to use as the module's default Font")]
        public Font ModuleFont
        {
            get { return moduleFont; }
            set 
            { 
                moduleFont = value;
                ModuleFontName = value.Name;
                ModuleFontPointSize = value.Size;
            }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("04 - Standard Panels"), DescriptionAttribute("Gets or sets the back color for most panels")]
        public Color StandardBackColor
        {
            get { return this.standardBackColor; }
            set { this.standardBackColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("04 - Standard Panels"), DescriptionAttribute("Gets or sets the text color for most panels")]
        public Color StandardTextColor
        {
            get { return this.standardTextColor; }
            set { this.standardTextColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("05 - Conversation Panels"), DescriptionAttribute("Gets or sets the back color for convo panels")]
        public Color ConvoBackColor
        {
            get { return this.convoBackColor; }
            set { this.convoBackColor = value; }
        }

        [XmlElement(Type = typeof(XmlColor))]
        [CategoryAttribute("05 - Conversation Panels"), DescriptionAttribute("Gets or sets the text color for convo panels")]
        public Color ConvoTextColor
        {
            get { return this.convoTextColor; }
            set { this.convoTextColor = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public Bitmap StandardThemeBitmap
        {
            get { return standardThemeBitmap; }
            set { standardThemeBitmap = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public Bitmap StandardLoadScreen
        {
            get { return standardLoadScreen; }
            set { standardLoadScreen = value; }
        }
        
        [XmlIgnore]
        [Browsable(false)]
        public Bitmap BtnInventoryBitmap
        {
            get { return btnInventoryBitmap; }
            set { btnInventoryBitmap = value; }
        }
        
        [XmlIgnore]
        [Browsable(false)]
        public Bitmap BtnJournalBitmap
        {
            get { return btnJournalBitmap; }
            set { btnJournalBitmap = value; }
        }
        
        [XmlIgnore]
        public Bitmap BtnSettingsBitmap
        {
            get { return btnSettingsBitmap; }
            set { btnSettingsBitmap = value; }
        }

        [XmlIgnore]
        [Browsable(false)]
        public Bitmap BtnRestBitmap
        {
            get { return btnRestBitmap; }
            set { btnRestBitmap = value; }
        }
        
        [XmlIgnore]
        [Browsable(false)]
        public Bitmap ChkGridBitmap
        {
            get { return chkGridBitmap; }
            set { chkGridBitmap = value; }
        }
        #endregion

        public Theme()
        {
           this.ModuleFont = new Font(this.ModuleFontName, this.ModuleFontPointSize, FontStyle.Regular);
        }
        public void passRefs(Game g)
        {
            game = g;
        }

        public Bitmap LoadStandardThemeBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (standardThemeBitmap != null)
            {
                standardThemeBitmap.Dispose();
            }
            using (Bitmap bitmap2 = new Bitmap(filename))
            {
                standardThemeBitmap = bitmap2.Clone(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), PixelFormat.Format32bppPArgb);
            }
            //standardThemeBitmap = new Bitmap(filename);
            return standardThemeBitmap;
        }
        public Bitmap LoadStandardLoadScreen(string filename)
        {
            // Sets up an image object to be displayed.
            if (standardLoadScreen != null)
            {
                standardLoadScreen.Dispose();
            }
            using (Bitmap bitmap2 = new Bitmap(filename))
            {
                standardLoadScreen = bitmap2.Clone(new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), PixelFormat.Format32bppPArgb);
            }
            //standardThemeBitmap = new Bitmap(filename);
            return standardLoadScreen;
        }
        public Bitmap LoadBtnInventoryBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (btnInventoryBitmap != null)
            {
                btnInventoryBitmap.Dispose();
            }
            btnInventoryBitmap = new Bitmap(filename);
            return btnInventoryBitmap;
        }
        public Bitmap LoadBtnJournalBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (btnJournalBitmap != null)
            {
                btnJournalBitmap.Dispose();
            }
            btnJournalBitmap = new Bitmap(filename);
            return btnJournalBitmap;
        }
        public Bitmap LoadBtnSettingsBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (btnSettingsBitmap != null)
            {
                btnSettingsBitmap.Dispose();
            }
            btnSettingsBitmap = new Bitmap(filename);
            return btnSettingsBitmap;
        }
        public Bitmap LoadBtnRestBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (btnRestBitmap != null)
            {
                btnRestBitmap.Dispose();
            }
            btnRestBitmap = new Bitmap(filename);
            return btnRestBitmap;
        }
        public Bitmap LoadChkGridBitmap(string filename)
        {
            // Sets up an image object to be displayed.
            if (chkGridBitmap != null)
            {
                chkGridBitmap.Dispose();
            }
            chkGridBitmap = new Bitmap(filename);
            return chkGridBitmap;
        }

        public void saveThemeFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Theme));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Theme file. Error: " + ex.Message);
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
        public Theme loadThemeFile(string filename)
        {
            Theme toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Theme));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Theme)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Theme file. Error:\n{0}", ex.Message);
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
}
