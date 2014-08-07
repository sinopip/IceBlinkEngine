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
    public partial class UseItemCombat : IBForm
    {
        public Game uic_game;
        public Form1 uic_frm;
        public int _selectedLbxIndex;
        private int _selectedPC = 0; 

        public UseItemCombat(Game game, Form1 frm, int PCindex)
        {
            InitializeComponent();
            uic_game = game;
            uic_frm = frm;
            IceBlinkButtonResize.setupAll(uic_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(uic_game);
            groupBox1.setupAll(uic_game);
            groupBox3.setupAll(uic_game);
            btnExit.setupAll(uic_game);
            btnUseItem.setupAll(uic_game);
            this.setupAll(uic_game);
            _selectedPC = PCindex;
            _selectedLbxIndex = 0;
            refreshlbxItems();
            refreshPanelInfo();
            refreshFonts();
        }
        public void refreshFonts()
        {
            groupBox1.Font = uic_game.module.ModuleTheme.ModuleFont;
            groupBox3.Font = uic_game.module.ModuleTheme.ModuleFont;
            lbxInventory.Font = uic_game.module.ModuleTheme.ModuleFont;
            txtDesc.Font = uic_game.module.ModuleTheme.ModuleFont;
            btnExit.Font = uic_game.module.ModuleTheme.ModuleFont;
            btnUseItem.Font = uic_game.module.ModuleTheme.ModuleFont;
            this.Invalidate();
        }
        public void refreshlbxItems()
        {
            //IBMessageBox.Show(game, "listBox refresh");
            lbxInventory.BeginUpdate();

            lbxInventory.DataSource = null;
            lbxInventory.DataSource = uic_game.partyInventoryList;
            lbxInventory.DisplayMember = "ItemName";

            lbxInventory.EndUpdate();
        }

        public void refreshPanelInfo()
        {
            if (uic_game.partyInventoryList.Count > 0)
            {
                //IBMessageBox.Show(game, "refresh panel");
                //IBMessageBox.Show(game, "panel selectedIndex = " + _selectedLbxIndex.ToString());
                txtDesc.Text = uic_game.partyInventoryList[_selectedLbxIndex].ItemDescription;
            }
        }

        private void lbxInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxInventory.SelectedIndex >= 0)
                _selectedLbxIndex = lbxInventory.SelectedIndex;

            refreshPanelInfo();
            lbxInventory.SelectedIndex = _selectedLbxIndex;            
        }

        private void btnUseItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            uic_game.indexOfPCtoLastUseItem = _selectedPC;
            if ((uic_game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == "none") || (uic_game.partyInventoryList[_selectedLbxIndex].OnUseItem.FilenameOrTag == ""))
            //if (uic_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename == "")
            {
                IBMessageBox.Show(uic_game, "Item does nothing");
            }
            else
            {
                try
                {
                    uic_frm.sf.MainMapScriptCall = true; //can be used as a flag in your scripts that the call is coming from the main map
                    var scriptItm = uic_game.partyInventoryList[_selectedLbxIndex].OnUseItem;
                    uic_frm.doScriptBasedOnFilename(scriptItm.FilenameOrTag, scriptItm.Parm1, scriptItm.Parm2, scriptItm.Parm3, scriptItm.Parm4);
                
                    //uic_frm.doScriptBasedOnFilename(uic_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs", "", "", "", "");
                    //uic_game.executeScript(uic_game.mainDirectory + "\\modules\\" + uic_game.module.ModuleFolderName + "\\scripts\\" + uic_game.partyInventoryList[_selectedLbxIndex].ItemScriptFilename + ".cs");
                    if (uic_game.deleteItemUsedScript)
                    {
                        uic_game.partyInventoryList.RemoveAt(_selectedLbxIndex);
                        uic_game.partyInventoryTagList.RemoveAt(_selectedLbxIndex);
                        _selectedLbxIndex = 0;
                        refreshlbxItems();
                        refreshPanelInfo();
                        uic_game.deleteItemUsedScript = false;
                    }
                }
                catch (Exception ex)
                {
                    IBMessageBox.Show(uic_game, "failed to fire item script");
                    uic_game.errorLog(ex.ToString());
                }
                finally
                {
                    uic_frm.sf.MainMapScriptCall = false; //set back to false after use
                }
            }
            // do this.close to end use item
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
