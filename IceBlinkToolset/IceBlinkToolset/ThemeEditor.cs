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
using System.Threading;

namespace IceBlinkToolset
{
    public partial class ThemeEditor : IBForm
    {
        private Module mod = new Module();
        private Game game;
        private ParentForm prntForm;

        public ThemeEditor(Module m, Game g, ParentForm pf)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = pf;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonClose.setupAll(game);
            propertyGrid1.SelectedObject = mod.ModuleTheme;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonClose.setupAll(game);
            iceBlinkButtonSmall1.setupAll(game);
            iceBlinkButtonMedium1.setupAll(game);
            iceBlinkButtonLarge1.setupAll(game);
            iceBlinkButtonRArrow1.setupAll(game);
            this.setupAll(game);
            refreshTheme();
            this.Invalidate();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshTheme();
            this.Invalidate();
        }

        private void refreshTheme()
        {
            this.IBBorderOutsideColor = mod.ModuleTheme.IBBorderOutsideColor;
            this.IBBorderMiddleColor = mod.ModuleTheme.IBBorderMiddleColor;
            this.IBBorderInsideColor = mod.ModuleTheme.IBBorderInsideColor;
            this.iceBlinkGroupBoxMedium1.BackgroundColor = mod.ModuleTheme.GroupBoxBackGroundColor;
            this.iceBlinkGroupBoxLarge1.BackgroundColor = mod.ModuleTheme.GroupBoxBackGroundColor;
            this.iceBlinkGroupBoxMedium1.BorderColor = mod.ModuleTheme.GroupBoxBorderColor;
            this.iceBlinkGroupBoxLarge1.BorderColor = mod.ModuleTheme.GroupBoxBorderColor;
            this.iceBlinkGroupBoxMedium1.HeaderForeColor = mod.ModuleTheme.HeaderForeColor;
            this.iceBlinkGroupBoxLarge1.HeaderForeColor = mod.ModuleTheme.HeaderForeColor;
            this.iceBlinkGroupBoxMedium1.HeaderShadowColor = mod.ModuleTheme.HeaderShadowColor;
            this.iceBlinkGroupBoxLarge1.HeaderShadowColor = mod.ModuleTheme.HeaderShadowColor;
            this.lblGray.Font = mod.ModuleTheme.ModuleFont;
            this.lblGray.ForeColor = mod.ModuleTheme.StandardTextColor;
            this.lblGray.BackColor = mod.ModuleTheme.StandardBackColor;
            this.lblConvo.Font = mod.ModuleTheme.ModuleFont;
            this.lblConvo.ForeColor = mod.ModuleTheme.ConvoTextColor;
            this.lblConvo.BackColor = mod.ModuleTheme.ConvoBackColor;
            this.panel1.BackColor = mod.ModuleTheme.StandardBackColor;
            this.panel2.BackColor = mod.ModuleTheme.ConvoBackColor;            
        }
    }
}
