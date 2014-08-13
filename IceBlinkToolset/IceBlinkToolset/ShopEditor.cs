using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace IceBlinkToolset
{
    public partial class ShopEditor : Form
    {
        private ParentForm prntForm;
        private Module mod;
        private Game game;
        private int selectedLbxIndex = 0;

        public ShopEditor(Module m, Game g, ParentForm p)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = p;
        }

        #region Handlers
        private void ShopEditor_Load(object sender, EventArgs e)
        {
            cmbItems.DataSource = null;
            cmbItems.DataSource = prntForm.itemsList.itemsList;
            cmbItems.DisplayMember = "ItemName";
            refreshLbxItems();
            refreshListBox();
        }
        private void lbxShops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((lbxShops.SelectedIndex >= 0) && (prntForm.shopsList.shopsList != null))
            {
                selectedLbxIndex = lbxShops.SelectedIndex;
                lbxShops.SelectedIndex = selectedLbxIndex;
                propertyGrid1.SelectedObject = prntForm.shopsList.shopsList[selectedLbxIndex];
                refreshLbxItems();
                refreshListBox();
            }
        }
        private void btnAddShop_Click(object sender, EventArgs e)
        {

            Shop newShop = new Shop();
            newShop.ShopTag = "newShopTag" + prntForm.mod.NextIdNumber.ToString();
            prntForm.shopsList.shopsList.Add(newShop);
            refreshListBox();
        }
        private void btnRemoveShop_Click(object sender, EventArgs e)
        {
            if (prntForm.shopsList.shopsList.Count > 0)
            {
                if (lbxShops.Items.Count > 0)
                {
                    try
                    {
                        int selectedIndex = lbxShops.SelectedIndex;
                        prntForm.shopsList.shopsList.RemoveAt(selectedIndex);
                    }
                    catch { }
                    prntForm._selectedLbxContainerIndex = 0;
                    lbxShops.SelectedIndex = 0;
                    refreshLbxItems();
                    refreshListBox();                    
                }
            }
        }
        private void btnDuplicateShop_Click(object sender, EventArgs e)
        {
            if (prntForm.shopsList.shopsList.Count > 0)
            {
                Shop newCopy = prntForm.shopsList.shopsList[selectedLbxIndex].DeepCopy();
                newCopy.passRefs(game);
                newCopy.ShopTag = "newCopiedShopTag_" + prntForm.mod.NextIdNumber.ToString();
                prntForm.shopsList.shopsList.Add(newCopy);
                refreshListBox();
                refreshLbxItems();
            }
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            if (prntForm.shopsList.shopsList.Count > 0)
            {
                try
                {
                    string newTag;
                    newTag = prntForm.itemsList.itemsList[cmbItems.SelectedIndex].ItemTag;
                    prntForm.shopsList.shopsList[selectedLbxIndex].shopItemTags.Add(newTag);
                    string newName;
                    newName = prntForm.itemsList.itemsList[cmbItems.SelectedIndex].ItemName;
                    prntForm.shopsList.shopsList[selectedLbxIndex].shopItemNames.Add(newName);
                }
                catch { }
            }
            refreshLbxItems();
            refreshListBox();
        }
        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (lbxItems.Items.Count > 0)
            {
                try
                {
                    if (lbxItems.SelectedIndex >= 0)
                    {
                        prntForm.shopsList.shopsList[selectedLbxIndex].shopItemTags.RemoveAt(lbxItems.SelectedIndex);
                        prntForm.shopsList.shopsList[selectedLbxIndex].shopItemNames.RemoveAt(lbxItems.SelectedIndex);
                    }
                }
                catch { }
                refreshLbxItems();
                refreshListBox();
            }
        }        
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            refreshListBox();
        }
        #endregion

        #region Methods
        private void refreshListBox()
        {
            if (prntForm.shopsList.shopsList.Count > 0)
            {
                lbxShops.BeginUpdate();
                lbxShops.DataSource = null;
                lbxShops.DataSource = prntForm.shopsList.shopsList;
                lbxShops.DisplayMember = "ShopTag";
                lbxShops.EndUpdate();
            }
            else
            {
                lbxShops.BeginUpdate();
                lbxShops.DataSource = null;
                lbxShops.EndUpdate();
            }
        }
        public void refreshLbxItems()
        {
            if (prntForm.shopsList.shopsList.Count > 0)
            {
                if (prntForm.shopsList.shopsList[selectedLbxIndex].shopItemTags.Count > 0)
                {
                    lbxItems.BeginUpdate();
                    lbxItems.DataSource = null;
                    lbxItems.DataSource = prntForm.shopsList.shopsList[selectedLbxIndex].shopItemNames;
                    lbxItems.EndUpdate();
                }
                else
                {
                    lbxItems.BeginUpdate();
                    lbxItems.DataSource = null;
                    lbxItems.EndUpdate();
                }
            }
            else
            {
                lbxItems.BeginUpdate();
                lbxItems.DataSource = null;
                lbxItems.EndUpdate();
            }
        }
        #endregion
    }
}
