// Disables the Trigger that the Party is currently on top of
// parm1 = the tag of the trigger (string)
// parm2 = not used
// parm3 = not used
// parm4 = not used
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
        public void Script(ScriptFunctions sf, string parm1, string parm2, string parm3, string parm4)
        {
            // C# code goes here            
            try
            {
                Trigger trig = sf.gm.currentArea.AreaTriggerList.getTriggerByTag(parm1);
                trig.Enabled = false;
            }
            catch
            {
                MessageBox.Show("can't find designated trigger tag in this area");
            }            
        }
    }
}
