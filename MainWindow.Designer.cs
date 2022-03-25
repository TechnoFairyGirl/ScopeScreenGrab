namespace ScopeScreenGrab
{
	partial class MainWindow
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
			this.hostText = new System.Windows.Forms.Label();
			this.addressText = new System.Windows.Forms.Label();
			this.hostBox = new System.Windows.Forms.TextBox();
			this.addressBox = new System.Windows.Forms.TextBox();
			this.screenshotBox = new System.Windows.Forms.PictureBox();
			this.getScreenshotButton = new System.Windows.Forms.Button();
			this.saveScreenshotButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.screenshotBox)).BeginInit();
			this.SuspendLayout();
			// 
			// hostText
			// 
			this.hostText.AutoSize = true;
			this.hostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hostText.Location = new System.Drawing.Point(28, 25);
			this.hostText.Name = "hostText";
			this.hostText.Size = new System.Drawing.Size(133, 18);
			this.hostText.TabIndex = 0;
			this.hostText.Text = "GPIB Adapter Host";
			// 
			// addressText
			// 
			this.addressText.AutoSize = true;
			this.addressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addressText.Location = new System.Drawing.Point(28, 60);
			this.addressText.Name = "addressText";
			this.addressText.Size = new System.Drawing.Size(101, 18);
			this.addressText.TabIndex = 2;
			this.addressText.Text = "GPIB Address";
			// 
			// hostBox
			// 
			this.hostBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hostBox.Location = new System.Drawing.Point(174, 24);
			this.hostBox.Name = "hostBox";
			this.hostBox.Size = new System.Drawing.Size(292, 24);
			this.hostBox.TabIndex = 1;
			// 
			// addressBox
			// 
			this.addressBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addressBox.Location = new System.Drawing.Point(174, 59);
			this.addressBox.Name = "addressBox";
			this.addressBox.Size = new System.Drawing.Size(61, 24);
			this.addressBox.TabIndex = 3;
			// 
			// screenshotBox
			// 
			this.screenshotBox.BackColor = System.Drawing.Color.Black;
			this.screenshotBox.Location = new System.Drawing.Point(31, 104);
			this.screenshotBox.Name = "screenshotBox";
			this.screenshotBox.Size = new System.Drawing.Size(660, 500);
			this.screenshotBox.TabIndex = 4;
			this.screenshotBox.TabStop = false;
			// 
			// getScreenshotButton
			// 
			this.getScreenshotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.getScreenshotButton.Location = new System.Drawing.Point(31, 626);
			this.getScreenshotButton.Name = "getScreenshotButton";
			this.getScreenshotButton.Size = new System.Drawing.Size(146, 39);
			this.getScreenshotButton.TabIndex = 4;
			this.getScreenshotButton.Text = "Get Screenshot";
			this.getScreenshotButton.UseVisualStyleBackColor = true;
			this.getScreenshotButton.Click += new System.EventHandler(this.getScreenshotButton_Click);
			// 
			// saveScreenshotButton
			// 
			this.saveScreenshotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.saveScreenshotButton.Location = new System.Drawing.Point(198, 626);
			this.saveScreenshotButton.Name = "saveScreenshotButton";
			this.saveScreenshotButton.Size = new System.Drawing.Size(146, 39);
			this.saveScreenshotButton.TabIndex = 5;
			this.saveScreenshotButton.Text = "Save Screenshot";
			this.saveScreenshotButton.UseVisualStyleBackColor = true;
			this.saveScreenshotButton.Click += new System.EventHandler(this.saveScreenshotButton_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(730, 690);
			this.Controls.Add(this.saveScreenshotButton);
			this.Controls.Add(this.getScreenshotButton);
			this.Controls.Add(this.screenshotBox);
			this.Controls.Add(this.addressBox);
			this.Controls.Add(this.hostBox);
			this.Controls.Add(this.addressText);
			this.Controls.Add(this.hostText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.Text = "Oscilloscope Screenshot Tool";
			((System.ComponentModel.ISupportInitialize)(this.screenshotBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label hostText;
		private System.Windows.Forms.Label addressText;
		private System.Windows.Forms.TextBox hostBox;
		private System.Windows.Forms.TextBox addressBox;
		private System.Windows.Forms.PictureBox screenshotBox;
		private System.Windows.Forms.Button getScreenshotButton;
		private System.Windows.Forms.Button saveScreenshotButton;
	}
}

