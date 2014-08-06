using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            if (sf.CombatSource is PC)
            {
                PC source = (PC)sf.CombatSource;
                Creature target = (Creature)sf.CombatTarget;
                
                Combat c = sf.frm.currentCombat;
                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                int saveChkRoll = sf.gm.Random(20);
                int saveChk = saveChkRoll + target.Will;
                int DC = 16;
                if (saveChk >= DC) //passed save check
                {
                    c.logText(target.Name, Color.Blue);
                    c.logText(" avoids the hold spell ", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(saveChkRoll.ToString() + " + " + target.Will.ToString() + " >= " + DC.ToString(), Color.Blue);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else
                {
                    c.logText(target.Name, Color.LightGray);
                    c.logText(" is held by a hold spell ", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    target.Status = CharBase.charStatus.Held;
                    target.AddEffectByTag("hold");
                }
            }
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                PC target = (PC)sf.CombatTarget;
                //int PCindex = (int)sf.CombatTarget;
                //PC target = sf.gm.playerList.PCList[PCindex];
                Combat c = sf.frm.currentCombat;
                //IBMessageBox.Show(sf.gm, "Regeneration Effect Begins");
                int saveChkRoll = sf.gm.Random(20);
                int saveChk = saveChkRoll + target.Will;
                int DC = 16;
                if (saveChk >= DC) //passed save check
                {
                    c.logText(target.Name, Color.Blue);
                    c.logText(" avoids the hold spell ", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(saveChkRoll.ToString() + " + " + target.Will.ToString() + " >= " + DC.ToString(), Color.Blue);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
                else
                {
                    c.logText(target.Name, Color.LightGray);
                    c.logText(" is held by a hold spell ", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    target.Status = CharBase.charStatus.Held;
                    target.AddEffectByTag("hold");
                }
            }
            else // don't know who cast this spell
            {
                IBMessageBox.Show(sf.gm, "Invalid script owner, not a Creature or PC");
                return;
            }
        }
    }
}
