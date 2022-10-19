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
    public partial class ComponentGrid : UserControl, INotifiable
    {
        public event Action<string> Notify;
        public ComponentGrid()
        {
            InitializeComponent();
            initializeGrid();            
        }
        IBindingList gridComponents { get; set; }
        void initializeGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            gridComponents = new BindingList<Component>();                                  

            dataGridView1.DataSource = gridComponents;
            dataGridView1.Columns["IsOnLoadQueue"].DataPropertyName = nameof(Component.IsOnLoadQueue);
            dataGridView1.Columns["Len"].DataPropertyName = nameof(Component.Len);
            dataGridView1.Columns["DownloadTime"].DataPropertyName = nameof(Component.DownloadTime);
            dataGridView1.Columns["FileName"].DataPropertyName = nameof(Component.FileName);
            dataGridView1.Columns["Number"].DataPropertyName = nameof(Component.Number);
            dataGridView1.Columns["FrameSet"].DataPropertyName = nameof(Component.FrameSet);
            dataGridView1.Columns["Direction"].DataPropertyName = nameof(Component.Direction);            
        }
        public void AddComponents(List<Component> components)
        {
            foreach (Component component in components)
                gridComponents.Add(component);
            dataGridView1.Refresh();
        }
        public void ClearGrid()
        {            
            gridComponents.Clear();            
            dataGridView1.Refresh();
            Notify?.Invoke("Список компонентов очищен");
        }
        public void RemoveSelectedRows()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                dataGridView1.Rows.Remove(row);
            dataGridView1.Refresh();
        } 
        public void CheckSelectedRows()
        {
            if (!(dataGridView1.SelectedRows.Count == 0))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {                    
                    ((Component)row.DataBoundItem).IsOnLoadQueue = true;
                }
            }
            dataGridView1.Refresh();
        }
        public void UncheckSelectedRows()
        {
            if (!(dataGridView1.SelectedRows.Count == 0))
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {                    
                    ((Component)row.DataBoundItem).IsOnLoadQueue = false;
                }
            }
            dataGridView1.Refresh();
        }
        Component componentToLoad;
        DataGridViewRow rowToLoad;
        public Component GetNextComponent()
        {
            if(dataGridView1.InvokeRequired)
            {
                return (Component)dataGridView1.Invoke(
                    new Func<Component>(() => getNextComponent())
                    );
            }
            else
                return getNextComponent();
        }
        Component getNextComponent()
        {
            if (componentToLoad != null && rowToLoad != null)
            {
                componentToLoad.IsOnLoadQueue = false;
                componentToLoad.DownloadTime = DateTime.Now;
                rowToLoad.DefaultCellStyle.BackColor = Color.White;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (((Component)row.DataBoundItem).IsOnLoadQueue)
                {
                    row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    rowToLoad = row;
                    componentToLoad = (Component)row.DataBoundItem;
                    return (Component)((Component)row.DataBoundItem).Clone();
                }
            }
            //return new Component() { Number = 1000 };
            throw new Exception("Нет компонентов для загрузки");
        }        
    }
}