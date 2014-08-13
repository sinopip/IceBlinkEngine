// NOT USED ANYMORE...REPLACED WITH itHealLight.cs
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
            PC pc = sf.gm.playerList.PCList[PCindex];
            //MessageBox.Show("Heal Light Wounds");
            int hp = pc.HP;
            string name = pc.Name;
            if (pc.HP <= -20)
            {
                IBMessageBox.Show(sf.gm, "Can't heal a dead character!");
            }
            else
            {
                IBMessageBox.Show(sf.gm, name + "'s current hit points are " + hp.ToString());
                pc.HP += 8;
                if (pc.HP > pc.HPMax)
                {
                    pc.HP = pc.HPMax;
                }
                if ((pc.HP > 0) && (pc.Status == CharBase.charStatus.Dead))
                {
                    pc.Status = CharBase.charStatus.Alive;
                }
                IBMessageBox.Show(sf.gm, "now " + name + "'s current hit points are " + pc.HP.ToString());
                sf.gm.deleteItemUsedScript = true;
            }
        }
    }
}
