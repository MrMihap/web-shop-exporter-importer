﻿namespace HobbyCenterExporter
{
  partial class FStartForm
  {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.LoadTList = new System.Windows.Forms.Button();
      this.LoadKT = new System.Windows.Forms.Button();
      this.CSVExportButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // LoadTList
      // 
      this.LoadTList.Location = new System.Drawing.Point(12, 41);
      this.LoadTList.Name = "LoadTList";
      this.LoadTList.Size = new System.Drawing.Size(203, 23);
      this.LoadTList.TabIndex = 1;
      this.LoadTList.Text = "Load prod List";
      this.LoadTList.UseVisualStyleBackColor = true;
      this.LoadTList.Click += new System.EventHandler(this.LoadTList_Click);
      // 
      // LoadKT
      // 
      this.LoadKT.Location = new System.Drawing.Point(12, 12);
      this.LoadKT.Name = "LoadKT";
      this.LoadKT.Size = new System.Drawing.Size(203, 23);
      this.LoadKT.TabIndex = 1;
      this.LoadKT.Text = "Load from web to bin";
      this.LoadKT.UseVisualStyleBackColor = true;
      this.LoadKT.Click += new System.EventHandler(this.LoadKT_Click);
      // 
      // CSVExportButton
      // 
      this.CSVExportButton.Location = new System.Drawing.Point(13, 71);
      this.CSVExportButton.Name = "CSVExportButton";
      this.CSVExportButton.Size = new System.Drawing.Size(202, 23);
      this.CSVExportButton.TabIndex = 2;
      this.CSVExportButton.Text = "Export to CSV";
      this.CSVExportButton.UseVisualStyleBackColor = true;
      this.CSVExportButton.Click += new System.EventHandler(this.CSVExportButton_Click);
      // 
      // FStartForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(222, 102);
      this.Controls.Add(this.CSVExportButton);
      this.Controls.Add(this.LoadKT);
      this.Controls.Add(this.LoadTList);
      this.Name = "FStartForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button LoadTList;
    private System.Windows.Forms.Button LoadKT;
    private System.Windows.Forms.Button CSVExportButton;
  }
}

