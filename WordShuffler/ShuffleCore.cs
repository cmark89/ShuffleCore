using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;

namespace WordShuffler
{
    public static class ShuffleCore
    {
        //Stores a list of all words in the deck (base)
        static List<string> wordDeck;

        //Stores a list of all words, from which words will be removed (current session)  
        static List<string> currentWordDeck;

        //Private field which stores the index of the displayed word
        private static int _displayedWordIndex;

        //This property wraps the previous field, and updates the shown text whenever it changes
        public static int displayedWordIndex
        {
            get
            {
                return _displayedWordIndex;
            }
            set
            {
                _displayedWordIndex = value;
                SetLabelText(_displayedWordIndex);
            }
        }

        //Timer for the change word event.
        static System.Windows.Forms.Timer timer;

        //How many milliseconds the displayed word will be shown for.
        static int spinSpeed; 
                       
        //This bool stores whether the words are spinning or not.  Used to prevent DATA IMPLOSION 
        public static bool spinning = false;

        //The color displayed when the spinning is active
        public static Color spinningColor = Color.Black;

        //The color displayed when the spinning is stopped
        public static Color stoppedColor = Color.Red;

        //This stores whether or not the drawn card should be discarded or not.
        public static bool discardDrawnCards = true;
     
     
        public static void Start()
        {
            //Initialize variables here
            spinSpeed = 80;

            wordDeck = new List<string>();
            currentWordDeck = new List<string>();

            //Open the text file.
            ReadTextFile("wordList.txt");

            if(currentWordDeck.Count > 0)
            {
                displayedWordIndex = 0;
            }
        }

        public static void ReadTextFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine("File read.");
                    string words = sr.ReadToEnd();
                    Console.WriteLine(words);
                    PrepareWordDeck(words);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File could not be read.\n" + e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        public static void PrepareWordDeck(string wordList)
        {
            string[] words = wordList.Split(',');
            wordDeck = new List<string>();
            for(int i = 0; i < words.Length; i++)
            {
                
                words[i] = words[i].Trim();
                wordDeck.Add(words[i]);
                Console.WriteLine(words[i]);
            }
            
            currentWordDeck = new List<string>(wordDeck);
            ShuffleWordDeck(currentWordDeck, 100);
        }
     
        public static void ShuffleWordDeck(List<string> deck, int timesToShuffle)
        {
            Random rand = new Random();
            int index1;
            int index2;    
     
            for(int i = 0; i < timesToShuffle; i++)
            {
                //Randomize the indexes
                index1 = rand.Next(0, deck.Count);    
                index2 = rand.Next(0, deck.Count);            
                   
                //Swap the indexes
                string tempString = deck[index1];
                deck[index1] = deck[index2];
                deck[index2] = tempString;
            }
        }


        public static void DisplayNextWord()
        {
            if (displayedWordIndex < currentWordDeck.Count - 1)
            {
                displayedWordIndex++;
            }
            else
            {
                displayedWordIndex = 0;
            }
        }
     
        public static void DisplayNextWord(object source, EventArgs e)
        {
            DisplayNextWord();
        }
     
     
        public static void StartWordSpin()
        {
            if (spinning)
                return;

            if(currentWordDeck.Count == 0)
            {
                ResetDeck();
            }

            ShuffleWordDeck(currentWordDeck, 25);
            
            timer = new System.Windows.Forms.Timer();
            timer.Interval = spinSpeed;
            timer.Tick += new EventHandler(DisplayNextWord);

            timer.Enabled = true;
            spinning = true;

            Program.form.SetLabelColor(spinningColor);
        }
     
        public static void StopWordSpin()
        {
            if (spinning == false)
                return;

            spinning = false;
            if(timer != null)
                timer.Enabled = false;

            timer = null;
            //DisplayNextWord();
            Program.form.SetLabelColor(stoppedColor);

            if(discardDrawnCards)
                currentWordDeck.RemoveAt(displayedWordIndex);
        }
     
        public static void ResetDeck()
        {
            currentWordDeck = new List<string>(wordDeck);
            displayedWordIndex = 0;
            ShuffleWordDeck(currentWordDeck, 100);
        }
     
        public static void SetLabelText(int index)
        {
            Program.form.SetLabelText(currentWordDeck[index]);
        }

    }
}

