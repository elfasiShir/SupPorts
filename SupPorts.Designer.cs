namespace SupPorts_V2
{
    partial class SupPorts
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
            this.FindPorts = new System.Windows.Forms.Button();
            this.IpInput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.IpInputHeader = new System.Windows.Forms.Label();
            this.ipThreadManager = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // FindPorts
            // 
            this.FindPorts.Location = new System.Drawing.Point(0, 0);
            this.FindPorts.Name = "FindPorts";
            this.FindPorts.Size = new System.Drawing.Size(131, 39);
            this.FindPorts.TabIndex = 0;
            this.FindPorts.Text = "FindPorts";
            this.FindPorts.UseVisualStyleBackColor = true;
            this.FindPorts.Click += new System.EventHandler(this.FindPorts_Click);
            // 
            // IpInput
            // 
            this.IpInput.Location = new System.Drawing.Point(0, 77);
            this.IpInput.Name = "IpInput";
            this.IpInput.Size = new System.Drawing.Size(131, 20);
            this.IpInput.TabIndex = 1;
            this.IpInput.TextChanged += new System.EventHandler(this.IpInput_TextChanged);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(225, 13);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(42, 13);
            this.labelOutput.TabIndex = 2;
            this.labelOutput.Text = "Output:";
            this.labelOutput.Click += new System.EventHandler(this.labelOutput_Click);
            // 
            // IpInputHeader
            // 
            this.IpInputHeader.AutoSize = true;
            this.IpInputHeader.Location = new System.Drawing.Point(-3, 61);
            this.IpInputHeader.Name = "IpInputHeader";
            this.IpInputHeader.Size = new System.Drawing.Size(46, 13);
            this.IpInputHeader.TabIndex = 3;
            this.IpInputHeader.Text = "Enter ip:";
            this.IpInputHeader.Click += new System.EventHandler(this.IpInputHeader_Click);
            // 
            // ipThreadManager
            // 
            this.ipThreadManager.DoWork += new System.ComponentModel.DoWorkEventHandler(this.IpThreadManager_DoWork);
            this.ipThreadManager.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.IpThreadManager_ProgressChanged);
            // 
            // SupPorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.IpInputHeader);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.IpInput);
            this.Controls.Add(this.FindPorts);
            this.Name = "SupPorts";
            this.Text = "SupPorts";
            this.Load += new System.EventHandler(this.SupPorts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FindPorts;
        private System.Windows.Forms.TextBox IpInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label IpInputHeader;
        private System.ComponentModel.BackgroundWorker ipThreadManager;
    }
}

