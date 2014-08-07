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
            TimeSpan t = TimeSpan.FromSeconds(sf.gm.module.WorldTime);
            DateTime mydate = new DateTime(t.Ticks);
            string text = mydate.ToString(("hh:mm:ss"));
            sf.returnScriptObject = text;
            sf.frm.toolTip1.SetToolTip(sf.frm.pnlWorldTime, "Time: " + text);
            //IBMessageBox.Show(sf.gm, "World Time UI Text has triggered");
        }
    }
}
