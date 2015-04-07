using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyCenterExporter
{
  public class CCatTree
  {
    List<CategoryProp> categories;
    public CCatTree()
    {
      categories = new List<CategoryProp>();
    }
    public CCatTree(List<CategoryProp> data)
    {
      categories = new List<CategoryProp>();
      categories.AddRange(data);
    }
    public string getPath(int id)
    {
      //берем нижнюю категрию
      CategoryProp currentCat = categories.Where(x => x.id == id).FirstOrDefault();
      List<CategoryProp> catPath = new List<CategoryProp>();
      if (currentCat == null) return "unbeeing path";
      catPath.Add(currentCat);
      while (currentCat.parent_id > 0)
      {
        
        //идем по всем родителям, пока не дойдем до корня
        currentCat = categories.Where(x => x.id == currentCat.parent_id).FirstOrDefault();
        //Дабавляем в путь
        if (currentCat != null)
          catPath.Add(currentCat);
      }
      //Переворачиваем список так что бы корневой элемент был первым, а лист - последним
      catPath.Reverse();

      string result = catPath.First().name;
      for (int i = 1; i < catPath.Count; i++)
      {
        result += "///" + catPath[i].name;
      }
      return result;
    }

  }
  class CCatElent
  {

  }
}
