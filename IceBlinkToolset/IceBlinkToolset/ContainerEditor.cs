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
    public partial class ContainerEditor : DockContent
    {
        Items cte_itemsList = new Items();
        IceBlinkCore.Container cte_container = new IceBlinkCore.Container();

        public ContainerEditor(Items items, IceBlinkCore.Container container)
        {
            InitializeComponent();
            cte_itemsList = items;
            cte_container = container;
        }

        private void ContainerEditor_Load(object sender, EventArgs e)
        {
            cmbItems.DataSource = null;
            cmbItems.DataSource = cte_itemsList.itemsList;
            cmbItems.DisplayMember = "ItemName";
            refreshLbxItems();
        }

        /*private void openToolStripMenuItem_Click (object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            //Empty the FileName text box of the dialog
            openFileDialog1.FileName = String.Empty;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog1.SafeFileName;
                containersList = containersList.loadContainersFile(filename);
                if (containersList == null)
                {
                    MessageBox.Show("returned a null containers list");
                }
            }
            //refreshListBox1();
        }*/

        /*private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Containers files (*.cntr)|*.cntr|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = ".cntr";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            if (saveFileDialog1.FileName.Length == 0) return;
            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                string filename = Path.GetFileName(saveFileDialog1.FileName);
                MessageBox.Show("filename = " + filename);
                containersList.saveContainersFile(filename);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Containers files (*.cntr)|*.cntr|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = ".cntr";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            if (saveFileDialog1.FileName.Length == 0) return;
            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                string filename = Path.GetFileName(saveFileDialog1.FileName);
                MessageBox.Show("filename = " + filename);
                containersList.saveContainersFile(filename);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/
        
        /*private void loadItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = Environment.CurrentDirectory;
            //Empty the FileName text box of the dialog
            openFileDialog2.FileName = String.Empty;

            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                cte_itemsList.itemsList.Clear();
                string filename = openFileDialog2.SafeFileName;
                cte_itemsList = cte_itemsList.loadItemsFile(filename);
                if (cte_itemsList == null)
                {
                    MessageBox.Show("returned a null items list");
                }
                cmbItems.DataSource = null;
                cmbItems.DataSource = cte_itemsList.itemsList;
                cmbItems.DisplayMember = "ItemName";
            }
            //refreshListBox1();
            //refreshPanelInfo();
        }*/

        /*public void refreshListBox1()
        {
            //MessageBox.Show("listBox refresh");
            listBox1.BeginUpdate();
            listBox1.DataSource = null;
            listBox1.DataSource = containersList.containers;
            listBox1.DisplayMember = "ContainerName";
            listBox1.EndUpdate();
        }*/
        
        public void refreshLbxItems()
        {
            lbxItems.BeginUpdate();
            lbxItems.DataSource = null;
            lbxItems.DataSource = cte_container.items;
            lbxItems.EndUpdate();
        }

        /*public void refreshPanelInfo()
        {
            //MessageBox.Show("refresh panel");
            try
            {
                txtName.Text = containersList.containers[_selectedLbx1Index].containerName;
            }
            catch
            {
                //MessageBox.Show("failed to refresh panel");
            }
        }*/

        /*private void btnAddContainer_Click(object sender, EventArgs e)
        {
            IceBlinkCore.Container newContainer = new IceBlinkCore.Container();
            newContainer.containerName = "new Container";
            containersList.containers.Add(newContainer);
            //refreshListBox1();
            //refreshPanelInfo();
        }*/

        /*private void btnRemoveContainer_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1)
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = listBox1.SelectedIndex;
                    containersList.containers.RemoveAt(selectedIndex);
                }
                catch { }
                _selectedLbx1Index = 0;
                listBox1.SelectedIndex = 0;
                refreshListBox1();
            }
        }*/

        /*private void btnDuplicateContainer_Click(object sender, EventArgs e)
        {
            IceBlinkCore.Container newContainer = new IceBlinkCore.Container();
            newContainer.containerName = containersList.containers[_selectedLbx1Index].containerName;
            newContainer.items.AddRange(containersList.containers[_selectedLbx1Index].items);
            containersList.containers.Add(newContainer);
            refreshListBox1();
            refreshPanelInfo();
        }*/

        /*private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("listBox selected index changed");
            if (listBox1.SelectedIndex >= 0)
            {
                _selectedLbx1Index = listBox1.SelectedIndex;
            }
            refreshPanelInfo();
            listBox1.SelectedIndex = _selectedLbx1Index;
            refreshLbxItems();
        }*/

        /*private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                containersList.containers[_selectedLbx1Index].containerName = txtName.Text;
                refreshListBox1();
            }
            catch { }
        }*/

        private void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                string newItemName = cte_itemsList.itemsList[cmbItems.SelectedIndex].ItemName;
                string newItemTag = cte_itemsList.itemsList[cmbItems.SelectedIndex].ItemTag;
                cte_container.items.Add(newItemName);
                cte_container.containerItemTags.Add(newItemTag);
                refreshLbxItems();
            }
            catch { }
        }

        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            if (lbxItems.Items.Count > 0)
            {
                try
                {
                    if (lbxItems.SelectedIndex >= 0)
                    {
                        cte_container.items.RemoveAt(lbxItems.SelectedIndex);
                        cte_container.containerItemTags.RemoveAt(lbxItems.SelectedIndex);
                    }
                }
                catch { }
                refreshLbxItems();
            }
        }
    }
}
