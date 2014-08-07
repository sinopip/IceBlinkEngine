//gaRemovePropByTag.cs - Removes a prop from any area, must use the tag of the placed prop
//parm1 = (string) the tag of the prop after placed on the map (not tag when in prop list)
//parm2 = not used
//parm3 = not used
//parm4 = not used
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
            // C# code goes here
            //removes a prop from any area, looking for placed prop tag
            try
            {
                foreach (Area ar in sf.gm.module.ModuleAreasObjects)
                {
                    Prop prp = ar.AreaPropList.getPropByTag(p1);
                    if (prp != null)
                    {
                        ar.AreaPropList.propsList.Remove(prp);
                        return;
                    }
                }
                IBMessageBox.Show(sf.gm, "can't find designated prop tag in any area");
            }
            catch
            {
                IBMessageBox.Show(sf.gm, "Error...failed trying to find prop in any area");
            }
        }
    }
}
