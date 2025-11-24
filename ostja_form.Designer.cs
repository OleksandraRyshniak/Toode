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
            this.maksma = new System.Windows.Forms.Button();
            this.kust_1 = new System.Windows.Forms.Button();
            this.ostukorv_lbl = new System.Windows.Forms.Label();
            this.tooded = new System.Windows.Forms.Label();
            this.list_box = new System.Windows.Forms.ListBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.total_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(631, 100);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(355, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // lisa_toode_btn
            // 
            this.lisa_toode_btn.Location = new System.Drawing.Point(208, 492);
            this.lisa_toode_btn.Margin = new System.Windows.Forms.Padding(4);
            this.lisa_toode_btn.Name = "lisa_toode_btn";
            this.lisa_toode_btn.Size = new System.Drawing.Size(333, 37);
            this.lisa_toode_btn.TabIndex = 1;
            this.lisa_toode_btn.Text = "Lisa toode";
            this.lisa_toode_btn.UseVisualStyleBackColor = true;
            this.lisa_toode_btn.Click += new System.EventHandler(this.lisa_toode_btn_Click);
            // 
            // maksma
            // 
            this.maksma.Location = new System.Drawing.Point(753, 534);
            this.maksma.Margin = new System.Windows.Forms.Padding(4);
            this.maksma.Name = "maksma";
            this.maksma.Size = new System.Drawing.Size(116, 38);
            this.maksma.TabIndex = 3;
            this.maksma.Text = "Maksma";
            this.maksma.UseVisualStyleBackColor = true;
            this.maksma.Click += new System.EventHandler(this.maksma_Click);
            // 
            // kust_1
            // 
            this.kust_1.Location = new System.Drawing.Point(631, 534);
            this.kust_1.Margin = new System.Windows.Forms.Padding(4);
            this.kust_1.Name = "kust_1";
            this.kust_1.Size = new System.Drawing.Size(103, 38);
            this.kust_1.TabIndex = 1;
            this.kust_1.Text = "Kustuta";
            this.kust_1.UseVisualStyleBackColor = true;
            this.kust_1.Click += new System.EventHandler(this.kust_1_Click);
            // 
            // ostukorv_lbl
            // 
            this.ostukorv_lbl.AutoSize = true;
            this.ostukorv_lbl.Font = new System.Drawing.Font("Cascadia Mono", 13F);
            this.ostukorv_lbl.Location = new System.Drawing.Point(752, 58);
            this.ostukorv_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ostukorv_lbl.Name = "ostukorv_lbl";
            this.ostukorv_lbl.Size = new System.Drawing.Size(117, 29);
            this.ostukorv_lbl.TabIndex = 6;
            this.ostukorv_lbl.Text = "Ostukorv";
            // 
            // tooded
            // 
            this.tooded.AutoSize = true;
            this.tooded.Font = new System.Drawing.Font("Cascadia Mono", 13F);
            this.tooded.Location = new System.Drawing.Point(317, 58);
            this.tooded.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tooded.Name = "tooded";
            this.tooded.Size = new System.Drawing.Size(91, 29);
            this.tooded.TabIndex = 8;
            this.tooded.Text = "Tooded";
            // 
            // list_box
            // 
            this.list_box.FormattingEnabled = true;
            this.list_box.ItemHeight = 16;
            this.list_box.Location = new System.Drawing.Point(16, 100);
            this.list_box.Margin = new System.Windows.Forms.Padding(4);
            this.list_box.Name = "list_box";
            this.list_box.Size = new System.Drawing.Size(147, 372);
            this.list_box.TabIndex = 9;
            this.list_box.SelectedIndexChanged += new System.EventHandler(this.list_box_SelectedIndexChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(172, 100);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(411, 373);
            this.dataGridView2.TabIndex = 10;
            // 
            // total_label
            // 
            this.total_label.AutoSize = true;
            this.total_label.Font = new System.Drawing.Font("Cascadia Mono", 10F);
            this.total_label.Location = new System.Drawing.Point(635, 493);
            this.total_label.Name = "total_label";
            this.total_label.Size = new System.Drawing.Size(20, 22);
            this.total_label.TabIndex = 11;
            this.total_label.Text = "Kokku: 0,00 €";
            // 
            // ostja_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 672);
            this.Controls.Add(this.total_label);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.list_box);
            this.Controls.Add(this.tooded);
            this.Controls.Add(this.ostukorv_lbl);
            this.Controls.Add(this.maksma);
            this.Controls.Add(this.kust_1);
            this.Controls.Add(this.lisa_toode_btn);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ostja_form";
            this.Text = "Ostja";
            this.Load += new System.EventHandler(this.muuja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button lisa_toode_btn;
        private System.Windows.Forms.Button maksma;
        private System.Windows.Forms.Button kust_1;
        private System.Windows.Forms.Label ostukorv_lbl;
        private System.Windows.Forms.Label tooded;
        private System.Windows.Forms.ListBox list_box;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label total_label;
    }
}