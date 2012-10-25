﻿namespace WordShuffler
{
    partial class ShuffleCoreForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShuffleCoreForm));
            this.startButton = new System.Windows.Forms.Button();
            this.shownWord = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.drawCardCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(12, 162);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(128, 47);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // shownWord
            // 
            this.shownWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shownWord.AutoSize = true;
            this.shownWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shownWord.Location = new System.Drawing.Point(136, 49);
            this.shownWord.Name = "shownWord";
            this.shownWord.Size = new System.Drawing.Size(105, 55);
            this.shownWord.TabIndex = 2;
            this.shownWord.Text = "text";
            this.shownWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(292, 162);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopButton.Location = new System.Drawing.Point(146, 162);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(129, 47);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // drawCardCheckbox
            // 
            this.drawCardCheckbox.AutoSize = true;
            this.drawCardCheckbox.Checked = true;
            this.drawCardCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawCardCheckbox.Location = new System.Drawing.Point(281, 191);
            this.drawCardCheckbox.Name = "drawCardCheckbox";
            this.drawCardCheckbox.Size = new System.Drawing.Size(96, 17);
            this.drawCardCheckbox.TabIndex = 4;
            this.drawCardCheckbox.Text = "Remove Cards";
            this.drawCardCheckbox.UseVisualStyleBackColor = true;
            this.drawCardCheckbox.CheckedChanged += new System.EventHandler(this.drawCardCheckbox_CheckedChanged);
            // 
            // ShuffleCoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 219);
            this.Controls.Add(this.drawCardCheckbox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.shownWord);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShuffleCoreForm";
            this.Text = "ShuffleCore";
            this.Load += new System.EventHandler(this.ShuffleCore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label shownWord;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.CheckBox drawCardCheckbox;
    }
}
