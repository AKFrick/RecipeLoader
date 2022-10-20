using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace RecipeLoader
{
    public partial class Form1 : Form, INotifiable
    {
        AppSettingsLoader settingsLoader;
        PlcLoader plcLoader;
        public Form1()
        {            
            InitializeComponent();            

            BtnSettings.Click += ShowSettings;
            BtnSaveSettings.Click += SaveSettings;
            BtnDeclineChanges.Click += DeclineChanges;
            BtnOpenRecipe.Click += OpenFileDialog;
            BtnClearGrid.Click += ClearGrid;
            BtnRemoveRows.Click += RemoveSelectedRows;
            BtnCheckToLoad.Click += (s,e) => componentGrid1.CheckSelectedRows();
            BtnUncheckToLoad.Click += (s, e) => componentGrid1.UncheckSelectedRows();

            Notify += (m) => processControl1.WriteLineTS(m);

            settingsControl1.Notify += Notify;
            componentGrid1.Notify += Notify;

            FormClosing += Form1_FormClosing;

            loadSettings();
            processControl1.MaxLines = settingsLoader.Settings.OutputMaxLines;

            plcLoader = new PlcLoader(settingsLoader.Settings.Plc, componentGrid1.GetNextComponentTS, componentGrid1.LoadSucceedTS);
            plcLoader.Notify += Notify;
            plcLoader.StartLoader();
        }
        private void OpenFileDialog(object sender, EventArgs e)
        {             
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Выберите файл рецепта",

                Multiselect = true,
                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = settingsLoader.Settings.RecipeSearchFilter,
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                Notify?.Invoke("***********************************************************");
                try
                {
                    ToolDictionary tools = loadTools();
                    RecipeParser parser = new RecipeParser(tools);
                    parser.Notify += Notify;
                    List<Component> recipe = parser.ParseFiles(openFileDialog1.FileNames);
                    componentGrid1.AddComponents(recipe);
                }
                catch (Exception ex)
                {
                    Notify?.Invoke(ex.Message);
                }
            }
        }

        public event Action<string> Notify;
        void loadSettings()
        {
            settingsLoader = new AppSettingsLoader();
            settingsLoader.Notify += Notify;
            settingsLoader.SettingsChanged += (s) => settingsControl1.Settings = s;
            try
            {
                settingsLoader.Load();
                if (settingsLoader.Settings.AppDirectory == Environment.CurrentDirectory)
                {
                    StartPosition = FormStartPosition.Manual;
                    Height = settingsLoader.Settings.FormHeight;
                    Width = settingsLoader.Settings.FormWidth;
                    Location = settingsLoader.Settings.FormLocation;
                }
            }
            catch (Exception e)
            {
                Notify?.Invoke(e.Message);                
            }
        }
        ToolDictionary loadTools()
        {            
            ToolDictionaryLoader loader = new ToolDictionaryLoader();
            loader.Notify += Notify;
            return loader.Load();                
        }
        private void DeclineChanges(object sender, EventArgs e)
        {
            HideSettings();
        }
        private void SaveSettings(object sender, EventArgs e)
        {
            try
            {
                settingsControl1.Save();
                settingsLoader.Save(settingsControl1.Settings);
                HideSettings();
            }
            catch (Exception ex)
            {
                Notify?.Invoke(ex.Message);
            }

        }
        private void ShowSettings(object sender, EventArgs e)
        {           
            settingsControl1.Visible = true;
            componentGrid1.Visible = false;
            BtnSettings.Visible = false;
            BtnClearGrid.Visible = false;
            BtnRemoveRows.Visible = false;
            BtnSaveSettings.Visible = true;
            BtnDeclineChanges.Visible = true;

            settingsControl1.Settings = settingsLoader.Settings;
        }
        private void HideSettings()
        {
            settingsControl1.Visible = false;
            componentGrid1.Visible = true;
            BtnSettings.Visible = true;
            BtnClearGrid.Visible = true;
            BtnRemoveRows.Visible = true;
            BtnSaveSettings.Visible = false;
            BtnDeclineChanges.Visible = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingsLoader.SaveFormDim(Height, Width, Location, Environment.CurrentDirectory);
        }

        private void RemoveSelectedRows(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Удалить выделенные строки?",
                                                "",
                                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                componentGrid1.RemoveSelectedRows();
            }
        }
        private void ClearGrid(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Очистить таблицу?",
                                    "",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                componentGrid1.ClearGrid();
            }
        }
    }
}
