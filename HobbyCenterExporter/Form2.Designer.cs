namespace HobbyCenterExporter
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
      this.DataGrid = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.processedTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.LoadedTextBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // DataGrid
      // 
      this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
      this.DataGrid.Location = new System.Drawing.Point(0, 0);
      this.DataGrid.Name = "DataGrid";
      this.DataGrid.Size = new System.Drawing.Size(1257, 432);
      this.DataGrid.TabIndex = 0;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "Column1";
      this.Column1.Name = "Column1";
      // 
      // Column2
      // 
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      // 
      // Column4
      // 
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      // 
      // Column5
      // 
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      // 
      // Column6
      // 
      this.Column6.HeaderText = "Column6";
      this.Column6.Name = "Column6";
      // 
      // Column7
      // 
      this.Column7.HeaderText = "Column7";
      this.Column7.Name = "Column7";
      // 
      // Column8
      // 
      this.Column8.HeaderText = "Column8";
      this.Column8.Name = "Column8";
      // 
      // Column9
      // 
      this.Column9.HeaderText = "Column9";
      this.Column9.Name = "Column9";
      // 
      // Column10
      // 
      this.Column10.HeaderText = "Column10";
      this.Column10.Name = "Column10";
      // 
      // Column11
      // 
      this.Column11.HeaderText = "Column11";
      this.Column11.Name = "Column11";
      // 
      // processedTextBox
      // 
      this.processedTextBox.Location = new System.Drawing.Point(92, 467);
      this.processedTextBox.Name = "processedTextBox";
      this.processedTextBox.Size = new System.Drawing.Size(100, 20);
      this.processedTextBox.TabIndex = 1;
      this.processedTextBox.Text = "обработано";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 470);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "обработано";
      // 
      // LoadedTextBox
      // 
      this.LoadedTextBox.Location = new System.Drawing.Point(92, 441);
      this.LoadedTextBox.Name = "LoadedTextBox";
      this.LoadedTextBox.Size = new System.Drawing.Size(100, 20);
      this.LoadedTextBox.TabIndex = 1;
      this.LoadedTextBox.Text = "загружено";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 444);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(61, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "загружено";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(231, 438);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "загрузить";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(231, 464);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 3;
      this.button2.Text = "обработать";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1269, 493);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.LoadedTextBox);
      this.Controls.Add(this.processedTextBox);
      this.Controls.Add(this.DataGrid);
      this.Name = "Form2";
      this.Text = "Form2";
      this.Load += new System.EventHandler(this.Form2_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView DataGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    private System.Windows.Forms.TextBox processedTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox LoadedTextBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

  }
}