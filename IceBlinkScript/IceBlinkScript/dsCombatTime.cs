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
            sf.gm.module.WorldTime += sf.gm.currentEncounter.TimePerRound;
            //IBMessageBox.Show(sf.gm, "Combat Time has triggered");
            Combat c = sf.frm.currentCombat;

            #region Code: Bleed to death at -20 hp
            //////////////////////////////////////////////////////////////////////////////////////
            foreach (PC pc in sf.gm.playerList.PCList)
            {
                if ((pc.HP <= 0) && (pc.HP > -20))
                {
                    pc.HP -= 1;
                    c.logText(pc.Name + " bleeds for one point of damage: Death and Game Over will occur at -20 HP! Heal to above 0 HP to stop the bleeding!", Color.Red);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    pc.Status = CharBase.charStatus.Dead;
                    if (pc.HP <= -20)
                    {
                        c.logText(pc.Name + " has DIED!", Color.Red);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                    }
                }
            }
            #endregion
        }
    }
}
