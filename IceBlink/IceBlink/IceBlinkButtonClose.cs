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
   public  class IceBlinkButtonClose : System.Windows.Forms.Button
    {
       //private Game game;
       System.Media.SoundPlayer playerButtonEnter = new System.Media.SoundPlayer();
       System.Media.SoundPlayer playerButtonClick = new System.Media.SoundPlayer();
       private Image normalImage;
       private Image hoverImage;
       private Image pressedImage;
       private bool pressed = false;
       private bool hover = false;

       public Image NormalImage
       {
           get { return this.normalImage; }
           set { this.normalImage = value; }
       }
       public Image HoverImage
       {
           get { return this.hoverImage; }
           set { this.hoverImage = value; }
       }
       public Image PressedImage
       {
           get { return this.pressedImage; }
           set { this.pressedImage = value; }
       }

       public IceBlinkButtonClose()
       {
           //game = g; 
           // 
           // iceBlinkButton1
           // 
           this.BackColor = System.Drawing.Color.Transparent;
           this.BackgroundImage = global::IceBlink.Properties.Resources.b_close_normal;
           this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
           this.FlatAppearance.BorderSize = 0;
           this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255); //transparent
           this.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 255, 255, 255); //transparent
           this.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 255, 255, 255); //transparent
           this.HoverImage = global::IceBlink.Properties.Resources.b_close_normal;
           this.Name = "iceBlinkButtonRArrow1";
           this.NormalImage = global::IceBlink.Properties.Resources.b_close_normal;
           this.PressedImage = global::IceBlink.Properties.Resources.b_close_normal;
           this.Size = new System.Drawing.Size(23, 23);
           this.Text = "";
           this.UseVisualStyleBackColor = false;
           this.DoubleBuffered = true;
       }

       public void setupAll(Game g)
       {
           loadSounds(g);
           loadButtonImages(g);
       }
       private void loadButtonImages(Game game)
       {
           try
           {
               if (game.module != null)
               {
                   if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonCloseNormalImage))
                   {
                       this.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonCloseNormalImage);
                       this.HoverImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonCloseHoverImage);
                       this.NormalImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonCloseNormalImage);
                       this.PressedImage = (Image)new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonClosePressedImage);
                   }
                   else
                   {
                       this.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_normal.png");
                       this.HoverImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_hover.png");
                       this.NormalImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_normal.png");
                       this.PressedImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_pressed.png");
                   }
               }
               else
               {
                   this.BackgroundImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_normal.png");
                   this.HoverImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_hover.png");
                   this.NormalImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_normal.png");
                   this.PressedImage = (Image)new Bitmap(game.mainDirectory + "\\data\\ui\\b_close_pressed.png");
               }
           }
           catch { }
       }
       private void loadSounds(Game game)
       {
           try
           {
               if (game.module != null)
               {
                   if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonClickSound))
                   {
                       playerButtonClick.SoundLocation = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonClickSound;
                   }
                   else
                   {
                       playerButtonClick.SoundLocation = game.mainDirectory + "\\data\\ui\\btn_click.wav";
                   }
               }
               else
               {
                   playerButtonClick.SoundLocation = game.mainDirectory + "\\data\\ui\\btn_click.wav";
               }
           }
           catch { }
           try
           {
               if (game.module != null)
               {
                   if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonEnterSound))
                   {
                       playerButtonEnter.SoundLocation = game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\ui\\" + game.module.moduleButtonEnterSound;
                   }
                   else
                   {
                       playerButtonEnter.SoundLocation = game.mainDirectory + "\\data\\ui\\btn_hover.wav";
                   }
               }
               else
               {
                   playerButtonEnter.SoundLocation = game.mainDirectory + "\\data\\ui\\btn_hover.wav";
               }
           }
           catch (Exception ex) { IBMessageBox.Show(game, ex.ToString()); }
       }

       // When the mouse button is pressed, set the "pressed" flag to true 
       // and invalidate the form to cause a repaint.  The .NET Compact Framework 
       // sets the mouse capture automatically.
       protected override void OnMouseDown(MouseEventArgs e)
       {
           this.pressed = true;
           try
           {
               playerButtonClick.Play();
           }
           catch (Exception ex) { MessageBox.Show(ex.ToString()); }
           this.Invalidate();
           base.OnMouseDown(e);
       }

       // When the mouse is released, reset the "pressed" flag 
       // and invalidate to redraw the button in the unpressed state.
       protected override void OnMouseUp(MouseEventArgs e)
       {
           this.pressed = false;
           this.Invalidate();
           base.OnMouseUp(e);
       }
       protected override void OnMouseEnter(EventArgs e)
       {
           this.hover = true;
           try
           {
               playerButtonEnter.Play();
           }
           catch (Exception ex) { MessageBox.Show(ex.ToString()); }
           this.Invalidate();
           base.OnMouseEnter(e);
       }
       protected override void OnMouseLeave(EventArgs e)
       {
           this.hover = false;
           this.Invalidate();
           base.OnMouseLeave(e);
       }
       protected override void OnMouseHover(EventArgs e)
       {
           this.hover = true;
           this.Invalidate();
           base.OnMouseHover(e);
       }

       // Override the OnPaint method to draw the background image and the text.
       protected override void OnPaint(PaintEventArgs e)
       {
           base.OnPaint(e);
           if ((this.pressed) && (this.PressedImage != null))
           {
               this.BackgroundImage = PressedImage;
           }
           else if ((this.hover) && (this.HoverImage != null))
           {
               this.BackgroundImage = HoverImage;
           }
           else
           {
               this.BackgroundImage = NormalImage;
           }
       }
   }
}
