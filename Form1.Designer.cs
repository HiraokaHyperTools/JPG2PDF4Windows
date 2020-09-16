namespace JPG2PDF4Windows
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectFilesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.altDpi = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.altDpi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectFilesBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 181);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PDF を作成";
            // 
            // selectFilesBtn
            // 
            this.selectFilesBtn.AllowDrop = true;
            this.selectFilesBtn.Image = global::JPG2PDF4Windows.Properties.Resources.DROP1PG_1_32_32_32;
            this.selectFilesBtn.Location = new System.Drawing.Point(6, 44);
            this.selectFilesBtn.Name = "selectFilesBtn";
            this.selectFilesBtn.Size = new System.Drawing.Size(226, 107);
            this.selectFilesBtn.TabIndex = 0;
            this.selectFilesBtn.Text = "画像ファイルを選択";
            this.selectFilesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.selectFilesBtn.UseVisualStyleBackColor = true;
            this.selectFilesBtn.Click += new System.EventHandler(this.selectFilesBtn_Click);
            this.selectFilesBtn.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectFilesBtn_DragDrop);
            this.selectFilesBtn.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectFilesBtn_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "DPI が未設定の場合の DPI";
            // 
            // altDpi
            // 
            this.altDpi.Location = new System.Drawing.Point(312, 37);
            this.altDpi.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.altDpi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.altDpi.Name = "altDpi";
            this.altDpi.Size = new System.Drawing.Size(89, 29);
            this.altDpi.TabIndex = 2;
            this.altDpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.altDpi.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(607, 233);
            this.Controls.Add(this.altDpi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JPG2PDF for Windows";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.altDpi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectFilesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown altDpi;
    }
}

