using System.Threading;

namespace epood_toode
{
    partial class Form2
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
            this.epood_lbl = new System.Windows.Forms.Label();
            this.muuja_btn = new System.Windows.Forms.Button();
            this.ostja_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // epood_lbl
            // 
            this.epood_lbl.AutoSize = true;
            this.epood_lbl.Font = new System.Drawing.Font("Cascadia Mono", 15F);
            this.epood_lbl.Location = new System.Drawing.Point(90, 22);
            this.epood_lbl.Name = "epood_lbl";
            this.epood_lbl.Size = new System.Drawing.Size(288, 27);
            this.epood_lbl.TabIndex = 0;
            this.epood_lbl.Text = "Tere tulemast e-poodi !";
            // 
            // muuja_btn
            // 
            this.muuja_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.muuja_btn.Location = new System.Drawing.Point(234, 71);
            this.muuja_btn.Name = "muuja_btn";
            this.muuja_btn.Size = new System.Drawing.Size(216, 37);
            this.muuja_btn.TabIndex = 1;
            this.muuja_btn.Text = "Müüja";
            this.muuja_btn.UseVisualStyleBackColor = false;
            this.muuja_btn.Click += new System.EventHandler(this.muuja_btn_Click);
            // 
            // ostja_btn
            // 
            this.ostja_btn.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ostja_btn.Location = new System.Drawing.Point(12, 71);
            this.ostja_btn.Name = "ostja_btn";
            this.ostja_btn.Size = new System.Drawing.Size(216, 37);
            this.ostja_btn.TabIndex = 2;
            this.ostja_btn.Text = "Ostja";
            this.ostja_btn.UseVisualStyleBackColor = false;
            this.ostja_btn.Click += new System.EventHandler(this.ostja_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 140);
            this.Controls.Add(this.ostja_btn);
            this.Controls.Add(this.muuja_btn);
            this.Controls.Add(this.epood_lbl);
            this.Name = "Form2";
            this.Text = "Epood";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label epood_lbl;
        private System.Windows.Forms.Button muuja_btn;
        private System.Windows.Forms.Button ostja_btn;
    }
}