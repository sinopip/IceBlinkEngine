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
            
            foreach (PC pc in sf.gm.playerList.PCList)
            {     
                if (pc.HP > -20)
                //if (pc.Status != CharBase.charStatus.Dead)
                {
                    pc.HP = pc.HPMax;
                    pc.SP = pc.SPMax;
                    pc.Status = CharBase.charStatus.Alive;
                }
            }
            IBMessageBox.Show(sf.gm, "Your party is fully rested");
        }
    }
}
