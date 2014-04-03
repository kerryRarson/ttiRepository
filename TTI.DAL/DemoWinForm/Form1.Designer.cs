namespace DemoWinForm
{
    partial class Form1
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
            this.cboStates = new System.Windows.Forms.ComboBox();
            this.btnLoadStates = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLoadStatesAsync = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboStates
            // 
            this.cboStates.FormattingEnabled = true;
            this.cboStates.Location = new System.Drawing.Point(12, 12);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(171, 21);
            this.cboStates.TabIndex = 0;
            this.cboStates.SelectedIndexChanged += new System.EventHandler(this.cboStates_SelectedIndexChanged);
            // 
            // btnLoadStates
            // 
            this.btnLoadStates.Location = new System.Drawing.Point(190, 9);
            this.btnLoadStates.Name = "btnLoadStates";
            this.btnLoadStates.Size = new System.Drawing.Size(75, 23);
            this.btnLoadStates.TabIndex = 1;
            this.btnLoadStates.Text = "Load States";
            this.btnLoadStates.UseVisualStyleBackColor = true;
            this.btnLoadStates.Click += new System.EventHandler(this.btnLoadStates_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 239);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnLoadStatesAsync
            // 
            this.btnLoadStatesAsync.Location = new System.Drawing.Point(190, 38);
            this.btnLoadStatesAsync.Name = "btnLoadStatesAsync";
            this.btnLoadStatesAsync.Size = new System.Drawing.Size(75, 23);
            this.btnLoadStatesAsync.TabIndex = 3;
            this.btnLoadStatesAsync.Text = "Load Async";
            this.btnLoadStatesAsync.UseVisualStyleBackColor = true;
            this.btnLoadStatesAsync.Click += new System.EventHandler(this.btnLoadStatesAsync_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Test await";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(12, 124);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(253, 95);
            this.lstPlayers.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadStatesAsync);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLoadStates);
            this.Controls.Add(this.cboStates);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStates;
        private System.Windows.Forms.Button btnLoadStates;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnLoadStatesAsync;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lstPlayers;
    }
}

