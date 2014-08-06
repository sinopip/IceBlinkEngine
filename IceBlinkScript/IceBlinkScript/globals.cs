//globals.cs - run from the console (hotkey "z") to see current GlobalInts status.
//To use:
//1) name this script "globals.cs" and place in your module's script folder
//2) in game, hit the hotkey "z"
//3) type "globals" in the textbox and then click the run button
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;
using System.Drawing;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            foreach (GlobalInt variable in sf.gm.module.ModuleGlobalInts)
            {
                sf.frm.logText("GlobalInt Variable: " + variable.Key + "  current value: " + variable.Value.ToString(), Color.Yellow);
                sf.frm.logText(Environment.NewLine, Color.Black);
            }
        }
    }
}
