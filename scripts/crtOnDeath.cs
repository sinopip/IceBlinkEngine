using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;


namespace IceBlink
{
    public class IceBlinkScript
    {
		public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {   
        	Creature cr = (Creature)sf.CombatSource; // sf.getScriptOwnerCreature();
			//MessageBox.Show(cr.NameWithNotes+" death!");
            foreach (LocalString hs in cr.CharLocalStrings)
            	if (hs.Key == "OnDeathSound")
            	{   
            		sf.PlaySoundFX(hs.Value);
            	    break;                          
            	}
           	sf.frm.currentCombat.drawEndEffect(cr.CombatLocation, 0, "generic_death.spt"); // file doesn't exists, this does nothing
        }
    }
}
