using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;

namespace IceBlink
{
    public partial class Debug : IBForm
    {
        private string _scriptToRun;
        private Game game;
        private Form1 frm;

        public Debug()
        {
            InitializeComponent();
        }

        public void passRefs(Form1 frm, Game game)
        {
            this.game = game;
            this.frm = frm;
            IceBlinkButtonResize.setupAll(game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(game);
            btnConsoleScript.setupAll(game);
            this.setupAll(game);
            rtxtMainLog.BackColor = game.module.ModuleTheme.StandardBackColor;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Z) && (!txtConsoleScript.Focused))
            {
                if (frm.debugOpen)
                {
                    frm.debugForm.Hide();
                    frm.debugOpen = false;
                }
                else
                {
                    frm.debugForm.Show();
                    frm.debugOpen = true;
                }
                return true;
            }            
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
        private void txtConsoleScript_TextChanged(object sender, EventArgs e)
        {
            _scriptToRun = txtConsoleScript.Text;
        }
        private void btnConsoleScript_Click(object sender, EventArgs e)
        {
            try
            {
                game.executeScript(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\scripts\\" + _scriptToRun + ".cs");
                //if (game.addPCScriptFired)
                //{
                //    frm.addPCtoParty();
                //    game.addPCScriptFired = false;
                //}
            }
            catch (Exception ex)
            {
                IBMessageBox.Show(game, "failed to run script");
                game.errorLog(ex.ToString());
            }
        }
        private void Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm.debugOpen = false;
            e.Cancel = true; // this cancels the close event.
        }

        private void btnResetCompiledScripts_Click(object sender, EventArgs e)
        {
            game.assemblyObjList.Clear();
            frm.logMainText("cleared all stored compiled scripts", Color.Black);
            frm.logMainText(Environment.NewLine, Color.Black);
        }
    }
}
