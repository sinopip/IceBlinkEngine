using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using IceBlinkToolset;
using System.IO;

namespace IceBlinkCore
{
    public partial class ScriptSelect : Form
    {
        public IWindowsFormsEditorService _wfes;
        public ScriptSelectEditorReturnObject returnObject = new ScriptSelectEditorReturnObject();
        public ParentForm prntForm;
        public List<string> scriptList = new List<string>();
        public bool firstTimeThrough = true;

        public ScriptSelect(ScriptSelectEditorReturnObject retObj, IWindowsFormsEditorService w)
        {
            InitializeComponent();
            this.TopLevel = false;
            this._wfes = w;
            this.returnObject = retObj;
            this.prntForm = returnObject.prntForm;
            refreshCmbBoxes();
            if (cmbObjectTagFilename.Items.Count > 0)
                cmbObjectTagFilename.SelectedIndex = 0;
        }

        #region Methods
        public void refreshCmbBoxes()
        {            
            fillScriptList();
            cmbObjectTagFilename.BeginUpdate();
            cmbObjectTagFilename.DataSource = null;
            cmbObjectTagFilename.DataSource = scriptList;
            cmbObjectTagFilename.EndUpdate();            
        }
        private void fillScriptList()
        {
            if (prntForm != null)
            {
                scriptList.Clear();
                string jobDir = "";
                if (prntForm.mod.ModuleName != "NewModule")
                {
                    jobDir = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\scripts";
                }
                else
                {
                    jobDir = prntForm._mainDirectory + "\\data\\NewModule\\scripts";
                }
                scriptList.Add("none");
                foreach (string f in Directory.GetFiles(jobDir, "*.cs"))
                {
                    string filename = Path.GetFileName(f);
                    scriptList.Add(filename);
                }
                string defaultDir = prntForm._mainDirectory + "\\data\\scripts";
                foreach (string f in Directory.GetFiles(defaultDir, "*.cs"))
                {
                    string filename = Path.GetFileName(f);
                    if (!scriptList.Contains(filename))
                    {
                        scriptList.Add(filename);
                    }
                }
            }
        }        
        private void refreshPanel()
        {            
            parm1.Text = returnObject.Parm1;
            parm2.Text = returnObject.Parm2;
            parm3.Text = returnObject.Parm3;
            parm4.Text = returnObject.Parm4;
            cmbObjectTagFilename.SelectedIndex = cmbObjectTagFilename.FindStringExact(returnObject.FilenameOrTag);
        }
        #endregion

        #region Event Handlers
        private void parm1_TextChanged_1(object sender, EventArgs e)
        {
            returnObject.Parm1 = parm1.Text;
        }
        private void parm2_TextChanged_1(object sender, EventArgs e)
        {
            returnObject.Parm2 = parm2.Text;
        }
        private void parm3_TextChanged_1(object sender, EventArgs e)
        {
            returnObject.Parm3 = parm3.Text;
        }
        private void parm4_TextChanged_1(object sender, EventArgs e)
        {
            returnObject.Parm4 = parm4.Text;
        }
        private void cmbObjectTagFilename_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if ((returnObject != null) && (cmbObjectTagFilename.SelectedItem != null))
                {
                    if (!firstTimeThrough)
                    {
                        returnObject.FilenameOrTag = cmbObjectTagFilename.SelectedItem.ToString();
                    }
                    firstTimeThrough = false;                    
                    //load script into rtxt for browsing
                    string jobDir = "";
                    if (prntForm != null)
                    {
                        if (prntForm.mod.ModuleName != "NewModule")
                        {
                            jobDir = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\scripts";
                        }
                        else
                        {
                            jobDir = prntForm._mainDirectory + "\\data\\NewModule\\scripts";
                        }
                    }
                    try
                    {
                        if (cmbObjectTagFilename.SelectedItem.ToString() != "none")
                        {
                            if (File.Exists(jobDir + "\\" + cmbObjectTagFilename.SelectedItem.ToString()))
                            {
                                rtxtScript.LoadFile(jobDir + "\\" + cmbObjectTagFilename.SelectedItem.ToString(), RichTextBoxStreamType.PlainText);
                            }
                            else if (File.Exists(prntForm._mainDirectory + "\\data\\scripts\\" + cmbObjectTagFilename.SelectedItem.ToString()))
                            {
                                rtxtScript.LoadFile(prntForm._mainDirectory + "\\data\\scripts\\" + cmbObjectTagFilename.SelectedItem.ToString(), RichTextBoxStreamType.PlainText);
                            }
                            else
                            {
                                rtxtScript.Text = "";
                            }
                        }
                        else
                        {
                            rtxtScript.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, please let us know: " + ex.ToString());
                prntForm.game.errorLog(ex.ToString());
            }
        }
        private void ScriptSelect_Load(object sender, EventArgs e)
        {
            refreshPanel();
        }
        private void ScriptSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            _wfes.CloseDropDown();
        }
        #endregion        
    }
}
