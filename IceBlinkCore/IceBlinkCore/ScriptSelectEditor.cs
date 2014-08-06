using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace IceBlinkCore
{
    public class ScriptSelectEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService wfes = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            if (wfes != null)
            {
                ScriptSelect scriptObjSelect = new ScriptSelect((ScriptSelectEditorReturnObject)value, wfes);
                scriptObjSelect._wfes = wfes;
                wfes.DropDownControl(scriptObjSelect);
                value = scriptObjSelect.returnObject;
            }
            return value;
        }
    }
}
