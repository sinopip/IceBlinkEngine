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
            MessageBox.Show("Heal Light Wounds");
            int hp = sf.gm.playerList.PCList[PCindex].HP;
            string name = sf.gm.playerList.PCList[PCindex].Name;
            MessageBox.Show(name + "'s current hit points are " + hp.ToString());
            sf.gm.playerList.PCList[PCindex].HP += 10;
            if (sf.gm.playerList.PCList[PCindex].HP > sf.gm.playerList.PCList[PCindex].HPMax)
            {
                sf.gm.playerList.PCList[PCindex].HP = sf.gm.playerList.PCList[PCindex].HPMax;
            }
            MessageBox.Show("now " + name + "'s current hit points are " + sf.gm.playerList.PCList[PCindex].HP.ToString());
            sf.gm.deleteItemUsedScript = true;
        }
    }
}
