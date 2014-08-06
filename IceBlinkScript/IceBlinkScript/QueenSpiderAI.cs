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
            Creature crt = (Creature)sf.CombatSource; //this is the creature that is calling this script
            sf.SpellToCast = sf.gm.module.ModuleSpellsList.getSpellByTag("web");
            if (crt.SP >= sf.SpellToCast.CostSP)
            {
                int PcIndex = sf.TargetClosestPcNotHeld(true); //(true) means that will ignore PCs in Stealth Mode
                PC pc = sf.gm.playerList.PCList[PcIndex];
                sf.CombatTarget = pc.CombatLocation; //we are using a Point type because the web spell is looking for a Point type (square location)
                sf.ActionToTake = ChosenAction.CastSpell;
            }
            else
            {
                int PCindex = sf.TargetClosestPC(true);
                sf.CombatTarget = PCindex;
                sf.ActionToTake = ChosenAction.MeleeRangedAttack;
            }            
        }
    }
}
