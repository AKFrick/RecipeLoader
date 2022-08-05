namespace RecipeLoader
{
    partial class SettingsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbArrayDim2 = new System.Windows.Forms.TextBox();
            this.tbArrayDim1 = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbEnableSystemMsg = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "НАСТРОЙКИ";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.cbEnableSystemMsg);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.tbIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 280);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbArrayDim2);
            this.groupBox1.Controls.Add(this.tbArrayDim1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(19, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 176);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки массива данных";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(258, 56);
            this.label6.TabIndex = 1;
            this.label6.Text = "Максимум инструментов \r\nна одну деталь";
            // 
            // tbArrayDim2
            // 
            this.tbArrayDim2.Location = new System.Drawing.Point(333, 116);
            this.tbArrayDim2.Name = "tbArrayDim2";
            this.tbArrayDim2.Size = new System.Drawing.Size(63, 34);
            this.tbArrayDim2.TabIndex = 2;
            // 
            // tbArrayDim1
            // 
            this.tbArrayDim1.Location = new System.Drawing.Point(333, 53);
            this.tbArrayDim1.Name = "tbArrayDim1";
            this.tbArrayDim1.Size = new System.Drawing.Size(63, 34);
            this.tbArrayDim1.TabIndex = 2;
            // 
            // tbIP
            // 
            this.tbIP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbIP.Location = new System.Drawing.Point(176, 35);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(235, 34);
            this.tbIP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Адрес ПЛК:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "Максимум строк в рецепте";
            // 
            // cbEnableSystemMsg
            // 
            this.cbEnableSystemMsg.AutoSize = true;
            this.cbEnableSystemMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbEnableSystemMsg.Location = new System.Drawing.Point(442, 27);
            this.cbEnableSystemMsg.Name = "cbEnableSystemMsg";
            this.cbEnableSystemMsg.Size = new System.Drawing.Size(204, 54);
            this.cbEnableSystemMsg.TabIndex = 4;
            this.cbEnableSystemMsg.Text = "Вывод системных\r\nсообщений";
            this.cbEnableSystemMsg.UseVisualStyleBackColor = true;
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(704, 280);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbArrayDim2;
        private System.Windows.Forms.TextBox tbArrayDim1;
        private System.Windows.Forms.CheckBox cbEnableSystemMsg;
        private System.Windows.Forms.Label label7;
    }
}
