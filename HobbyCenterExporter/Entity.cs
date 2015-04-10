using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace HobbyCenterExporter
{
  [Serializable]
  public class ShopLibrary
  {
    public List<CategoryProp> Categories;
    public List<ProductProp> ProductProps;
    public ShopLibrary()
    {
      Categories = new List<CategoryProp>();
      ProductProps = new List<ProductProp>();
    }
  }
  public class Category
  {
    public int id;
    public int parent_id;
    public string name;

  }
  [Serializable]
  public class CategoryProp
  {
    public int id;
    public int parent_id;
    public string name;
    public string parent_name;
    public string description;
    public string extended_description;
    public string keywords;
    public override string ToString()
    {
      return description;
      //return base.ToString();
    }
  }

  [Serializable]
  public class Product
  {
    public int id;
    public string article;
    public string name;
    public string qty_free;
    public volatile bool IsLoaded = false;
  }
  [Serializable]
  public class ProductProp
  {
    public ProductProp()  { }

    public ProductProp(Post data)
    {
      try
      {
        this.product_id = int.Parse(data["product_id"]);
        this.article = data["article"];
        this.brand_id = int.Parse(data["brand_id"]);
        this.brand_name = data["brand_name"];
        string[] categoriesArray = data["category_list"].Split(',');
        string category = categoriesArray.First().Replace(" ", "");
        this.categories = new List<int>();

        if (categoriesArray.Count() >= 1)
        {
          int value;
          foreach (string category_id in categoriesArray)
          {
            value = 0;
            int.TryParse(category_id, out value);
            this.categories.Add(value);
          }
          //do noth
        }
        else
        {
          this.categories.Add(0);
        }
        if (category.Equals(""))
          this.category_list = 0;
        else
        {
          this.category_list = int.Parse(category);
        }
        this.descrip_full = data["descrip_full"];
        this.descrip_lite = data["descrip_lite"];
        this.images_title = "www.hobbycenter.ru/imglib" + data["images_title"];
        this.link_eng_pdf = data["link_eng_pdf"];
        this.link_exploded = data["link_exploded"];
        this.link_ext = data["link_ext"];        this.link_pdf = data["link_pdf"];
        this.link_pdf2 = data["link_pdf2"];
        this.link_video = data["link_video"];
        this.meta_description = data["meta_description"];
        this.meta_keywords = data["meta_keywords"];
        this.name_lite = data["name_lite"];
        this.name_rus = data["name_rus"];
        this.price_gold = data["price_gold"];
        this.price_map = data["price_map"];
        this.price_platina = data["price_platina"];
        this.price_retail = data["price_retail"];
        this.price_silver = data["price_silver"];
        this.qty_free = data["qty_free"];
        this.qty_in_box = data["qty_in_box"];
        this.qty_status = data["qty_status"];
        this.qty_weight = data["qty_weight"];
        //this.spares = data["spares"];
      }

      catch (KeyNotFoundException e)
      {
        throw new Exception(e.Message);
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public int product_id;
    public string article;
    public string name_lite; //— название КТ как на сайте HobbyCente
    public string name_rus; //— русское название КТ
    public string descrip_lite; //— краткое описание
    public string descrip_full;// — полное описание (с html тегами)
    public string meta_keywords;// — meta-ключевые слова (для поисковиков)
    public string meta_description;// — meta-описание (для поисковиков)
    public string link_video;// — ссылка на видео (если она есть, или если её нет в описании)
    public string link_ext;// — ссылка на внешний источник
    public string link_pdf;// — ссылка на pdf инструкцию по эксплуатации
    public string link_eng_pdf;// — ссылка на pdf инструкцию по эксплуатации ENG (оригинал)
    public string link_pdf2;// — ссылка на pdf инструкцию по запуску
    public string link_exploded;// — ссылка на развернутое описание для модели
    public string images_title;// — имя файла (из директории /imglib/) картинки титула
    public int brand_id;// — идентификатор бренда (получение списков смотрите выше)
    public string brand_name;// — имя бренда

    public int category_list;// — идентификатор  (получение списков смотрите выше)
    public List<int> categories;
    public string qty_free;// — свободный остаток на складе
    public string qty_status;// — статус остатка (для пользователей)
    public string qty_in_box;// — колиство единиц товара в коробке
    public string qty_weight;// — вес товара в килограммах
    public string price_retail;// — цена для розницы
    public string price_silver;// — цена для серебряного дилера
    public string price_gold;// — цена для золотого дилера
    public string price_platina;// — цена для платинового дилера
    public string price_map;// — минимальная рекламная цена
    public string spares;// — список артикулов запчастей
  }
  [Serializable]
  public class ProductItem
  {
    public int id;
    public string article;
    public string name;
    public string brand;
    public int category_list;
    public int main_category;
    public int dealer_price;
    public int retail_price;
    public string qty_free;
    public string sale;
    public string weight;
    public string volume;
    public string description;
  }
  public class Post : Dictionary<string, string>
  {
  }
  public enum ListCode
  {
    brands,// — полный список брендов
    categories,// — полный список категорий и подкатегорий
    products_all,// — полный список продуктов (КТ) около 30.000 записей
    //(с этим ключом можно передавать параметр category_id=id конечной категории, 
    //в этом случае выборка будет ограничена товарами указанной категории)
    products_models,// — список только моделей (КТ) около 10.000 записей
    products_spareparts,// — список только запчастей (КТ) около 20.000 записей
    products_all_new,// все актуальные товары (около 6000)
    products_full// вся инфа об товаре
  }
  public enum ResultType
  {
    xml,
    csv
  }
}
//prodProp.id = int.Parse(reader.GetAttribute("id"));
//prodProp.brand_id = int.Parse(reader.GetAttribute("brand_id"));
//prodProp.brand_name = reader.GetAttribute("brand_name");
//prodProp.categoryId0 = int.Parse(reader.GetAttribute("categoryId0"));
//prodProp.categoryId1 = int.Parse(reader.GetAttribute("categoryId1"));
//prodProp.categoryName0 = reader.GetAttribute("categoryName0");
//prodProp.categoryName1 = reader.GetAttribute("categoryName1");
//prodProp.descrip_full = reader.GetAttribute("descrip_full");
//prodProp.descrip_lite = reader.GetAttribute("descrip_lite");
//prodProp.image_0 = reader.GetAttribute("image_0");
//prodProp.image_1 = reader.GetAttribute("image_1");
//prodProp.images_title = reader.GetAttribute("images_title");
//prodProp.link_eng_pdf = reader.GetAttribute("link_eng_pdf");
//prodProp.link_exploded = reader.GetAttribute("link_exploded");
//prodProp.link_ext = reader.GetAttribute("link_ext");
//prodProp.link_pdf = reader.GetAttribute("link_pdf");
//prodProp.link_pdf2 = reader.GetAttribute("link_pdf2");
//prodProp.link_video = reader.GetAttribute("link_video");
//prodProp.meta_description = reader.GetAttribute("meta_description");
//prodProp.meta_keywords = reader.GetAttribute("meta_keywords");
//prodProp.name_lite = reader.GetAttribute("name_lite");
//prodProp.name_rus = reader.GetAttribute("name_rus");
//prodProp.price_gold = reader.GetAttribute("price_gold");
//prodProp.price_map = reader.GetAttribute("price_map");
//prodProp.price_platina = reader.GetAttribute("price_platina");
//prodProp.price_retail = reader.GetAttribute("price_retail");
//prodProp.price_silver = reader.GetAttribute("price_silver");
//prodProp.qty_free = reader.GetAttribute("qty_free");
//prodProp.qty_in_box = reader.GetAttribute("qty_in_box");
//prodProp.qty_status = reader.GetAttribute("qty_status");
//prodProp.qty_weight = reader.GetAttribute("qty_weight");
//prodProp.spares = reader.GetAttribute("spares");