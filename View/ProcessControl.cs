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
        public int MaxLines { get; set; } = 200;
        public ProcessControl()
        {
            InitializeComponent(); 

        }

        public void WriteLineTS(string line)
        {
            if (tbOutput.InvokeRequired)
            {
                Action action = () => WriteLine(line);
                tbOutput.Invoke(action);
            }
            else
                WriteLine(line);                      
        }
        void WriteLine(string line)
        {     
            if(tbOutput.Lines.Length > MaxLines * 2)
            {
                var lines = tbOutput.Lines;
                var newLines = lines.Skip(MaxLines);
                tbOutput.Lines = newLines.ToArray();
            }
            tbOutput.AppendText($"{DateTime.Now}: {line} \r\n");
            tbOutput.ScrollToCaret();
        }
    }
}
