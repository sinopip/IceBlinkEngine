//gcSetPropShowIfPassSkillCheck.cs - Checks to see if selectedPC passes a skill check and if so will set a Prop to show = true
//parm1 = (int) difficulty class (DC) of prop to see it
//parm2 = (string) tag of the skill to check (ex. survival)
//parm3 = (string) tag of the prop in the current area to check for "show"
//parm4 = (string) floaty text to display if skill check passed
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
                int skChkRoll = sf.gm.Random(20);
                int skChkMods = sk.Ranks + sk.Modifiers;
                int skChk = skChkRoll + skChkMods;
                int DC = parm1;
                if (skChk >= DC) // if successful, set variable on PC of "StealthModeOn"
                {
                    sf.DrawFloatyTextOverSquare(p4, sf.gm.playerPosition.X, sf.gm.playerPosition.Y, 75, Color.White, Color.Black);
                    Prop prp = sf.GetPropByTag(p3);
                    if (prp != null)
                    {
                        prp.Show = true;
                    }
                }
                else //else say failed and end turn
                {
                    sf.DrawFloatyTextOverSquare("Skill Check Failed", sf.gm.playerPosition.X, sf.gm.playerPosition.Y, 75, Color.White, Color.Black);
                }
            }
            else
            {
                MessageBox.Show("Skill: " + p2 + " was not found in the PC's skill list");
            }
        }
    }
}
