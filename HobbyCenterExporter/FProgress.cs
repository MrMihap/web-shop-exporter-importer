using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HobbyCenterExporter
{
  public partial class FProgress : Form
  {
    public int Loaded
    {
      get
      {
        return 0;
      }
      set
      {
        loadedTB.Text = value.ToString();
        this.Refresh();
      }
    }

    public int Passed
    {
      get
      {
        return 0;
      }
      set
      {
        passedTB.Text = value.ToString();
        this.Refresh();
      }
    }

    public FProgress()
    {
      InitializeComponent();
    }

    private void FProgress_Load(object sender, EventArgs e)
    {

    }
  }
}
