using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace HobbyCenterExporter
{
  class CCSVBuilder
  {
    public static string BuildLine(string[] array)
    {
      string result = "";
      for (int i = 0; i < array.Length; i++)
      {
        //Debug
        string s = HttpUtility.HtmlDecode(array[i]);
        array[i] = s;
        if (array[i].Contains("7kodxw6sflc"))
        {
        }
        string cell = s.Replace("\"", "\"\"");
        //cell = cell.Replace("&nbsp;", " ");
        //cell = cell.Replace("quot;", "\"");
        //cell = cell.Replace("amp;", " ");
        //cell = cell.Replace("&ldquo;", "\"");
        //cell = cell.Replace("&rdquo;", "\"");
        //cell = cell.Replace("& nbsp;", " ");
        //cell = cell.Replace("& ldquo;", "\"");
        //cell = cell.Replace("& rdquo;", "\"");
        cell = cell.Replace(";", ":");
        //cell = cell.Replace("&","");
        cell = cell.Replace("/imglib/", "http://www.hobbycenter.ru/imglib/");
        //        cell = cell.Replace(";", "\";\"");
        if (i < array.Length - 1)
          cell += ";";
        result += cell;
      }
      return result;
    }
  }
}
