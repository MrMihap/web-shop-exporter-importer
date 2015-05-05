namespace HobbyCenterExporter
{
  partial class FToFile
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
      this.FilePathTextBox = new System.Windows.Forms.TextBox();
      this.LoadCatsButton = new System.Windows.Forms.Button();
      this.LoadItemsButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.CatsCount = new System.Windows.Forms.TextBox();
      this.ItemsCount = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SaveButton = new System.Windows.Forms.Button();
      this.AllowLoadAdditionalImages = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.threadCountUpDown = new System.Windows.Forms.NumericUpDown();
      this.label6 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadCountUpDown)).BeginInit();
      this.SuspendLayout();
      // 
      // FilePathTextBox
      // 
      this.FilePathTextBox.Location = new System.Drawing.Point(12, 187);
      this.FilePathTextBox.Name = "FilePathTextBox";
      this.FilePathTextBox.Size = new System.Drawing.Size(327, 20);
      this.FilePathTextBox.TabIndex = 1;
      this.FilePathTextBox.Text = "Cllick me to select file name";
      this.FilePathTextBox.Click += new System.EventHandler(this.FilePathTextBox_Click);
      // 
      // LoadCatsButton
      // 
      this.LoadCatsButton.Location = new System.Drawing.Point(84, 19);
      this.LoadCatsButton.Name = "LoadCatsButton";
      this.LoadCatsButton.Size = new System.Drawing.Size(75, 22);
      this.LoadCatsButton.TabIndex = 2;
      this.LoadCatsButton.Text = "start";
      this.LoadCatsButton.UseVisualStyleBackColor = true;
      this.LoadCatsButton.Click += new System.EventHandler(this.LoadCatsButton_Click);
      // 
      // LoadItemsButton
      // 
      this.LoadItemsButton.Location = new System.Drawing.Point(84, 19);
      this.LoadItemsButton.Name = "LoadItemsButton";
      this.LoadItemsButton.Size = new System.Drawing.Size(75, 23);
      this.LoadItemsButton.TabIndex = 3;
      this.LoadItemsButton.Text = "start";
      this.LoadItemsButton.UseVisualStyleBackColor = true;
      this.LoadItemsButton.Click += new System.EventHandler(this.LoadItemsButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Load Cats";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(183, 24);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(62, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Load Count";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(183, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(62, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Load Count";
      // 
      // CatsCount
      // 
      this.CatsCount.Location = new System.Drawing.Point(252, 21);
      this.CatsCount.Name = "CatsCount";
      this.CatsCount.Size = new System.Drawing.Size(100, 20);
      this.CatsCount.TabIndex = 5;
      // 
      // ItemsCount
      // 
      this.ItemsCount.Location = new System.Drawing.Point(252, 21);
      this.ItemsCount.Name = "ItemsCount";
      this.ItemsCount.Size = new System.Drawing.Size(100, 20);
      this.ItemsCount.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 24);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(59, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Load Items";
      // 
      // SaveButton
      // 
      this.SaveButton.Location = new System.Drawing.Point(350, 185);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(75, 23);
      this.SaveButton.TabIndex = 6;
      this.SaveButton.Text = "Save";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // AllowLoadAdditionalImages
      // 
      this.AllowLoadAdditionalImages.AutoSize = true;
      this.AllowLoadAdditionalImages.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.AllowLoadAdditionalImages.Location = new System.Drawing.Point(6, 48);
      this.AllowLoadAdditionalImages.Name = "AllowLoadAdditionalImages";
      this.AllowLoadAdditionalImages.Size = new System.Drawing.Size(198, 17);
      this.AllowLoadAdditionalImages.TabIndex = 7;
      this.AllowLoadAdditionalImages.Text = "Выгружать дополнительные фото";
      this.AllowLoadAdditionalImages.UseVisualStyleBackColor = true;
      this.AllowLoadAdditionalImages.CheckedChanged += new System.EventHandler(this.AllowLoadAdditionalImages_CheckedChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.threadCountUpDown);
      this.groupBox1.Controls.Add(this.LoadItemsButton);
      this.groupBox1.Controls.Add(this.AllowLoadAdditionalImages);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.ItemsCount);
      this.groupBox1.Location = new System.Drawing.Point(12, 86);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(413, 94);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Загрузка товаров";
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.LoadCatsButton);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.label3);
      this.groupBox2.Controls.Add(this.CatsCount);
      this.groupBox2.Location = new System.Drawing.Point(12, 12);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(413, 68);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Загрузка списков категорий";
      // 
      // threadCountUpDown
      // 
      this.threadCountUpDown.Location = new System.Drawing.Point(145, 71);
      this.threadCountUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.threadCountUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.threadCountUpDown.Name = "threadCountUpDown";
      this.threadCountUpDown.Size = new System.Drawing.Size(59, 20);
      this.threadCountUpDown.TabIndex = 8;
      this.threadCountUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.threadCountUpDown.ValueChanged += new System.EventHandler(this.threadCountUpDown_ValueChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(6, 73);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(113, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "LOADING_THREADS";
      // 
      // FToFile
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(429, 210);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.SaveButton);
      this.Controls.Add(this.FilePathTextBox);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FToFile";
      this.Text = "FToFile";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.threadCountUpDown)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox FilePathTextBox;
    private System.Windows.Forms.Button LoadCatsButton;
    private System.Windows.Forms.Button LoadItemsButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox CatsCount;
    private System.Windows.Forms.TextBox ItemsCount;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button SaveButton;
    private System.Windows.Forms.CheckBox AllowLoadAdditionalImages;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.NumericUpDown threadCountUpDown;
    private System.Windows.Forms.GroupBox groupBox2;
  }
}