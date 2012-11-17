namespace WordShuffler
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
            this.drawCardCheckbox = new System.Windows.Forms.CheckBox();
            this.deckSelectBox = new System.Windows.Forms.ComboBox();
            this.optionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(97, 200);
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
            this.shownWord.Location = new System.Drawing.Point(136, 82);
            this.shownWord.Name = "shownWord";
            this.shownWord.Size = new System.Drawing.Size(105, 55);
            this.shownWord.TabIndex = 2;
            this.shownWord.Text = "text";
            this.shownWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resetButton.Location = new System.Drawing.Point(292, 200);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // drawCardCheckbox
            // 
            this.drawCardCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.drawCardCheckbox.AutoSize = true;
            this.drawCardCheckbox.Checked = true;
            this.drawCardCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawCardCheckbox.Location = new System.Drawing.Point(281, 229);
            this.drawCardCheckbox.Name = "drawCardCheckbox";
            this.drawCardCheckbox.Size = new System.Drawing.Size(96, 17);
            this.drawCardCheckbox.TabIndex = 4;
            this.drawCardCheckbox.Text = "Remove Cards";
            this.drawCardCheckbox.UseVisualStyleBackColor = true;
            this.drawCardCheckbox.CheckedChanged += new System.EventHandler(this.drawCardCheckbox_CheckedChanged);
            // 
            // deckSelectBox
            // 
            this.deckSelectBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deckSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deckSelectBox.FormattingEnabled = true;
            this.deckSelectBox.Location = new System.Drawing.Point(234, 12);
            this.deckSelectBox.Name = "deckSelectBox";
            this.deckSelectBox.Size = new System.Drawing.Size(133, 21);
            this.deckSelectBox.TabIndex = 5;
            this.deckSelectBox.SelectedIndexChanged += new System.EventHandler(this.deckSelectBox_SelectedIndexChanged_1);
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(12, 12);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(66, 21);
            this.optionsButton.TabIndex = 6;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // ShuffleCoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 251);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.deckSelectBox);
            this.Controls.Add(this.drawCardCheckbox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.shownWord);
            this.Controls.Add(this.startButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShuffleCoreForm";
            this.Text = "ShuffleCore";
            this.Load += new System.EventHandler(this.ShuffleCoreForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label shownWord;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox drawCardCheckbox;
        private System.Windows.Forms.ComboBox deckSelectBox;
        private System.Windows.Forms.Button optionsButton;

    }
}

