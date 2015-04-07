namespace HobbyCenterExporter
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
      this.loadcat = new System.Windows.Forms.Button();
      this.LoadTList = new System.Windows.Forms.Button();
      this.LoadKT = new System.Windows.Forms.Button();
      this.txb_text = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // loadcat
      // 
      this.loadcat.Location = new System.Drawing.Point(12, 12);
      this.loadcat.Name = "loadcat";
      this.loadcat.Size = new System.Drawing.Size(203, 23);
      this.loadcat.TabIndex = 0;
      this.loadcat.Text = "Load categories";
      this.loadcat.UseVisualStyleBackColor = true;
      this.loadcat.Click += new System.EventHandler(this.loadcat_Click);
      // 
      // LoadTList
      // 
      this.LoadTList.Location = new System.Drawing.Point(12, 42);
      this.LoadTList.Name = "LoadTList";
      this.LoadTList.Size = new System.Drawing.Size(203, 23);
      this.LoadTList.TabIndex = 1;
      this.LoadTList.Text = "Load prod List";
      this.LoadTList.UseVisualStyleBackColor = true;
      this.LoadTList.Click += new System.EventHandler(this.LoadTList_Click);
      // 
      // LoadKT
      // 
      this.LoadKT.Location = new System.Drawing.Point(12, 104);
      this.LoadKT.Name = "LoadKT";
      this.LoadKT.Size = new System.Drawing.Size(203, 23);
      this.LoadKT.TabIndex = 1;
      this.LoadKT.Text = "Save Catalog to File";
      this.LoadKT.UseVisualStyleBackColor = true;
      this.LoadKT.Click += new System.EventHandler(this.LoadKT_Click);
      // 
      // txb_text
      // 
      this.txb_text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.txb_text.Location = new System.Drawing.Point(293, 15);
      this.txb_text.Multiline = true;
      this.txb_text.Name = "txb_text";
      this.txb_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txb_text.Size = new System.Drawing.Size(517, 178);
      this.txb_text.TabIndex = 2;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(822, 205);
      this.Controls.Add(this.txb_text);
      this.Controls.Add(this.LoadKT);
      this.Controls.Add(this.LoadTList);
      this.Controls.Add(this.loadcat);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button loadcat;
    private System.Windows.Forms.Button LoadTList;
    private System.Windows.Forms.Button LoadKT;
    private System.Windows.Forms.TextBox txb_text;
  }
}

