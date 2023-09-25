namespace Penjualan
{
    partial class Return_Barang
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Nokwitansi = new System.Windows.Forms.TextBox();
            this.Kodebarang = new System.Windows.Forms.TextBox();
            this.namabarang = new System.Windows.Forms.TextBox();
            this.harga = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tanggalkembali = new System.Windows.Forms.DateTimePicker();
            this.satuan = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.IDpengembalian = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Nokwitansi
            // 
            this.Nokwitansi.Location = new System.Drawing.Point(49, 237);
            this.Nokwitansi.Name = "Nokwitansi";
            this.Nokwitansi.Size = new System.Drawing.Size(255, 20);
            this.Nokwitansi.TabIndex = 1;
            // 
            // Kodebarang
            // 
            this.Kodebarang.Location = new System.Drawing.Point(49, 286);
            this.Kodebarang.Name = "Kodebarang";
            this.Kodebarang.Size = new System.Drawing.Size(255, 20);
            this.Kodebarang.TabIndex = 2;
            // 
            // namabarang
            // 
            this.namabarang.Location = new System.Drawing.Point(49, 334);
            this.namabarang.Name = "namabarang";
            this.namabarang.Size = new System.Drawing.Size(255, 20);
            this.namabarang.TabIndex = 3;
            // 
            // harga
            // 
            this.harga.Location = new System.Drawing.Point(49, 387);
            this.harga.Name = "harga";
            this.harga.Size = new System.Drawing.Size(255, 20);
            this.harga.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cari";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tanggalkembali
            // 
            this.tanggalkembali.Location = new System.Drawing.Point(49, 189);
            this.tanggalkembali.Name = "tanggalkembali";
            this.tanggalkembali.Size = new System.Drawing.Size(255, 20);
            this.tanggalkembali.TabIndex = 6;
            // 
            // satuan
            // 
            this.satuan.Location = new System.Drawing.Point(49, 437);
            this.satuan.Name = "satuan";
            this.satuan.Size = new System.Drawing.Size(255, 20);
            this.satuan.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(358, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(597, 268);
            this.dataGridView1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Return barang";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(49, 485);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(500, 20);
            this.textBox7.TabIndex = 10;
            this.textBox7.Text = "aaaa";
            // 
            // IDpengembalian
            // 
            this.IDpengembalian.Location = new System.Drawing.Point(94, 128);
            this.IDpengembalian.Name = "IDpengembalian";
            this.IDpengembalian.Size = new System.Drawing.Size(178, 20);
            this.IDpengembalian.TabIndex = 11;
            this.IDpengembalian.Text = " q";
            // 
            // Return_Barang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 453);
            this.Controls.Add(this.IDpengembalian);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.satuan);
            this.Controls.Add(this.tanggalkembali);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.harga);
            this.Controls.Add(this.namabarang);
            this.Controls.Add(this.Kodebarang);
            this.Controls.Add(this.Nokwitansi);
            this.Controls.Add(this.textBox1);
            this.Name = "Return_Barang";
            this.Text = "Return_Barang";
            this.Load += new System.EventHandler(this.Return_Barang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Nokwitansi;
        private System.Windows.Forms.TextBox Kodebarang;
        private System.Windows.Forms.TextBox namabarang;
        private System.Windows.Forms.TextBox harga;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker tanggalkembali;
        private System.Windows.Forms.TextBox satuan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox IDpengembalian;
    }
}