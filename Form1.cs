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
        ToolDictionaryLoader toolLoader;
        public Form1()
        {            
            InitializeComponent();

            BtnSettings.Click += ShowSettings;
            BtnSaveSettings.Click += SaveSettings;
            BtnDeclineChanges.Click += DeclineChanges;
            BtnOpenRecipe.Click += OpenFileDialog;

            Notify += (m) => processControl1.WriteLine(m);

            settingsControl1.Notify += Notify;

            FormClosing += Form1_FormClosing;

            loadSettings();
            loadTools(); 
        }
        private void OpenFileDialog(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Выберите файл рецепта",

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
                loadTools();
                ParseFile(openFileDialog1.FileName);
            }
        }
        void ParseFile(string filename)
        {
            Notify?.Invoke("***********************************************************");
            RecipeParser parser = new RecipeParser(toolLoader.Tools);
            parser.Notify += Notify;
            RecipeData recipe = parser.Parse(filename);

            BtnOpenRecipe.Enabled = false;
            Thread thread = new Thread(() => loadToPlc(recipe));
            thread.IsBackground = true;
            thread.Start();

            Notify?.Invoke("***********************************************************");
        }


        void loadToPlc(RecipeData recipe)
        {
            try
            {
                PLCDataLoader plcLoader = new PLCDataLoader(settingsLoader.Settings.ArrayDim1, settingsLoader.Settings.ArrayDim2);
                plcLoader.Notify += Notify;
                plcLoader.LoadRecipe(recipe);
            }
            catch (Exception e)
            {
                Notify?.Invoke(e.Message);
            }
            Invoke(new Action(() =>
                {
                    BtnOpenRecipe.Enabled = true;
                }));
        }          

        public Action<string> Notify { get; set; }
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
        void loadTools()
        {
            toolLoader = new ToolDictionaryLoader();
            toolLoader.Notify += Notify;
            try
            {
                toolLoader.Load();
            }
            catch (Exception e)
            {
                Notify?.Invoke(e.Message);
            }
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
            BtnSettings.Visible = false;
            BtnSaveSettings.Visible = true;
            BtnDeclineChanges.Visible = true;

            settingsControl1.Settings = settingsLoader.Settings;
        }
        private void HideSettings()
        {
            settingsControl1.Visible = false;
            BtnSettings.Visible = true;
            BtnSaveSettings.Visible = false;
            BtnDeclineChanges.Visible = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingsLoader.SaveFormDim(Height, Width, Location, Environment.CurrentDirectory);
        }
    }
}
