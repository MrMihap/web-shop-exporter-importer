using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using HobbyCenterExporter.core;

namespace HobbyCenterExporter
{
  public partial class FToFile : Form
  {
    string Login = "IJVXHNIRBO";
    string Pswd = "kPr4HZXfYV";
    int LOADING_THREADS_COUNT = 1;
    List<CategoryProp> CatPropList = new List<CategoryProp>();
    List<Category> categories = new List<Category>();
    List<Product> prodIdList = new List<Product>();
    public ShopLibrary shopLibrary = new ShopLibrary();
    Queue<Product> LoadingQueue = new Queue<Product>();
    private object shopLibLock = new object();
    public FToFile()
    {
      InitializeComponent();
    }
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

    private void FilePathTextBox_Click(object sender, EventArgs e)
    {
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.AddExtension = true;
      dialog.DefaultExt = "bin";
      dialog.Filter = "bin files (*.bin)|*.bin|All files|*.*";
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          filePath = dialog.FileName;
          break;
      }
    }

    private void NewAPILoadCats()
    {
      string md5sourse = Login + Pswd + ResultType.xml + ListCode.categories;
      string md5 = GetMd5Sum(md5sourse);
      string request = "list.php?login=IJVXHNIRBO&type=xml&code=" + ListCode.categories + "&key=" + md5;
      string website = "http://hobbycenter.ru/API/";
      string targeturl = website + request;

      WebClient client = new WebClient();
      client.Encoding = Encoding.UTF8;
      string text = client.DownloadString(website + request);
      using (XmlReader reader = XmlReader.Create(new StringReader(text)))
      {
        // загрузка идентификаторов категорий
        // костыль
        Category cat25 = new Category();
        cat25.id = 25;
        cat25.parent_id = 0;
        cat25.name = "Запчасти";
        categories.Add(cat25);
        while (reader.Read())
        {
          switch (reader.NodeType)
          {
            case XmlNodeType.Element:
              string s = reader.GetAttribute("id");
              string ss = reader.GetAttribute("parent_id");
              if (s == null) continue;
              Category cat = new Category();
              int.TryParse(s, out cat.id);
              int.TryParse(ss, out cat.parent_id);
              cat.name = reader.GetAttribute("name");
              categories.Add(cat);
              break;
          }
        }
      }
      // загрузим подробности
      for (int i = 0; i < categories.Count; i++)
      {
        CategoryProp props = new CategoryProp();
        props.id = categories[i].id;
        props.name = categories[i].name;
        props.parent_id = categories[i].parent_id;
        if (props.parent_id == 0)
          props.parent_name = "";
        else
          props.parent_name = (from p in categories where p.id == props.parent_id select p).FirstOrDefault().name;
        shopLibrary.Categories.Add(props);
      }
    }

    private void LoadItemsButton_Click(object sender, EventArgs e)
    {
      //string Login = "IJVXHNIRBO";
      //string Pswd = "kPr4HZXfYV";
      //string md5sourse = Login + Pswd + ResultType.xml + ListCode.products_all_new;
      //string md5 = GetMd5Sum(md5sourse);

      //string request = "list.php?login=" + Login + "&type=" + ResultType.xml + "&code=" + ListCode.products_all_new + "&key=" + md5;
      //string website = "http://hobbycenter.ru/API/";
      #region get actual items list
      //получаем список всех id актуальных товаров
      //WebClient client = new WebClient();
      //client.Encoding = Encoding.UTF8;
      //string text = client.DownloadString(website + request);
      //using (XmlReader reader = XmlReader.Create(new StringReader(text)))
      //{
      //  while (reader.Read())
      //  {
      //    switch (reader.NodeType)
      //    {
      //      case XmlNodeType.Element:
      //        string s = reader.GetAttribute("id");
      //        string ss = reader.GetAttribute("parent_id");
      //        if (s == null) continue;
      //        Product prod = new Product();
      //        int.TryParse(s, out prod.id);
      //        prod.name = reader.GetAttribute("name");
      //        prod.article = reader.GetAttribute("article");
      //        prodIdList.Add(prod);
      //        LoadingQueue.Enqueue(prod);
      //        ItemsCount.Text = prodIdList.Count.ToString();
      //        break;
      //    }
      //  }
      //}
      #endregion
      NewAPILoadCats();
      NewAPILoadAllItems();
      #region MTASK LOADING
      //Task[] taskArray = new Task[1];
      //for (int i = 0; i < taskArray.Count(); i++)
      //{
      // // taskArray[i] = new Task(ParticalLoaderFunction);
      // // taskArray[i].Start();
      //}
      //Thread.Sleep(500);
      //while (taskArray.Where(task => task.Status == TaskStatus.Running).Count() > 0)
      //{
      //  ItemsCount.Text = shopLibrary.ProductProps.Count.ToString() + " / " + prodIdList.Count().ToString();
      //  ItemsCount.Refresh();
      //  Thread.Sleep(1000);
      //}
      //for (int i = 0; i < taskArray.Count(); i++)
      //{
      //  taskArray[i].Wait();
      //}
      #endregion
      MessageBox.Show("удачно загружено дохера товаров!");
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      if (filePath.Count() > 10)
      {
        CDatafileInterface.WriteToFile(filePath, shopLibrary);
        shopLibrary = CDatafileInterface.ReadFromFile(filePath);
      }
      else
      {
        MessageBox.Show("укажи нормальное имя файла, придурок!");
      }
    }
    private void NewAPILoadAllItems()
    {
      string Login = "IJVXHNIRBO";
      string Pswd = "kPr4HZXfYV";
      string md5sourse = Login + Pswd + ResultType.xml + ListCode.products_full;
      string md5 = GetMd5Sum(md5sourse);

      string request = "list.php?login=" + Login + "&type=" + ResultType.xml + "&code=" + ListCode.products_full + "&key=" + md5;
      string website = "http://hobbycenter.ru/API/";

      string response;
      WebClient client = new WebClient();
      client.Encoding = Encoding.UTF8;
      
      response = client.DownloadString(website + request);
      shopLibrary.ProductProps.AddRange(CHttpLoader.FromXML(response));
    }
    
    #region Helpers
    private Post PostParser(string text)
    {
      Post collection = new Post();
      int HeaderEnd = text.IndexOf("<pre>");
      string body = text.Substring(HeaderEnd, text.Length - HeaderEnd);
      body = body.Replace("<pre>Array\n(\n", "");
      body = body.Replace("\n)\n</pre>", "");
      body += "[";
      //MessageBox.Show(body);
      for (int i = 0; i < body.Length; i++)
      {
        //first: find [
        int idxLeft = body.IndexOf("[", i) + 1;
        //second:
        int idxRight = body.IndexOf("]", idxLeft);
        if (idxLeft < 0 || idxRight < 0) break;
        int idxSubRight = body.IndexOf("=>", idxRight);
        if (idxSubRight - idxRight != 2)
        {
          i = idxRight + 1;
          continue;
        }
        string Key = body.Substring(idxLeft, idxRight - idxLeft);
        i += idxRight - idxLeft + 1;
        int valueStart = body.IndexOf("=>", idxRight) + 2;
        int valueEnd = body.IndexOf("[", valueStart);
        if (valueStart < 0) break;
        if (valueEnd < 0) break;
        string value = body.Substring(valueStart, valueEnd - valueStart);
        value = value.Replace("\n", " ");
        value = value.Replace("\r", " ");

        for (
          int SpacePosition = value.IndexOf(" ", (value.Length - 2 > 0) ? value.Length - 2 : 0);
          SpacePosition > 0;
          SpacePosition = value.IndexOf(" ", (value.Length - 2 > 0) ? value.Length - 2 : 0))
        {
          value = value.Remove(SpacePosition, 1);
        }
        for (int SpacePosition = value.IndexOf(" ", 0); SpacePosition >= 0 && SpacePosition < 2; SpacePosition = value.IndexOf(" ", 0))
        {
          value = value.Remove(SpacePosition, 1);
        }
        i += valueEnd - valueStart;
        if (!collection.Keys.Contains(Key))
          collection.Add(Key, value);
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
    #endregion




  }
}
