using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using IceBlink;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class Module
    {
        #region Fields
        private string versionIB = "IceBlink vX";
        private string moduleFolderName = "";
        private string moduleName = "";
        private string moduleDescription = "";
        private string themeFolderName = "default";
        private int nextIdNumber = 100;
        private bool useRestSystem = true;
        private bool useAlignment = true;
        private int worldTime = 0;
        private Theme moduleTheme = new Theme();
        private Items moduleItemsList = new Items();
        private Encounters moduleEncountersList = new Encounters();
        private Containers moduleContainersList = new Containers();
        private Shops moduleShopsList = new Shops();
        private Creatures moduleCreaturesList = new Creatures();
        private Props modulePropsList = new Props();
        private Journal moduleJournal = new Journal();
        public PlayerClasses modulePlayerClassList = new PlayerClasses();
        public Races moduleRacesList = new Races();
        public Skills moduleSkillsList = new Skills();
        public Spells moduleSpellsList = new Spells();
        public Traits moduleTraitsList = new Traits();
        public Effects moduleEffectsList = new Effects();
        private List<string> moduleAreasList = new List<string>();
        private List<string> moduleConvosList = new List<string>();
        private List<Area> moduleAreasObjects = new List<Area>();
        private List<GlobalInt> moduleGlobalInts = new List<GlobalInt>();
        private List<GlobalString> moduleGlobalStrings = new List<GlobalString>();
        private List<GlobalObject> moduleGlobalObjects = new List<GlobalObject>();
        private List<GlobalListItem> moduleGlobalListItems = new List<GlobalListItem>();
        private List<LocalListItem> moduleLocalListItems = new List<LocalListItem>();
        private List<ConvoSavedValues> moduleConvoSavedValuesList = new List<ConvoSavedValues>();
        private string startingArea = "";
        private Point startingPlayerPosition = new Point(0,0);
        private string creaturesFileName = "creatures.crt";
        private string itemsFileName = "items.items";
        private string propsFileName = "props.prp";
        private string containersFileName = "containers.cntr";
        private string shopsFileName = "shops.shp";
        private string encountersFileName = "encounters.enctr";
        private string journalFileName = "journal.jnl";
        private string playerClassesFileName = "playerClasses.cls";
        private string racesFileName = "races.rce";
        private string skillsFileName = "skills.skl";
        private string spellsFileName = "spells.spls";
        private string traitsFileName = "traits.trts";
        private string effectsFileName = "effects.eft";
        private string labelFunds = "Gold";
        private string labelSpells = "Spells";
        private string moduleFontName = "Comic Sans MS"; // "Micorsoft Sans Serif";
        private float moduleFontPointSize = 9.0f; // 9.75f;
        private float moduleFontScale = 1.0f;
        private float moduleFloatyFontScale = 1.75f;
        private Font moduleFont = new Font("Comic Sans MS",9.0f);
        public string moduleButtonEnterSound = "btn_hover.wav";
        public string moduleButtonClickSound = "btn_click.wav";
        public string moduleButtonMediumNormalImage = "b_med_normal.png";
        public string moduleButtonMediumHoverImage = "b_med_hover.png";
        public string moduleButtonMediumPressedImage = "b_med_pressed.png";
        public string moduleButtonMediumDisabledImage = "b_med_disabled.png";
        public string moduleButtonSmallNormalImage = "b_sml_normal.png";
        public string moduleButtonSmallHoverImage = "b_sml_hover.png";
        public string moduleButtonSmallPressedImage = "b_sml_pressed.png";
        public string moduleButtonSmallDisabledImage = "b_sml_disabled.png";
        public string moduleButtonLargeNormalImage = "b_lrg_normal.png";
        public string moduleButtonLargeHoverImage = "b_lrg_hover.png";
        public string moduleButtonLargePressedImage = "b_lrg_pressed.png";
        public string moduleButtonLargeDisabledImage = "b_lrg_disabled.png";
        public string moduleButtonRArrowNormalImage = "b_rarw_normal.png";
        public string moduleButtonRArrowHoverImage = "b_rarw_hover.png";
        public string moduleButtonRArrowPressedImage = "b_rarw_pressed.png";
        public string moduleButtonRArrowDisabledImage = "b_rarw_disabled.png";
        public string moduleButtonCloseNormalImage = "b_close_normal.png";
        public string moduleButtonCloseHoverImage = "b_close_hover.png";
        public string moduleButtonClosePressedImage = "b_close_pressed.png";
        public string moduleButtonResizeNormalImage = "b_rsize_normal.png";
        public string moduleButtonResizeHoverImage = "b_rsize_hover.png";
        public string moduleButtonResizePressedImage = "b_rsize_pressed.png";
        public string moduleGroupBoxLargeImage = "gb_lrg_header.png";
        public string moduleGroupBoxMediumImage = "gb_med_header.png";
        public string moduleGroupBoxSmallImage = "gb_sml_header.png";
        private ScriptSelectEditorReturnObject onHeartBeat = new ScriptSelectEditorReturnObject();
        #endregion

        #region Properties
        [XmlIgnore]
        public Game game;

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Version of IceBlink used to create this module"), ReadOnly(true)]
        public string VersionIB
        {
            get { return versionIB; }
            set { versionIB = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of Folder that the module is/will be located in"), ReadOnly(true)]
        public string ModuleFolderName
        {
            get { return moduleFolderName; }
            set { moduleFolderName = value; }
        }
        
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Name of the Module")]
        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        [XmlElement]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Description of the Module")]
        public string ModuleDescription
        {
            get { return moduleDescription; }
            set { moduleDescription = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("The Module's Theme Folder Name"), Browsable(false)]
        public string ThemeFolderName
        {
            get { return themeFolderName; }
            set { themeFolderName = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Use the rest system...see script 'restSystem.cs' in the default script folder")]
        public bool UseRestSystem
        {
            get { return useRestSystem; }
            set { useRestSystem = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Use the alignment system in this module")]
        public bool UseAlignment
        {
            get { return useAlignment; }
            set { useAlignment = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Current value for World Time in generic units")]
        public int WorldTime
        {
            get { return worldTime; }
            set { worldTime = value; }
        }

        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Used for making unique Tags and ResRefs"), ReadOnly(true)]
        public int NextIdNumber
        {
            get 
            {
                nextIdNumber++;
                return nextIdNumber; 
            }
            set { nextIdNumber = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Theme ModuleTheme
        {
            get { return moduleTheme; }
            set { moduleTheme = value; }
        }

        [XmlIgnore]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Items ModuleItemsList
        {
            get { return moduleItemsList; }
            set { moduleItemsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Encounters ModuleEncountersList
        {
            get { return moduleEncountersList; }
            set { moduleEncountersList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Containers ModuleContainersList
        {
            get { return moduleContainersList; }
            set { moduleContainersList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Shops ModuleShopsList
        {
            get { return moduleShopsList; }
            set { moduleShopsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Creatures ModuleCreaturesList
        {
            get { return moduleCreaturesList; }
            set { moduleCreaturesList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Props ModulePropsList
        {
            get { return modulePropsList; }
            set { modulePropsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Journal ModuleJournal
        {
            get { return moduleJournal; }
            set { moduleJournal = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public PlayerClasses ModulePlayerClassList
        {
            get { return modulePlayerClassList; }
            set { modulePlayerClassList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Races ModuleRacesList
        {
            get { return moduleRacesList; }
            set { moduleRacesList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Skills ModuleSkillsList
        {
            get { return moduleSkillsList; }
            set { moduleSkillsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Spells ModuleSpellsList
        {
            get { return moduleSpellsList; }
            set { moduleSpellsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Traits ModuleTraitsList
        {
            get { return moduleTraitsList; }
            set { moduleTraitsList = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("")]
        public Effects ModuleEffectsList
        {
            get { return moduleEffectsList; }
            set { moduleEffectsList = value; }
        }

        [XmlArrayItem("ModuleAreasList")]
        [CategoryAttribute("Misc"), DescriptionAttribute(""), Browsable(false)]
        public List<string> ModuleAreasList
        {
            get { return moduleAreasList; }
            set { moduleAreasList = value; }
        }

        [XmlArrayItem("ModuleConvosList")]
        [CategoryAttribute("Misc"), DescriptionAttribute(""), Browsable(false)]
        public List<string> ModuleConvosList
        {
            get { return moduleConvosList; }
            set { moduleConvosList = value; }
        }

        [XmlArrayItem("ModuleAreasObjects")]
        [CategoryAttribute("Misc"), DescriptionAttribute(""), Browsable(false)]
        public List<Area> ModuleAreasObjects
        {
            get { return moduleAreasObjects; }
            set { moduleAreasObjects = value; }
        }

        [XmlArrayItem("ModuleGlobalInts")]
        public List<GlobalInt> ModuleGlobalInts
        {
            get { return moduleGlobalInts; }
            set { moduleGlobalInts = value; }
        }

        [XmlArrayItem("ModuleGlobalStrings")]
        public List<GlobalString> ModuleGlobalStrings
        {
            get { return moduleGlobalStrings; }
            set { moduleGlobalStrings = value; }
        }

        [XmlArrayItem("ModuleGlobalObjects")]
        [CategoryAttribute("Misc"), DescriptionAttribute(""), Browsable(false)]
        public List<GlobalObject> ModuleGlobalObjects
        {
            get { return moduleGlobalObjects; }
            set { moduleGlobalObjects = value; }
        }

        [XmlArrayItem("ModuleGlobalListItems")]
        public List<GlobalListItem> ModuleGlobalListItems
        {
            get { return moduleGlobalListItems; }
            set { moduleGlobalListItems = value; }
        }

        [XmlArrayItem("ModuleLocalListItems")]
        public List<LocalListItem> ModuleLocalListItems
        {
            get { return moduleLocalListItems; }
            set { moduleLocalListItems = value; }
        }

        [XmlArrayItem("ModuleConvoSavedValuesList")]
        public List<ConvoSavedValues> ModuleConvoSavedValuesList
        {
            get { return moduleConvoSavedValuesList; }
            set { moduleConvoSavedValuesList = value; }
        }
        
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Filename of starting Area (DO NOT include \".level\" extension)")]
        public string StartingArea
        {
            get { return startingArea; }
            set { startingArea = value; }
        }
        
        [XmlElement]
        [CategoryAttribute("01 - Main"), DescriptionAttribute("Starting location in starting area")]
        public Point StartingPlayerPosition
        {
            get { return startingPlayerPosition; }
            set { startingPlayerPosition = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for creatures"), ReadOnly(true)]
        public string CreaturesFileName
        {
            get { return creaturesFileName; }
            set { creaturesFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for items"), ReadOnly(true)]
        public string ItemsFileName
        {
            get { return itemsFileName; }
            set { itemsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for props"), ReadOnly(true)]
        public string PropsFileName
        {
            get { return propsFileName; }
            set { propsFileName = value; }
        }
        
        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for shops"), ReadOnly(true)]
        public string ShopsFileName
        {
            get { return shopsFileName; }
            set { shopsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for containers"), ReadOnly(true)]
        public string ContainersFileName
        {
            get { return containersFileName; }
            set { containersFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for encounters"), ReadOnly(true)]
        public string EncountersFileName
        {
            get { return encountersFileName; }
            set { encountersFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for player classes"), ReadOnly(true)]
        public string PlayerClassesFileName
        {
            get { return playerClassesFileName; }
            set { playerClassesFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for journal"), ReadOnly(true)]
        public string JournalFileName
        {
            get { return journalFileName; }
            set { journalFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for races"), ReadOnly(true)]
        public string RacesFileName
        {
            get { return racesFileName; }
            set { racesFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for skills"), ReadOnly(true)]
        public string SkillsFileName
        {
            get { return skillsFileName; }
            set { skillsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for spells"), ReadOnly(true)]
        public string SpellsFileName
        {
            get { return spellsFileName; }
            set { spellsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for traits"), ReadOnly(true)]
        public string TraitsFileName
        {
            get { return traitsFileName; }
            set { traitsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("03 - Misc"), DescriptionAttribute("Name of file for effects"), ReadOnly(true)]
        public string EffectsFileName
        {
            get { return effectsFileName; }
            set { effectsFileName = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Label to use for Funds (ex. Gold, Credits, Coin, etc.)")]
        public string LabelFunds
        {
            get { return labelFunds; }
            set { labelFunds = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Label to use for Spells (ex. Spells, Powers, Psionics, etc.)")]
        public string LabelSpells
        {
            get { return labelSpells; }
            set { labelSpells = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Font Name (must be exact) to use as the module's default Font")]
        public string ModuleFontName
        {
            get { return moduleFontName; }
            set { moduleFontName = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Font Point Size (float value) to use as the module's default Font size")]
        public float ModuleFontPointSize
        {
            get { return moduleFontPointSize; }
            set { moduleFontPointSize = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Font scale for text")]
        public float ModuleFontScale
        {
            get { return moduleFontScale; }
            set { moduleFontScale = value; }
        }

        [XmlElement]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Font scale for floaty text")]
        public float ModuleFloatyFontScale
        {
            get { return moduleFloatyFontScale; }
            set { moduleFloatyFontScale = value; }
        }

        [XmlIgnore]
        [CategoryAttribute("02 - Labels"), DescriptionAttribute("Font to use as the module's default Font"), ReadOnly(true)]
        public Font ModuleFont
        {
            get { return moduleFont; }
            set { moduleFont = value; }
        }

        [XmlElement]
        [CategoryAttribute("04 - Scripts"), DescriptionAttribute("fires at the beginning of each move (not during combat)")]
        [Editor(typeof(ScriptSelectEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ScriptSelectEditorReturnObject OnHeartBeat
        {
            get { return onHeartBeat; }
            set { onHeartBeat = value; }
        }

        [XmlIgnore]
        Area newArea = new Area();
        #endregion

        public Module()
        {
            moduleItemsList.passRefs(game);
            moduleCreaturesList.passRefs(game);
            moduleContainersList.passRefs(game);            
        }
        public void passRefs(Game g, ParentForm pf)
        {
            game = g;
            OnHeartBeat.prntForm = pf;
        }
        public void saveModuleFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Module));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Module file. Error: " + ex.Message);
                game.errorLog(ex.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                writer = null;
            }
        }
        public Module loadModuleFile(string filename)
        {
            Module toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Module));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Module)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open Module xml file. Error:\n{0}", ex.Message);
                game.errorLog(ex.ToString());
            }
            finally
            {
                if (myFileStream != null)
                {
                    myFileStream.Close();
                }
            }
            return toReturn;
        }
        public void loadAreas(string path)
        {
            foreach (string areaName in moduleAreasList)
            {
                try
                {
                    newArea = newArea.loadAreaFile(path + areaName + ".level");
                    if (newArea == null)
                    {
                        MessageBox.Show("returned a null area filling areaList");
                    }
                    if (game == null)
                    {
                        MessageBox.Show("game is null in module before filling areaList");
                    }
                    newArea.passRefs(game, newArea.MapSizeInSquares.Width, newArea.MapSizeInSquares.Height);
                    moduleAreasObjects.Add(newArea);
                    loadAreaStuff(newArea);
                    //MessageBox.Show("open file success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed to open all files: " + ex.ToString() + ex.Message);
                    game.errorLog(ex.ToString());
                }
            }
        }
        public void loadAreaStuff(Area a)
        {

            foreach (Trigger t in a.AreaTriggerList.triggersList)
            {
                t.passRefs(game, null, a);
            }

            //Bitmap newBitmap;
            foreach (Creature crt in a.AreaCreatureList.creatures)
            {
                //load spritesheet and pass refs
                crt.LoadSpriteStuff(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName);
                /*if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Image = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\module\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Image = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\player\\" + crt.CharSprite.SpriteSheetFilename);
                }
                else if (File.Exists(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename))
                {
                    crt.CharSprite.Image = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\tokens\\" + crt.CharSprite.SpriteSheetFilename);
                }
                crt.passRefs(game, null);
                crt.CharSprite.passRefs(game);*/
                //load image into spritesheet
                //newBitmap = new Bitmap(prntForm._mainDirectory + "\\modules\\" + le_mod.ModuleFolderName + "\\graphics\\sprites\\" + crt.CharSprite.SpriteSheetFilename);
                //crtBitmapList.Add(newBitmap);
            }
            foreach (Prop prp in a.AreaPropList.propsList)
            {
                prp.LoadPropSpriteStuff(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName);
                //prp.LoadSpriteStuff(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\props");
                //prp.PropSprite.Image = new Bitmap(game.mainDirectory + "\\modules\\" + game.module.ModuleFolderName + "\\graphics\\sprites\\props\\" + prp.PropSprite.SpriteSheetFilename);
                //prp.passRefs(game, null);
                //prp.PropSprite.passRefs(game);
                //newBitmap = new Bitmap(prntForm._mainDirectory + "\\modules\\" + le_mod.ModuleFolderName + "\\graphics\\sprites\\" + prp.PropSprite.SpriteSheetFilename);
                //propBitmapList.Add(newBitmap);
            }
        }
        public void loadStartingArea(Game game)
        {
            try
            {
                foreach (Area area in moduleAreasObjects)
                {
                    if (startingArea == area.AreaFileName)
                    {
                        game.currentArea = area;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to find starting area: " + ex.ToString() + ex.Message);
                game.errorLog(ex.ToString());
            }
        }        
        public void loadCombatArea(Game game, string filename)
        {
            try
            {
                foreach (Area area in moduleAreasObjects)
                {
                    if (filename == area.AreaFileName)
                    {
                        game.currentCombatArea = area;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to find starting area: " + ex.ToString() + ex.Message);
                game.errorLog(ex.ToString() + ex.Message);
            }
        }
        /*public void loadAreaPalettes()
        {
            try
            {
                foreach (Area area in moduleAreasObjects)
                {
                    if (!area.loadPalette("data\\palette.bmp", 5))
                    {
                        MessageBox.Show("Error loading palette");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("failed to open palettes for areas: " + ex.ToString() + ex.Message);
                game.errorLog(ex.ToString() + ex.Message);
            }
        }*/
        /*public Item getItem(string name)
        {
            foreach (Item it in items)
            {
                if (it.p_name == name) return it;
            }
            return null;
        }*/
    }
}
