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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.LeftBar = new System.Windows.Forms.Panel();
            this.BtnSaveSettings = new System.Windows.Forms.Button();
            this.BtnOpenRecipe = new System.Windows.Forms.Button();
            this.BtnDeclineChanges = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.processControl1 = new RecipeLoader.ProcessControl();
            this.settingsControl1 = new RecipeLoader.SettingsControl();
            this.MainLayout.SuspendLayout();
            this.LeftBar.SuspendLayout();
            this.Content.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.MainLayout.Controls.Add(this.LeftBar, 1, 0);
            this.MainLayout.Controls.Add(this.Content, 0, 0);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Margin = new System.Windows.Forms.Padding(4);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 1;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 569F));
            this.MainLayout.Size = new System.Drawing.Size(1023, 659);
            this.MainLayout.TabIndex = 0;
            // 
            // LeftBar
            // 
            this.LeftBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.LeftBar.Controls.Add(this.BtnSaveSettings);
            this.LeftBar.Controls.Add(this.BtnOpenRecipe);
            this.LeftBar.Controls.Add(this.BtnDeclineChanges);
            this.LeftBar.Controls.Add(this.BtnSettings);
            this.LeftBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftBar.Location = new System.Drawing.Point(777, 4);
            this.LeftBar.Margin = new System.Windows.Forms.Padding(4);
            this.LeftBar.Name = "LeftBar";
            this.LeftBar.Size = new System.Drawing.Size(242, 651);
            this.LeftBar.TabIndex = 0;
            // 
            // BtnSaveSettings
            // 
            this.BtnSaveSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSaveSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSaveSettings.Location = new System.Drawing.Point(0, 408);
            this.BtnSaveSettings.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSaveSettings.Name = "BtnSaveSettings";
            this.BtnSaveSettings.Size = new System.Drawing.Size(242, 81);
            this.BtnSaveSettings.TabIndex = 2;
            this.BtnSaveSettings.Text = "Сохранить";
            this.BtnSaveSettings.UseVisualStyleBackColor = true;
            this.BtnSaveSettings.Visible = false;
            // 
            // BtnOpenRecipe
            // 
            this.BtnOpenRecipe.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnOpenRecipe.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOpenRecipe.Location = new System.Drawing.Point(0, 0);
            this.BtnOpenRecipe.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOpenRecipe.Name = "BtnOpenRecipe";
            this.BtnOpenRecipe.Size = new System.Drawing.Size(242, 81);
            this.BtnOpenRecipe.TabIndex = 1;
            this.BtnOpenRecipe.Text = "Загрузить рецепт";
            this.BtnOpenRecipe.UseVisualStyleBackColor = true;
            // 
            // BtnDeclineChanges
            // 
            this.BtnDeclineChanges.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnDeclineChanges.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnDeclineChanges.Location = new System.Drawing.Point(0, 489);
            this.BtnDeclineChanges.Margin = new System.Windows.Forms.Padding(0);
            this.BtnDeclineChanges.Name = "BtnDeclineChanges";
            this.BtnDeclineChanges.Size = new System.Drawing.Size(242, 81);
            this.BtnDeclineChanges.TabIndex = 0;
            this.BtnDeclineChanges.Text = "Не сохранять";
            this.BtnDeclineChanges.UseVisualStyleBackColor = true;
            this.BtnDeclineChanges.Visible = false;
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSettings.Location = new System.Drawing.Point(0, 570);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(242, 81);
            this.BtnSettings.TabIndex = 0;
            this.BtnSettings.Text = "Настройки";
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
            this.Content.Size = new System.Drawing.Size(765, 651);
            this.Content.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.processControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.settingsControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(763, 649);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // processControl1
            // 
            this.processControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processControl1.Location = new System.Drawing.Point(4, 527);
            this.processControl1.Margin = new System.Windows.Forms.Padding(4);
            this.processControl1.Name = "processControl1";
            this.processControl1.Size = new System.Drawing.Size(755, 118);
            this.processControl1.TabIndex = 1;
            // 
            // settingsControl1
            // 
            this.settingsControl1.AutoSize = true;
            this.settingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsControl1.Location = new System.Drawing.Point(4, 4);
            this.settingsControl1.Margin = new System.Windows.Forms.Padding(4);
            this.settingsControl1.Name = "settingsControl1";
            this.settingsControl1.Notify = null;
            this.settingsControl1.Settings = null;
            this.settingsControl1.Size = new System.Drawing.Size(755, 515);
            this.settingsControl1.TabIndex = 0;
            this.settingsControl1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 659);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.Panel LeftBar;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Panel Content;
        private System.Windows.Forms.Button BtnOpenRecipe;
        private SettingsControl settingsControl1;
        private System.Windows.Forms.Button BtnSaveSettings;
        private System.Windows.Forms.Button BtnDeclineChanges;
        private ProcessControl processControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

