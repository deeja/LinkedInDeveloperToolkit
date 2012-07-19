using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinkedIn.Samples.WindowsForms
{
  public partial class PinDialog : Form
  {
    public string Pin
    {
      get
      {
        return this.pinTextBox.Text;
      }
    }

    public PinDialog()
    {
      InitializeComponent();
    }
  }
}
