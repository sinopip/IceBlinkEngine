using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IceBlinkCore;
using IceBlink;

namespace openForgeScript
{
    public partial class WorldMap : IBForm
    {
        public ScriptFunctions sf;

        public WorldMap(ScriptFunctions s)
        {
            InitializeComponent();
            sf = s;
            this.setupAll(sf.gm);
            IceBlinkButtonResize.setupAll(sf.gm);
            IceBlinkButtonResize.Enabled = false;
            IceBlinkButtonResize.Visible = false;
            IceBlinkButtonClose.setupAll(sf.gm);
            LoadMapImage();
            LoadLocationMarker();
            PlaceMarker();
        }
        private void PlaceMarker()
        {
            string area = sf.gm.currentArea.AreaFileName;

            if ((area == "charn") || (area == "barracks") || (area == "civicBuilding") || (area == "sanctuary") || (area == "store") || (area == "tomb") || (area == "tindraHome"))
            {
                pnlFlag.Location = new Point(432, 185);
            }
            else if (area == "falls")
            {
                pnlFlag.Location = new Point(471, 247);
            }
            else if (area == "forest")
            {
                pnlFlag.Location = new Point(346, 326);
            }
            else if ((area == "caves") || (area == "valley") || (area == "castle"))
            {
                pnlFlag.Location = new Point(365, 390);
            }
        }
        private void LoadMapImage()
        {
            string mapImageFilename = "WesternLands.jpg";
            try
            {
                pnlMap.BackgroundImage = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\" + mapImageFilename);
            }
            catch { MessageBox.Show("Failed to find " + mapImageFilename); }
        }
        private void LoadLocationMarker()
        {
            string markerFilename = "locMarker.png";
            try
            {
                pnlFlag.BackgroundImage = new Bitmap(sf.gm.mainDirectory + "\\modules\\" + sf.gm.module.ModuleFolderName + "\\graphics\\" + markerFilename);
            }
            catch { MessageBox.Show("Failed to find " + markerFilename); }
        }
    }
}
