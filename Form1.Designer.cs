namespace RecipeLoader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.LeftBar = new System.Windows.Forms.Panel();
            this.BtnUncheckToLoad = new System.Windows.Forms.Button();
            this.BtnCheckToLoad = new System.Windows.Forms.Button();
            this.BtnRemoveRows = new System.Windows.Forms.Button();
            this.BtnClearGrid = new System.Windows.Forms.Button();
            this.BtnSaveSettings = new System.Windows.Forms.Button();
            this.BtnOpenRecipe = new System.Windows.Forms.Button();
            this.BtnDeclineChanges = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.processControl1 = new RecipeLoader.ProcessControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.componentGrid1 = new RecipeLoader.View.ComponentGrid();
            this.settingsControl1 = new RecipeLoader.SettingsControl();
            this.MainLayout.SuspendLayout();
            this.LeftBar.SuspendLayout();
            this.Content.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.MainLayout.Controls.Add(this.LeftBar, 1, 0);
            this.MainLayout.Controls.Add(this.Content, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(4);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.Size = new System.Drawing.Size(873, 674);
            this.MainLayout.TabIndex = 0;
            // 
            // LeftBar
            // 
            this.LeftBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.LeftBar.Controls.Add(this.BtnUncheckToLoad);
            this.LeftBar.Controls.Add(this.BtnCheckToLoad);
            this.LeftBar.Controls.Add(this.BtnRemoveRows);
            this.LeftBar.Controls.Add(this.BtnClearGrid);
            this.LeftBar.Controls.Add(this.BtnSaveSettings);
            this.LeftBar.Controls.Add(this.BtnOpenRecipe);
            this.LeftBar.Controls.Add(this.BtnDeclineChanges);
            this.LeftBar.Controls.Add(this.BtnSettings);
            this.LeftBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftBar.Location = new System.Drawing.Point(657, 4);
            this.LeftBar.Margin = new System.Windows.Forms.Padding(4);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(212, 666);
            this.LeftBar.TabIndex = 0;
            // 
            // BtnUncheckToLoad
            // 
            this.BtnUncheckToLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnUncheckToLoad.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnUncheckToLoad.Image = global::RecipeLoader.Properties.Resources.UncheckPic;
            this.BtnUncheckToLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUncheckToLoad.Location = new System.Drawing.Point(0, 162);
            this.BtnUncheckToLoad.Margin = new System.Windows.Forms.Padding(4);
            this.BtnUncheckToLoad.Name = "BtnUncheckToLoad";
            this.BtnUncheckToLoad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnUncheckToLoad.Size = new System.Drawing.Size(212, 81);
            this.BtnUncheckToLoad.TabIndex = 5;
            this.BtnUncheckToLoad.Text = "Снять";
            this.BtnUncheckToLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUncheckToLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUncheckToLoad.UseVisualStyleBackColor = true;
            // 
            // BtnCheckToLoad
            // 
            this.BtnCheckToLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCheckToLoad.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCheckToLoad.Image = global::RecipeLoader.Properties.Resources.CheckPic;
            this.BtnCheckToLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCheckToLoad.Location = new System.Drawing.Point(0, 81);
            this.BtnCheckToLoad.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCheckToLoad.Name = "BtnCheckToLoad";
            this.BtnCheckToLoad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnCheckToLoad.Size = new System.Drawing.Size(212, 81);
            this.BtnCheckToLoad.TabIndex = 6;
            this.BtnCheckToLoad.Text = "Отметить";
            this.BtnCheckToLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCheckToLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCheckToLoad.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveRows
            // 
            this.BtnRemoveRows.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnRemoveRows.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnRemoveRows.Image = global::RecipeLoader.Properties.Resources.RemoveRowPic;
            this.BtnRemoveRows.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRemoveRows.Location = new System.Drawing.Point(0, 261);
            this.BtnRemoveRows.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRemoveRows.Name = "BtnRemoveRows";
            this.BtnRemoveRows.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnRemoveRows.Size = new System.Drawing.Size(212, 81);
            this.BtnRemoveRows.TabIndex = 4;
            this.BtnRemoveRows.Text = "Удалить строки";
            this.BtnRemoveRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRemoveRows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRemoveRows.UseVisualStyleBackColor = true;
            // 
            // BtnClearGrid
            // 
            this.BtnClearGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClearGrid.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnClearGrid.Image = global::RecipeLoader.Properties.Resources.ClearPic;
            this.BtnClearGrid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClearGrid.Location = new System.Drawing.Point(0, 342);
            this.BtnClearGrid.Margin = new System.Windows.Forms.Padding(4);
            this.BtnClearGrid.Name = "BtnClearGrid";
            this.BtnClearGrid.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnClearGrid.Size = new System.Drawing.Size(212, 81);
            this.BtnClearGrid.TabIndex = 3;
            this.BtnClearGrid.Text = "Очистить таблицу";
            this.BtnClearGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClearGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClearGrid.UseVisualStyleBackColor = true;
            // 
            // BtnSaveSettings
            // 
            this.BtnSaveSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSaveSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSaveSettings.Image = global::RecipeLoader.Properties.Resources.SavePic;
            this.BtnSaveSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveSettings.Location = new System.Drawing.Point(0, 423);
            this.BtnSaveSettings.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSaveSettings.Name = "BtnSaveSettings";
            this.BtnSaveSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnSaveSettings.Size = new System.Drawing.Size(212, 81);
            this.BtnSaveSettings.TabIndex = 2;
            this.BtnSaveSettings.Text = "Сохранить";
            this.BtnSaveSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSaveSettings.UseVisualStyleBackColor = true;
            this.BtnSaveSettings.Visible = false;
            // 
            // BtnOpenRecipe
            // 
            this.BtnOpenRecipe.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOpenRecipe.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOpenRecipe.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenRecipe.Image")));
            this.BtnOpenRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpenRecipe.Location = new System.Drawing.Point(0, 0);
            this.BtnOpenRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOpenRecipe.Name = "BtnOpenRecipe";
            this.BtnOpenRecipe.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnOpenRecipe.Size = new System.Drawing.Size(212, 81);
            this.BtnOpenRecipe.TabIndex = 1;
            this.BtnOpenRecipe.Text = "Добавить файл";
            this.BtnOpenRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOpenRecipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnOpenRecipe.UseVisualStyleBackColor = true;
            // 
            // BtnDeclineChanges
            // 
            this.BtnDeclineChanges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnDeclineChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnDeclineChanges.Image = global::RecipeLoader.Properties.Resources.DeclinePi;
            this.BtnDeclineChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeclineChanges.Location = new System.Drawing.Point(0, 504);
            this.BtnDeclineChanges.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDeclineChanges.Name = "BtnDeclineChanges";
            this.BtnDeclineChanges.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnDeclineChanges.Size = new System.Drawing.Size(212, 81);
            this.BtnDeclineChanges.TabIndex = 0;
            this.BtnDeclineChanges.Text = "Отменить";
            this.BtnDeclineChanges.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeclineChanges.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeclineChanges.UseVisualStyleBackColor = true;
            this.BtnDeclineChanges.Visible = false;
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSettings.Image = global::RecipeLoader.Properties.Resources.SettingsPic;
            this.BtnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.Location = new System.Drawing.Point(0, 585);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BtnSettings.Size = new System.Drawing.Size(212, 81);
            this.BtnSettings.TabIndex = 0;
            this.BtnSettings.Text = "Настройки";
            this.BtnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSettings.UseVisualStyleBackColor = true;
            // 
            // Content
            // 
            this.Content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Content.Controls.Add(this.tableLayoutPanel1);
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(4, 4);
            this.Content.Margin = new System.Windows.Forms.Padding(4);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(645, 666);
            this.Content.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.processControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(643, 664);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // processControl1
            // 
            this.processControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processControl1.Location = new System.Drawing.Point(4, 468);
            this.processControl1.Margin = new System.Windows.Forms.Padding(4);
            this.processControl1.Name = "processControl1";
            this.processControl1.Size = new System.Drawing.Size(635, 192);
            this.processControl1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.componentGrid1);
            this.panel1.Controls.Add(this.settingsControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 458);
            this.panel1.TabIndex = 2;
            // 
            // componentGrid1
            // 
            this.componentGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentGrid1.Location = new System.Drawing.Point(0, 0);
            this.componentGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.componentGrid1.Name = "componentGrid1";
            this.componentGrid1.Size = new System.Drawing.Size(637, 458);
            this.componentGrid1.TabIndex = 1;
            // 
            // settingsControl1
            // 
            this.settingsControl1.AutoSize = true;
            this.settingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsControl1.Location = new System.Drawing.Point(0, 0);
            this.settingsControl1.Name = "settingsControl1";
            this.settingsControl1.Settings = null;
            this.settingsControl1.Size = new System.Drawing.Size(637, 458);
            this.settingsControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 674);
            this.Controls.Add(this.MainLayout);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Загрузка рецептов в ПЛК";
            this.MainLayout.ResumeLayout(false);
            this.LeftBar.ResumeLayout(false);
            this.Content.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Panel LeftBar;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Button BtnOpenRecipe;
        private System.Windows.Forms.Button BtnSaveSettings;
        private System.Windows.Forms.Button BtnDeclineChanges;
        private ProcessControl processControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private View.ComponentGrid componentGrid1;
        private SettingsControl settingsControl1;
        private System.Windows.Forms.Button BtnClearGrid;
        private System.Windows.Forms.Button BtnRemoveRows;
        private System.Windows.Forms.Button BtnCheckToLoad;
        private System.Windows.Forms.Button BtnUncheckToLoad;
    }
}

