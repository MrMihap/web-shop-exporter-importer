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
  public partial class Form1 : Form
  {
    string Login = "IJVXHNIRBO";
    string Pswd = "kPr4HZXfYV";
    public List<CategoryProp> CatPropList = new List<CategoryProp>();
    public Form1()
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
      string text = client.DownloadString(website + request);

      txb_text.Text = text;

      Form2 form = new Form2(text);
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
    }

  }
  

}
