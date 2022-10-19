using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using S7.Net;

namespace RecipeLoader
{
    public partial class Form1 : Form, INotifiable
    {
        AppSettingsLoader settingsLoader;
        ToolDictionary tools;
        System.Threading.Timer plcLoadTimer;
        public Form1()
        {            
            InitializeComponent();

            BtnSettings.Click += ShowSettings;
            BtnSaveSettings.Click += SaveSettings;
            BtnDeclineChanges.Click += DeclineChanges;
            BtnOpenRecipe.Click += OpenFileDialog;
            BtnClearGrid.Click += (s, e) =>  componentGrid1.ClearGrid();
            BtnRemoveRows.Click += (s, e) => componentGrid1.RemoveSelectedRows(); 
            BtnCheckToLoad.Click += (s,e) => componentGrid1.CheckSelectedRows();
            BtnUncheckToLoad.Click += (s, e) => componentGrid1.UncheckSelectedRows();

            Notify += (m) => processControl1.WriteLine(m);

            settingsControl1.Notify += Notify;
            componentGrid1.Notify += Notify;

            FormClosing += Form1_FormClosing;

            loadSettings();
            TestTimer();
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
        void ThreadLoadToPLC()
        {
            BtnOpenRecipe.Enabled = false;
           // Thread thread = new Thread(() => loadToPlc(recipe));
           // thread.IsBackground = true;
           // thread.Start();
        }
        void TestTimer()
        {
            var autoEvent = new AutoResetEvent(false);
            plcLoadTimer = new System.Threading.Timer(GetComp, autoEvent, 2000, 250);            
        }
        public void GetComp(Object stateInfo)
        {
            try
            {
                Notify?.Invoke(componentGrid1.GetNextComponent().Number.ToString());
            }
            catch (Exception ex)
            {
                Notify?.Invoke(ex.Message);
            }
        }

        void loadToPlc(List<Component> recipe)
        {
            try
            {
                PLCDataLoader recipeLoader = new PLCDataLoader(settingsLoader.Settings.Plc);
                recipeLoader.Notify += Notify;
                recipeLoader.LoadRecipe(recipe);
            }
            catch (Exception e)
            {
                Notify?.Invoke(e.Message);
            }
            finally
            {
                Invoke(new Action(() =>
                    {
                        BtnOpenRecipe.Enabled = true;
                        Notify?.Invoke("***********************************************************");
                    }));
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
    }
}
