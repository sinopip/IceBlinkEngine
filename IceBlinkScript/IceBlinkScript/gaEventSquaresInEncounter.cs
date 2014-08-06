//gaEventSquaresInEncounter.cs - Custom event stuff, place this script on the creature's OnStartCombatTurn script hook
//parm1 = none
//parm2 = none
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
        private List<Point> squaresList;
        private List<string> pcsEffected = new List<string>();

        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            squaresList = new List<Point>()
            {
                new Point(5,10),
                new Point(5,11),
                new Point(6,10),
                new Point(6,11)
            }; //you can add to this list as you need, just follow the pattern and make the last one not have a comma after ")"

            foreach (PC pc in sf.gm.playerList.PCList)
            {
                foreach (Point sqr in squaresList)
                {
                    if (pc.CombatLocation == sqr)
                    {
                        // do stuff here like
                        pcsEffected.Add(pc.Name);
                        pc.HP -= 3;
                        if (pc.HP <= 0)
                        {
                            pc.Status = CharBase.charStatus.Dead;
                        }
                    }
                }
            }

            if (CheckIfLastCreature(sf))
            {
                //remove the DM creature by giving it 0 HP, endCombat collector will do the rest in the combat engine
                Creature crt = (Creature)sf.CombatSource; //this is the creature that is calling this script
                crt.HP = 0;
            }

            string listOfPCs = "";
            foreach (string s in pcsEffected)
            {
                listOfPCs += s + ", ";
            }
            if (pcsEffected.Count > 0)
            {
                MessageBox.Show("The following PCs have taken 3 HP damage: " + Environment.NewLine +
                                 "(" + listOfPCs + ")");
            }
        }

        private bool CheckIfLastCreature(ScriptFunctions sf)
        {
            int foundCrt = 0;
            foreach (Creature crtr in sf.gm.currentEncounter.EncounterCreatureList.creatures)
            {
                if (crtr.HP > 0)
                {
                    foundCrt++;
                }
            }
            if (foundCrt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

