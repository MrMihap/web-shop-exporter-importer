using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;
namespace HobbyCenterExporter
{
  class CImageLoader
  {
    string SiteUrl = "http://www.hobbycenter.ru/imglib/";
    string selectedDir = "";
    ShopLibrary library = null;
    Queue<ProductItem> UnloadedQueue = new Queue<ProductItem>();
    object QueueLock = new object();
    public CImageLoader()
    {

    }
    public CImageLoader(ShopLibrary data)
    {
      library = data;
    }

    public void LoadImages()
    {
      if (library == null) this.InitialiseLib();
      if (library == null) return;
      FolderBrowserDialog dialog = new FolderBrowserDialog();
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          if (dialog.SelectedPath.Length < 8)
          {
            MessageBox.Show("Укажите нормальное имя папки");
            return;
          }
          selectedDir = dialog.SelectedPath + @"\";
          break;
        case DialogResult.Cancel:
          MessageBox.Show("Операция отменена пользователем");
          return;
      }
      foreach (ProductItem item in library.ProductProps)
      {
        UnloadedQueue.Enqueue(item);
      }
      Task[] LoadThreads = new Task[1];
      for (int i = 0; i < LoadThreads.Count(); i++)
      {
        LoadThreads[i] = new Task(LoadImagesFunction);
        LoadThreads[i].Start();
      }
      Thread.Sleep(1000);
      for (int i = 0; i < LoadThreads.Count(); i++)
      {
        LoadThreads[i].Wait();
      }
      MessageBox.Show("Фото выгружены в указанную диркторию");
      this.BuildImgCSV();

    }
    private void LoadImagesFunction()
    {
      WebClient Client = new WebClient();
      ProductItem currentTarget = null;
      while (UnloadedQueue.Count > 0)
      {
        lock (QueueLock)
          if (UnloadedQueue.Count == 0) return;
          else
            currentTarget = UnloadedQueue.Dequeue();
      
        try
        {
          string filename =selectedDir + currentTarget.Photo.Replace("http://hobbycenter.ru/imglib/", "");
          Client.DownloadFile(currentTarget.Photo, filename);
          foreach (string gallery in currentTarget.gallery)
          {
            filename = selectedDir + gallery.Replace("http://hobbycenter.ru/imglib/", "");
            Client.DownloadFile(gallery, filename);
          }
        }
        catch
        {
          continue;
        }
      }

    }
    private void BuildImgCSV()
    {
      if (library == null) return;
      string filePath = "";
      SaveFileDialog dialog = new SaveFileDialog();
      dialog.AddExtension = true;
      dialog.DefaultExt = "csv";
      dialog.Filter = "csv files (*.csv)|*.csv";
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          filePath = dialog.FileName;
          break;
      }
      if (filePath.Length < 8) return;
      #region Атрибуты экспорта
      string[] attrArray = new string[]{ 
       "Product code",	
       "Pair type",
       "Detailed image"
      };
      #endregion
      using (StreamWriter swr = new StreamWriter(filePath))
      {
        string line = CSVLineBuilder(attrArray);
        swr.WriteLine(line);
        foreach (ProductItem item in library.ProductProps)
        {
          string[] Values = new string[attrArray.Count()];
          Values[0] = item.article.ToString();
          Values[1] = "M";
          Values[2] = item.Photo.Replace("http://hobbycenter.ru/imglib/", ""); 
          line = CSVLineBuilder(Values);
          swr.WriteLine(line);

          foreach (string gallery in item.gallery)
          {
            Values = new string[attrArray.Count()];
            Values[0] = item.article.ToString();
            Values[1] = "A";
            Values[2] = gallery.Replace("http://hobbycenter.ru/imglib/", "");
          }
        }
      }
      MessageBox.Show("Данные для выгрузки фото сохранены в файл успешно");
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
        cell = cell.Replace("&", "");
        //        cell = cell.Replace(";", "\";\"");
        if (i < array.Length - 1)
          cell += ";";
        result += cell;
      }
      return result;
    }

    private void InitialiseLib()
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.AddExtension = true;
      dialog.DefaultExt = "bin";
      dialog.Filter = "bin files (*.bin)|*.bin|All files|*.*";
      switch (dialog.ShowDialog())
      {
        case DialogResult.OK:
          if (dialog.FileName.Length < 8)
          {
            MessageBox.Show("Укажите нормальное имя файла");
            return;
          }
          library = CDatafileInterface.ReadFromFile(dialog.FileName);
          break;
      }
    }
  }
}
