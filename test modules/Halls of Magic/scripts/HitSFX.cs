using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using IceBlinkCore;
using IceBlink;
using System.Threading;

namespace IceBlink
{
    public class IceBlinkScript
    {
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {
            // C# code goes here
            if (p1 != "" && p1!="none")
			{
			try
			{
			  Creature cr = (Creature)sf.CombatSource;
              sf.PlaySoundFX(p1);
			} catch {}}
			else try
			{
            //Item it = sf.gm.scriptOwnerItem;
			PC pc = sf.gm.playerList.PCList[sf.gm.scriptOwnerIndexOfPC];            
            foreach (LocalString hs in pc.MainHand.ItemLocalStrings)
            	if (hs.Key == "OnHitSound")
            	{            	            	
            		sf.PlaySoundFX(hs.Value);
            		break;                          
            	}
			} catch {} 
        }
    }
}
