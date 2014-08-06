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
            sf.gm.module.WorldTime += sf.gm.currentArea.TimePerMove;
            sf.frm.pnlWorldTime.Invalidate();
            //IBMessageBox.Show(sf.gm, "World Time has triggered");

            #region Code: Bleed to death at -20 hp
            //////////////////////////////////////////////////////////////////////////////////////
            foreach (PC pc in sf.gm.playerList.PCList)
            {
                if ((pc.HP <= 0) && (pc.HP > -20))
                {
                    int bleedPoints = 1 * (sf.gm.currentArea.TimePerMove / 6);
                    pc.HP -= bleedPoints;
                    sf.frm.logText(pc.Name + " bleeds for "+ bleedPoints.ToString() + " point(s) of damage: Death and Game Over will occur at -20 HP! Heal to above 0 hp to stop the bleeding!", Color.Red);
                    sf.frm.logText(Environment.NewLine, Color.Black);
                    pc.Status = CharBase.charStatus.Dead;
                    if (pc.HP <= -20)
                    {
                        sf.frm.logText(pc.Name + " has DIED!", Color.Red);
                        sf.frm.logText(Environment.NewLine, Color.Black);
                    }
                }
            }
            #endregion
        }
    }
}
