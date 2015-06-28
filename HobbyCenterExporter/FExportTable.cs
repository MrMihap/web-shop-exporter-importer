using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
using System.Windows.Forms;

namespace HobbyCenterExporter
{
  public partial class FExportTable : Form
  {
    private List<CategoryProp> CatList;
    private CategoryProp SelectedCat;
    private List<Product> prodIdList = new List<Product>();
    private List<ProductItem> prodPropsList = new List<ProductItem>();
    private ShopLibrary shopLibrary;
    string src = "";
    public string _filePath = "";
    public string filePath
    {
      get
      {
        return _filePath;
      }
      set
      {
        _filePath = value;
        FilePathTextBox.Text = _filePath;
      }
    }

    public FExportTable()
    {
      InitializeComponent();
    }



    public FExportTable(List<CategoryProp> _CatList, string sourse)
    {
      InitializeComponent();
      CatList = _CatList;
      src = sourse;
    }

    private Post PostParser(string text)
    {
      Post collection = new Post();
      {
      }
      return collection;
    }
    static public string GetMd5Sum(string str)
    {
      MD5 md5 = MD5CryptoServiceProvider.Create();
      byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(str));
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dataMd5.Length; i++)
        sb.AppendFormat("{0:x2}", dataMd5[i]);
      return sb.ToString();
    }


    private void Form3_Load(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
      dialog.Filter = "bin files (*.bin)|*.bin|All files|*.*";
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          filePath = dialog.FileName;
          break;
      }
      shopLibrary = CDatafileInterface.ReadFromFile(filePath);
      categoriesList.Items.AddRange(shopLibrary.Categories.ToArray());
      categoriesList.SelectedIndex = 0;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      while (dataGrid.Rows.Count > 0) dataGrid.Rows.RemoveAt(0);

      CCatTree categories = new CCatTree(shopLibrary.Categories);
      #region Атрибуты экспорта
      string[] attrArray = new string[]{ 
       "Product code",	
       "Language",	
       "Category",	
       "Price",	
       "Weight",	
       "Product name",	
       "Description",	
       "Meta keywords",	
       "Meta description",	
       "Search words",	
       "Features",	
       "SEO name",	
       "Short description",	
       "Detailed image",	
       "Page title",	
       "Image URL",
       "Quantity"
      };
      #endregion
      dataGrid.Rows.Add(attrArray);
      foreach (ProductItem prop in shopLibrary.ProductProps)
      {
        string sku = "";
        string skucategory = "";
        if (shopLibrary.Categories.Where(x => x.id == prop.main_category).Count() > 0)
        {
          sku = "re-" + shopLibrary.Categories.Where(x => x.id == prop.main_category).First().id.ToString();
          skucategory = "recat-" + shopLibrary.Categories.Where(x => x.id == prop.main_category).First().id.ToString();
        }
        else
        {
          continue;
        }
        if (shopLibrary.Categories.Where(x => x.id == prop.main_category).First().id != SelectedCat.id)
        {
          continue;
        }
        string[] Values = new string[attrArray.Count()];
        //Product code	
        Values[0] = prop.article.ToString();
        //Language	
        Values[1] = "ru";
        //Category	
        Values[2] = categories.getPath(prop.main_category);
        //Price	
        Values[3] = ((int)(prop.retail_price * 0.95)).ToString();
        //Weight	
        Values[4] = prop.weight;
        //Product name	
        Values[5] = prop.name;
        //Description	
        Values[6] = prop.extended_description.Replace("&lt;", "<").Replace("&gt;", ">"); //desc full
        //Meta keywords	
        Values[7] = prop.name + " " + prop.brand;//prop.meta_keywords.Replace("&lt;", "<").Replace("&gt;", ">");//meta key
        //Meta description	
        Values[8] = prop.description;
        //Search words
        Values[9] = prop.description + " " + prop.name + " " + prop.brand;
        //Features	
        Values[10] = "";
        //SEO name	
        Values[11] = prop.name;
        //Short description
        Values[12] = prop.description.Replace("&lt;", "<").Replace("&gt;", ">");
        //Detailed image
        Values[13] = "";
        //Page title	
        Values[14] = prop.name;
        //Image URL
        Values[15] = prop.Photo;
        //Quantity
        Values[16] = "100";



        dataGrid.Rows.Add(Values);
      }
      //выгрузка в таблицу
      MessageBox.Show("Выгружено : " + (dataGrid.Rows.Count -1).ToString() + "товаров");
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (categoriesList.SelectedItem is CategoryProp) SelectedCat = categoriesList.SelectedItem as CategoryProp;

    }
  }
}
