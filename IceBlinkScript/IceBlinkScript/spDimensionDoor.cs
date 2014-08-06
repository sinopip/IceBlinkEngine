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
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;

                if (IsOpen(target, sf, c))
                {
                    c.logText(source.Name, Color.Blue);
                    c.logText(" teleports to another location", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    source.CombatLocation = target;
                }
                else
                {
                    c.logText(source.Name, Color.Blue);
                    c.logText(" fails to teleport, square is already occupied", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }                
            }          
            else if (sf.CombatSource is Creature)
            {
                Creature source = (Creature)sf.CombatSource;
                Point target = (Point)sf.CombatTarget;
                Combat c = sf.frm.currentCombat;

                if (IsOpen(target, sf, c))
                {
                    c.logText(source.Name, Color.Blue);
                    c.logText(" teleports to another location", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    source.CombatLocation = target;
                }
                else
                {
                    c.logText(source.Name, Color.Blue);
                    c.logText(" fails to teleport, square is already occupied", Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                    c.logText(Environment.NewLine, Color.Black);
                }
            }
            else // don't know who cast this spell
            {
                MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            } 
        }

        public bool IsOpen(Point target, ScriptFunctions sf, Combat c)
        {
            foreach (PC pc in sf.gm.playerList.PCList)
            {
                if (pc.CombatLocation == target) { return false; }
            }
            foreach (Creature crt in c.com_encounter.EncounterCreatureList.creatures)
            {
                if (crt.CombatLocation == target) { return false; }
            }
            return true;
        }
    }
}
