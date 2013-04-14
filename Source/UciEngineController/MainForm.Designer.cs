namespace UciEngineController
{
    partial class MainForm
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
      this.GoButton = new System.Windows.Forms.Button();
      this.StopButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // GoButton
      // 
      this.GoButton.Location = new System.Drawing.Point(12, 22);
      this.GoButton.Name = "GoButton";
      this.GoButton.Size = new System.Drawing.Size(75, 23);
      this.GoButton.TabIndex = 0;
      this.GoButton.Text = "Go";
      this.GoButton.UseVisualStyleBackColor = true;
      this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
      // 
      // StopButton
      // 
      this.StopButton.Location = new System.Drawing.Point(104, 22);
      this.StopButton.Name = "StopButton";
      this.StopButton.Size = new System.Drawing.Size(75, 23);
      this.StopButton.TabIndex = 1;
      this.StopButton.Text = "Stop";
      this.StopButton.UseVisualStyleBackColor = true;
      this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(402, 201);
      this.Controls.Add(this.StopButton);
      this.Controls.Add(this.GoButton);
      this.Name = "MainForm";
      this.Text = "UCI Engine Controller";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.Button StopButton;
    }
}

