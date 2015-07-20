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
      this.SaveButton = new System.Windows.Forms.Button();
      this.loadAllItems = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // FilePathTextBox
      // 
      this.FilePathTextBox.Location = new System.Drawing.Point(12, 59);
      this.FilePathTextBox.Name = "FilePathTextBox";
      this.FilePathTextBox.Size = new System.Drawing.Size(327, 20);
      this.FilePathTextBox.TabIndex = 1;
      this.FilePathTextBox.Text = "Cllick me to select file name";
      this.FilePathTextBox.Click += new System.EventHandler(this.FilePathTextBox_Click);
      // 
      // SaveButton
      // 
      this.SaveButton.Location = new System.Drawing.Point(350, 57);
      this.SaveButton.Name = "SaveButton";
      this.SaveButton.Size = new System.Drawing.Size(75, 23);
      this.SaveButton.TabIndex = 6;
      this.SaveButton.Text = "Save";
      this.SaveButton.UseVisualStyleBackColor = true;
      this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
      // 
      // loadAllItems
      // 
      this.loadAllItems.Location = new System.Drawing.Point(12, 12);
      this.loadAllItems.Name = "loadAllItems";
      this.loadAllItems.Size = new System.Drawing.Size(229, 23);
      this.loadAllItems.TabIndex = 7;
      this.loadAllItems.Text = "Загрузить товары и категории";
      this.loadAllItems.UseVisualStyleBackColor = true;
      this.loadAllItems.Click += new System.EventHandler(this.LoadItemsButton_Click);
      // 
      // FToFile
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(430, 86);
      this.Controls.Add(this.loadAllItems);
      this.Controls.Add(this.SaveButton);
      this.Controls.Add(this.FilePathTextBox);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "FToFile";
      this.Text = "FToFile";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox FilePathTextBox;
    private System.Windows.Forms.Button SaveButton;
    private System.Windows.Forms.Button loadAllItems;
  }
}