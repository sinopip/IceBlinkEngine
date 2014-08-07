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
    public partial class ContainerDialogBox : IBForm
    {
        private int _selectedLbxIndex = 0;
        private Game cnt_game;
        private IceBlinkCore.Container cnt_container;

        public ContainerDialogBox(Game game, IceBlinkCore.Container container)
        {
            InitializeComponent();
            cnt_game = game;
            cnt_container = container;
            IceBlinkButtonResize.setupAll(cnt_game);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(cnt_game);
            IceBlinkButtonClose.Enabled = false;
            IceBlinkButtonClose.Visible = false;
            this.setupAll(cnt_game);
            groupBox1.setupAll(cnt_game);
            btnCloseContainer.setupAll(cnt_game);
            btnLootAll.setupAll(cnt_game);
            btnTakeSelected.setupAll(cnt_game);
            refreshPanel();
            refreshFonts();
        }
        public void refreshFonts()
        {
            lbxItems.BackColor = cnt_game.module.ModuleTheme.StandardBackColor;
            groupBox1.Font = cnt_game.module.ModuleTheme.ModuleFont;
            lbxItems.Font = Form1.ChangeFontSizeStatic(cnt_game.module.ModuleTheme.ModuleFont, 1.25f);
            btnCloseContainer.Font = Form1.ChangeFontSizeStatic(cnt_game.module.ModuleTheme.ModuleFont, 0.85f);
            btnLootAll.Font = Form1.ChangeFontSizeStatic(cnt_game.module.ModuleTheme.ModuleFont, 0.85f);
            btnTakeSelected.Font = Form1.ChangeFontSizeStatic(cnt_game.module.ModuleTheme.ModuleFont, 0.85f);
            this.Invalidate();
        }
        private void btnLootAll_Click(object sender, EventArgs e)
        {
            foreach(Item newItem in cnt_container.containerInventoryList)
            {
                cnt_game.partyInventoryList.Add(newItem);
                cnt_game.partyInventoryTagList.Add(newItem.ItemTag);
            }
            cnt_container.containerInventoryList.Clear();
            cnt_container.items.Clear();
            cnt_container.containerItemTags.Clear();
            refreshPanel();
            this.Close();
        }

        private void btnTakeSelected_Click(object sender, EventArgs e)
        {
            if (cnt_container.containerInventoryList.Count > 0)
            {
                cnt_game.partyInventoryList.Add(cnt_container.containerInventoryList[lbxItems.SelectedIndex]);
                cnt_game.partyInventoryTagList.Add(cnt_container.containerInventoryList[lbxItems.SelectedIndex].ItemTag);
                cnt_container.containerInventoryList.RemoveAt(lbxItems.SelectedIndex);
                cnt_container.items.RemoveAt(lbxItems.SelectedIndex);
                cnt_container.containerItemTags.RemoveAt(lbxItems.SelectedIndex);
                refreshPanel();
            }
        }

        private void btnCloseContainer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _selectedLbxIndex = lbxItems.SelectedIndex;
            refreshPanel();
            lbxItems.SelectedIndex = _selectedLbxIndex;
        }

        public void refreshPanel()
        {
            //IBMessageBox.Show(game, "listBox refresh");
            lbxItems.BeginUpdate();

            lbxItems.DataSource = null;
            lbxItems.DataSource = cnt_container.containerInventoryList;
            lbxItems.DisplayMember = "ItemName";

            lbxItems.EndUpdate();
        }
    }
}
