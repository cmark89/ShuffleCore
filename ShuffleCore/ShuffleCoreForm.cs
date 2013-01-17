using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShuffleCore;

namespace WordShuffler
{
    public partial class ShuffleCoreForm : Form
    {
        private OptionsForm optionsForm;

        public ShuffleCoreForm()
        {
            InitializeComponent();

            optionsForm = null;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (ShuffleCore.spinning)
            {
                ShuffleCore.StopWordSpin();
                startButton.Text = "Start";
            }
            else
            {
                ShuffleCore.StartWordSpin();
                startButton.Text = "Stop";
            }
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ShuffleCore.StopWordSpin();
        }

        public void SetLabelText(string text)
        {
            shownWord.Text = text;
            int x = this.Width;
            int y = this.Height;
            int labelX = shownWord.Width;
            int labelY = shownWord.Height;

            shownWord.Left = (x / 2) - (labelX / 2);
            shownWord.Top = (y / 2) - (labelY / 2);
        }

        public void SetLabelColor(Color color)
        {
            shownWord.ForeColor = color;
        }

        public void SetLabelFontSize(int size)
        {
            shownWord.Font = new Font(shownWord.Font.FontFamily.Name, size);
            SetLabelText(shownWord.Text);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetLabelColor(ShuffleCore.spinningColor);
            
            ShuffleCore.ResetDeck();
        }

        private void drawCardCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ShuffleCore.discardDrawnCards = drawCardCheckbox.Checked;
        }

        public void AddDeckToSelection(string s)
        {
            deckSelectBox.Items.Add(s);
        }

        public void SetDropdownDefault()
        {
            deckSelectBox.SelectedIndex = 0;
        }

        private void deckSelectBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ShuffleCore.SetCurrentDeck(deckSelectBox.SelectedIndex);
            SetLabelColor(Color.Black);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            if (optionsForm == null || !optionsForm.Visible)
            {
                optionsForm = new OptionsForm();
                optionsForm.Show();
            }
            else
            {
                optionsForm.BringToFront();
            }
        }

        private void ShuffleCoreForm_Load(object sender, EventArgs e)
        {

        }

    }
}
