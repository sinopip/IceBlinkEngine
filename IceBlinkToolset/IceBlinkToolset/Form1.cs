/* IceBlink Toolset by Jeremy Smith, copyright 2013 */

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
    public partial class ParentForm : Form
    {
        public string _mainDirectory = Directory.GetCurrentDirectory();
        public Module mod = new Module();
        public Game game;
        public Journal journal = new Journal();
        public Creatures creaturesList = new Creatures();
        public Containers containersList = new Containers();
        public Shops shopsList = new Shops();
        public Encounters encountersList = new Encounters();
        public Items itemsList = new Items();
        public Props propsList = new Props();
        public Triggers triggersList = new Triggers();
        public PlayerClasses playerClassesList = new PlayerClasses();
        public Races racesList = new Races();
        public Skills skillsList = new Skills();
        public Spells spellsList = new Spells();
        public Traits traitsList = new Traits();
        public Effects effectsList = new Effects();
        public List<string> itemsParentNodeList = new List<string>();
        public List<string> creaturesParentNodeList = new List<string>();
        public List<string> propsParentNodeList = new List<string>();
        public List<Area> openAreasList = new List<Area>();
        public List<Convo> openConvosList = new List<Convo>();
        public string selectedEncounterCreatureTag = "";
        public string selectedEncounterPropTag = "";
        public string selectedEncounterTriggerTag = "";
        public string selectedLevelMapCreatureTag = "";
        public string selectedLevelMapPropTag = "";
        public string selectedLevelMapTriggerTag = "";
        public bool CreatureSelected = false;
        public bool PropSelected = false;
        public int nodeCount = 1;
        public int createdTab = 0;
        public int _selectedLbxAreaIndex;
        public int _selectedLbxConvoIndex;
        public int _selectedLbxContainerIndex;
        public int _selectedLbxEncounterIndex;
        public string lastSelectedCreatureNodeName = "";
        public string lastSelectedItemNodeName = "";
        public string lastSelectedPropNodeName = "";
        public Bitmap iconBitmap;
        public string lastModuleFullPath;
        //Bitmap portraitBitmap;

        private DeserializeDockContent m_deserializeDockContent;
        public IceBlinkProperties frmIceBlinkProperties;
        public IconSprite frmIconSprite;
        public Blueprints frmBlueprints;
        public AreaForm frmAreas;
        public ConversationsForm frmConversations;
        public EncountersForm frmEncounters;
        public ContainersForm frmContainers;
        public LogForm frmLog;
        public bool m_bSaveLayout = true;


        public ParentForm()
        {
            InitializeComponent();
            //saveAsToolStripMenuItem.Enabled = false;
            //saveToolStripButton.Enabled = false;
            //saveToolStripMenuItem.Enabled = false;
            //tsbSaveIncremental.Enabled = false;
            dockPanel1.Dock = DockStyle.Fill;
            dockPanel1.BackColor = Color.Beige;
            dockPanel1.BringToFront();
            frmIceBlinkProperties = new IceBlinkProperties(this);
            frmIconSprite = new IconSprite(this);
            frmBlueprints = new Blueprints(this);
            frmAreas = new AreaForm(this);
            frmConversations = new ConversationsForm(this);
            frmEncounters = new EncountersForm(this);
            frmContainers = new ContainersForm(this);
            frmLog = new LogForm(this);
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }        
        private void ParentForm_Load(object sender, EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            string configDefaultFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DefaultLayout.config");

            if (File.Exists(configFile))
            {
                dockPanel1.LoadFromXml(configFile, m_deserializeDockContent);
            }
            else if (File.Exists(configDefaultFile))
            {
                dockPanel1.LoadFromXml(configDefaultFile, m_deserializeDockContent);
            }
            else
            {
                //do nothing
            }

            game = new Game();
            game.mainDirectory = Directory.GetCurrentDirectory();
            openModule(_mainDirectory + "\\data\\NewModule\\NewModule.module");
            openCreatures(_mainDirectory + "\\data\\NewModule\\data\\" + mod.CreaturesFileName);
            openItems(_mainDirectory + "\\data\\NewModule\\data\\" + mod.ItemsFileName);
            openProps(_mainDirectory + "\\data\\NewModule\\data\\" + mod.PropsFileName);
            openJournal(_mainDirectory + "\\data\\NewModule\\data\\" + mod.JournalFileName);
            openPlayerClasses(_mainDirectory + "\\data\\NewModule\\data\\" + mod.PlayerClassesFileName);
            openRaces(_mainDirectory + "\\data\\NewModule\\data\\" + mod.RacesFileName);
            openSkills(_mainDirectory + "\\data\\NewModule\\data\\" + mod.SkillsFileName);
            openSpells(_mainDirectory + "\\data\\NewModule\\data\\" + mod.SpellsFileName);
            openTraits(_mainDirectory + "\\data\\NewModule\\data\\" + mod.TraitsFileName);
            openEffects(_mainDirectory + "\\data\\NewModule\\data\\" + mod.EffectsFileName);
            game.errorLog("Starting IceBlink Toolset");
            saveAsTemp();

            this.WindowState = FormWindowState.Maximized;
        }
        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //close all open tab documents first
            CloseAllDocuments();
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (m_bSaveLayout)
                dockPanel1.SaveAsXml(configFile);
            else if (File.Exists(configFile))
                File.Delete(configFile);
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(IceBlinkProperties).ToString())
                return frmIceBlinkProperties;
            else if (persistString == typeof(IconSprite).ToString())
                return frmIconSprite;
            else if (persistString == typeof(Blueprints).ToString())
                return frmBlueprints;
            else if (persistString == typeof(AreaForm).ToString())
                return frmAreas;
            else if (persistString == typeof(ConversationsForm).ToString())
                return frmConversations;
            else if (persistString == typeof(EncountersForm).ToString())
                return frmEncounters;
            else if (persistString == typeof(ContainersForm).ToString())
                return frmContainers;
            else //(persistString == typeof(LogForm).ToString())
                return frmLog;
        }
        private void CloseAllDocuments()
        {            
            for (int index = dockPanel1.Contents.Count - 1; index >= 0; index--)
            {
                if (dockPanel1.Contents[index] is IDockContent)
                {                    
                    IDockContent content = (IDockContent)dockPanel1.Contents[index];
                    if ((content.DockHandler.TabText == "Areas") ||
                        (content.DockHandler.TabText == "Conversations") ||
                        (content.DockHandler.TabText == "Containers") ||
                        (content.DockHandler.TabText == "Encounters") ||
                        (content.DockHandler.TabText == "LogForm") ||
                        (content.DockHandler.TabText == "Blueprints") ||
                        (content.DockHandler.TabText == "Properties") ||
                        (content.DockHandler.TabText == "IconSprite"))
                    {
                        //skip these, do not close them
                    }
                    else
                    {
                        content.DockHandler.Close();
                    }
                }
            }
        }
        private void loadAllDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");            
        }

        #region File Handling
        private void openModule(string filename)
        {            
            mod = mod.loadModuleFile(filename);
            if (mod == null)
            {
                MessageBox.Show("returned a null module");
            }
            mod.passRefs(game, this);
            frmAreas.lbxAreas.DataSource = null;
            frmAreas.lbxAreas.DataSource = mod.ModuleAreasList;
            frmAreas.refreshListBoxAreas();
            frmConversations.refreshListBoxConvos();
        }
        private void openCreatures(string filename)
        {
            if (File.Exists(filename))
            {
                creaturesList.creatures.Clear();
                creaturesList = creaturesList.loadCreaturesFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find creatures.crt file. Will create a new one upon saving module.");
            }
            frmBlueprints.UpdateTreeViewCreatures();
            foreach (Creature crt in creaturesList.creatures)
            {
                crt.passRefs(game, this);
                crt.passRefs(this);
            }
            loadCreatureSprites();
        }
        private void loadCreatureSprites()
        {
            foreach (Creature crt in creaturesList.creatures)
            {
                //load sprite sheet for each creature
                if (crt.CharSprite.SpriteSheetFilename != null)
                {
                    if (mod.ModuleName != "NewModule")
                    {
                        crt.LoadSpriteStuff(_mainDirectory + "\\modules\\" + mod.ModuleFolderName);
                        /*if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename))
                        {
                            crt.CharSprite.Image = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename);
                        }
                        else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename))
                        {
                            crt.CharSprite.Image = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename);
                        }
                        else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                        {
                            crt.CharSprite.Image = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                        }
                        else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                        {
                            crt.CharSprite.Image = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                        }
                        else
                        {
                            MessageBox.Show("Couldn't find the spritesheet: " + crt.CharSprite.SpriteSheetFilename);
                        }*/
                    }
                    else
                    {
                        crt.LoadSpriteStuff(_mainDirectory + "\\data\\NewModule");
                        //crt.CharSprite.Image = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                    }
                }
            }     
        }
        private void openItems(string filename)
        {
            if (File.Exists(filename))
            {
                itemsList.itemsList.Clear();
                itemsList.passRefs(game);
                itemsList = itemsList.loadItemsFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find items.items file. Will create a new one upon saving module.");
            }
            foreach (Item itm in itemsList.itemsList)
            {
                itm.passRefs(game, this);
            }
            frmBlueprints.UpdateTreeViewItems();
        }
        private void openProps(string filename)
        {
            if (File.Exists(filename))
            {
                propsList.propsList.Clear();
                propsList = propsList.loadPropsFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find props.prp file. Will create a new one upon saving module.");
            }
            frmBlueprints.UpdateTreeViewProps();
            foreach (Prop prp in propsList.propsList)
            {
                prp.passRefs(game, this);
            }
            loadPropSprites();
        }
        private void loadPropSprites()
        {
            foreach (Prop prp in propsList.propsList)
            {
                //load sprite and sheet for each creature
                if (mod.ModuleName != "NewModule")
                {
                    prp.LoadPropSpriteStuffForTS(_mainDirectory + "\\modules\\" + mod.ModuleFolderName);
                    //prp.PropSprite.Image = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename);
                }
                else
                {
                    prp.LoadPropSpriteStuffForTS(_mainDirectory + "\\data\\NewModule");
                    //prp.PropSprite.Image = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename);
                }
            }
        }
        private void openShops(string filename)
        {
            if (File.Exists(filename))
            {
                shopsList.shopsList.Clear();
                shopsList.passRefs(game);
                shopsList = shopsList.loadShopsFile(filename);
                shopsList.passRefs(game);
            }
            else
            {
                MessageBox.Show("Couldn't find shops.shp file. Will create a new one upon saving module.");
            }
        }
        private void openContainers(string filename)
        {
            if (File.Exists(filename))
            {
                containersList.containers.Clear();
                containersList = containersList.loadContainersFile(filename);
                foreach (IceBlinkCore.Container cntnr in containersList.containers)
                {
                    if (cntnr.containerItemTags.Count == 0)
                    {
                        foreach (string s in cntnr.items)
                        {
                            Item newItem = itemsList.getItem(s);
                            cntnr.containerItemTags.Add(newItem.ItemTag);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Couldn't find containers.cntr file. Will create a new one upon saving module.");
            }
            frmContainers.refreshListBoxContainers();
        }
        private void openEncounters(string filename)
        {
            if (File.Exists(filename))
            {
                encountersList.encounters.Clear();
                encountersList = encountersList.loadEncountersFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find encounters.enctr file. Will create a new one upon saving module.");
            }
            frmEncounters.refreshListBoxEncounters();
            foreach (Encounter e in encountersList.encounters)
            {
                foreach (Creature crt in e.EncounterCreatureList.creatures)
                {
                    crt.passRefs(game, this);
                }
            }
        }
        private void openJournal(string filename)
        {
            if (File.Exists(filename))
            {
                journal.categories.Clear();
                journal.passRefs(game);
                journal = journal.loadJournalFile(filename);
                journal.passRefs(game);
            }
            else
            {
                MessageBox.Show("Couldn't find journal.jnl file. Will create a new one upon saving module.");
            }
        }
        private void openEffects(string filename)
        {
            if (File.Exists(filename))
            {
                effectsList.effectsList.Clear();
                effectsList.passRefs(game);
                effectsList = effectsList.loadEffectsFile(filename);
                effectsList.passRefs(game);
            }
            else
            {
                MessageBox.Show("Couldn't find effects.eft file. Will create a new one upon saving module.");
            }            
            foreach (Effect e in effectsList.effectsList)
            {
                e.passRefs(game, this);
            }
        }
        private void openPlayerClasses(string filename)
        {
            if (File.Exists(filename))
            {
                playerClassesList.playerClassList.Clear();
                playerClassesList = playerClassesList.loadPlayerClassesFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find playerClasses.cls file. Will create a new one upon saving module.");
            }
        }
        private void openRaces(string filename)
        {
            if (File.Exists(filename))
            {
                racesList.racesList.Clear();
                racesList = racesList.loadRacesFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find races.rce file. Will create a new one upon saving module.");
            }
        }
        private void openSkills(string filename)
        {
            if (File.Exists(filename))
            {
                skillsList.skillsList.Clear();
                skillsList = skillsList.loadSkillsFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find skills.skl file. Will create a new one upon saving module.");
            }
            foreach (Skill sk in skillsList.skillsList)
            {
                sk.passRefs(game, this);
            }
        }
        private void openSpells(string filename)
        {
            if (File.Exists(filename))
            {
                spellsList.spellList.Clear();
                spellsList = spellsList.loadSpellsFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find spells.spls file. Will create a new one upon saving module.");
            }
            foreach (Spell sp in spellsList.spellList)
            {
                sp.passRefs(game, this);
            }
        }
        private void openTraits(string filename)
        {
            if (File.Exists(filename))
            {
                traitsList.traitList.Clear();
                traitsList = traitsList.loadTraitsFile(filename);
            }
            else
            {
                MessageBox.Show("Couldn't find traits.trts file. Will create a new one upon saving module.");
            }
            foreach (Trait tr in traitsList.traitList)
            {
                tr.passRefs(game, this);
            }
        }
        private void openFiles()
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\modules";
            //Empty the FileName text box of the dialog
            openFileDialog1.FileName = String.Empty;
            openFileDialog1.Filter = "Module files (*.module)|*.module|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string filename = Path.GetFullPath(openFileDialog1.FileName);
                string directory = Path.GetDirectoryName(openFileDialog1.FileName);
                openModule(filename);
                openCreatures(directory + "\\data\\" + mod.CreaturesFileName);
                openItems(directory + "\\data\\" + mod.ItemsFileName);
                openContainers(directory + "\\data\\" + mod.ContainersFileName);
                openShops(directory + "\\data\\" + mod.ShopsFileName);
                openEncounters(directory + "\\data\\" + mod.EncountersFileName);
                openProps(directory + "\\data\\" + mod.PropsFileName);
                openJournal(directory + "\\data\\" + mod.JournalFileName);
                openPlayerClasses(directory + "\\data\\" + mod.PlayerClassesFileName);
                openRaces(directory + "\\data\\" + mod.RacesFileName);
                openSkills(directory + "\\data\\" + mod.SkillsFileName);
                openSpells(directory + "\\data\\" + mod.SpellsFileName);
                openTraits(directory + "\\data\\" + mod.TraitsFileName);
                openEffects(directory + "\\data\\" + mod.EffectsFileName);
                loadSpriteDropdownList();
                loadSoundDropdownList();
            }
        }
        public void loadSpriteDropdownList()
        {
            DropdownStringLists.spriteStringList = new List<string>();
            DropdownStringLists.spriteStringList.Add("none");
            string jobDir = "";
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\FXs";
            foreach (string f in Directory.GetFiles(jobDir,"*.spt"))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.spriteStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.spriteStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt"))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.spriteStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\data\\graphics\\sprites";
            foreach (string f in Directory.GetFiles(jobDir, "*.spt", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.spriteStringList.Add(filename);
            }
        }
        public void loadSoundDropdownList()
        {
            DropdownStringLists.soundStringList = new List<string>();
            DropdownStringLists.soundStringList.Add("none");
            string jobDir = "";
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\sounds";
            foreach (string f in Directory.GetFiles(jobDir, "*.mp3", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.soundStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\sounds";
            foreach (string f in Directory.GetFiles(jobDir, "*.wav", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.soundStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\data\\sounds";
            foreach (string f in Directory.GetFiles(jobDir, "*.mp3", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.soundStringList.Add(filename);
            }
            jobDir = game.mainDirectory + "\\data\\sounds";
            foreach (string f in Directory.GetFiles(jobDir, "*.wav", SearchOption.AllDirectories))
            {
                string filename = Path.GetFileName(f);
                DropdownStringLists.soundStringList.Add(filename);
            }
        }
        /*private void saveFilesOld()
        {
            saveFileDialog1.Filter = "module files (*.module)|*.module|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            //Empty the FileName text box of the dialog
            saveFileDialog1.FileName = String.Empty;
            //saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.DefaultExt = ".module";
            //saveFileDialog1.AddExtension = true;
            saveFileDialog1.OverwritePrompt = true;
            //saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

            //Open the dialog and determine which button was pressed
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result != DialogResult.OK) return;
            if (saveFileDialog1.FileName.Length == 0) return;
            //If the user presses the Save button
            if (result == DialogResult.OK)
            {
                string filename = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName); //test8
                string directory = Path.GetDirectoryName(saveFileDialog1.FileName); //C:\\Users\\Jeremy\\Documents\\Visual Studio 2010\\Projects\\openForgeRPGToolset\\openForgeRPGToolset\\bin\\Debug
                //MessageBox.Show("filename = " + filename);
                try
                {
                    mod.ModuleName = filename + ".module";
                    mod.ModuleFolderName = filename;
                    mod.saveModuleFile(directory + "\\" + filename + ".module");
                    creaturesList.saveCreaturesFile(directory + "\\creatures.crt");
                    itemsList.saveItemsFile(directory + "\\items.items");
                    containersList.saveContainersFile(directory + "\\containers.cntr");
                }
                catch
                {
                    MessageBox.Show("failed to save file");
                }
            }
        }*/
        private void saveAsTemp()
        {
            lastModuleFullPath = _mainDirectory + "\\data\\NewModule";
            mod.ModuleFolderName = "temp01";
            string directory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName;
            try
            {
                if (!Directory.Exists(directory)) // if folder does not exist, create it and copy contents from previous folder
                {
                    createDirectory(directory);
                    createDirectory(directory + "//data");
                    DirectoryCopy(lastModuleFullPath, directory, true); // needs to copy contents from previous folder into new folder and overwrite files with new updates
                    createFiles(directory);
                }
                else
                {
                    createDirectory(directory + "//data");
                    createFiles(directory); // if folder exists, then overwrite all files in folder
                }
                //MessageBox.Show("temp01 module saved");
            }
            catch (Exception e)
            {
                MessageBox.Show("failed to save temp01 module: " + e.ToString());
            }
        }
        private void saveFiles()
        {
            if ((mod.StartingArea == null) || (mod.StartingArea == ""))
            {
                MessageBox.Show("Starting area was not detected, please type in the starting area's name in module properties (Edit/Modules Properties). Your module will not work without a starting area defined.");
                //return;
            }
            if ((mod.ModuleName.Length == 0) || (mod.ModuleName == "NewModule"))
            {
                saveAsFiles();
                return;
            }
            string directory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName;
            try
            {
                if (!Directory.Exists(directory)) // if folder does not exist, create it and copy contents from previous folder
                {
                    createDirectory(directory);
                    DirectoryCopy(lastModuleFullPath, directory, true); // needs to copy contents from previous folder into new folder and overwrite files with new updates
                    createFiles(directory);
                }
                else
                {
                    createFiles(directory); // if folder exists, then overwrite all files in folder
                }
                MessageBox.Show("Moduled saved");
            }
            catch (Exception e)
            {
                MessageBox.Show("failed to save module: " + e.ToString());
            }
        }
        private void saveAsFiles()
        {
            if ((mod.StartingArea == null) || (mod.StartingArea == ""))
            {
                //MessageBox.Show("Starting area was not detected, please type in the starting area's name in module properties (Edit/Modules Properties). Your module will not work without a starting area defined.");
                //return;
            }
            //if (mod.ModuleName != "NewModule")
            //{
                lastModuleFullPath = _mainDirectory + "\\modules\\" + mod.ModuleFolderName;
            //}
            //else
            //{
            //    lastModuleFullPath = _mainDirectory + "\\data\\" + mod.ModuleFolderName;
            //}
            ModuleNameDialog mnd = new ModuleNameDialog();
            mnd.ShowDialog();
            mod.ModuleName = mnd.ModText;
            mod.ModuleFolderName = mnd.ModText;
            saveFiles();
        }
        private void incrementalSave() //incremental save option
        {
            if ((mod.StartingArea == null) || (mod.StartingArea == ""))
            {
                MessageBox.Show("Starting area was not detected, please type in the starting area's name in module properties (Edit/Modules Properties). Your module will not work without a starting area defined.");
                //return;
            }
            else
            {
                // save a backup with a incremental folder name
                string lastDir = mod.ModuleFolderName;
                string workingDir = _mainDirectory + "\\modules";
                string backupDir = _mainDirectory + "\\module_backups";
                string fileName = mod.ModuleFolderName;
                string incrementDirName = "";
                for (int i = 0; i < 999; i++) // add an incremental save option (uses directoryName plus number for folder name)
                {
                    if (!Directory.Exists(backupDir + "\\" + fileName + "(" + i.ToString() + ")"))
                    {
                        incrementDirName = fileName + "(" + i.ToString() + ")";
                        createDirectory(backupDir + "\\" + incrementDirName);
                        DirectoryCopy(workingDir + "\\" + lastDir, backupDir + "\\" + incrementDirName, true); // needs to copy contents from previous folder into new folder and overwrite files with new updates
                        //DirectoryInfo dir = Directory.CreateDirectory(workingDir + "\\" + incrementDirName);
                        createFiles(backupDir + "\\" + incrementDirName);
                        break;
                    }
                    else
                    {
                        //lastDir = workingDir + "\\" + fileName + "(" + i.ToString() + ")";
                    }
                }
                MessageBox.Show("Moduled backup " + incrementDirName + " was saved");

                // save over original module
                string directory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName;
                try
                {
                    if (!Directory.Exists(directory)) // if folder exists, then overwrite all files in folder
                    {
                        createDirectory(directory);
                    }
                    createFiles(directory);
                    MessageBox.Show("Moduled saved");
                    //mod.saveModuleFile(directory + "\\" + mod.ModuleName + ".module");
                    //creaturesList.saveCreaturesFile(directory + "\\creatures.crt");
                    //itemsList.saveItemsFile(directory + "\\items.items");
                    //containersList.saveContainersFile(directory + "\\containers.cntr");
                }
                catch
                {
                    MessageBox.Show("failed to save module");
                }
            }
        }        
        private void createFiles(string fullPathDirectory)
        {
            try
            {
                mod.VersionIB = game.IBVersion;
                mod.saveModuleFile(fullPathDirectory + "\\" + mod.ModuleName + ".module");
                creaturesList.saveCreaturesFile(fullPathDirectory + "\\data\\creatures.crt");
                itemsList.saveItemsFile(fullPathDirectory + "\\data\\items.items");
                containersList.saveContainersFile(fullPathDirectory + "\\data\\containers.cntr");
                shopsList.saveShopsFile(fullPathDirectory + "\\data\\shops.shp");
                encountersList.saveEncountersFile(fullPathDirectory + "\\data\\encounters.enctr");
                propsList.savePropsFile(fullPathDirectory + "\\data\\props.prp");
                journal.saveJournalFile(fullPathDirectory + "\\data\\journal.jnl");
                playerClassesList.savePlayerClassesFile(fullPathDirectory + "\\data\\playerClasses.cls");
                racesList.saveRacesFile(fullPathDirectory + "\\data\\races.rce");
                skillsList.saveSkillsFile(fullPathDirectory + "\\data\\skills.skl");
                spellsList.saveSpellsFile(fullPathDirectory + "\\data\\spells.spls");
                traitsList.saveTraitsFile(fullPathDirectory + "\\data\\traits.trts");
                effectsList.saveEffectsFile(fullPathDirectory + "\\data\\effects.eft");
                // save convos that are open
                foreach (Convo convo in openConvosList)
                {
                    try
                    {
                        convo.SaveContentConversation(this._mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\dialog\\" + convo.ConvoFileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save Convo file to disk. Original error: " + ex.Message);
                    }
                }
                // save areas that are open
                foreach (Area a in openAreasList)
                {
                    try
                    {
                        a.saveAreaFile(this._mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\areas\\" + a.AreaFileName + ".level");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save area file to disk. Original error: " + ex.Message);
                    }
                }
            }
            catch { MessageBox.Show("failed to createFiles"); }
        }
        private void newModule()
        {
            openModule(_mainDirectory + "\\data\\NewModule\\NewModule.module");
            openCreatures(_mainDirectory + "\\data\\NewModule\\data\\" + mod.CreaturesFileName);
            openItems(_mainDirectory + "\\data\\NewModule\\data\\" + mod.ItemsFileName);
        }
        private void createDirectory(string fullPath)
        {
            try
            {
                DirectoryInfo dir = Directory.CreateDirectory(fullPath);
            }
            catch { MessageBox.Show("failed to create the directory: " + fullPath); }
        }
        private void DirectoryCopy(string sourceDirPath, string destDirPath, bool copySubDirs)
        {
            try
            {
                //string _currentDir = System.IO.Directory.GetCurrentDirectory();
                DirectoryInfo dir = new DirectoryInfo(sourceDirPath);
                DirectoryInfo[] dirs = dir.GetDirectories();

                FileInfo[] files = dir.GetFiles(); // Get the file contents of the directory to copy.
                foreach (FileInfo file in files)
                {
                    try
                    {
                        if (file.Name != "NewModule.module")
                        {
                            string temppath = Path.Combine(destDirPath, file.Name); // Create the path to the new copy of the file.
                            file.CopyTo(temppath, false); // Copy the file.
                        }
                    }
                    catch { MessageBox.Show("failed to copy file"); }
                }

                if (copySubDirs) // If copySubDirs is true, copy the subdirectories.
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        try
                        {
                            string temppath = Path.Combine(destDirPath, subdir.Name); // Create the subdirectory.
                            createDirectory(temppath);
                            DirectoryCopy(subdir.FullName, temppath, copySubDirs); // Copy the subdirectories.
                        }
                        catch { MessageBox.Show("failed to copy sub folders"); }
                    }
                }
            }
            catch { MessageBox.Show("failed to copy the directory"); }
        }
        private void refreshIcon()
        {
            if (frmBlueprints.tabCreatureItem.SelectedIndex == 0) //creature
            {
                refreshIconCreatures();
            }
            else if (frmBlueprints.tabCreatureItem.SelectedIndex == 1) //item
            {
                refreshIconItems();
            }
            else //prop
            {
                refreshIconProps();
            }
        }
        public void logText(string text)
        {
            frmLog.rtxtLog.AppendText(text);
            frmLog.rtxtLog.ScrollToCaret();
        }
        #endregion

        #region Event Handlers
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFiles();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFiles();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFiles();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsFiles();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFiles();
        }
        private void tsbSaveIncremental_Click(object sender, EventArgs e)
        {
            incrementalSave();
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
            //newModule();
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
            //newModule();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // maybe should ask to save first if any changes have been made
            this.Close();
        }
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIceBlinkProperties.Show(dockPanel1);
        }
        private void spriteIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIconSprite.Show(dockPanel1);
        }
        private void blueprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBlueprints.Show(dockPanel1);
        }
        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAreas.Show(dockPanel1);
        }
        private void conversationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConversations.Show(dockPanel1);
        }
        private void encountersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEncounters.Show(dockPanel1);
        }
        private void containersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContainers.Show(dockPanel1);
        }
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLog.Show(dockPanel1);
        }
        private void modulePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmIceBlinkProperties.propertyGrid1.SelectedObject = mod;
        }
        private void spriteEditorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SpriteEditor spriteEdit = new SpriteEditor(mod, game, this);
            spriteEdit.ShowDialog();
        }
        private void journalEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JournalEditor journalEdit = new JournalEditor(mod, game, this);
            journalEdit.ShowDialog();
        }
        private void shopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShopEditor shopEdit = new ShopEditor(mod, game, this);
            shopEdit.ShowDialog();
        }
        private void mergerEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MergerEditor mergerEdit = new MergerEditor(mod, game, this);
            mergerEdit.ShowDialog();
        }
        private void playerClassEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerClassEditor playerClassEdit = new PlayerClassEditor(mod, game, this);
            playerClassEdit.ShowDialog();
        }
        private void raceEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RacesEditor raceEdit = new RacesEditor(mod, game, this);
            raceEdit.ShowDialog();
        }
        private void skillsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkillEditor skillEdit = new SkillEditor(mod, game, this);
            skillEdit.ShowDialog();
        }
        private void spellEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpellEditor sEdit = new SpellEditor(mod, game, this);
            sEdit.ShowDialog();
        }
        private void traitEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraitEditor tEdit = new TraitEditor(mod, game, this);
            tEdit.ShowDialog();
        }
        private void effectEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EffectEditor eEdit = new EffectEditor(mod, game, this);
            eEdit.ShowDialog();
        }
        private void themeEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemeEditor tEdit = new ThemeEditor(mod, game, this);
            tEdit.ShowDialog();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show(test.EventTag1.TagOrFilename + " " +
                test.EventTag1.Parm1 + " " +
                test.EventTag1.Parm2 + " " +
                test.EventTag1.Parm3 + " " +
                test.EventTag1.Parm4 + " " +
                test.EventTag1.TransPoint.X.ToString() + " " +
                test.EventTag1.TransPoint.Y.ToString());*/
        }
        /*private void addNewAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelEditor newChild = new LevelEditor(ref mod);      //add new child
            TabPage childTab = new TabPage();         //create new tab page
            newChild.MdiParent = this;                       //set as child of this form
            //newChild.Name = "Child" + createdTab.ToString();
            newChild.Text = " New Area " + createdTab.ToString() + "   [X]";
            //childTab.Name = newChild.Name;           //make sure name and text are same
            childTab.Text = newChild.Text;                  //this is for syncrhonize later
            childTab.Tag = "LevelEditor";
            tabControl1.TabPages.Add(childTab);     //add new tab
            newChild.LevelEditorPanel.Parent = childTab;     //attach to tab
            tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
            newChild.Show();                                 //as new form created so that corresponding tab and child form is active
            createdTab++;   //increment of course
            mod.ModuleAreasList.Add("New Area");
            refreshListBoxAreas();
        }

        private void addNewConversationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvoEditor newChild = new ConvoEditor(ref mod);      //add new child
            TabPage childTab = new TabPage();         //create new tab page
            newChild.MdiParent = this;                       //set as child of this form
            newChild.Name = "Child" + createdTab.ToString();
            newChild.Text = " Child no " + createdTab.ToString() + "   [X]";
            newChild.setParent();
            childTab.Name = newChild.Name;           //make sure name and text are same
            childTab.Text = newChild.Text;                  //this is for syncrhonize later
            childTab.Tag = "ConvoEditor";
            tabControl1.TabPages.Add(childTab);     //add new tab
            newChild.convoMainEditorPanel.Parent = childTab;     //attach to tab
            tabControl1.SelectTab(childTab);     //this is to make sure that tab page is selected in the same time
            newChild.Show();                                 //as new form created so that corresponding tab and child form is active
            createdTab++;   //increment of course
            mod.ModuleConvosList.Add("New Convo");
            refreshListBoxConvos();
        }*/
        /*private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //This code will render a "x" mark at the end of the Tab caption. 
            e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
            e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
            e.DrawFocusRectangle();
        }*/
        /*private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //Looping through the controls.
            for (int i = 0; i < this.tabControl1.TabPages.Count; i++)
            {    
                Rectangle r = tabControl1.GetTabRect(i);   
                //Getting the position of the "x" mark.    
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);    
                if (closeButton.Contains(e.Location))    
                {        
                    if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)        
                    {
                        //this.tabControl1.SelectedTab.Dispose();
                        this.tabControl1.TabPages.RemoveAt(i);            
                        break;        
                    }    
                }
            }
        }*/
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("not implemented yet");
        }
        private void tabCreatureItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("changed tab");
            if (frmBlueprints.tabCreatureItem.SelectedIndex == 0)
            {
                //show sprite for currently selected creature
                refreshIcon();
            }
            else if (frmBlueprints.tabCreatureItem.SelectedIndex == 1) //item
            {
                //show icon for currently selected item
                refreshIcon();
            }
            else //prop
            {
                //show sprite for currently selected prop
                refreshIcon();
            }
        }
        private void btnSelectIcon_Click(object sender, EventArgs e)
        {
            if (frmBlueprints.tabCreatureItem.SelectedIndex == 0) //creature
            {
                LoadCreatureSprite();
            }
            else if (frmBlueprints.tabCreatureItem.SelectedIndex == 1) //item
            {
                LoadItemIcon();
            }
            else //prop
            {
                LoadPropSprite();
            }
        }
        #endregion        

        #region Creature Stuff
        /*
        private void UpdateTreeViewCreatures() //creature
        {
            frmBlueprints.tvCreatures.Nodes.Clear();
            creaturesParentNodeList.Clear();
            foreach (Creature crt in creaturesList.creatures)
            {
                if (!CheckExistsCreatureCategory(crt.CategoryName))
                    creaturesParentNodeList.Add(crt.CategoryName);
            }
            foreach (string crt in creaturesParentNodeList)
            {
                TreeNode parentNode;
                parentNode = frmBlueprints.tvCreatures.Nodes.Add(crt);
                PopulateTreeViewCreatures(crt, parentNode);
            }
            frmBlueprints.tvCreatures.ExpandAll();
            refreshPropertiesCreatures();
        }
        private bool CheckExistsCreatureCategory(string parentNodeName) //creature
        {
            foreach (string par in creaturesParentNodeList)
            {
                if (parentNodeName == par)
                    return true;
            }
            return false;
        }
        private void PopulateTreeViewCreatures(string parentName, TreeNode parentNode)
        {
            var filteredItems = creaturesList.creatures.Where(item => item.CategoryName == parentName);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                childNode = parentNode.Nodes.Add(i.Name);
                childNode.Name = i.Tag;
            }
        }
        private void refreshPropertiesCreatures()
        {
            if (frmBlueprints.tvCreatures.SelectedNode != null)
            {
                string _nodeTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                frmIceBlinkProperties.propertyGrid1.SelectedObject = GetCreature(_nodeTag);
            }
        }
        */
        public void refreshIconCreatures()
        {
            if (frmBlueprints.tvCreatures.SelectedNode != null)
            {
                try
                {
                    //show icon for selected creature
                    string _nodeTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                    string filename = creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename);
                    }
                    else
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }

                    /*if (mod.ModuleName != "NewModule")
                        if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename);
                        }
                        else
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                        }
                    else
                    {
                        if (File.Exists(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename);
                        }
                        else
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                        }
                    }*/
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch { }
            }
        }
        /*
        public Creature GetCreature(string _nodeTag)
        {
            foreach (Creature crt in creaturesList.creatures)
            {
                if (crt.Tag == _nodeTag)
                    return crt;
            }
            return null;
        }
        private int GetCreatureIndex(string _nodeTag)
        {
            int cnt = 0;
            foreach (Creature crt in creaturesList.creatures)
            {
                if (crt.Tag == _nodeTag)
                    return cnt;
                cnt++;
            }
            return -1;
        }
        */
        /*
        private void tvCreatures_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //logText("afterselect");
            if (frmBlueprints.tvCreatures.SelectedNode != null && frmBlueprints.tvCreatures.Nodes.Count > 0)
            {
                selectedEncounterCreatureTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                selectedLevelMapCreatureTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                selectedEncounterPropTag = "";
                selectedLevelMapPropTag = "";
                PropSelected = false;
                logText(selectedEncounterCreatureTag);
                logText(Environment.NewLine);
            }
            refreshPropertiesCreatures();
            refreshIconCreatures();
        }
        private void tvCreatures_MouseClick(object sender, MouseEventArgs e)
        {
            //logText("mouseclick");
            if (frmBlueprints.tvCreatures.SelectedNode != null && frmBlueprints.tvCreatures.Nodes.Count > 0)
            {
                selectedEncounterCreatureTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                selectedLevelMapCreatureTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                selectedEncounterPropTag = "";
                selectedLevelMapPropTag = "";
                PropSelected = false;
                logText(selectedEncounterCreatureTag);
                logText(Environment.NewLine);
            }
            refreshPropertiesCreatures();
            refreshIconCreatures();
        }
        private void btnAddCreature_Click(object sender, EventArgs e)
        {
            Creature newCreature = new Creature();
            newCreature.CategoryName = "New Category";
            newCreature.Tag = "new_tag" + nodeCount.ToString();
            nodeCount++;
            creaturesList.creatures.Add(newCreature);
            UpdateTreeViewCreatures();
            //refreshListBoxCreatures();
        }
        private void btnRemoveCreature_Click(object sender, EventArgs e)
        {
            if (frmBlueprints.tvCreatures.SelectedNode != null && frmBlueprints.tvCreatures.Nodes.Count > 0)
            {
                try
                {
                    string _nodeTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                    creaturesList.creatures.RemoveAt(GetCreatureIndex(_nodeTag));
                    frmBlueprints.tvCreatures.Nodes.RemoveAt(frmBlueprints.tvCreatures.SelectedNode.Index);
                    UpdateTreeViewCreatures();
                    // The Remove button was clicked.
                    //int selectedIndex = tvCreatures.SelectedIndex;
                    //creaturesList.creatures.RemoveAt(selectedIndex);
                }
                catch
                {
                    logText("Failed to remove creature");
                    logText(Environment.NewLine);
                }
                //_selectedLbxCreaturesIndex = 0;
                //lbxCreatures.SelectedIndex = 0;
                //refreshListBoxCreatures();
            }
        }
        private void btnDuplicateCreature_Click(object sender, EventArgs e)
        {
            string _nodeTag = frmBlueprints.tvCreatures.SelectedNode.Name;
            Creature newCreature = creaturesList.creatures[GetCreatureIndex(_nodeTag)].DeepCopy();
            creaturesList.creatures.Add(newCreature);
            UpdateTreeViewCreatures();
        }        
        */
        public void LoadCreatureSprite()
        {
            using (var sel = new SpriteSelector(game, mod))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string _nodeTag = lastSelectedCreatureNodeName;
                    string filename = game.returnSpriteFilename;
                    //IBMessageBox.Show(game, "filename selected = " + filename);
                    try
                    {
                        Creature crt = creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)];
                        crt.SpriteFilename = filename;
                        //creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].LoadCharacterSprite(directory, filename);
                        crt.LoadSpriteStuff(_mainDirectory + "\\modules\\" + mod.ModuleFolderName);

                        //thisPC.SpriteFilename = filename;
                        //thisPC.LoadSpriteStuff(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName);
                        iconBitmap = (Bitmap)crt.CharSprite.Image.Clone();
                        //iconGameMap = new Bitmap(ccr_game.mainDirectory + "\\modules\\" + ccr_game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + thisPC.CharSprite.SpriteSheetFilename);
                        frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                        if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                        //iconBitmap.Image = (Image)iconGameMap;

                        //if (iconGameMap == null)
                        //{
                        //    IBMessageBox.Show(ccr_game, "returned a null icon bitmap");
                        //}
                    }
                    catch
                    {
                        MessageBox.Show("failed to load image...make sure to select a creature from the list first");
                    }
                }
            }
            loadCreatureSprites();
            /*
            if (mod.ModuleName != "NewModule")
                openFileDialog2.InitialDirectory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\";
            else
                openFileDialog2.InitialDirectory = _mainDirectory + "\\data\\NewModule\\graphics\\sprites\\tokens";
            //Empty the FileName text box of the dialog
            openFileDialog2.FileName = String.Empty;
            openFileDialog2.Filter = "Sprite files (*.spt)|*.spt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) return;
            if (openFileDialog2.FileName.Length == 0) return;
            if (result == DialogResult.OK) // Test result.
            {
                string filename = Path.GetFileName(openFileDialog2.FileName);
                string directory = Path.GetDirectoryName(openFileDialog2.FileName);
                //string _nodeTag = frmBlueprints.tvCreatures.SelectedNode.Name;
                string _nodeTag = lastSelectedCreatureNodeName;
                try
                {
                    creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].SpriteFilename = filename;
                    creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].LoadCharacterSprite(directory, filename);

                    string filename2 = creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\tokens\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2);
                    }
                    else
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }
                    
                    //if (mod.ModuleName != "NewModule")
                    //    iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename);
                    //else
                    //    iconBitmap = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\tokens\\" + creaturesList.creatures[frmBlueprints.GetCreatureIndex(_nodeTag)].CharSprite.SpriteSheetFilename);
                    
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch
                {
                    MessageBox.Show("failed to load image...make sure to select a creature from the list first");
                }
            }
            loadCreatureSprites();
            */
        }
        #endregion

        #region Item Stuff
        /*
        private void UpdateTreeViewItems()
        {
            frmBlueprints.tvItems.Nodes.Clear();
            itemsParentNodeList.Clear();
            foreach (Item item in itemsList.itemsList)
            {
                if (!CheckExistsItemCategory(item.ItemCategoryName))
                    itemsParentNodeList.Add(item.ItemCategoryName);
            }
            foreach (string item in itemsParentNodeList)
            {
                TreeNode parentNode;
                parentNode = frmBlueprints.tvItems.Nodes.Add(item);
                PopulateTreeViewItems(item, parentNode);
            }
            frmBlueprints.tvItems.ExpandAll();
            refreshPropertiesItems();
        }
        private bool CheckExistsItemCategory(string parentNodeName)
        {
            foreach (string par in itemsParentNodeList)
            {
                if (parentNodeName == par)
                    return true;
            }
            return false;
        }
        private void PopulateTreeViewItems(string parentName, TreeNode parentNode)
        {
            var filteredItems = itemsList.itemsList.Where(item => item.ItemCategoryName == parentName);

            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                childNode = parentNode.Nodes.Add(i.ItemName);
                childNode.Name = i.ItemTag;
            }
        }
        private void refreshPropertiesItems()
        {
            if (frmBlueprints.tvItems.SelectedNode != null)
            {
                string _nodeTag = frmBlueprints.tvItems.SelectedNode.Name;
                frmIceBlinkProperties.propertyGrid1.SelectedObject = GetItem(_nodeTag);
            }
        }
        public Item GetItem(string _nodeTag)
        {
            foreach (Item item in itemsList.itemsList)
            {
                if (item.ItemTag == _nodeTag)
                    return item;
            }
            return null;
        }
        private int GetItemIndex(string _nodeTag)
        {
            int cnt = 0;
            foreach (Item item in itemsList.itemsList)
            {
                if (item.ItemTag == _nodeTag)
                    return cnt;
                cnt++;
            }
            return -1;
        }
        */
        public void refreshIconItems()
        {
            if (frmBlueprints.tvItems.SelectedNode != null)
            {
                try
                {
                    string _nodeTag = frmBlueprints.tvItems.SelectedNode.Name;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename);
                    }
                    else
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch { }
            }
        }
        /*
        private void tvItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshPropertiesItems();
            refreshIconItems();
        }
        private void tvItems_MouseClick(object sender, MouseEventArgs e)
        {
            refreshPropertiesItems();
            refreshIconItems();
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Item newItem = new Item();
            newItem.ItemName = "new item";
            newItem.ItemCategoryName = "New Category";
            newItem.ItemTag = "new_tag" + nodeCount.ToString();
            nodeCount++;
            itemsList.itemsList.Add(newItem);
            UpdateTreeViewItems();
        }
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (frmBlueprints.tvItems.SelectedNode != null && frmBlueprints.tvItems.Nodes.Count > 0)
            {
                try
                {
                    string _nodeTag = frmBlueprints.tvItems.SelectedNode.Name;
                    itemsList.itemsList.RemoveAt(GetItemIndex(_nodeTag));
                    frmBlueprints.tvItems.Nodes.RemoveAt(frmBlueprints.tvItems.SelectedNode.Index);
                    UpdateTreeViewItems();
                }
                catch
                {
                    logText("Failed to remove item");
                    logText(Environment.NewLine);
                }
            }
        }
        private void btnDuplicateItem_Click(object sender, EventArgs e)
        {
            string _nodeTag = frmBlueprints.tvItems.SelectedNode.Name;
            Item newItem = itemsList.itemsList[GetItemIndex(_nodeTag)].DeepCopy();
            itemsList.itemsList.Add(newItem);
            UpdateTreeViewItems();
        }
        */
        public void LoadItemIcon()
        {
            using (var sel = new ItemImageSelector(game, mod))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string filename = game.returnSpriteFilename;
                    string _nodeTag = lastSelectedItemNodeName;
                    try
                    {
                        itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename = filename;
                        if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + filename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + filename);
                        }
                        else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename);
                        }
                        else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + filename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + filename);
                        }
                        else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename);
                        }
                        else
                        {
                            MessageBox.Show("The image selected is not from one of the designated items folder locations...will use blank.png");
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                        }
                        frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                        if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                    }
                    catch
                    {
                        MessageBox.Show("failed to load image...make sure to select an item from the list first");
                    }
                }
            }

            /*
            if (mod.ModuleName != "NewModule")
                openFileDialog2.InitialDirectory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items";
            else
                openFileDialog2.InitialDirectory = _mainDirectory + "\\data\\NewModule\\graphics\\sprites\\items";
            //openFileDialog2.InitialDirectory = Environment.CurrentDirectory;
            //Empty the FileName text box of the dialog
            openFileDialog2.FileName = String.Empty;
            openFileDialog2.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) return;
            if (openFileDialog2.FileName.Length == 0) return;
            if (result == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog2.SafeFileName;
                //MessageBox.Show("filename selected = " + filename);
                //string _nodeTag = frmBlueprints.tvItems.SelectedNode.Name;
                string _nodeTag = lastSelectedItemNodeName;
                try
                {
                    itemsList.itemsList[frmBlueprints.GetItemIndex(_nodeTag)].ItemIconFilename = filename;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\items\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\items\\" + filename);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename);
                    }
                    else
                    {
                        MessageBox.Show("The image selected is not from one of the designated items folder locations...will use blank.png");
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch
                {
                    MessageBox.Show("failed to load image...make sure to select an item from the list first");
                }
            }  
            */
        }
        #endregion

        #region Props Stuff
        /*
        private void UpdateTreeViewProps()
        {
            frmBlueprints.tvProps.Nodes.Clear();
            propsParentNodeList.Clear();
            foreach (Prop prp in propsList.propsList)
            {
                if (!CheckExistsPropCategory(prp.PropCategoryName))
                    propsParentNodeList.Add(prp.PropCategoryName);
            }
            foreach (string prp in propsParentNodeList)
            {
                TreeNode parentNode;
                parentNode = frmBlueprints.tvProps.Nodes.Add(prp);
                PopulateTreeViewProps(prp, parentNode);
            }
            frmBlueprints.tvProps.ExpandAll();
            refreshPropertiesProps();
        }
        private bool CheckExistsPropCategory(string parentNodeName)
        {
            foreach (string par in propsParentNodeList)
            {
                if (parentNodeName == par)
                    return true;
            }
            return false;
        }
        private void PopulateTreeViewProps(string parentName, TreeNode parentNode)
        {
            var filteredProps = propsList.propsList.Where(prp => prp.PropCategoryName == parentName);

            TreeNode childNode;
            foreach (var pr in filteredProps.ToList())
            {
                childNode = parentNode.Nodes.Add(pr.PropName);
                childNode.Name = pr.PropTag;
            }
        }
        private void refreshPropertiesProps()
        {
            if (frmBlueprints.tvProps.SelectedNode != null)
            {
                string _nodeTag = frmBlueprints.tvProps.SelectedNode.Name;
                frmIceBlinkProperties.propertyGrid1.SelectedObject = GetProp(_nodeTag);
            }
        }
        public Prop GetProp(string _nodeTag)
        {
            foreach (Prop prp in propsList.propsList)
            {
                if (prp.PropTag == _nodeTag)
                    return prp;
            }
            return null;
        }
        private int GetPropIndex(string _nodeTag)
        {
            int cnt = 0;
            foreach (Prop prp in propsList.propsList)
            {
                if (prp.PropTag == _nodeTag)
                    return cnt;
                cnt++;
            }
            return -1;
        }
        */
        public void refreshIconProps()
        {
            if (frmBlueprints.tvProps.SelectedNode != null)
            {
                try
                {
                    string _nodeTag = frmBlueprints.tvProps.SelectedNode.Name;
                    string filename2 = propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\props\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\props\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2);
                    }
                    else
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }

                    /*if (mod.ModuleName != "NewModule")
                    {
                        if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename);
                        }
                        else
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                        }
                    }
                    else
                    {
                        if (File.Exists(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename))
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename);
                        }
                        else
                        {
                            iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                        }
                    }*/
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch { }
            }
        }
        /*
        private void tvProps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (frmBlueprints.tvProps.SelectedNode != null && frmBlueprints.tvProps.Nodes.Count > 0)
            {
                selectedEncounterPropTag = frmBlueprints.tvProps.SelectedNode.Name;
                selectedLevelMapPropTag = frmBlueprints.tvProps.SelectedNode.Name;
                selectedEncounterCreatureTag = "";
                selectedLevelMapCreatureTag = "";
                CreatureSelected = false;
                logText(selectedEncounterPropTag);
                logText(Environment.NewLine);
            }
            refreshPropertiesProps();
            refreshIconProps();
        }
        private void tvProps_MouseClick(object sender, MouseEventArgs e)
        {
            if (frmBlueprints.tvProps.SelectedNode != null && frmBlueprints.tvProps.Nodes.Count > 0)
            {
                selectedEncounterPropTag = frmBlueprints.tvProps.SelectedNode.Name;
                selectedLevelMapPropTag = frmBlueprints.tvProps.SelectedNode.Name;
                selectedEncounterCreatureTag = "";
                selectedLevelMapCreatureTag = "";
                CreatureSelected = false;
                logText(selectedEncounterPropTag);
                logText(Environment.NewLine);
            }
            refreshPropertiesProps();
            refreshIconProps();
        }
        private void btnAddProp_Click(object sender, EventArgs e)
        {
            Prop newProp = new Prop();
            newProp.PropName = "newProp";
            newProp.PropCategoryName = "New Category";
            newProp.PropTag = "newPropTag" + nodeCount.ToString();
            nodeCount++;
            propsList.propsList.Add(newProp);
            UpdateTreeViewProps();
        }
        private void btnRemoveProp_Click(object sender, EventArgs e)
        {
            if (frmBlueprints.tvProps.SelectedNode != null && frmBlueprints.tvProps.Nodes.Count > 0)
            {
                try
                {
                    string _nodeTag = frmBlueprints.tvProps.SelectedNode.Name;
                    propsList.propsList.RemoveAt(GetPropIndex(_nodeTag));
                    frmBlueprints.tvProps.Nodes.RemoveAt(frmBlueprints.tvProps.SelectedNode.Index);
                    UpdateTreeViewProps();
                }
                catch
                {
                    logText("Failed to remove prop");
                    logText(Environment.NewLine);
                }
            }
        }
        private void btnDuplicateProp_Click(object sender, EventArgs e)
        {
            string _nodeTag = frmBlueprints.tvProps.SelectedNode.Name;
            Prop newProp = propsList.propsList[GetPropIndex(_nodeTag)].DeepCopy();
            propsList.propsList.Add(newProp);
            UpdateTreeViewProps();
        }
        */
        public void LoadPropSprite()
        {
            using (var sel = new PropSpriteSelector(game, mod))
            {
                var result = sel.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    string _nodeTag = lastSelectedPropNodeName;
                    string filename = game.returnSpriteFilename;
                    try
                    {
                        Prop prp = propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)];
                        prp.PropSpriteFilename = filename;
                        prp.LoadPropSpriteStuffForTS(_mainDirectory + "\\modules\\" + mod.ModuleFolderName);

                        iconBitmap = (Bitmap)prp.PropSprite.Image.Clone();
                        frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                        if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                    }
                    catch
                    {
                        MessageBox.Show("failed to load image...make sure to select a prop from the list first");
                    }
                }
            }
            loadPropSprites();

            /*
            if (mod.ModuleName != "NewModule")
                openFileDialog2.InitialDirectory = _mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props";
            else
                openFileDialog2.InitialDirectory = _mainDirectory + "\\data\\NewModule\\graphics\\sprites\\props";
            //Empty the FileName text box of the dialog
            openFileDialog2.FileName = String.Empty;
            openFileDialog2.Filter = "Sprite files (*.spt)|*.spt|All files (*.*)|*.*";
            openFileDialog2.FilterIndex = 1;
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result != DialogResult.OK) return;
            if (openFileDialog2.FileName.Length == 0) return;
            if (result == DialogResult.OK) // Test result.
            {
                string filename = Path.GetFileName(openFileDialog2.FileName);
                string directory = Path.GetDirectoryName(openFileDialog2.FileName);
                //string _nodeTag = frmBlueprints.tvProps.SelectedNode.Name;
                string _nodeTag = lastSelectedPropNodeName;
                try
                {
                    propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSpriteFilename = filename;
                    propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].LoadPropSprite(directory, filename);

                    string filename2 = propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename;
                    if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\props\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\props\\" + filename2);
                    }
                    else if (File.Exists(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2))
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\sprites\\" + filename2);
                    }
                    else
                    {
                        iconBitmap = new Bitmap(_mainDirectory + "\\data\\graphics\\blank.png");
                    }
                    
                    //if (mod.ModuleName != "NewModule")
                    //    iconBitmap = new Bitmap(_mainDirectory + "\\modules\\" + mod.ModuleFolderName + "\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename);
                    //else
                    //    iconBitmap = new Bitmap(_mainDirectory + "\\data\\NewModule\\graphics\\sprites\\props\\" + propsList.propsList[frmBlueprints.GetPropIndex(_nodeTag)].PropSprite.SpriteSheetFilename);
                    
                    frmIconSprite.pbIcon.BackgroundImage = (Image)iconBitmap;
                    if (iconBitmap == null) { MessageBox.Show("returned a null icon bitmap"); }
                }
                catch
                {
                    MessageBox.Show("failed to load image...make sure to select a prop from the list first");
                }
            }
            loadPropSprites();
            */
        }
        #endregion                                                                        
    }
}
