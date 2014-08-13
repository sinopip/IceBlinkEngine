//gcCheckIfPassSkillCheck.cs - Checks to see if selectedPC passes a skill check and if so will set a Prop to show = true
//parm1 = (int) difficulty class (DC) to check against
//parm2 = (string) tag of the skill to check (ex. survival)
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
            int parm1 = Convert.ToInt32(p1);
            PC pc = sf.gm.playerList.PCList[sf.gm.selectedPartyLeader];
            Skill sk =  pc.KnownSkillsList.getSkillByTag(p2);
            if (sk != null)
            {
                sf.gm.returnCheck = false;

                int skChkRoll = sf.gm.Random(20);
                int skChkMods = sk.Ranks + sk.Modifiers;
                int skChk = skChkRoll + skChkMods;
                int DC = parm1;

                if (skChk >= DC)
                {
                    sf.gm.returnCheck = true;
                }                
            }
            else
            {
                IBMessageBox.Show(sf.gm, "Skill: " + p2 + " was not found in the PC's skill list");
            }
        }
    }
}
