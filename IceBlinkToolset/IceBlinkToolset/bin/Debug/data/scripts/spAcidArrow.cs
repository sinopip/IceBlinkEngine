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

                float resist = (float)(1f - ((float)target.DamageTypeResistanceValueAcid / 100f));
                float damage = 2 * sf.gm.Random(4);
                int acidDam = (int)(damage * resist);
                if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " acidDam = " + acidDam.ToString(), Color.Silver); }
                c.logText(source.Name, Color.Blue);
                c.logText(" attacks ", Color.Black);
                c.logText(target.Name, Color.LightGray);
                c.logText(" with an Acid Arrow and HITS for ", Color.Black);
                c.logText(acidDam.ToString(), Color.Lime);
                c.logText(" point(s) of acid damage", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);

                int numberOfRounds = (source.ClassLevel / 3); //1 round per 3 levels
                if (numberOfRounds > 6) { numberOfRounds = 6; } //can not have more than 6 rounds
                Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("acidArrow").DeepCopy();
                ef.DurationInUnits = numberOfRounds * 6;

                c.logText(target.Name, Color.LightGray);
                c.logText(" will suffer from acid damage for ", Color.Black);
                c.logText(numberOfRounds.ToString(), Color.Lime);
                c.logText(" round(s)", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                target.AddEffectByObject(ef);

                target.HP -= acidDam;
                if (target.HP <= 0)
                {
                    c.logText(source.Name + " killed the " + target.Name, Color.Lime);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
            }          
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                PC target = (PC)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;

                float resist = (float)(1f - ((float)target.DamageTypeResistanceTotalAcid / 100f));
                float damage = 2 * sf.gm.Random(4);
                int acidDam = (int)(damage * resist);
                if (sf.frm.debugMode) { c.logText("resist = " + resist.ToString() + " damage = " + damage.ToString() + " acidDam = " + acidDam.ToString(), Color.Silver); }
                c.logText(source.Name, Color.Blue);
                c.logText(" attacks ", Color.Black);
                c.logText(target.Name, Color.LightGray);
                c.logText(" with an Acid Arrow and HITS for ", Color.Black);
                c.logText(acidDam.ToString(), Color.Lime);
                c.logText(" point(s) of acid damage", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);

                int numberOfRounds = (source.ClassLevel / 3); //1 round per 3 levels
                if (numberOfRounds > 6) { numberOfRounds = 6; } //can not have more than 6 rounds
                Effect ef = sf.gm.module.ModuleEffectsList.getEffectByTag("acidArrow").DeepCopy();
                ef.DurationInUnits = numberOfRounds * 6;

                c.logText(target.Name, Color.LightGray);
                c.logText(" will suffer from acid damage for ", Color.Black);
                c.logText(numberOfRounds.ToString(), Color.Lime);
                c.logText(" round(s)", Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                c.logText(Environment.NewLine, Color.Black);
                target.AddEffectByObject(ef);

                target.HP -= acidDam;
                if (target.HP <= 0)
                {
                    c.logText(target.Name + " has been killed!", Color.Red);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    target.Status = PC.charStatus.Dead;
                }
            }
            else // don't know who cast this spell
            {
                MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            } 
        }
    }
}
