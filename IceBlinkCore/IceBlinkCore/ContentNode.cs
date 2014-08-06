using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using IceBlink;
using System.ComponentModel;

namespace IceBlinkCore
{
    [Serializable]
    public class ContentNode
    {
        [XmlIgnore]
        public Game game;
        [XmlAttribute]
        public int idNum = -1;
        [XmlAttribute]
        public int orderNum = 0;
        [XmlAttribute]
        public bool pcNode = true;
        [XmlAttribute]
        public int linkTo = 0;
        [XmlElement]
        public bool ShowOnlyOnce = false;
        [XmlElement]
        public bool NodeIsActive = true;
        [XmlElement]
        public string NodePortraitBitmap = "";
        [XmlElement]
        public string NodeNpcName = "";
        [XmlElement]
        public string NodeSound = "none";
        [XmlElement]
        public string conversationText = "Continue";
        [XmlElement]
        public bool IsExpanded = true;
        [XmlArrayItem("ContentNode")]
        public List<ContentNode> subNodes = new List<ContentNode>();
        [XmlArrayItem("Action")]
        public List<Action> actions = new List<Action>();
        [XmlArrayItem("Condition")]
        public List<Condition> conditions = new List<Condition>();
        [XmlIgnore]
        public bool isLink
        {
            get
            {
                return (linkTo > 0);
            }
        }

        public ContentNode()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public ContentNode NewContentNode(int nextIdNum)
        {
            ContentNode newNode = new ContentNode();
            newNode.passRefs(game);
            newNode.idNum = nextIdNum;
            return newNode;
        }
        public void AddNodeToSubNode(ContentNode contentNode)
        {
            subNodes.Add(contentNode);
        }
        public void RemoveNodeFromSubNode(ContentNode contentNode)
        {
            bool returnvalue = subNodes.Remove(contentNode);
        }
        public void AddNodeToActions(Action actionNode)
        {
            actions.Add(actionNode);
        }
        public void RemoveNodeFromActions(int actionNodeIndex)
        {
            actions.RemoveAt(actionNodeIndex);
        }
        public void AddNodeToConditions(Condition conditionNode)
        {
            conditions.Add(conditionNode);
        }
        public void RemoveNodeFromConditions(int conditionNodeIndex)
        {
            //MessageBox.Show("conditionNodeIndex = " + conditionNodeIndex.ToString());
            //MessageBox.Show("c_script = " + conditions[conditionNodeIndex].c_script);
            conditions.RemoveAt(conditionNodeIndex);
        }
        public ContentNode SearchContentNodeById(int checkIdNum)
        {
            ContentNode tempNode = null;
            if (idNum == checkIdNum)
            {
                return this;
            }
            foreach (ContentNode subNode in subNodes)
            {
                tempNode = subNode.SearchContentNodeById(checkIdNum);
                if (tempNode != null)
                {
                    return tempNode;
                }
            }
            return null;
        }
        public ContentNode DuplicateContentNode(int nextIdNum)
        {
            ContentNode newNode = new ContentNode();
            //newNode = (ContentNode)this.MemberwiseClone();
            newNode.passRefs(game);
            newNode.conversationText = this.conversationText;
            //newNode.idNum = nextIdNum;
            newNode.pcNode = this.pcNode;
            newNode.linkTo = this.linkTo;
            newNode.NodePortraitBitmap = this.NodePortraitBitmap;
            newNode.NodeSound = this.NodeSound;
            newNode.IsExpanded = this.IsExpanded;
            newNode.ShowOnlyOnce = this.ShowOnlyOnce;
            newNode.NodeIsActive = this.NodeIsActive;

            newNode.actions = new List<Action>();
            foreach (Action a in this.actions)
            {
                Action ac = a.DeepCopy();
                newNode.actions.Add(ac);
            }
            newNode.conditions = new List<Condition>();
            foreach (Condition c in this.conditions)
            {
                Condition cc = c.DeepCopy();
                newNode.conditions.Add(cc);
            }

            return newNode;
        }        
        public ContentNode Duplicate()
        {
            ContentNode copy = new ContentNode();
            copy = (ContentNode)this.MemberwiseClone();
            copy.passRefs(game);
            //copy.conversationText = this.conversationText;
            //copy.idNum = this.idNum;
            copy.actions = new List<Action>();
            foreach (Action a in this.actions)
            {
                Action ac = a.DeepCopy();
                copy.actions.Add(ac);
            }
            copy.conditions = new List<Condition>();
            foreach (Condition c in this.conditions)
            {                
                Condition cc = c.DeepCopy();
                copy.conditions.Add(cc);
            }
            foreach (ContentNode node in this.subNodes)
            {
                copy.subNodes.Add(node.Duplicate());
            }
            return copy;
        }
        public ContentNode NewContentNodeLink(int nextOrderNum)
        {
            ContentNode newNode = new ContentNode();
            newNode.passRefs(game);
            newNode.orderNum = nextOrderNum;
            return newNode;
        }
    }

    [Serializable]
    public class Condition : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string script;
        private string btnAndOr;
        private bool and; //and = true   or = false
        private bool not; //checked = true   unchecked = false
        private string parameter_1;
        private string parameter_2;
        private string parameter_3;
        private string parameter_4;

        [XmlIgnore]
        public Game game;

        [XmlAttribute]
        public string c_script
        {
            get {return script;}
            set
            {
                script = value;
                this.NotifyPropertyChanged("c_script");
            }
        }
        [XmlAttribute]
        public string c_btnAndOr
        {
            get { return btnAndOr; }
            set
            {
                btnAndOr = value;
                this.NotifyPropertyChanged("c_btnAndOr");
            }
        }
        [XmlAttribute]
        public bool c_and
        {
            get {return and;}
            set
            {
                and = value;
                this.NotifyPropertyChanged("c_and");
            }
        }        
        [XmlAttribute]
        public bool c_not
        {
            get {return not;}
            set
            {
                not = value;
                this.NotifyPropertyChanged("c_not");
            }
        }
        [XmlAttribute]
        public string c_parameter_1
        {
            get {return parameter_1;}
            set
            {
                parameter_1 = value;
                this.NotifyPropertyChanged("c_parameter_1");
            }
        }
        [XmlAttribute]
        public string c_parameter_2
        {
            get {return parameter_2;}
            set
            {
                parameter_2 = value;
                this.NotifyPropertyChanged("c_parameter_2");
            }
        }
        [XmlAttribute]
        public string c_parameter_3
        {
            get {return parameter_3;}
            set
            {
                parameter_3 = value;
                this.NotifyPropertyChanged("c_parameter_3");
            }
        }
        [XmlAttribute]
        public string c_parameter_4
        {
            get {return parameter_4;}
            set
            {
                parameter_4 = value;
                this.NotifyPropertyChanged("c_parameter_4");
            }
        }

        public Condition()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public Condition DeepCopy()
        {
            Condition other = (Condition)this.MemberwiseClone();            
            return other;
        }
        /*public bool doCheck(ref Game game)
        {
            switch (c_script)
            {
                case "chk_global_int":
                    //check if variable is equal
                    foreach (GlobalInt variable in game.module.ModuleGlobalInts)
                    {
                        //MessageBox.Show("variable.Key = " + variable.Key + "   c_parameter_1 = " + c_parameter_1);
                        //MessageBox.Show("c_parameter_2 = " + c_parameter_2 + "   variable.Value = " + variable.Value.ToString());
                        //MessageBox.Show("c_not = " + c_not.ToString());
                        if (variable.Key == c_parameter_1)
                        {
                            //MessageBox.Show("variable.Key == c_parameter_1");
                            if (variable.Value == Convert.ToInt32(c_parameter_2))
                            {
                                //MessageBox.Show("variable.Value == Convert.ToInt32(c_parameter_2)");
                                if (c_not == true) { return false; }
                                else { return true; }
                            }
                        }
                    }
                    //return true;
                    break;
                case "chk_item":
                    //check if item is on any of the party members
                    // par1 (s)Item Tag, par2 (n)Quantity
                    int numFound = 0;
                    foreach (PC pc in game.playerList.PCList)
                    {
                        if (pc.Body.ItemTag == c_parameter_1)
                            numFound++;
                        if (pc.MainHand.ItemTag == c_parameter_1)
                            numFound++;
                        if (pc.Ring1.ItemTag == c_parameter_1)
                            numFound++;
                        if (pc.OffHand.ItemTag == c_parameter_1)
                            numFound++;
                    }
                    foreach (Item item in game.partyInventoryList)
                    {
                        if (item.ItemTag == c_parameter_1)
                            numFound++;
                    }
                    if (numFound >= Convert.ToInt32(c_parameter_2))
                    {
                        return true;
                    }
                    break;
                case "chk_gold":
                    //check the total amount of gold of the party
                    if (game.partyGold >= Convert.ToInt32(c_parameter_1))
                        return true;
                    break;
                case "chk_class_level":
                    //check class level
                    if (game.playerList.PCList[Convert.ToInt32(c_parameter_1)].Class.ToString() == c_parameter_2)
                    {
                        if (game.playerList.PCList[Convert.ToInt32(c_parameter_1)].ClassLevel >= Convert.ToInt32(c_parameter_3))
                        {
                            return true;
                        }
                    }
                    break;
                case "chk_race":
                    //check the race
                    if (game.playerList.PCList[Convert.ToInt32(c_parameter_1)].Race.ToString() == c_parameter_2)
                    {
                        return true;
                    }
                    break;
                case "chk_male":
                    //check to see if male (false is female)
                    if (game.playerList.PCList[Convert.ToInt32(c_parameter_1)].Gender.ToString() == c_parameter_2)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }*/
    }

    [Serializable]
    public class Action : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string script;
        private string parameter_1;
        private string parameter_2;
        private string parameter_3;
        private string parameter_4;

        [XmlIgnore]
        public Game game;

        [XmlAttribute]
        public string a_script
        {
            get { return script; }
            set
            {
                script = value;
                this.NotifyPropertyChanged("a_script");
            }
        }
        [XmlAttribute]
        public string a_parameter_1
        {
            get { return parameter_1; }
            set
            {
                parameter_1 = value;
                this.NotifyPropertyChanged("a_parameter_1");
            }
        }
        [XmlAttribute]
        public string a_parameter_2
        {
            get { return parameter_2; }
            set
            {
                parameter_2 = value;
                this.NotifyPropertyChanged("a_parameter_2");
            }
        }
        [XmlAttribute]
        public string a_parameter_3
        {
            get { return parameter_3; }
            set
            {
                parameter_3 = value;
                this.NotifyPropertyChanged("a_parameter_3");
            }
        }
        [XmlAttribute]
        public string a_parameter_4
        {
            get { return parameter_4; }
            set
            {
                parameter_4 = value;
                this.NotifyPropertyChanged("a_parameter_4");
            }
        }

        public Action()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public Action DeepCopy()
        {
            Action other = (Action)this.MemberwiseClone();
            return other;
        }
        public void doAction(ref Game game)
        {
            switch (a_script)
            {
                case "set_global_int":
                    //check if variable is equal
                    int exists = 0;
                    foreach (GlobalInt variable in game.module.ModuleGlobalInts)
                    {
                        if (variable.Key == a_parameter_1)
                        {
                            variable.Value = Convert.ToInt32(a_parameter_2);
                            exists = 1;
                        }
                    }
                    if (exists == 0)
                    {
                        GlobalInt newGlobal = new GlobalInt();
                        newGlobal.Key = a_parameter_1;
                        newGlobal.Value = Convert.ToInt32(a_parameter_2);
                        game.module.ModuleGlobalInts.Add(newGlobal);
                    }
                    break;
                case "run_script":
                    //check if variable is equal
                    //MessageBox.Show("fire script");
                    game.executeScript(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\scripts\\" + a_parameter_1 + ".cs");                                        
                    break;
                case "give_item":
                    //give the item to the party inventory
                    Item newItem = game.module.ModuleItemsList.getItemByTag(a_parameter_1).DeepCopy();
                    game.partyInventoryList.Add(newItem);
                    break;
                case "give_gold":
                    //give gold to the party
                    game.partyGold += Convert.ToInt32(a_parameter_1);
                    break;
                case "give_xp":
                    int xpToGive = Convert.ToInt32(a_parameter_1) / game.playerList.PCList.Count;
                    //give xp to each PC member...split the value given
                    foreach (PC givePcXp in game.playerList.PCList)
                    {
                        givePcXp.XP += xpToGive;
                    }
                    break;
                case "take_item":
                    //take an item away
                    for (int i = 0; i < Convert.ToInt32(a_parameter_2); i++)
                    {
                        bool FoundOne = false;
                        int cnt = 0;
                        foreach (Item item in game.partyInventoryList)
                        {
                            if (!FoundOne)
                            {
                                if (item.ItemTag == a_parameter_1)
                                {
                                    game.partyInventoryList.RemoveAt(cnt);
                                    FoundOne = true;
                                }
                            }
                            cnt++;
                        }
                        cnt = 0;
                        foreach (PC pc in game.playerList.PCList)
                        {
                            if (!FoundOne)
                            {
                                if (pc.Body.ItemTag == a_parameter_1)
                                {
                                    game.playerList.PCList[cnt].Body = new Item();
                                    game.playerList.PCList[cnt].Body.ItemName = "";
                                    FoundOne = true;
                                }
                                if (pc.MainHand.ItemTag == a_parameter_1)
                                {
                                    game.playerList.PCList[cnt].MainHand = new Item();
                                    game.playerList.PCList[cnt].MainHand.ItemName = "";
                                    FoundOne = true;
                                }
                                if (pc.Ring1.ItemTag == a_parameter_1)
                                {
                                    game.playerList.PCList[cnt].Ring1 = new Item();
                                    game.playerList.PCList[cnt].Ring1.ItemName = "";
                                    FoundOne = true;
                                }
                                if (pc.OffHand.ItemTag == a_parameter_1)
                                {
                                    game.playerList.PCList[cnt].OffHand = new Item();
                                    game.playerList.PCList[cnt].OffHand.ItemName = "";
                                    FoundOne = true;
                                }
                            }
                            cnt++;
                        }
                    }
                    break;
                case "attack":
                    //make NPC hostile and start encounter
                    //game.currentArea.a_tilemap[game.playerPosition.Y * game._numberOfSquares + game.playerPosition.X].encounterChk = true;
                    //game.currentArea.a_tilemap[game.playerPosition.Y * game._numberOfSquares + game.playerPosition.X].encounterTag = a_parameter_1;
                    break;
            }
        }
    }
}
