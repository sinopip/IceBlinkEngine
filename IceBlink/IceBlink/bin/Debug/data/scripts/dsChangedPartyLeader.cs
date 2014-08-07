//dsChangedPartyLeader.cs
//p1 = Index of new party leader
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
            int parm1 = Convert.ToInt32(p1); // parm1 = index of currently selected party leader
            PC pc = sf.gm.playerList.PCList[parm1];
            //IBMessageBox.Show(sf.gm, "new party leader is " + pc.Name);
        }
    }
}
