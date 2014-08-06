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
            string propTag = (string)sf.passParameterScriptObject;
            Prop prp = sf.GetPropByTag(propTag);
            PropRefs prpRef = sf.GetPropRefsByTag(propTag);
            if ((prp != null) && (prpRef != null))
            {
                prp.PropLocked = false;
                prpRef.PropLockedChk = false;
            }
        }
    }
}
