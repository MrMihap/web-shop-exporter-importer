using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;
namespace HobbyCenterExporter
{
  public partial class FWebLoader : Form
  {

    List<Category> categories = new List<Category>();
    public List<CategoryProp> propList = new List<CategoryProp>();
    string Login = "IJVXHNIRBO";
    string Pswd = "kPr4HZXfYV";
    string XMLsource = "";
    public FWebLoader()
    {
      InitializeComponent();
    }
    public FWebLoader(string xmlsource)
    {
      InitializeComponent();
      XMLsource = xmlsource;

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
    private void Form2_Load(object sender, EventArgs e)
    {

    }
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

    private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      string md5sourse = Login + Pswd;
      string md5 = GetMd5Sum(md5sourse);
      string request = "categories.php?login=" + Login + "&id=770&key=" + md5;
      string website = "http://hobbycenter.ru/API/";
      //http://hobbycenter.ru/API/categories.php?login=IJVXHNIRBO&id=770&key=a86e0ca05ddba3b774b7be94b36972a5

      using (XmlReader reader = XmlReader.Create(new StringReader(XMLsource)))
      {
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
              LoadedTextBox.Text = categories.Count.ToString();
              break;
          }
        }
      }
     
    }

    private void button2_Click(object sender, EventArgs e)
    {
      string md5sourse = Login + Pswd;
      string md5 = GetMd5Sum(md5sourse);
      string request = "categories.php?login=" + Login + "&id=770&key=" + md5;
      string website = "http://hobbycenter.ru/API/";
      for (int i = 0; i < categories.Count; i++)
      {
        WebClient client = new WebClient();
        client.Encoding = Encoding.UTF8;
        md5sourse = Login + Pswd + categories[i].id.ToString();
        md5 = GetMd5Sum(md5sourse);
        request = "categories.php?login=" + Login + "&id=" + categories[i].id.ToString() + "&key=" + md5;
        string text = client.DownloadString(website + request);


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
        propList.Add(props);

        processedTextBox.Text = propList.Count().ToString();
        processedTextBox.Refresh();
      }
      foreach (CategoryProp prop in propList)
      {
        string type = "";
        string parent = "";
        if (prop.parent_id == 0)
        {
          type = "Раздел";
          parent = "";
        }
        else
        {
          type = "Подраздел";
          parent = "recat-" + prop.parent_id.ToString();
        }
        DataGrid.Rows.Add(
          "recat-" + prop.id.ToString(),
          parent,
          prop.description,
          prop.extended_description,
          prop.description,
          "",
          prop.keywords,
          prop.description,
          "1",
          "1");
      }
    }
  }
}
