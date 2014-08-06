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
            int PCindex = sf.gm.indexOfPCtoLastUseItem;
            PC pc = sf.gm.playerList.PCList[PCindex];
            //MessageBox.Show("Heal Light Wounds");
            int hp = pc.HP;
            string name = pc.Name;
            if (pc.HP <= -20)
            {
                IBMessageBox.Show(sf.gm, "Can't bless a dead character!");
            }
            else
            {
                IBMessageBox.Show(sf.gm, name + " is now blessed for 3 rounds");
                int numberOfRounds = 3;
                Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("bless").DeepCopy();
                ef.DurationInUnits = numberOfRounds * 6;
                if (sf.MainMapScriptCall) //the script was called from a main map
                {
                    pc.AddEffectOnMainMapByObject(ef);
                }
                else
                {
                    pc.AddEffectByObject(ef);
                }
                sf.gm.deleteItemUsedScript = true;
            }            
        }
    }
}
