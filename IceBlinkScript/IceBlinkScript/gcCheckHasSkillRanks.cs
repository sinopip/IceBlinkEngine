//gcCheckHasSkillRanks.cs - Checks to see if selectedPC has enough skill ranks in a skill
//parm1 = (string) tag of the skill to check (ex. survival)
//parm2 = (int) skill ranks needed
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
            // C# code goes here
            int parm2 = Convert.ToInt32(p2);
            PC pc = sf.gm.playerList.PCList[sf.gm.selectedPartyLeader];
            Skill sk =  pc.KnownSkillsList.getSkillByTag(p1);
            if (sk != null)
            {
                sf.gm.returnCheck = false;
                if (sk.Ranks >= parm2)
                {
                    sf.gm.returnCheck = true;
                }
            }
            else
            {
                IBMessageBox.Show(sf.gm, "Skill: " + p1 + " was not found in the PC's skill list");
            }
        }
    }
}
