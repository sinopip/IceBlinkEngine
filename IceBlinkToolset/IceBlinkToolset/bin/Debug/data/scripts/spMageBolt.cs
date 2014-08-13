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
                int numberOfBolts = ((source.ClassLevel - 1) / 2) + 1; //1 bolt for every 2 levels after level 1
                if (numberOfBolts > 5) { numberOfBolts = 5; } //can not have more than 5 bolts
                for (int i = 0; i < numberOfBolts; i++)
                {
                    int damage = 1 * sf.gm.Random(4) + 1;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" attacks ", Color.Black);
                    c.logText(target.Name, Color.LightGray);
                    c.logText(" with a Mage Bolt and HITS for ", Color.Black);
                    c.logText(damage.ToString(), Color.Lime);
                    c.logText(" point(s) of damage", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);

                    target.HP = target.HP - damage;
                    if (target.HP <= 0)
                    {
                        c.logText(source.Name + " killed the " + target.Name, Color.Lime);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                    }
                }
            }          
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                PC target = (PC)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;

                int numberOfBolts = ((source.ClassLevel - 1) / 2) + 1; //1 bolt for every 2 levels after level 1
                if (numberOfBolts > 5) { numberOfBolts = 5; } //can not have more than 5 bolts
                for (int i = 0; i < numberOfBolts; i++)
                {
                    int damage = 1 * sf.gm.Random(4) + 1;
                    c.logText(source.Name, Color.Blue);
                    c.logText(" attacks ", Color.Black);
                    c.logText(target.Name, Color.LightGray);
                    c.logText(" with a Mage Bolt and HITS for ", Color.Black);
                    c.logText(damage.ToString(), Color.Lime);
                    c.logText(" point(s) of damage", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);

                    target.HP = target.HP - damage;
                    if (target.HP <= 0)
                    {
                        c.logText(target.Name + " has been killed!", Color.Red);
                        c.logText(Environment.NewLine, Color.Black);
                        c.logText(Environment.NewLine, Color.Black);
                        target.Status = PC.charStatus.Dead;
                    }
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
