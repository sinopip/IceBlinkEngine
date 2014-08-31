// NOT USED ANYMORE...REPLACED WITH itRegenSPLight.cs
// parm1 = CurrentDurationInUnits
// parm2 = DurationInUnits
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            int PCindex = sf.gm.indexOfPCtoLastUseItem;
            //MessageBox.Show("Regenerate Spell Points Light");
            int sp = sf.gm.playerList.PCList[PCindex].SP;
            string name = sf.gm.playerList.PCList[PCindex].Name;
            IBMessageBox.Show(sf.gm, name + "'s current spell points are " + sp.ToString());
            sf.gm.playerList.PCList[PCindex].SP = sf.gm.playerList.PCList[PCindex].SP + 20;
            if (sf.gm.playerList.PCList[PCindex].SP > sf.gm.playerList.PCList[PCindex].SPMax)
            {
                sf.gm.playerList.PCList[PCindex].SP = sf.gm.playerList.PCList[PCindex].SPMax;
            }
            IBMessageBox.Show(sf.gm, "now " + name + "'s current spell points are " + sf.gm.playerList.PCList[PCindex].SP.ToString());
            sf.gm.deleteItemUsedScript = true;
        }
    }
}
