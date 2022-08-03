using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecipeLoader
{
    public partial class ProcessControl : UserControl
    {
        int maxLines = 10;
        public ProcessControl()
        {
            InitializeComponent();                  
        }
        public void WriteLine(string line)
        {
            tbOutput.AppendText($"{DateTime.Now}: {line} \r\n");
            tbOutput.ScrollToCaret();
        }
    }
}
