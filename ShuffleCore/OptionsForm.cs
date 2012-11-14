using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShuffleCore
{
    public partial class OptionsForm : Form
    {
        string lastShuffleSpeedInput;
        string lastFontInput;

        public OptionsForm()
        {
            InitializeComponent();   
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            shuffleSpeedTextBox.Text = Properties.Settings.Default.ShuffleSpeed.ToString();
            fontSizeTextBox.Text = Properties.Settings.Default.FontSize.ToString();

            lastFontInput = fontSizeTextBox.Text;
            lastShuffleSpeedInput = shuffleSpeedTextBox.Text;
        }


        //Verify input is numeric
        private void shuffleSpeedTextBox_TextChanged(object sender, EventArgs e)
        {
            int numeral;
            if (!Int32.TryParse(shuffleSpeedTextBox.Text, out numeral))
            {
                //The input was not a number, so ping the user and undo the input.
                shuffleSpeedTextBox.Text = lastShuffleSpeedInput;
                shuffleSpeedTextBox.SelectionStart = shuffleSpeedTextBox.Text.Length;
                shuffleSpeedTextBox.SelectionLength = 0;
            }
            else
            {
                lastShuffleSpeedInput = shuffleSpeedTextBox.Text;
            }
        }


        //Verify input is numeric
        private void fontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            int numeral;
            if (!Int32.TryParse(fontSizeTextBox.Text, out numeral))
            {
                //The input was not a number, so ping the user and undo the input.
                fontSizeTextBox.Text = lastFontInput;
                fontSizeTextBox.SelectionStart = fontSizeTextBox.Text.Length;
                fontSizeTextBox.SelectionLength = 0;
            }
            else
            {
                lastFontInput = fontSizeTextBox.Text;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShuffleSpeed = Int32.Parse(shuffleSpeedTextBox.Text);
            Properties.Settings.Default.FontSize = Int32.Parse(fontSizeTextBox.Text);
            Properties.Settings.Default.Save();

            WordShuffler.ShuffleCore.UpdateSettings();
            this.Close();
        }


    }
}
