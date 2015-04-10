using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Threading;
namespace HobbyCenterExporter
{
  public partial class FStartForm : Form
  {
    string Login = "IJVXHNIRBO";
    string Pswd = "kPr4HZXfYV";
    public List<CategoryProp> CatPropList = new List<CategoryProp>();
    ShopLibrary loadedLib;
    public FStartForm()
    {
      InitializeComponent();
    }

    private void loadcat_Click(object sender, EventArgs e)
    {
      string md5sourse = Login + Pswd + ResultType.xml + ListCode.categories;
      string md5 = GetMd5Sum(md5sourse);
      string request = "list.php?login=IJVXHNIRBO&type=xml&code=" + ListCode.categories + "&key=" + md5;
      string website = "http://hobbycenter.ru/API/";
      string targeturl = website + request;

      WebClient client = new WebClient();
      client.Encoding = Encoding.UTF8;
      string response = client.DownloadString(website + request);
      FWebLoader form = new FWebLoader(response);
      form.Show();
      CatPropList = form.propList;
    }

    private void LoadTList_Click(object sender, EventArgs e)
    {

      FExportTable form = new FExportTable();
      form.ShowDialog();
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

    private void LoadKT_Click(object sender, EventArgs e)
    {
      FToFile form = new FToFile();
      form.ShowDialog();
      loadedLib = form.shopLibrary;
    }

    private void CSVExportButton_Click(object sender, EventArgs e)
    {
      string filePath = "";
      MessageBox.Show("Укажите файл с данными о товарах и категориях в формате .bin");
      OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

      dialog.Filter = "bin files (*.bin)|*.bin|All files|*.*";
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          filePath = dialog.FileName;
          break;
      }
      
      ShopLibrary shopLibrary = CDatafileInterface.ReadFromFile(filePath);
      MessageBox.Show(
        "Из файла успешно загружено " 
        + shopLibrary.ProductProps.Count 
        + " товаров и " 
        + shopLibrary.Categories.Count 
        +" категорий" );
      MessageBox.Show("Укажите имя CSV файла для выгрузки в него товаров и категорий");
      SaveFileDialog Savedialog = new SaveFileDialog();
      Savedialog.AddExtension = true;
      Savedialog.DefaultExt = "csv";
      Savedialog.Filter = "csv files (*.csv)|*.csv";
      switch (Savedialog.ShowDialog())
      {
        case DialogResult.OK:
          filePath = Savedialog.FileName;
          break;
      }
      using (StreamWriter swr = new StreamWriter(filePath))
      {
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
       "Image URL"
      };
        #endregion
        int lineCount = 0;
        CCatTree categories = new CCatTree(shopLibrary.Categories);

        swr.WriteLine(CSVLineBuilder(attrArray));
        foreach (ProductProp prop in shopLibrary.ProductProps)
        {
          string[] Values = new string[attrArray.Count()];
          //Product code	
          Values[0] = prop.article.ToString();
          //Language	
          Values[1] = "ru";
          //Category	
          try
          {
            Values[2] = categories.getPath(prop.category_list);
          }
          catch (KeyNotFoundException ex)
          {
            continue;
          }
          //Price	
          Values[3] = ((int)(Double.Parse(prop.price_retail) * 0.95)).ToString();
          //Weight	
          Values[4] = prop.qty_weight;
          //Product name	
          Values[5] = prop.name_rus;
          //Description	
          Values[6] = prop.descrip_full.Replace("&lt;", "<").Replace("&gt;", ">"); //desc full
          //Meta keywords	
          Values[7] = prop.meta_keywords.Replace("&lt;", "<").Replace("&gt;", ">");//meta key
          //Meta description	
          Values[8] = prop.meta_description;
          //Search words
          Values[9] = prop.meta_description + " " + prop.name_lite + " " + prop.name_lite + " " + prop.meta_keywords;
          //Features	
          Values[10] = "";
          //SEO name	
          Values[11] = prop.name_rus;
          //Short description
          Values[12] = prop.descrip_lite.Replace("&lt;", "<").Replace("&gt;", ">");
          //Detailed image
          Values[13] = "";
          //Page title	
          Values[14] = prop.name_rus;
          //Image URL
          Values[15] = prop.images_title;
          swr.WriteLine(CSVLineBuilder(Values));
          lineCount++;
        }
        MessageBox.Show("Удачно выгружено " + lineCount.ToString() +" наименований");
      }

    }

    string CSVLineBuilder(string[] array)
    {
      string result = "";
      for (int i = 0; i < array.Length; i++)
      {
        if (array[i].Contains("35910"))
        {
        }
        string cell = array[i].Replace("\"", "\"\"");
        cell = cell.Replace("&nbsp;", " ");
        cell = cell.Replace("quot;", "\"");
        cell = cell.Replace("amp;", " ");
        cell = cell.Replace("&ldquo;", "\"");
        cell = cell.Replace("&rdquo;", "\"");
        cell = cell.Replace("& nbsp;", " ");
        cell = cell.Replace("& ldquo;", "\"");
        cell = cell.Replace("& rdquo;", "\"");
        cell = cell.Replace(";", ":");
        cell = cell.Replace("&","");
        //        cell = cell.Replace(";", "\";\"");
        if (i < array.Length - 1)
          cell += ";";
        result += cell;
      }
      return result;
    }

    private void imgLoadButton_Click(object sender, EventArgs e)
    {
      CImageLoader loader = new CImageLoader(loadedLib);
      loader.LoadImages();
    }

    private void FStartForm_Load(object sender, EventArgs e)
    {

    }
  }


}
