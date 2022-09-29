using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecipeLoader.View
{
    public partial class ComponentGrid : UserControl
    {
        public ComponentGrid()
        {
            InitializeComponent();
            initializeGrid();
            
        }
        void initializeGrid()
        {
            IList<MyClass> mylist = new List<MyClass>();                                  
            for (int i = 0; i < 100; i++)
            {
                mylist.Add(new MyClass() { Name = "Vasya", Description = "Chelovek" });
            }

            dataGridView1.DataSource = mylist;
        }
        public class MyClass
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
