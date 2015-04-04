namespace HobbyCenterExporter
{
  partial class FProgress
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
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.passedTB = new System.Windows.Forms.TextBox();
      this.loadedTB = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(61, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "загружено";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 39);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(66, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "обработано";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(84, 36);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 1;
      // 
      // passedTB
      // 
      this.passedTB.Location = new System.Drawing.Point(84, 36);
      this.passedTB.Name = "passedTB";
      this.passedTB.Size = new System.Drawing.Size(100, 20);
      this.passedTB.TabIndex = 1;
      // 
      // loadedTB
      // 
      this.loadedTB.Location = new System.Drawing.Point(84, 10);
      this.loadedTB.Name = "loadedTB";
      this.loadedTB.Size = new System.Drawing.Size(100, 20);
      this.loadedTB.TabIndex = 1;
      // 
      // FProgress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(398, 65);
      this.Controls.Add(this.loadedTB);
      this.Controls.Add(this.passedTB);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "FProgress";
      this.Text = "FProgress";
      this.Load += new System.EventHandler(this.FProgress_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox passedTB;
    private System.Windows.Forms.TextBox loadedTB;
  }
}