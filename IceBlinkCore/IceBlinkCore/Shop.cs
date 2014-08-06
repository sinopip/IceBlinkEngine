using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using IceBlink;
using IceBlinkToolset;

namespace IceBlinkCore
{
    [Serializable]
    public class Shops
    {
        [XmlIgnore]
        public Game game;
        [XmlArrayItem("Shops")]
        public List<Shop> shopsList = new List<Shop>();
        public Shops()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        public void saveShopsFile(string filename)
        {
            StreamWriter writer = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Shops));
                writer = new StreamWriter(filename);
                ser.Serialize(writer, this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save Shops file. Error: " + ex.Message);
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
        public Shops loadShopsFile(string filename)
        {
            Shops toReturn = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Shops));
            FileStream myFileStream = null;
            try
            {
                myFileStream = new FileStream(filename, FileMode.Open);
                toReturn = (Shops)serializer.Deserialize(myFileStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open xml Shops file. Error:\n{0}", ex.Message);
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
        public Shop getShopByTag(string tag)
        {
            foreach (Shop shp in shopsList)
            {
                if (shp.ShopTag == tag)
                {
                    return shp;
                }
            }
            return null;
        }
    }

    [Serializable]
    public class Shop
    {
        [XmlIgnore]
        public Game game;

        private string shopTag = "newShopTag";

        [XmlElement]
        public string ShopTag
        {
            get { return shopTag; }
            set { shopTag = value; }
        }        

        [XmlArrayItem("ShopItemsTags")]
        public List<string> shopItemTags = new List<string>();

        [XmlElement]
        public List<string> InitialShopItemTags = new List<string>();

        [XmlArrayItem("ShopItemsNames")]
        public List<string> shopItemNames = new List<string>();

        [XmlIgnore]
        public List<Item> shopItemObjectsList = new List<Item>();

        public Shop()
        {
        }
        public void passRefs(Game g)
        {
            game = g;
        }
        
        public override string ToString()
        {
            return ShopTag;
        }
        public Shop ShallowCopy()
        {
            return (Shop)this.MemberwiseClone();
        }
        public Shop DeepCopy()
        {
            Shop other = (Shop)this.MemberwiseClone();
            other.shopItemNames = new List<string>();
            for (int i = 0; i < this.shopItemNames.Count; i++)
            {
                other.shopItemNames.Add(this.shopItemNames[i]);
            }
            other.shopItemTags = new List<string>();
            for (int i = 0; i < this.shopItemTags.Count; i++)
            {
                other.shopItemTags.Add(this.shopItemTags[i]);
            }
            other.InitialShopItemTags = new List<string>();
            for (int i = 0; i < this.InitialShopItemTags.Count; i++)
            {
                other.InitialShopItemTags.Add(this.InitialShopItemTags[i]);
            }
            other.shopItemObjectsList = new List<Item>();
            return other;
        }
    }
}
