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
    public partial class AreaForm : DockContent
    {
        public ParentForm prntForm;

        public AreaForm(ParentForm pf)
        {
            InitializeComponent();
            prntForm = pf;
        }

        #region Area Stuff
        public void refreshListBoxAreas()
        {
            //if (lbxAreas.Items.Count < 1)
            //{
            lbxAreas.BeginUpdate();
            lbxAreas.DataSource = null;
            lbxAreas.DataSource = prntForm.mod.ModuleAreasList;
            lbxAreas.EndUpdate();
            //}
        }
        private void lbxAreas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((lbxAreas.Items.Count > 0) && (lbxAreas.SelectedIndex >= 0))
            {
                int index = this.lbxAreas.IndexFromPoint(e.Location);

                if (index != System.Windows.Forms.ListBox.NoMatches)
                {

                    //MessageBox.Show(index.ToString());
                    //do your stuff here
                    //prntForm._selectedLbxAreaIndex = index;
                    EditArea();
                }
            }
        }
        private void lbxAreas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //MessageBox.Show("listBox selected index changed");
            if (lbxAreas.SelectedIndex >= 0)
            {
                prntForm._selectedLbxAreaIndex = lbxAreas.SelectedIndex;
                txtAreaName.Text = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
                lbxAreas.SelectedIndex = prntForm._selectedLbxAreaIndex;                
            }
            //refreshListBoxAreas();
            //refreshLbxItems();
        }
        private void txtAreaName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] = txtAreaName.Text;
                refreshListBoxAreas();
                //containersList.containers[_selectedLbx1Index].containerName = txtName.Text;
                //refreshListBox1();
            }
            catch { }
        }
        private void btnAddArea_Click_1(object sender, EventArgs e)
        {
            Area newArea = new Area();
            newArea.AreaFileName = "new area";
            prntForm.mod.ModuleAreasList.Add(newArea.AreaFileName);
            refreshListBoxAreas();
            // should I create a new file at this point?
        }
        private void btnRemoveArea_Click_1(object sender, EventArgs e)
        {
            if ((lbxAreas.Items.Count > 0) && (lbxAreas.SelectedIndex >= 0))
            {
                try
                {
                    // The Remove button was clicked.
                    int selectedIndex = lbxAreas.SelectedIndex;
                    prntForm.mod.ModuleAreasList.RemoveAt(selectedIndex);
                }
                catch { }
                prntForm._selectedLbxAreaIndex = 0;
                lbxAreas.SelectedIndex = 0;
                refreshListBoxAreas();
            }
        }
        private void btnEditArea_Click_1(object sender, EventArgs e)
        {
            if ((lbxAreas.Items.Count > 0) && (lbxAreas.SelectedIndex >= 0))
            {
                EditArea();
                /*
                LevelEditor newChild = new LevelEditor(prntForm.mod, prntForm.game, prntForm);      //add new child
                //            TabPage childTab = new TabPage();         //create new tab page
                //          newChild.MdiParent = this;                       //set as child of this form
                //newChild.Name = "Child" + createdTab.ToString();            
                // should use the file name from selected area in lbxAreas
                // should automatically load area image and .level file upon clicking on the edit button

                //newChild.Text = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] + "   [X]";
                newChild.Text = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
                //childTab.Name = newChild.Name;           //make sure name and text are same
                //          childTab.Text = newChild.Text;                  //this is for syncrhonize later
                //        childTab.Tag = "LevelEditor";
                //            prntForm.tabControl1.TabPages.Add(childTab);     //add new tab
                //      newChild.LevelEditorPanel.Parent = childTab;     //attach to tab
                //            prntForm.tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
                newChild.Show(prntForm.dockPanel1);                                 //as new form created so that corresponding tab and child form is active
                //    prntForm.createdTab++;   //increment of course
                //mod.ModuleAreasList.Add("New Area");
                refreshListBoxAreas();
                newChild.g_directory = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\areas";
                newChild.g_filename = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
                //newChild.saveTilemapFile();
                */
            }
        }
        private void btnRename_Click(object sender, EventArgs e)
        {
            if ((lbxAreas.Items.Count > 0) && (lbxAreas.SelectedIndex >= 0))
            {
                RenameDialog newName = new RenameDialog();
                DialogResult result = newName.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        #region New Area
                        if (prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] == "new area")
                        {
                            //if file exists, rename the file
                            string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\areas";
                            if (File.Exists(filePath + "\\" + prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] + ".level"))
                            {
                                try
                                {
                                    //rename file
                                    File.Move(filePath + "\\" + prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] + ".level", filePath + "\\" + newName.RenameText + ".level"); // Try to move
                                    try
                                    {
                                        //load area
                                        Area newArea = new Area();
                                        newArea = newArea.loadAreaFile(filePath + "\\" + newName.RenameText + ".level");
                                        if (newArea == null)
                                        {
                                            MessageBox.Show("returned a null area");
                                        }
                                        //change area file name in area file object properties
                                        newArea.AreaFileName = newName.RenameText;
                                        newArea.saveAreaFile(filePath + "\\" + newName.RenameText + ".level");
                                        prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] = newName.RenameText;
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
                                prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] = newName.RenameText;
                            }
                            refreshListBoxAreas();
                        }
                        #endregion
                        #region Existing Area
                        else
                        {
                            DialogResult sure = MessageBox.Show("Are you sure you wish to change the area name and the area file name? (make sure to update any references to this area name such as transitions and scripts)", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (sure == System.Windows.Forms.DialogResult.Yes)
                            {
                                //if file exists, rename the file
                                string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\areas";
                                if (File.Exists(filePath + "\\" + prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] + ".level"))
                                {
                                    try
                                    {
                                        //rename file
                                        File.Move(filePath + "\\" + prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] + ".level", filePath + "\\" + newName.RenameText + ".level"); // Try to move
                                        try
                                        {
                                            //load area
                                            Area newArea = new Area();
                                            newArea = newArea.loadAreaFile(filePath + "\\" + newName.RenameText + ".level");
                                            if (newArea == null)
                                            {
                                                MessageBox.Show("returned a null area");
                                            }
                                            //change area file name in area file object properties
                                            newArea.AreaFileName = newName.RenameText;
                                            newArea.saveAreaFile(filePath + "\\" + newName.RenameText + ".level");
                                            prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] = newName.RenameText;
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
                                    prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex] = newName.RenameText;
                                }
                                refreshListBoxAreas();
                            }                            
                        }
                        #endregion
                    }
                    catch { }
                }
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            prntForm.mod.ModuleAreasList = prntForm.mod.ModuleAreasList.OrderBy(o => o).ToList();
            refreshListBoxAreas();
        }
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            if ((lbxAreas.Items.Count > 0) && (lbxAreas.SelectedIndex >= 0))
            {
                //if file exists, rename the file
                string filePath = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\areas";
                string filename = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
                if (File.Exists(filePath + "\\" + filename + ".level"))
                {
                    try
                    {
                        //rename file
                        File.Copy(filePath + "\\" + filename + ".level", filePath + "\\" + filename + "-Copy.level");
                        try
                        {
                            //load area
                            Area newArea = new Area();
                            newArea = newArea.loadAreaFile(filePath + "\\" + filename + "-Copy.level");
                            if (newArea == null)
                            {
                                MessageBox.Show("returned a null area");
                            }
                            //change area file name in area file object properties
                            newArea.AreaFileName = filename + "-Copy";
                            newArea.saveAreaFile(filePath + "\\" + filename + "-Copy.level");

                            prntForm.mod.ModuleAreasList.Add(newArea.AreaFileName);
                            refreshListBoxAreas();
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
                    MessageBox.Show("File: " + filename + ".level does not exist in the areas folder");
                }
                refreshListBoxAreas();
            }
        }        
        #endregion

        private void EditArea()
        {
            LevelEditor newChild = new LevelEditor(prntForm.mod, prntForm.game, prntForm); //add new child
            newChild.Text = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
            newChild.Show(prntForm.dockPanel1); //as new form created so that corresponding tab and child form is active
            refreshListBoxAreas();
            newChild.g_directory = prntForm._mainDirectory + "\\modules\\" + prntForm.mod.ModuleFolderName + "\\areas";
            newChild.g_filename = prntForm.mod.ModuleAreasList[prntForm._selectedLbxAreaIndex];
        }
    }
}
