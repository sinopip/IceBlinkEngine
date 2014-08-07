//pcOnScoringHit_SleepOne.cs
//parm1 = (int) DC of sleep effect based on item's ability.  
//parm2 = none
//parm3 = none
//parm4 = none
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
            if ((p1 == "none") || (p1 == ""))
            {
                p1 = "0";
            }            
            int parm1 = Convert.ToInt32(p1);

            // C# code goes here
            Combat c = sf.frm.currentCombat;
            PC pc = (PC)sf.CombatSource;
            Creature crt = (Creature)sf.CombatTarget;            

            int saveChkRoll = sf.gm.Random(20);
            int saveChk = saveChkRoll + crt.Will;
            int DC = parm1;
            if (saveChk >= DC) //passed save check
            {
                c.logText(crt.Name, Color.Blue);
                c.logText(" avoids a sleep effect from item ", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(saveChkRoll.ToString() + " + " + crt.Will.ToString() + " >= " + DC.ToString(), Color.Blue);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
            else //failed check
            {
                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                c.logText(crt.Name, Color.LightGray);
                c.logText(" is held by a sleep effect from item ", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(saveChkRoll.ToString() + " + " + crt.Will.ToString() + " < " + DC.ToString(), Color.Blue);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                crt.Status = CharBase.charStatus.Held;
                crt.AddEffectByTag("sleep");
            }
        }
    }
}
