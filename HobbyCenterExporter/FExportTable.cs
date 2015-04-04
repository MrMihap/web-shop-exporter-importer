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

      foreach (ProductProp prop in shopLibrary.ProductProps)
      {
        string sku = "";
        string skucategory = "";
        if (shopLibrary.Categories.Where(x => x.id == prop.category_list).Count() > 0)
        {
          sku = "re-" + shopLibrary.Categories.Where(x => x.id == prop.category_list).First().id.ToString();
          skucategory = "recat-" + shopLibrary.Categories.Where(x => x.id == prop.category_list).First().id.ToString();
        }
        else
        {
          continue;
        }
        if (shopLibrary.Categories.Where(x => x.id == prop.category_list).First().id != SelectedCat.id)
        {
          continue;
        }
        //Code
        //lang (ru)
        //Category	
        //Price	
        //Weight	
        //Name	
        //description_full
        //meta_keywords	
        //meta_description	
        //meta_title	(Page Title)
        //Short Description

        dataGrid.Rows.Add(
          prop.article, //sku
          "ru", //lang
          "", //cat
          Double.Parse(prop.price_retail) * 0.95, //price
          prop.qty_weight, //weight
          prop.name_lite, //name
          prop.descrip_full, //desc full
          prop.meta_keywords,//meta key
          prop.meta_description,//meta desc
          prop.name_rus,//meta
          prop.descrip_lite//meta
          );
      }
      //выгрузка в таблицу
      MessageBox.Show("Выгружено : " + dataGrid.Rows.Count.ToString() + "товаров");
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (categoriesList.SelectedItem is CategoryProp) SelectedCat = categoriesList.SelectedItem as CategoryProp;
    }
  }
}
