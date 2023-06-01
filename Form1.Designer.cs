
namespace Lab_8 {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.Syncron = new System.Windows.Forms.Button();
      this.FolderBase = new System.Windows.Forms.TextBox();
      this.FolderSync = new System.Windows.Forms.TextBox();
      this.State = new System.Windows.Forms.Label();
      this.FilePath = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.DeleteFile = new System.Windows.Forms.Button();
      this.CreateFile = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.FileState = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // Syncron
      // 
      this.Syncron.FlatAppearance.BorderSize = 0;
      this.Syncron.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Syncron.Location = new System.Drawing.Point(68, 107);
      this.Syncron.Name = "Syncron";
      this.Syncron.Size = new System.Drawing.Size(241, 48);
      this.Syncron.TabIndex = 0;
      this.Syncron.Text = "Синхронизировать";
      this.Syncron.UseVisualStyleBackColor = true;
      this.Syncron.Click += new System.EventHandler(this.Syncron_Click);
      // 
      // FolderBase
      // 
      this.FolderBase.Location = new System.Drawing.Point(19, 21);
      this.FolderBase.Name = "FolderBase";
      this.FolderBase.Size = new System.Drawing.Size(335, 22);
      this.FolderBase.TabIndex = 1;
      this.FolderBase.TextChanged += new System.EventHandler(this.FolderBase_TextChanged);
      // 
      // FolderSync
      // 
      this.FolderSync.Location = new System.Drawing.Point(19, 62);
      this.FolderSync.Name = "FolderSync";
      this.FolderSync.Size = new System.Drawing.Size(335, 22);
      this.FolderSync.TabIndex = 2;
      this.FolderSync.TextChanged += new System.EventHandler(this.FolderSync_TextChanged);
      // 
      // State
      // 
      this.State.AutoSize = true;
      this.State.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.State.Location = new System.Drawing.Point(80, 186);
      this.State.MaximumSize = new System.Drawing.Size(250, 70);
      this.State.Name = "State";
      this.State.Size = new System.Drawing.Size(0, 25);
      this.State.TabIndex = 3;
      this.State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // FilePath
      // 
      this.FilePath.Location = new System.Drawing.Point(19, 18);
      this.FilePath.Name = "FilePath";
      this.FilePath.Size = new System.Drawing.Size(335, 22);
      this.FilePath.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel1.Controls.Add(this.State);
      this.panel1.Controls.Add(this.FolderSync);
      this.panel1.Controls.Add(this.FolderBase);
      this.panel1.Controls.Add(this.Syncron);
      this.panel1.Location = new System.Drawing.Point(95, 175);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(367, 262);
      this.panel1.TabIndex = 5;
      // 
      // DeleteFile
      // 
      this.DeleteFile.Location = new System.Drawing.Point(19, 46);
      this.DeleteFile.Name = "DeleteFile";
      this.DeleteFile.Size = new System.Drawing.Size(167, 26);
      this.DeleteFile.TabIndex = 6;
      this.DeleteFile.Text = "Удалить файл";
      this.DeleteFile.UseVisualStyleBackColor = true;
      this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
      // 
      // CreateFile
      // 
      this.CreateFile.Location = new System.Drawing.Point(187, 46);
      this.CreateFile.Name = "CreateFile";
      this.CreateFile.Size = new System.Drawing.Size(167, 26);
      this.CreateFile.TabIndex = 7;
      this.CreateFile.Text = "Создать файл";
      this.CreateFile.UseVisualStyleBackColor = true;
      this.CreateFile.Click += new System.EventHandler(this.CreateFile_Click);
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel2.Controls.Add(this.FileState);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.CreateFile);
      this.panel2.Controls.Add(this.DeleteFile);
      this.panel2.Controls.Add(this.FilePath);
      this.panel2.Location = new System.Drawing.Point(95, 44);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(367, 125);
      this.panel2.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(72, 92);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(0, 17);
      this.label1.TabIndex = 8;
      // 
      // FileState
      // 
      this.FileState.AutoSize = true;
      this.FileState.Location = new System.Drawing.Point(75, 87);
      this.FileState.Name = "FileState";
      this.FileState.Size = new System.Drawing.Size(0, 17);
      this.FileState.TabIndex = 9;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
      this.ClientSize = new System.Drawing.Size(562, 486);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Sync Folders";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button Syncron;
    private System.Windows.Forms.TextBox FolderBase;
    private System.Windows.Forms.TextBox FolderSync;
    private System.Windows.Forms.Label State;
    private System.Windows.Forms.TextBox FilePath;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button DeleteFile;
    private System.Windows.Forms.Button CreateFile;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label FileState;
  }
}