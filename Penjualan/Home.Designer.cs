namespace Penjualan
{
    partial class Home
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
            this.panelUtama = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelUtama.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUtama
            // 
            this.panelUtama.Controls.Add(this.label4);
            this.panelUtama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUtama.Location = new System.Drawing.Point(0, 0);
            this.panelUtama.Name = "panelUtama";
            this.panelUtama.Size = new System.Drawing.Size(978, 400);
            this.panelUtama.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(387, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(285, 42);
            this.label4.TabIndex = 0;
            this.label4.Text = "Selamat Datang";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 400);
            this.Controls.Add(this.panelUtama);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelUtama.ResumeLayout(false);
            this.panelUtama.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUtama;
        private System.Windows.Forms.Label label4;
    }
}