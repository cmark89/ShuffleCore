﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordShuffler
{
    public partial class ShuffleCoreForm : Form
    {
        public ShuffleCoreForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ShuffleCore.StartWordSpin();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            ShuffleCore.StopWordSpin();
        }

        public void SetLabelText(string text)
        {
            shownWord.Text = text;
            int x = this.Width;
            int labelX = shownWord.Width;

            shownWord.Left = (x / 2) - (labelX / 2);
        }

        public void SetLabelColor(Color color)
        {
            shownWord.ForeColor = color;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetLabelColor(ShuffleCore.spinningColor);
            
            ShuffleCore.ResetDeck();
        }

        private void ShuffleCore_Load(object sender, EventArgs e)
        {

        }

        private void drawCardCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ShuffleCore.discardDrawnCards = drawCardCheckbox.Checked;
        }
    }
}