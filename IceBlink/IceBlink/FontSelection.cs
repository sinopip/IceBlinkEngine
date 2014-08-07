using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using System.IO;
using System.Drawing.Drawing2D;

namespace IceBlink
{
    public partial class FontSelection : IBForm
    {
        private Form1 frm;
        private Game game;
        public List<ShadowTextObject> textList = new List<ShadowTextObject>();
        
        public FontSelection()
        {
            InitializeComponent();
            timer1.Interval = 67;
            timer1.Enabled = true;
            timer1.Start();
            label2.Font = new Font("Micorsoft Sans Serif", 9.75f);
            label5.Font = new Font("Micorsoft Sans Serif", 9.75f);            
        }
        public void passRefs(Game g, Form1 f)
        {
            game = g;
            frm = f;
            numFontScale.Value = (decimal)game.module.ModuleTheme.ModuleFontScale;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            btnFontSelect.setupAll(game);
            btnTestFont.setupAll(game);
            this.setupAll(game);
            refreshFonts();
        }
        public void refreshFonts()
        {
            panel1.BackColor = game.module.ModuleTheme.StandardBackColor;
            panel2.BackColor = game.module.ModuleTheme.ConvoBackColor;
            label1.Font = game.module.ModuleTheme.ModuleFont;
            btnFontSelect.Font = game.module.ModuleTheme.ModuleFont;
            btnTestFont.Font = game.module.ModuleTheme.ModuleFont;
            numFontScale.Font = game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        private void btnFontSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                game.module.ModuleTheme.ModuleFont = fontDialog1.Font;
                label3.Font = fontDialog1.Font;
                label4.Font = fontDialog1.Font;
            }
            refreshFonts();
        }
        private void btnTestFont_Click(object sender, EventArgs e)
        {
            int rnd = game.Random(3);
            if (rnd == 1)
            {
                DrawFloatyText("This is the new font size ABC0123456789", 3, 40, 100, Color.Lime, Color.Black);
            }
            else if (rnd == 2)
            {
                DrawFloatyText("This is the new font size ABC0123456789", 3, 40, 100, Color.Red, Color.Black);
            }
            else
            {
                DrawFloatyText("This is the new font size ABC0123456789", 3, 40, 100, Color.Black, Color.White);
            }
        }
        private void numFontScale_ValueChanged(object sender, EventArgs e)
        {
            game.module.ModuleTheme.ModuleFontScale = (float)numFontScale.Value;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTextShadowOutline(e, 15, 95, 0, "This is the new font size ABC0123456789", 100, 255, game.module.ModuleTheme.ModuleFont.FontFamily, game.module.ModuleTheme.ModuleFont.SizeInPoints * game.module.ModuleTheme.ModuleFontScale, Color.White, Color.Black);
            //foreach (ShadowTextObject to in textList)
            //{
            //    DrawTextShadowOutline(e, to.X, to.Y, to.Z, to.Text, to.AlphaShadow, to.AlphaText, to.Font, to.FontPointSize, to.TextColor, to.ShadowColor);
            //}
            base.OnPaint(e);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            foreach (ShadowTextObject to in textList)
            {
                DrawTextShadowOutline(e, to.X, to.Y, to.Z, to.Text, to.AlphaShadow, to.AlphaText, game.module.ModuleTheme.ModuleFont.FontFamily, game.module.ModuleTheme.ModuleFont.SizeInPoints * game.module.ModuleTheme.ModuleFontScale, to.TextColor, to.ShadowColor);
            }
            //base.OnPaint(e);
        }
        public void DrawTextShadowOutline(PaintEventArgs e, int x, int y, int z, string text, int aShad, int aText, FontFamily font, float fontPointSize, Color textColor, Color shadowColor)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
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

                //fontFamily.Dispose();
                path.Dispose();
                brush.Dispose();
            }
            catch
            {
                timer1.Stop();
                IBMessageBox.Show(game, "Font does not work, try another");
                timer1.Start();
                game.module.ModuleTheme.ModuleFont = new Font("Microsoft Sans Serif", 10.0f);
            }
        }
        private void doTimers()
        {
            //used to determine the fade in and out start times and the speed to float up
            foreach (ShadowTextObject to in textList)
            {
                to.Timer++;
                to.Z = -(to.Timer / 7);
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
            for (int i = textList.Count - 1; i >= 0; i--)
            {
                if (textList[i].Timer > textList[i].TimeLength + 30)
                {
                    textList.RemoveAt(i);
                }
            }
            //this.Invalidate();
            panel3.Invalidate();
        }
        private void doFades()
        {
            //controls the fade in and out
            foreach (ShadowTextObject to in textList)
            {
                if (to.FadeIn)
                {
                    to.AlphaShadow += 10;
                    if (to.AlphaShadow > 100)
                        to.AlphaShadow = 100;
                    to.AlphaText += 25;
                    if (to.AlphaText > 255)
                        to.AlphaText = 255;
                }
                if (to.FadeOut)
                {
                    to.AlphaShadow -= 4;
                    if (to.AlphaShadow < 0)
                        to.AlphaShadow = 0;
                    to.AlphaText -= 10;
                    if (to.AlphaText < 0)
                        to.AlphaText = 0;
                }
            }
            //this.Invalidate();
            panel3.Invalidate();
        }
        public void DrawFloatyText(string text, int x, int y, int timeLength, Color textColor, Color shadowColor)
        {
            textList.Add(new ShadowTextObject(text, x, y, timeLength, textColor, shadowColor));
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            doTimers();
            doFades();
        }        
    }
}
