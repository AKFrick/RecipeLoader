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
        IList<LoadQueueComponent> comp { get; set; }
        void initializeGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            comp = new List<LoadQueueComponent>();                                  
            for (int i = 0; i < 100; i++)
            {
                comp.Add(new LoadQueueComponent() { IsOnLoadQueue = true, Len = 55, DownloadTime = DateTime.Now }) ;
            }

            dataGridView1.DataSource = comp;
            dataGridView1.Columns["IsOnLoadQueue"].DataPropertyName = nameof(LoadQueueComponent.IsOnLoadQueue);
            dataGridView1.Columns["Len"].DataPropertyName = nameof(Component.Len);
            dataGridView1.Columns["DownloadTime"].DataPropertyName = nameof(LoadQueueComponent.DownloadTime);
            dataGridView1.Columns["FileName"].DataPropertyName = nameof(LoadQueueComponent.File);
        }
        public bool getState()
        {
            return comp[0].IsOnLoadQueue;
        }
        public string Description { get; set; }        
        public class LoadQueueComponent : Component
        {
            public bool IsOnLoadQueue { get; set; }
            public DateTime DownloadTime { get; set; }
        }
    }
}
