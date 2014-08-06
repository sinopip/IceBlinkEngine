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
            if (sf.passParameterScriptObject is PC)
            {
                PC source = (PC)sf.passParameterScriptObject;
                source.HPMax += (1 * source.ClassLevel);
            }
            else if (sf.passParameterScriptObject is Creature)
            {
                Creature source = (Creature)sf.passParameterScriptObject;
                source.HPMax += (1 * source.ClassLevel);
            }
            else // don't know who cast this spell
            {
                MessageBox.Show("Invalid script owner, not a Creature of PC");
                return;
            }
        }
    }
}
