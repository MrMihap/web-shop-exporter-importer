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

namespace HobbyCenterExporter
{
  public partial class FToFile : Form
  {
    string Login = "IJVXHNIRBO";
    string Pswd = "kPr4HZXfYV";
    List<CategoryProp> CatPropList = new List<CategoryProp>();
    List<Category> categories = new List<Category>();
    List<Product> prodIdList = new List<Product>();
    ShopLibrary shopLibrary = new ShopLibrary();
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

    private void LoadCatsButton_Click(object sender, EventArgs e)
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
              CatsCount.Text = shopLibrary.Categories.Count.ToString() + "/" + categories.Count().ToString();
              CatsCount.Refresh();
              break;
          }
        }
      }
      // загрузим подробности
      for (int i = 0; i < categories.Count; i++)
      {
        client = new WebClient();
        client.Encoding = Encoding.UTF8;
        md5sourse = Login + Pswd + categories[i].id.ToString();
        md5 = GetMd5Sum(md5sourse);
        request = "categories.php?login=" + Login + "&id=" + categories[i].id.ToString() + "&key=" + md5;
        text = client.DownloadString(website + request);
        Post DataProps = PostParser(text);
        CategoryProp props = new CategoryProp();
        props.description = DataProps["description"];
        props.extended_description = DataProps["extended_description"];
        props.id = int.Parse(DataProps["id"]);
        props.keywords = DataProps["keywords"];
        props.name = DataProps["name"];
        props.parent_id = categories[i].parent_id;
        if (props.parent_id == 0)
          props.parent_name = "";
        else
          props.parent_name = (from p in categories where p.id == props.parent_id select p).FirstOrDefault().name;
        shopLibrary.Categories.Add(props);
        CatsCount.Text = shopLibrary.Categories.Count.ToString() + "/" + categories.Count().ToString();
        CatsCount.Refresh();
      }
    }

    private void LoadItemsButton_Click(object sender, EventArgs e)
    {
      string Login = "IJVXHNIRBO";
      string Pswd = "kPr4HZXfYV";
      string md5sourse = Login + Pswd + ResultType.xml + ListCode.products_all_new;
      string md5 = GetMd5Sum(md5sourse);

      string request = "list.php?login=" + Login + "&type=" + ResultType.xml + "&code=" + ListCode.products_all_new + "&key=" + md5;
      string website = "http://hobbycenter.ru/API/";

      //получаем список всех id актуальных товаров
      WebClient client = new WebClient();
      client.Encoding = Encoding.UTF8;
      string text = client.DownloadString(website + request);
      using (XmlReader reader = XmlReader.Create(new StringReader(text)))
      {
        while (reader.Read())
        {
          switch (reader.NodeType)
          {
            case XmlNodeType.Element:
              string s = reader.GetAttribute("id");
              string ss = reader.GetAttribute("parent_id");
              if (s == null) continue;
              Product prod = new Product();
              int.TryParse(s, out prod.id);
              prod.name = reader.GetAttribute("name");
              prod.article = reader.GetAttribute("article");
              prodIdList.Add(prod);
              ItemsCount.Text = prodIdList.Count.ToString();
              break;
          }
        }
      }
      // теперь загрузим подробности товаров
      for (int i = 0; i < prodIdList.Count; i++)
      {
        Product prod = prodIdList[i];
        client = new WebClient();
        client.Encoding = Encoding.UTF8;
        //http://www.hobbycenter.ru/API/i.php?login=IJVXHNIRBO&type=xml&code=products_full&key=5e6bd6affc75b4dfc4fea4683daab461&article=TRA24054&attribute=description|extended_description
        #region new api using
        //// $key =  md5('Логин для API' . 'Пароль для API' . 'yml' . 'products_full');
        //client.Encoding = Encoding.UTF8;
        //md5sourse = Login + Pswd + ResultType.xml + ListCode.products_full;
        //md5 = GetMd5Sum(md5sourse);
        //request = "i.php?login=" + Login + "&type=" + ResultType.xml + "&code=" + ListCode.products_full + "&key=" + md5 + "&article=" + prod.article + "&attribute=description|extended_description";
        //text = client.DownloadString(website + request);
        //ProductItem prodProp = new ProductItem();
        //#region xml parsing
        //using (XmlReader reader = XmlReader.Create(new StringReader(text)))
        //{
        //  while (reader.Read())
        //  {
        //    switch (reader.NodeType)
        //    {
        //      case XmlNodeType.Element:
        //        if (!reader.Name.Equals("item")) continue;
        //        #region fill the properties
        //        prodProp.article = reader.GetAttribute("article");
        //        prodProp.brand = reader.GetAttribute("brand");
        //        string s = reader.GetAttribute("category_list");
        //        // prodProp.category_list = int.Parse(reader.GetAttribute(s));
        //        prodProp.dealer_price = int.Parse(reader.GetAttribute("dealer_price"));
        //        prodProp.description = reader.GetAttribute("description");
        //        prodProp.id = int.Parse(reader.GetAttribute("id"));
        //        prodProp.main_category = int.Parse(reader.GetAttribute("main_category"));
        //        prodProp.name = reader.GetAttribute("name");
        //        prodProp.qty_free = reader.GetAttribute("qty_free");
        //        prodProp.retail_price = int.Parse(reader.GetAttribute("retail_price"));
        //        prodProp.sale = reader.GetAttribute("sale");
        //        prodProp.volume = reader.GetAttribute("volume");
        //        prodProp.weight = reader.GetAttribute("weight");
        //        #endregion
        //        break;
        //    }
        //  }
        //}
        //#endregion
        #endregion
        //1 — название КТ (полное и сокр.)
        //2 — описание КТ (полное и сокр., мета-данные)
        //4 — ссылки к описанию (видео, pdf инструкции)
        //8 — галерея картинок (картинка шапка и галерея)
        //16 — бренд (id и имя)
        //32 — категории (id'шники и имена)
        //64 — количество (кол. на складе, кол. в коробке, вес)
        //128 — цены для каждого из видов дилерства

        int ktSumm = 1 + 2 + 4 + 8 + 16 + 32 + 64 + 128;
        md5sourse = Login + Pswd + prod.article + ktSumm.ToString();
        md5 = GetMd5Sum(md5sourse);
        request = "product.php?login=" + Login + "&article=" + prod.article + "&code=" + ktSumm.ToString() + "&key=" + md5;
        //http://hobbycenter.ru/API/product.php?login=IJVXHNIRBO&article=TRA76054&code=43&key=0e5e915d062d88976a4b9fc88a18f4cc где:
        text = client.DownloadString(website + request);
        Post postData = PostParser(text);
        ProductProp product = new ProductProp();
        try
        {
          product = new ProductProp(postData);
        }
        catch(Exception ex)
        {
          MessageBox.Show("Ошибка декодинга, выгрузка будет продолжена, \nкод ошибки сообщить разработчику\n" + ex.Message);
          continue;
        }
        shopLibrary.ProductProps.Add(product);
        ItemsCount.Text = shopLibrary.ProductProps.Count.ToString() + " / " + prodIdList.Count().ToString();
        ItemsCount.Refresh();

        //login – логин указанный в настройках API
        //code – сумма запрашиваемой информации, подробнее:
        //article — артикул опрашиваемого товара (получение списков смотрите выше)
        //key — ключ сверки доступа к API, подробнее:

        //пример: $key = md5($login.$passAPI.$article.$code), где:
        //       
        //shopLibrary.ProductProps.Add();

      }
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
          int SpacePosition = value.IndexOf(" ", (value.Length - 2 > 0) ? value.Length -2 : 0); 
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
