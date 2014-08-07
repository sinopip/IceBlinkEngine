using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using IceBlinkCore;
using System.IO;

namespace IceBlink
{
    public class IceBlinkGroupBoxLarge : System.Windows.Forms.GroupBox
    {
        private Image headerImage;
        private string ibText;
        private Color headerForeColor = Color.White;
        private Color headerShadowColor = Color.Black;
        private Color backgroundColor;
        private Color borderColor;
        private float borderThickness = 2.0f;

        #region Properties
        public Image HeaderImage
        {
            get { return this.headerImage; }
            set { this.headerImage = value; }
        }
        public string TextIB
        {
            get { return this.ibText; }
            set { this.ibText = value; }
        }
        public Color HeaderForeColor
        {
            get { return this.headerForeColor; }
            set { this.headerForeColor = value; }
        }
        public Color HeaderShadowColor
        {
            get { return this.headerShadowColor; }
            set { this.headerShadowColor = value; }
        }
        /// <summary>This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.</summary>
        [Category("Appearance"), Description("This feature will change the group control color. This color can also be used in combination with BackgroundGradientColor for a gradient paint.")]
        public System.Drawing.Color BackgroundColor{get{return backgroundColor;} set{backgroundColor=value; this.Refresh();}}
  
        /// <summary>This feature will allow you to change the color of the control's border.</summary>
        [Category("Appearance"), Description("This feature will allow you to change the color of the control's border.")]
        public System.Drawing.Color BorderColor{get{return borderColor;} set{borderColor=value; this.Refresh();}}
  
        /// <summary>This feature will allow you to set the control's border size.</summary>
        [Category("Appearance"), Description("This feature will allow you to set the control's border size.")]
        public float BorderThickness
        {
            get{return borderThickness;} 
            set
            {
                if(value>3)
                {
                    borderThickness=3;
                }
                else
                {
                    if(value<1){borderThickness=1;}
                    else{borderThickness=value;}
                }
                this.Refresh();
            }
        }
        #endregion



        public IceBlinkGroupBoxLarge()
        {            
            this.Text = "";
            this.TextIB = "iceBlinkGBLarge1";
            this.HeaderImage = global::IceBlink.Properties.Resources.gb_lrg_header;
            this.DoubleBuffered = true;
            InitializeStyles();
            this.BackColor = Color.Transparent;
        }

        /// <summary>This method will initialize the controls custom styles.</summary>
        private void InitializeStyles()
        {
            //Set the control styles----------------------------------
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            //--------------------------------------------------------
        }

        public void setupAll(Game g)
        {
            loadHeaderImage(g);
            this.HeaderForeColor = g.module.ModuleTheme.HeaderForeColor;
            this.HeaderShadowColor = g.module.ModuleTheme.HeaderShadowColor;
            this.BackgroundColor = g.module.ModuleTheme.GroupBoxBackGroundColor;
            this.BorderColor = g.module.ModuleTheme.GroupBoxBorderColor;
        }
        private void loadHeaderImage(Game game)
        {
            try
            {
                if (game.module != null)
                {
                    if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleGroupBoxLargeImage))
                    {
                        this.HeaderImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleGroupBoxLargeImage);
                    }
                    else
                    {
                        this.HeaderImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\gb_lrg_header.png");
                    }
                }
                else
                {
                    this.HeaderImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\gb_lrg_header.png");
                }
            }
            catch { }
        }

        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            PaintBack(e.Graphics);
            DrawHeaderImage(e.Graphics);
            int x = this.Width / 2;
            int y = this.Height / 2;
            DrawButtonTextShadowOutline(e, x, y, Text, 100, 255, Font.FontFamily, Font.Size, HeaderForeColor, HeaderShadowColor);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>This method will paint the control.</summary>
        /// <param name="g">The paint event graphics object.</param>
        private void PaintBack(System.Drawing.Graphics g)
        {
            //Set Graphics smoothing mode to Anit-Alias-- 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //-------------------------------------------
  
            //Declare Variables------------------
            int ArcWidth = 5;
            int ArcHeight = 5;
            int ArcX1 = 0;
            int ArcX2 = this.Width - (ArcWidth + 1);
            int ArcY1 = 10;
            int ArcY2 = this.Height - (ArcHeight + 1);
            GraphicsPath path = new GraphicsPath();
            Brush BorderBrush = new SolidBrush(this.BorderColor);
            Pen BorderPen = new Pen(BorderBrush, this.BorderThickness);
            LinearGradientBrush BackgroundGradientBrush = null;
            Brush BackgroundBrush = new SolidBrush(this.BackgroundColor);
            //-----------------------------------
  
            //Create Rounded Rectangle Path------
            path.AddArc(ArcX1, ArcY1, ArcWidth, ArcHeight, 180, 90); // Top Left
            path.AddArc(ArcX2, ArcY1, ArcWidth, ArcHeight, 270, 90); //Top Right
            path.AddArc(ArcX2, ArcY2, ArcWidth, ArcHeight, 360, 90); //Bottom Right
            path.AddArc(ArcX1, ArcY2, ArcWidth, ArcHeight, 90, 90); //Bottom Left
            path.CloseAllFigures(); 
            //-----------------------------------
  
            //Check if Gradient Mode is enabled--
            //Paint Rounded Rectangle------------
            g.FillPath(BackgroundBrush, path);
            //-----------------------------------

            //Paint Rounded Rectangle (gradient)-
            //BackgroundGradientBrush = new LinearGradientBrush(new Rectangle(0,0,this.Width,this.Height), this.BackgroundColor, this.BackgroundGradientColor, (LinearGradientMode)this.BackgroundGradientMode);
            //g.FillPath(BackgroundGradientBrush, path);
            //-----------------------------------

  
            //Paint Borded-----------------------
            g.DrawPath(BorderPen, path);
            //-----------------------------------
  
            //Destroy Graphic Objects------------
            if(path!=null){path.Dispose();}
            if(BorderBrush!=null){BorderBrush.Dispose();}
            if(BorderPen!=null){BorderPen.Dispose();}
            if(BackgroundGradientBrush!=null){BackgroundGradientBrush.Dispose();}
            if(BackgroundBrush!=null){BackgroundBrush.Dispose();}
            //-----------------------------------
        }

        private void DrawHeaderImage(Graphics g)
        {
            g.DrawImage(this.HeaderImage, 0, 0, this.Width, this.HeaderImage.Height);
        }

        public void DrawButtonTextShadowOutline(PaintEventArgs e, int x, int y, string text, int aShad, int aText, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                StringFormat strformat = new StringFormat();
                strformat.Alignment = StringAlignment.Center;
                strformat.LineAlignment = StringAlignment.Center;

                GraphicsPath path = new GraphicsPath();
                float emSize = e.Graphics.DpiY * fontPointSize / 72;
                Rectangle rect = new Rectangle(0, 0, this.Width, 25);
                path.AddString(text, font, (int)FontStyle.Regular, emSize, rect, strformat);
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
            catch (Exception ex)
            {
                MessageBox.Show("draw text on button not working: " + ex.ToString());
            }
        }
    }
}
