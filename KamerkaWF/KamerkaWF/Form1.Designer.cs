namespace KamerkaWF
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
            this.CaptureBox = new System.Windows.Forms.PictureBox();
            this.CamerasCB = new System.Windows.Forms.ComboBox();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.ResolutionCB = new System.Windows.Forms.ComboBox();
            this.SnapshotButton = new System.Windows.Forms.Button();
            this.RecordButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptureBox
            // 
            this.CaptureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaptureBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.CaptureBox.Location = new System.Drawing.Point(12, 12);
            this.CaptureBox.Name = "CaptureBox";
            this.CaptureBox.Size = new System.Drawing.Size(625, 180);
            this.CaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CaptureBox.TabIndex = 0;
            this.CaptureBox.TabStop = false;
            // 
            // CamerasCB
            // 
            this.CamerasCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CamerasCB.FormattingEnabled = true;
            this.CamerasCB.Location = new System.Drawing.Point(12, 198);
            this.CamerasCB.Name = "CamerasCB";
            this.CamerasCB.Size = new System.Drawing.Size(625, 21);
            this.CamerasCB.TabIndex = 1;
            this.CamerasCB.SelectedIndexChanged += new System.EventHandler(this.CamerasCB_SelectedIndexChanged);
            // 
            // CaptureButton
            // 
            this.CaptureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CaptureButton.Location = new System.Drawing.Point(12, 252);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(122, 23);
            this.CaptureButton.TabIndex = 2;
            this.CaptureButton.Text = "Start / Stop";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // ResolutionCB
            // 
            this.ResolutionCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResolutionCB.FormattingEnabled = true;
            this.ResolutionCB.Location = new System.Drawing.Point(13, 225);
            this.ResolutionCB.Name = "ResolutionCB";
            this.ResolutionCB.Size = new System.Drawing.Size(624, 21);
            this.ResolutionCB.TabIndex = 3;
            this.ResolutionCB.SelectedIndexChanged += new System.EventHandler(this.ResolutionCB_SelectedIndexChanged);
            // 
            // SnapshotButton
            // 
            this.SnapshotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SnapshotButton.Location = new System.Drawing.Point(140, 252);
            this.SnapshotButton.Name = "SnapshotButton";
            this.SnapshotButton.Size = new System.Drawing.Size(95, 23);
            this.SnapshotButton.TabIndex = 4;
            this.SnapshotButton.Text = "Take snapshot";
            this.SnapshotButton.UseVisualStyleBackColor = true;
            this.SnapshotButton.Click += new System.EventHandler(this.SnapshotButton_Click);
            // 
            // RecordButton
            // 
            this.RecordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RecordButton.Location = new System.Drawing.Point(241, 252);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(122, 23);
            this.RecordButton.TabIndex = 5;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 294);
            this.Controls.Add(this.RecordButton);
            this.Controls.Add(this.SnapshotButton);
            this.Controls.Add(this.ResolutionCB);
            this.Controls.Add(this.CaptureButton);
            this.Controls.Add(this.CamerasCB);
            this.Controls.Add(this.CaptureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CaptureBox;
        private System.Windows.Forms.ComboBox CamerasCB;
        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.ComboBox ResolutionCB;
        private System.Windows.Forms.Button SnapshotButton;
        private System.Windows.Forms.Button RecordButton;
    }
}

