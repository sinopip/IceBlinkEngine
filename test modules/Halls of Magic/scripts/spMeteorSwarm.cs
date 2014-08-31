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
            
            Creature source = sf.GetActionCreatureData();
            if (source == null)
            {
            	MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }                           
 
            SpellParameters sp = new SpellParameters();
            sp.Name = "Meteor Swarm";
            sp.TargetType = "any";
            sp.Type = "Damage";
            sp.NbDice = source.ClassLevel / 2+1;
            sp.Die = 4;
            sp.DiceAdd = 0;
            sp.BaseDC = 15;
            sp.Save = "Reflex";
            sp.StatMod = "INT";
            sp.SuccessSaveResistance = 0.5;
            sp.EnergySource = "Fire";
			sp.SpellColor = Color.Red;
            sp.Description = "is burned";
			sp.SpriteFileName = "explosion1x1.spt";
            sp.SoundFX = "fireball_end.wav";
            sf.DoSpell(sp);
            Point OriginalTargetPoint = (Point)sf.CombatTarget;
            for (int i=0; i<3; i++)
            {
            	Point TargetPoint = new Point();
            	TargetPoint.X = OriginalTargetPoint.X + sf.gm.Random(3)-2;
            	TargetPoint.Y = OriginalTargetPoint.Y + sf.gm.Random(3)-2;
            	sf.CombatTarget = TargetPoint;
            	sf.frm.currentCombat.attackPcAnimation((PC)sf.CombatSource, 0);
            	Point pxSourcePoint = new Point(source.CombatLocation.X *sf.gm._squareSize+sf.gm._squareSize/2,
            	                                source.CombatLocation.Y *sf.gm._squareSize+sf.gm._squareSize/2);
            	Point pxTargetPoint = new Point(TargetPoint.X *sf.gm._squareSize+sf.gm._squareSize/2,
            	                                TargetPoint.Y *sf.gm._squareSize+sf.gm._squareSize/2);
            	sf.PlaySoundFX("sml_fireball_launch.wav");
            	sf.frm.currentCombat.drawProjectile(pxSourcePoint, pxTargetPoint, "firebolt.spt");
            	//sf.PlaySoundFX("fireball_end.wav");
            	sf.frm.currentCombat.drawEndEffect(TargetPoint, 1, "explosion3x3.spt");
            	sf.DoSpellAction(sp, false);
            	sf.frm.currentCombat.Refresh();
            }
        }
    }
}
