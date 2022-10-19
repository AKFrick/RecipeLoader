namespace RecipeLoader.View
{
    partial class ComponentGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IsOnLoadQueue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FrameSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Len = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DownloadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 647);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsOnLoadQueue,
            this.FileName,
            this.FrameSet,
            this.Number,
            this.Len,
            this.Direction,
            this.DownloadTime});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(897, 647);
            this.dataGridView1.TabIndex = 0;
            // 
            // IsOnLoadQueue
            // 
            this.IsOnLoadQueue.HeaderText = "Загрузить?";
            this.IsOnLoadQueue.MinimumWidth = 6;
            this.IsOnLoadQueue.Name = "IsOnLoadQueue";
            this.IsOnLoadQueue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsOnLoadQueue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsOnLoadQueue.Width = 125;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "Файл";
            this.FileName.MinimumWidth = 6;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 200;
            // 
            // FrameSet
            // 
            this.FrameSet.HeaderText = "Сборка";
            this.FrameSet.MinimumWidth = 6;
            this.FrameSet.Name = "FrameSet";
            this.FrameSet.ReadOnly = true;
            this.FrameSet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FrameSet.Width = 200;
            // 
            // Number
            // 
            this.Number.HeaderText = "Номер";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Number.Width = 125;
            // 
            // Len
            // 
            this.Len.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Len.HeaderText = "Длина";
            this.Len.MinimumWidth = 6;
            this.Len.Name = "Len";
            this.Len.ReadOnly = true;
            this.Len.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Len.Width = 150;
            // 
            // Direction
            // 
            this.Direction.HeaderText = "Направление";
            this.Direction.MinimumWidth = 6;
            this.Direction.Name = "Direction";
            this.Direction.ReadOnly = true;
            this.Direction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Direction.Width = 125;
            // 
            // DownloadTime
            // 
            this.DownloadTime.HeaderText = "Время загрузки";
            this.DownloadTime.MinimumWidth = 6;
            this.DownloadTime.Name = "DownloadTime";
            this.DownloadTime.ReadOnly = true;
            this.DownloadTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DownloadTime.Width = 175;
            // 
            // ComponentGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComponentGrid";
            this.Size = new System.Drawing.Size(897, 647);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOnLoadQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Len;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn DownloadTime;
    }
}
