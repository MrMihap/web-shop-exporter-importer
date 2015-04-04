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
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.CatsCount = new System.Windows.Forms.TextBox();
      this.ItemsCount = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.SaveButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // FilePathTextBox
      // 
      this.FilePathTextBox.Location = new System.Drawing.Point(89, 68);
      this.FilePathTextBox.Name = "FilePathTextBox";
      this.FilePathTextBox.Size = new System.Drawing.Size(588, 20);
      this.FilePathTextBox.TabIndex = 1;
      this.FilePathTextBox.Text = "Cllick me to select file name";
      this.FilePathTextBox.Click += new System.EventHandler(this.FilePathTextBox_Click);
      // 
      // LoadCatsButton
      // 
      this.LoadCatsButton.Location = new System.Drawing.Point(89, 12);
      this.LoadCatsButton.Name = "LoadCatsButton";
      this.LoadCatsButton.Size = new System.Drawing.Size(75, 22);
      this.LoadCatsButton.TabIndex = 2;
      this.LoadCatsButton.Text = "start";
      this.LoadCatsButton.UseVisualStyleBackColor = true;
      this.LoadCatsButton.Click += new System.EventHandler(this.LoadCatsButton_Click);
      // 
      // LoadItemsButton
      // 
      this.LoadItemsButton.Location = new System.Drawing.Point(89, 40);
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
      this.label1.Location = new System.Drawing.Point(2, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Load Cats";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(2, 71);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(81, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "Select File Path";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(188, 17);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(62, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Load Count";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(188, 45);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(62, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Load Count";
      // 
      // CatsCount
      // 
      this.CatsCount.Location = new System.Drawing.Point(257, 14);
      this.CatsCount.Name = "CatsCount";
      this.CatsCount.Size = new System.Drawing.Size(100, 20);
      this.CatsCount.TabIndex = 5;
      // 
      // ItemsCount
      // 
      this.ItemsCount.Location = new System.Drawing.Point(257, 42);
      this.ItemsCount.Name = "ItemsCount";
      this.ItemsCount.Size = new System.Drawing.Size(100, 20);
      this.ItemsCount.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(2, 45);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(59, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "Load Items";
      // 
      // SaveButton
      // 
      this.SaveButton.Location = new System.Drawing.Point(683, 66);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(75, 23);
      this.SaveButton.TabIndex = 6;
      this.SaveButton.Text = "Save";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // FToFile
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(772, 91);
      this.Controls.Add(this.SaveButton);
      this.Controls.Add(this.ItemsCount);
      this.Controls.Add(this.CatsCount);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.LoadItemsButton);
      this.Controls.Add(this.LoadCatsButton);
      this.Controls.Add(this.FilePathTextBox);
      this.Name = "FToFile";
      this.Text = "FToFile";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox FilePathTextBox;
    private System.Windows.Forms.Button LoadCatsButton;
    private System.Windows.Forms.Button LoadItemsButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox CatsCount;
    private System.Windows.Forms.TextBox ItemsCount;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button SaveButton;
  }
}