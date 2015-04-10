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
    Queue<ProductProp> UnloadedQueue = new Queue<ProductProp>();
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
      foreach (ProductProp item in library.ProductProps)
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

    }
    private void LoadImagesFunction()
    {
      WebClient Client = new WebClient();
      ProductProp currentTarget = null;
      while (UnloadedQueue.Count > 0)
      {
        lock (QueueLock)
          if (UnloadedQueue.Count == 0) return;
          else
            currentTarget = UnloadedQueue.Dequeue();
        try
        {
          Client.DownloadFile(SiteUrl + currentTarget.images_title, selectedDir + currentTarget.images_title);
        }
        catch
        {
          continue;
        }
      }

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
