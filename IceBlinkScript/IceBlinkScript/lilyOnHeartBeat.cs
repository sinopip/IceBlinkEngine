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
        public void Script(ScriptFunctions sf, string p1, string p2, string p3, string p4)
        {            
            // C# code goes here
            int chance = sf.gm.Random(20);
            MessageBox.Show("random = " + chance.ToString());
            if (chance == 1)
            {
                sf.DrawFloatyTextOverThisScriptOwnerCreature("Hello there!", 100); //will use White and Black as default
            }
            if (chance == 2)
            {
                sf.DrawFloatyTextOverThisScriptOwnerCreature("Can you please help me?", 100, Color.Green, Color.Black);
            }
            if (chance == 3)
            {
                sf.DrawFloatyTextOverThisScriptOwnerCreature("This place is giving me the creeps!", 100, Color.Yellow, Color.Red);
            }
            if (chance == 4)
            {
                sf.DrawFloatyTextOverThisScriptOwnerCreature("Watch out for skeletons, my friends.", 100, Color.Red, Color.Black);
            }
        }
    }
}
