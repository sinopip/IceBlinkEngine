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
            Combat c = sf.frm.currentCombat;
            Creature crt = (Creature)sf.CombatSource; //this is the creature that is calling this script
            PC pc = (PC)sf.CombatTarget;

            int saveChkRoll = sf.gm.Random(20);
            int saveChk = saveChkRoll + pc.Fortitude;
            int DC = 10;
            if (saveChk >= DC) //passed save check
            {
                c.logText(pc.Name, Color.Blue);
                c.logText(" avoids being poisoned ", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(saveChkRoll.ToString() + " + " + pc.Fortitude.ToString() + " >= " + DC.ToString(), Color.Blue);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
            }
            else //failed check
            {
                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                c.logText(pc.Name, Color.LightGray);
                c.logText(" fails saving throw and is poisoned for 3 rounds ", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(saveChkRoll.ToString() + " + " + pc.Fortitude.ToString() + " < " + DC.ToString(), Color.Blue);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                //pc.Status = CharBase.charStatus.Held;
                pc.AddEffectByTag("poisonedLight");
            }
        }
    }
}
