using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using IceBlinkCore;
using IceBlink;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
			
            Creature source = sf.GetActionCreatureData();
            Point ptsource = (Point)sf.CombatTarget;
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }      
 
            SpellParameters sp = new SpellParameters();
            sp.Name = "Tornado";
            sp.TargetType = "any";
            sp.Type = "Damage";
            sp.NbDice = source.ClassLevel;
            sp.Die = 3;
            sp.DiceAdd = 0;
            sp.BaseDC = 12;
            sp.Save = "Reflex";
            sp.StatMod = "CHA";
            sp.SuccessSaveResistance = 0.5;
            sp.EnergySource = "Bludgeoning";
			sp.SpellColor = Color.Red;
            sp.Description = "is stuck";
			sp.EffectDescription = "is blowned to the ground!";
            sp.Effect = sf.gm.module.moduleEffectsList.getEffectByTag("kd"); 
            sf.DoSpell(sp);
			// displacement
			List<object> targets = sf.GetAllCombatTargets("any");
			foreach (object t in targets)
			{
				// trying to find a free tile
				int rnd_tile = sf.gm.Random(3)-1;
				for (int i=0; i < 3; i++)
				{
					rnd_tile = (rnd_tile + 1) % 3;
					Point ptdestination = new Point();
					if (t is PC)
					{
						ptdestination = ((PC)t).CombatLocation;
						if (((PC)t).CombatLocation.Y < ptsource.Y)
						{
							ptdestination.Y = ptdestination.Y - 1;
							ptdestination.X += rnd_tile - 1;
						}
						else if (((PC)t).CombatLocation.Y > ptsource.Y)
						{
							ptdestination.Y = ptdestination.Y + 1;
							ptdestination.X += rnd_tile - 1;
						}
						else if (((PC)t).CombatLocation.X < ptsource.X)
						{
							ptdestination.X = ptdestination.X - 1;
							ptdestination.Y += rnd_tile - 1;
						}
						else if (((PC)t).CombatLocation.X > ptsource.X)
						{
							ptdestination.X = ptdestination.X + 1;
							ptdestination.Y += rnd_tile - 1;
						}
					}
					else if (t is Creature)
					{
						ptdestination = ((Creature)t).CombatLocation;
						if (((Creature)t).CombatLocation.Y < ptsource.Y)
						{
							ptdestination.Y = ptdestination.Y - 1;
							ptdestination.X += rnd_tile - 1;
						}
						else if (((Creature)t).CombatLocation.Y > ptsource.Y)
						{
							ptdestination.Y = ptdestination.Y + 1;
							ptdestination.X += rnd_tile - 1;
						}
						else if (((Creature)t).CombatLocation.X < ptsource.X)
						{
							ptdestination.X = ptdestination.X - 1;
							ptdestination.Y += rnd_tile - 1;
						}
						else if (((Creature)t).CombatLocation.X > ptsource.X)
						{
							ptdestination.X = ptdestination.X + 1;
							ptdestination.Y += rnd_tile - 1;
						}	
					}
					if (sf.gm.currentCombatArea.getCreatureByLocation(ptdestination.X,ptdestination.Y) != null)
						    continue;
					foreach (PC pc in sf.gm.playerList.PCList)
						if (pc.CombatLocation.X == ptdestination.X && pc.CombatLocation.Y == ptdestination.Y)
					      continue;
					
					//MessageBox.Show(ptsource.ToString() + " -> " +ptdestination.ToString());
					if ((t is PC && ((PC)t).HP > 0) || (t is Creature && ((Creature)t).HP > 0))
						if (ptdestination != ptsource)
						{
							if (t is PC)
								sf.frm.currentCombat.drawEndEffect(((PC)t).CombatLocation, 0, "stars.spt");
							else if (t is Creature)
								sf.frm.currentCombat.drawEndEffect(((Creature)t).CombatLocation, 0, "stars.spt");
							sf.frm.currentCombat.Refresh();
							Thread.Sleep(100);
							sf.frm.currentCombat.drawEndEffect(ptdestination, 0, "stars.spt");
							sf.frm.currentCombat.Refresh();
							Thread.Sleep(100);
						}
					if (t is PC)
						((PC)t).CombatLocation = ptdestination;
					else if (t is Creature)
						((Creature)t).CombatLocation = ptdestination;
					sf.frm.currentCombat.Refresh();
							Thread.Sleep(100);
					break;
				}
			}
        }
    }
}
