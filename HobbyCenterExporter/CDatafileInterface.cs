using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace HobbyCenterExporter
{
  public static class CDatafileInterface
  {
    
      static public ShopLibrary ReadFromFile(string Path)
      {
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.None))
        {
          return (ShopLibrary)formatter.Deserialize(fStream);
        }
      }

      static public void WriteToFile(string Path, ShopLibrary data)
      {
        BinaryFormatter formatter = new BinaryFormatter();
        using (Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None))
        {
          formatter.Serialize(fStream, data);
        }
      }
  }
}
