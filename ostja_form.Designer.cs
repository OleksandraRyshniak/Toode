namespace epood_toode
{
    partial class ostja_form
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lisa_toode_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toode_lbl = new System.Windows.Forms.Label();
            this.ostukorv = new System.Windows.Forms.Label();
            this.maksma = new System.Windows.Forms.Button();
            this.kust_1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(459, 401);
            this.dataGridView1.TabIndex = 0;
            // 
            // lisa_toode_btn
            // 
            this.lisa_toode_btn.Location = new System.Drawing.Point(102, 433);
            this.lisa_toode_btn.Name = "lisa_toode_btn";
            this.lisa_toode_btn.Size = new System.Drawing.Size(250, 30);
            this.lisa_toode_btn.TabIndex = 1;
            this.lisa_toode_btn.Text = "Lisa toode";
            this.lisa_toode_btn.UseVisualStyleBackColor = true;
            this.lisa_toode_btn.Click += new System.EventHandler(this.lisa_toode_btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.kust_1);
            this.panel1.Controls.Add(this.toode_lbl);
            this.panel1.Controls.Add(this.ostukorv);
            this.panel1.Location = new System.Drawing.Point(541, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 341);
            this.panel1.TabIndex = 2;
            // 
            // toode_lbl
            // 
            this.toode_lbl.Location = new System.Drawing.Point(3, 64);
            this.toode_lbl.Name = "toode_lbl";
            this.toode_lbl.Size = new System.Drawing.Size(216, 23);
            this.toode_lbl.TabIndex = 0;
            // 
            // ostukorv
            // 
            this.ostukorv.AutoSize = true;
            this.ostukorv.Location = new System.Drawing.Point(112, 18);
            this.ostukorv.Name = "ostukorv";
            this.ostukorv.Size = new System.Drawing.Size(50, 13);
            this.ostukorv.TabIndex = 0;
            this.ostukorv.Text = "Ostukorv";
            // 
            // maksma
            // 
            this.maksma.Location = new System.Drawing.Point(606, 388);
            this.maksma.Name = "maksma";
            this.maksma.Size = new System.Drawing.Size(190, 45);
            this.maksma.TabIndex = 3;
            this.maksma.Text = "Maksma";
            this.maksma.UseVisualStyleBackColor = true;
            // 
            // kust_1
            // 
            this.kust_1.Location = new System.Drawing.Point(266, 64);
            this.kust_1.Name = "kust_1";
            this.kust_1.Size = new System.Drawing.Size(25, 26);
            this.kust_1.TabIndex = 1;
            this.kust_1.Text = "🗑️";
            this.kust_1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(229, 69);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // ostja_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 546);
            this.Controls.Add(this.maksma);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lisa_toode_btn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ostja_form";
            this.Text = "Ostja";
            this.Load += new System.EventHandler(this.muuja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button lisa_toode_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ostukorv;
        private System.Windows.Forms.Button maksma;
        private System.Windows.Forms.Label toode_lbl;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button kust_1;
    }
}