using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ShuffleCore;

namespace WordShuffler
{
    static class Program
    {
        public static ShuffleCoreForm form;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new ShuffleCoreForm();
            ShuffleCore.Start();
            Application.Run(form);
        }
    }
}
