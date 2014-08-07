using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;
using System.IO;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            try
            {
                sf.frm.pnlWorldTime.BackgroundImage = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\clock.png");
            }
            catch { }
            
            
            sf.AddButtonToBottomPanel("castSpell", 8, 8, 48, 48);
            sf.AddButtonToBottomPanel("useTrait", 68, 8, 48, 48);
            sf.AddButtonToBottomPanel("partyConvo", sf.frm.panelBottom.Width - 60, 8, 48, 48);
            sf.AddButtonToBottomPanel("combatOrder", sf.frm.panelBottom.Width - 120, 8, 48, 48);
            //sf.AddButtonToLeftPanel("worldMap", 21, 300, 48, 48);
            try
            {
                Button btn = sf.GetBottomPanelButtonByTag("castSpell");
                btn.Image = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\spells.png");
            }
            catch { }
            try
            {
                Button btn = sf.GetBottomPanelButtonByTag("useTrait");
                btn.Image = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\traits.png");
            }
            catch { }
            try
            {
                Button btn = sf.GetBottomPanelButtonByTag("partyConvo");
                btn.Image = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\partyConvo.png");
            }
            catch { }
            try
            {
                Button btn = sf.GetBottomPanelButtonByTag("combatOrder");
                btn.Image = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\combatOrder.png");
            }
            catch { }
            //try
            //{
            //    Button btn = sf.GetLeftPanelButtonByTag("worldMap");
            //    btn.Image = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\worldMap.png");
            //}
            //catch { }
        }
    }
}
