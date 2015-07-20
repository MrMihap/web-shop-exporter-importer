using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HobbyCenterExporter;

namespace HobbyCenterExporter.core
{
  public static class CHttpLoader
  {
    static string LoadUtemProperties()
    {
      string result = "error";
      return result;
    }
    public static List<ProductItem> FromXML(string xmlSourse)
    {
      List<ProductItem> productProps = new List<ProductItem>();
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(xmlSourse);

      foreach (XmlElement item in doc.GetElementsByTagName("item"))
      {
        ProductItem productItem = new ProductItem();
        productItem.article = item.GetAttribute("article");
        int.TryParse(item.GetAttribute("id"), out productItem.id);
        productItem.name = item.GetAttribute("name");
        productItem.description = item.GetAttribute("description");
        productItem.extended_description = item.GetAttribute("extended_description");
        productItem.weight = item.GetAttribute("weight");
        productItem.volume = item.GetAttribute("volume");
        productItem.last_update = 0;
        ulong.TryParse(item.GetAttribute("last_update"), out productItem.last_update);
        productItem.brand = item.GetAttribute("brand");
        foreach (string catstr in item.GetAttribute("category_list").Split(','))
        {
          int id = 0;
          int.TryParse(catstr, out id);
          productItem.category_list.Add(id);
        }
        foreach (string imgstr in item.GetAttribute("gallery").Split('|'))
        {
          if(!imgstr.Equals(""))
          productItem.gallery.Add(imgstr);
        }
        productItem.Photo = item.GetAttribute("photo");
        productItem.qty_free = item.GetAttribute("qty_free");
        productItem.main_category = -1;
        int.TryParse(item.GetAttribute("main_category"), out productItem.main_category);
        productItem.sale = 1;
        int.TryParse(item.GetAttribute("sale"), out productItem.sale);
        productItem.spares = item.GetAttribute("spares");
        productItem.dealer_price = 0;
        productItem.retail_price = 0;
        int.TryParse(item.GetAttribute("dealer_price"), out productItem.dealer_price);
        int.TryParse(item.GetAttribute("retail_price"), out productItem.retail_price);


        if (productItem.sale == 1)
        {
          productProps.Add(productItem);        
        }

      }

      return productProps;
    }
  }

}
