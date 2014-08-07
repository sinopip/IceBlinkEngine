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
            if (sf.MainMapScriptCall) //the script was called from a main map
            {
                PC source = (PC)sf.MainMapSource;
                PC target = (PC)sf.MainMapTarget;
                Form1 c = sf.frm;

                int numberOfRounds = (source.ClassLevel * 20); //20 rounds per level
                //if (numberOfRounds > 6) { numberOfRounds = 6; } //can not have more than 6 rounds
                Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("mageArmor").DeepCopy();
                ef.DurationInUnits = numberOfRounds * 6;

                c.logText("Mage Armor is applied on ", Color.Silver);
                c.logText(target.Name, Color.Blue);
                c.logText(" for " + numberOfRounds.ToString(), Color.Blue);
                c.logText(" round(s)", Color.Black);
                c.logText(Environment.NewLine, Color.Silver);
                target.AddEffectOnMainMapByObject(ef);
            }
            else //the script was called from a combat map
            {
                if (sf.CombatSource is PC)
                {
                    PC source = (PC)sf.CombatSource;
                    PC target = (PC)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;

                    int numberOfRounds = (source.ClassLevel * 20); //20 rounds per level
                    //if (numberOfRounds > 6) { numberOfRounds = 6; } //can not have more than 6 rounds
                    Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("mageArmor").DeepCopy();
                    ef.DurationInUnits = numberOfRounds * 6;

                    c.logText("Mage Armor is applied on ", Color.Silver);
                    c.logText(target.Name, Color.Blue);
                    c.logText(" for " + numberOfRounds.ToString(), Color.Blue);
                    c.logText(" round(s)", Color.Black);
                    c.logText(Environment.NewLine, Color.Silver);
                    target.AddEffectByObject(ef);
                }
                else if (sf.CombatSource is Creature)
                {
                    Creature source = (Creature)sf.CombatSource;
                    Creature target = (Creature)sf.CombatTarget;
                    Combat c = sf.frm.currentCombat;

                    int numberOfRounds = (source.ClassLevel * 20); //20 rounds per level
                    //if (numberOfRounds > 6) { numberOfRounds = 6; } //can not have more than 6 rounds
                    Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("mageArmor").DeepCopy();
                    ef.DurationInUnits = numberOfRounds * 6;

                    c.logText("Mage Armor is applied on ", Color.Silver);
                    c.logText(target.Name, Color.Blue);
                    c.logText(" for " + numberOfRounds.ToString(), Color.Blue);
                    c.logText(" round(s)", Color.Black);
                    c.logText(Environment.NewLine, Color.Silver);
                    target.AddEffectByObject(ef);
                }
                else // don't know who cast this spell
                {
                    MessageBox.Show("Invalid script owner, not a Creature of PC");
                    return;
                }
            }
        }
    }
}
