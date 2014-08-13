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
    public partial class JournalEditor : Form
    {
        public ParentForm prntForm;
        public Module mod;
        public Game game;
        public TreeNode currentSelectedNode = new TreeNode();

        public JournalEditor(Module m, Game g, ParentForm p)
        {
            InitializeComponent();
            mod = m;
            game = g;
            prntForm = p;
        }
        private void JournalEditor_Load(object sender, EventArgs e)
        {
            if (prntForm.journal.categories.Count == 0)
            {
                JournalCategory newCat = new JournalCategory();
                newCat.OrderIndex = prntForm.journal.categories.Count;
                newCat.Tag = "catTag" + prntForm.journal.NextIdNum.ToString();
                prntForm.journal.categories.Add(newCat);
                JournalEntry newEntry = new JournalEntry();
                newEntry.OrderIndex = newCat.Entries.Count;
                newEntry.Tag = "entryTag" + prntForm.journal.NextIdNum.ToString();
                newCat.Entries.Add(newEntry);                
            }
            UpdateTreeView();
        }

        #region Handlers
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //happens only after a new selection is made (change a node selected)
            //order is MouseDown, NodeMouseClick, AfterSelect, MouseClick
            //MessageBox.Show("AfterSelect");
            refreshProperties();
        }
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            //happens anywhere clicked
            //order is MouseDown, NodeMouseClick, AfterSelect, MouseClick
            //MessageBox.Show("MouseClick");
            refreshProperties();
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //happens first if a node is clicked on
            //order is MouseDown, NodeMouseClick, AfterSelect, MouseClick
            //MessageBox.Show("NodeMouseClick");
            treeView1.SelectedNode = e.Node;
            currentSelectedNode = e.Node;
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //happens anywhere in the TreeView when any mouse button is pressed down
            //order is MouseDown, NodeMouseClick, AfterSelect, MouseClick
            //MessageBox.Show("MouseDown");
            currentSelectedNode = null; 
        }
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateTreeView();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                string _nodeTag = treeView1.SelectedNode.Name;
                if (treeView1.SelectedNode.Parent != null)
                {
                    GetChildByTag(_nodeTag).EntryText = richTextBox1.Text;
                }
            }
        }
        private void ctxTreeView_Opening_1(object sender, CancelEventArgs e)
        {
            if (currentSelectedNode != null)
            {
                if (currentSelectedNode.Parent == null) //parent
                {
                    addChildNodeToolStripMenuItem.Enabled = true;
                    addParentNodeToolStripMenuItem.Enabled = false;
                    removeNodeToolStripMenuItem.Enabled = true;
                }
                else //child
                {
                    addChildNodeToolStripMenuItem.Enabled = false;
                    addParentNodeToolStripMenuItem.Enabled = false;
                    removeNodeToolStripMenuItem.Enabled = true;
                }
            }
            else //blank area, not a parent or child
            {
                addChildNodeToolStripMenuItem.Enabled = false;
                addParentNodeToolStripMenuItem.Enabled = true;
                removeNodeToolStripMenuItem.Enabled = false;
            }
        }
        private void tsbAddParent_Click(object sender, EventArgs e)
        {
            AddParent();
        }
        private void tsbAddChild_Click(object sender, EventArgs e)
        {
            if ((treeView1.SelectedNode != null) && (treeView1.SelectedNode.Parent == null))
            {
                AddChild(treeView1.SelectedNode.Name);
            }
        }
        private void tsbRemove_Click(object sender, EventArgs e)
        {
            //check to see if parent, if so delete
            if ((currentSelectedNode != null) && (treeView1.Nodes.Count > 0))
            {
                if (currentSelectedNode.Parent == null) //parent
                {
                    RemoveParent();
                }
                else //child
                {
                    RemoveChild();
                }
            }
        }
        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            MoveUp();
        }
        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            MoveDown();
        }
        private void tsbExpandAll_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        private void tsbCollapseAll_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            UpdateTreeView();
        }
        private void addParentNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddParent();
        }
        private void addChildNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check to see if parent, if so add a child to it
            if (currentSelectedNode != null)
            {
                if (currentSelectedNode.Parent == null)
                {
                    AddChild(currentSelectedNode.Name);
                }
            }
        }
        private void removeNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check to see if parent, if so delete
            if ((currentSelectedNode != null) && (treeView1.Nodes.Count > 0))
            {
                if (currentSelectedNode.Parent == null) //parent
                {
                    RemoveParent();
                }
                else //child
                {
                    RemoveChild();
                }
            }
            //check to see if child, if so delete
        }
        #endregion

        #region Methods
        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            foreach (JournalCategory pnt in prntForm.journal.categories)
            {
                TreeNode parentNode = treeView1.Nodes.Add(pnt.Name);
                parentNode.Name = pnt.Tag;
                TreeNode childNode;
                foreach (JournalEntry chd in pnt.Entries)
                {
                    childNode = parentNode.Nodes.Add(chd.EntryTitle);
                    childNode.Name = chd.Tag;
                }
            }
            treeView1.ExpandAll();
            if (currentSelectedNode != null)
            {
                treeView1.SelectedNode = currentSelectedNode;
            }
            refreshProperties();
        }
        public JournalCategory GetParentByTag(string _nodeTag)
        {
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                if (cust.Tag == _nodeTag)
                    return cust;
            }
            return null;
        }
        public int GetIndexOfParentByTag(string _nodeTag)
        {
            int index = 0;
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                if (cust.Tag == _nodeTag)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
        public JournalEntry GetChildByTag(string _nodeTag)
        {
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                foreach (JournalEntry chd in cust.Entries)
                {
                    if (chd.Tag == _nodeTag)
                        return chd;
                }
            }
            return null;
        }
        public JournalCategory GetParentOfChildByTag(string _nodeTag)
        {
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                foreach (JournalEntry chd in cust.Entries)
                {
                    if (chd.Tag == _nodeTag)
                        return cust;
                }
            }
            return null;
        }
        public int GetIndexOfChildByTag(string _nodeTag)
        {
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                int index = 0;
                foreach (JournalEntry chd in cust.Entries)
                {
                    if (chd.Tag == _nodeTag)
                    {
                        return index;
                    }
                    index++;
                }
            }
            return -1;
        }
        private void refreshProperties()
        {
            if (treeView1.SelectedNode != null)
            {
                string _nodeTag = treeView1.SelectedNode.Name;
                if (treeView1.SelectedNode.Parent == null)
                {
                    propertyGrid1.SelectedObject = GetParentByTag(_nodeTag);
                    richTextBox1.Text = "";
                }
                else
                {
                    propertyGrid1.SelectedObject = GetChildByTag(_nodeTag);
                    richTextBox1.Text = GetChildByTag(_nodeTag).EntryText;
                }
            }
        }
        private void AddParent()
        {
            JournalCategory newParent = new JournalCategory();
            newParent.OrderIndex = prntForm.journal.categories.Count;
            newParent.Tag = "catTag" + prntForm.journal.NextIdNum.ToString(); 
            prntForm.journal.categories.Add(newParent);
            UpdateTreeView();
        }
        private void AddChild(string parentTag)
        {
            JournalCategory pnt = GetParentByTag(parentTag);
            JournalEntry newChild = new JournalEntry();
            newChild.OrderIndex = pnt.Entries.Count;
            newChild.Tag = "entryTag" + prntForm.journal.NextIdNum.ToString(); 
            pnt.Entries.Add(newChild);
            UpdateTreeView();
        }
        private void RemoveParent()
        {
            prntForm.journal.categories.Remove(GetParentByTag(currentSelectedNode.Name));
            UpdateTreeView();
        }
        private void RemoveChild()
        {
            foreach (JournalCategory cust in prntForm.journal.categories)
            {
                foreach (JournalEntry chd in cust.Entries)
                {
                    if (chd.Tag == currentSelectedNode.Name)
                    {
                        cust.Entries.Remove(chd);
                        UpdateTreeView();
                        return;
                    }
                }
            }
        }
        private void MoveUp()
        {
            if ((currentSelectedNode != null) && (treeView1.Nodes.Count > 0))
            {
                if (currentSelectedNode.Parent == null) //parent
                {
                    if (GetParentByTag(currentSelectedNode.Name).OrderIndex > 0)
                    {
                        //change index of selected parent by -1
                        int selectedParentIndex = GetIndexOfParentByTag(currentSelectedNode.Name);
                        prntForm.journal.categories[selectedParentIndex].OrderIndex--;
                        //change index of parent above by +1
                        prntForm.journal.categories[selectedParentIndex - 1].OrderIndex++;
                        //run sort on list of parents
                        prntForm.journal.categories.Sort((x, y) => x.OrderIndex.CompareTo(y.OrderIndex));
                        UpdateTreeView();
                    }
                }
                else //child
                {
                    if (GetChildByTag(currentSelectedNode.Name).OrderIndex > 0)
                    {
                        JournalCategory p = GetParentOfChildByTag(currentSelectedNode.Name);
                        JournalEntry c = GetChildByTag(currentSelectedNode.Name);
                        //change index of selected child by -1
                        int selectedChildIndex = GetIndexOfChildByTag(currentSelectedNode.Name);
                        p.Entries[selectedChildIndex].OrderIndex--;
                        //change index of parent above by +1
                        p.Entries[selectedChildIndex - 1].OrderIndex++;
                        //run sort on list of parents
                        p.Entries.Sort((x, y) => x.OrderIndex.CompareTo(y.OrderIndex));
                        UpdateTreeView();
                    }
                }
            }
        }
        private void MoveDown()
        {
            if ((currentSelectedNode != null) && (treeView1.Nodes.Count > 0))
            {
                if (currentSelectedNode.Parent == null) //parent
                {
                    if (GetParentByTag(currentSelectedNode.Name).OrderIndex < prntForm.journal.categories.Count - 1)
                    {
                        //change index of selected parent by +1
                        int selectedParentIndex = GetIndexOfParentByTag(currentSelectedNode.Name);
                        prntForm.journal.categories[selectedParentIndex].OrderIndex++;
                        //change index of parent above by -1
                        prntForm.journal.categories[selectedParentIndex + 1].OrderIndex--;
                        //run sort on list of parents
                        prntForm.journal.categories.Sort((x, y) => x.OrderIndex.CompareTo(y.OrderIndex));
                        UpdateTreeView();
                    }
                }
                else //child
                {
                    JournalCategory p = GetParentOfChildByTag(currentSelectedNode.Name);
                    JournalEntry c = GetChildByTag(currentSelectedNode.Name);
                    if (c.OrderIndex < p.Entries.Count - 1)
                    {                                                
                        //change index of selected child by +1
                        int selectedChildIndex = GetIndexOfChildByTag(currentSelectedNode.Name);
                        p.Entries[selectedChildIndex].OrderIndex++;
                        //change index of parent above by -1
                        p.Entries[selectedChildIndex + 1].OrderIndex--;
                        //run sort on list of parents
                        p.Entries.Sort((x, y) => x.OrderIndex.CompareTo(y.OrderIndex));
                        UpdateTreeView();
                    }
                }
            }
        }
        #endregion        
    }
}
