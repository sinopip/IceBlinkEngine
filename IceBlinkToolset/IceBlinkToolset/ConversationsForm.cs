using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace IceBlinkToolset
{
    public partial class ConversationsForm : DockContent
    {
        public ParentForm prntForm;

        public ConversationsForm(ParentForm pf)
        {
            InitializeComponent();
            prntForm = pf;
        }

        #region Conversation Stuff
        public void refreshListBoxConvos()
        {
            //if (lbxAreas.Items.Count < 1)
            //{
            lbxConvos.BeginUpdate();
            lbxConvos.DataSource = null;
            lbxConvos.DataSource = prntForm.mod.ModuleConvosList;
            lbxConvos.EndUpdate();
            //}           
            DropdownStringLists.convoStringList = new List<string>();
            DropdownStringLists.convoStringList.Add("none");
            foreach (string s in prntForm.mod.ModuleConvosList)
            {
                DropdownStringLists.convoStringList.Add(s);
            }
        }
        private void txtConvoName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = txtConvoName.Text;
                refreshListBoxConvos();
                //containersList.containers[_selectedLbx1Index].containerName = txtName.Text;
                //refreshListBox1();
            }
            catch { }
        }
        private void btnAddConvo_Click_1(object sender, EventArgs e)
        {
            Convo newConvo = new Convo();
            newConvo.ConvoFileName = "new conversation";
            prntForm.mod.ModuleConvosList.Add(newConvo.ConvoFileName);
            refreshListBoxConvos();
            // should I create a new file at this point?
        }
        private void btnRemoveConvo_Click_1(object sender, EventArgs e)
        {
            if ((lbxConvos.Items.Count > 0) && (lbxConvos.SelectedIndex >= 0))
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxConvos.SelectedIndex;
                    prntForm.mod.ModuleConvosList.RemoveAt(selectedIndex);
                }
                catch { }
                prntForm._selectedLbxConvoIndex = 0;
                lbxConvos.SelectedIndex = 0;
                refreshListBoxConvos();
            }
        }
        private void btnEditConvo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((lbxConvos.Items.Count > 0) && (lbxConvos.SelectedIndex >= 0))
                {
                    EditConvo();
                    /*
                    ConvoEditor newChild = new ConvoEditor(prntForm.mod, prntForm);      //add new child
                    //   TabPage childTab = new TabPage();         //create new tab page
                    //    newChild.MdiParent = this;                       //set as child of this form
                    // should use the file name from selected convo in lbxConvos
                    //newChild.Name = "Child" + createdTab.ToString();
                    newChild.Text = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex];
                    //      newChild.setParent();
                    //childTab.Name = newChild.Name;           //make sure name and text are same
                    //      childTab.Text = newChild.Text;                  //this is for syncrhonize later
                    //      childTab.Tag = "ConvoEditor";
                    //              tabControl1.TabPages.Add(childTab);     //add new tab
                    //      newChild.convoMainEditorPanel.Parent = childTab;     //attach to tab
                    //            tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
                    newChild.Show(prntForm.dockPanel1);                                 //as new form created so that corresponding tab and child form is active
                    //      prntForm.createdTab++;   //increment of course
                    //mod.ModuleConvosList.Add("New Convo");
                    refreshListBoxConvos();
                    newChild.ce_filename = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml";
                    newChild.saveConvoFile();
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed: " + ex.ToString());
                prntForm.game.errorLog("failed: " + ex.ToString());
            }
        }
        private void lbxConvos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //MessageBox.Show("listBox selected index changed");
            if (lbxConvos.SelectedIndex >= 0)
            {
                prntForm._selectedLbxConvoIndex = lbxConvos.SelectedIndex;
                txtConvoName.Text = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex];
                lbxConvos.SelectedIndex = prntForm._selectedLbxConvoIndex;
            }
            //refreshListBoxAreas();
            //refreshLbxItems();
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if ((lbxConvos.Items.Count > 0) && (lbxConvos.SelectedIndex >= 0))
            {
                RenameDialog newName = new RenameDialog();
                DialogResult result = newName.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    /*try
                    {
                        prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = newName.RenameText;
                        refreshListBoxConvos();
                    }
                    catch { }
                    */
                    try
                    {
                        #region New Convo
                        if (prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] == "new conversation")
                        {
                            //if file exists, rename the file
                            string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\dialog";
                            if (File.Exists(filePath + "\\" + prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml"))
                            {
                                try
                                {
                                    //rename file
                                    File.Move(filePath + "\\" + prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml", filePath + "\\" + newName.RenameText + ".xml"); // Try to move
                                    try
                                    {
                                        //load area
                                        Convo newConvo = new Convo();
                                        newConvo = newConvo.GetConversation(filePath + "\\" + newName.RenameText + ".xml");
                                        if (newConvo == null)
                                        {
                                            MessageBox.Show("returned a null convo");
                                        }
                                        //change area file name in area file object properties
                                        newConvo.ConvoFileName = newName.RenameText;
                                        newConvo.SaveContentConversation(filePath + "\\" + newName.RenameText + ".xml");
                                        prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = newName.RenameText;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("failed to open file: " + ex.ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString()); // Write error
                                }
                            }
                            else
                            {
                                prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = newName.RenameText;
                            }
                            refreshListBoxConvos();
                        }
                        #endregion
                        #region Existing Convo
                        else
                        {
                            DialogResult sure = MessageBox.Show("Are you sure you wish to change the conversation name and the conversation file name? (make sure to update any references to this conversation name such as creature attached convo name and scripts)", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (sure == System.Windows.Forms.DialogResult.Yes)
                            {
                                //if file exists, rename the file
                                string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\dialog";
                                if (File.Exists(filePath + "\\" + prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml"))
                                {
                                    try
                                    {
                                        //rename file
                                        File.Move(filePath + "\\" + prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml", filePath + "\\" + newName.RenameText + ".xml"); // Try to move
                                        try
                                        {
                                            //load convo
                                            Convo newConvo = new Convo();
                                            newConvo = newConvo.GetConversation(filePath + "\\" + newName.RenameText + ".xml");
                                            if (newConvo == null)
                                            {
                                                MessageBox.Show("returned a null convo");
                                            }
                                            //change convo file name in convo file object properties
                                            newConvo.ConvoFileName = newName.RenameText;
                                            newConvo.SaveContentConversation(filePath + "\\" + newName.RenameText + ".xml");
                                            prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = newName.RenameText;
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("failed to open file: " + ex.ToString());
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString()); // Write error
                                    }
                                }
                                else
                                {
                                    prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] = newName.RenameText;
                                }
                                refreshListBoxConvos();
                            }
                        }
                        #endregion
                    }
                    catch { }
                }
            }
        }
        private void lbxConvos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lbxConvos.IndexFromPoint(e.Location);

            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //MessageBox.Show(index.ToString());
                //do your stuff here
                //prntForm._selectedLbxConvoIndex = index;
                try
                {
                    if ((lbxConvos.Items.Count > 0) && (lbxConvos.SelectedIndex >= 0))
                    {
                        EditConvo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed: " + ex.ToString());
                    prntForm.game.errorLog("failed: " + ex.ToString());
                }
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            prntForm.mod.ModuleConvosList = prntForm.mod.ModuleConvosList.OrderBy(o => o).ToList();
            refreshListBoxConvos();
        }
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if ((lbxConvos.Items.Count > 0) && (lbxConvos.SelectedIndex >= 0))
            {
                //if file exists, rename the file
                string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\dialog";
                string filename = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex];
                if (File.Exists(filePath + "\\" + filename + ".xml"))
                {
                    try
                    {
                        //rename file
                        File.Copy(filePath + "\\" + filename + ".xml", filePath + "\\" + filename + "-Copy.xml"); // Try to move
                        try
                        {
                            //load convo
                            Convo newConvo = new Convo();
                            newConvo = newConvo.GetConversation(filePath + "\\" + filename + "-Copy.xml");
                            if (newConvo == null)
                            {
                                MessageBox.Show("returned a null convo");
                            }
                            //change convo file name in convo file object properties
                            newConvo.ConvoFileName = filename + "-Copy";
                            newConvo.SaveContentConversation(filePath + "\\" + filename + "-Copy.xml");
                            prntForm.mod.ModuleConvosList.Add(newConvo.ConvoFileName);
                            refreshListBoxConvos();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("failed to open file: " + ex.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString()); // Write error
                    }
                }
                else
                {
                    MessageBox.Show("File: " + filename + ".xml does not exist in the dialog folder");
                }
                refreshListBoxConvos();
            }
        }                
        #endregion 

        private void EditConvo()
        {
            ConvoEditor newChild = new ConvoEditor(prntForm.mod, prntForm); //add new child
            newChild.Text = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex];
            newChild.Show(prntForm.dockPanel1);  //as new form created so that corresponding tab and child form is active
            refreshListBoxConvos();
            newChild.ce_filename = prntForm.mod.ModuleConvosList[prntForm._selectedLbxConvoIndex] + ".xml";
            newChild.saveConvoFile();
        }
    }
}
