using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;
using ShuffleCore.Properties;

namespace WordShuffler
{
    public static class ShuffleCore
    {
        static List<List<string>> deckCollection;

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
            spinSpeed = Settings.Default.ShuffleSpeed;
            Program.form.SetLabelFontSize(Settings.Default.FontSize);

            deckCollection = new List<List<string>>();
            wordDeck = new List<string>();
            currentWordDeck = new List<string>();

            string dir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(dir);

            //Check if the deck directory exists.
            if(!Directory.Exists(dir + "/Decks"))
            {
                CreateDeckFolder(dir);
            }

            //Read all the files in the deck folder and add each of them to the overall list of decks.


            Console.WriteLine("/Decks contains " + Directory.GetFiles(dir + "\\Decks\\").Length + " files.");
            string[] deckFiles = Directory.GetFiles(dir + "\\Decks\\");
            if (deckFiles.Length > 0)
            {
                foreach (string s in deckFiles)
                {
                    ReadTextFile(s);
                }
            }         
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(dir + "\\Decks\\Default.txt", false, Encoding.Unicode))
                    {
                        sw.WriteLine("put, words, here, separated, by commas, 日本語、でもOK");
                    }

                    ReadTextFile(dir + "\\Decks\\Default.txt");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (deckCollection.Count > 0)
            {
                //Set to zero for now
                SetCurrentDeck(0);
                Program.form.SetDropdownDefault();
            }
        }

        //Returns the simple file name given a path
        public static string GetFileName(string path)
        {
            string[] s = path.Split('\\');
            return s[s.Length - 1];
        }

        //Returns the name of just the file, sans the extension
        public static string GetDeckName(string path)
        {
            string[] s = path.Split('\\');
            string filename = s[s.Length - 1];
            s = filename.Split('.');
            return s[0];
        }


        //Creates the files directory if it does not already exist
        public static void CreateDeckFolder(string dir)
        {
            Console.WriteLine("Creating /Decks.");
            //If the deck directory doesn't exist, create it
            Directory.CreateDirectory(dir + "/Decks");

            MoveLocalTextFiles(dir);
        }


        //Move all text files into the deck folder if possible.
        public static void MoveLocalTextFiles(string dir)
        {
            
            string[] pretxts = Directory.GetFiles(dir, "*.txt", SearchOption.TopDirectoryOnly);
            Console.WriteLine("Found " + pretxts.Length + " compatible text files:");

            foreach (string s in pretxts)
            {
                //Ignore if readme or changelog
                if (s == dir + "readme.txt" || s == dir + "changelog.txt")
                {
                    Console.WriteLine(s + " found.  Ignoring.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Move file " + GetFileName(s));
                    Console.WriteLine("Source: " + dir + GetFileName(s));
                    Console.WriteLine("Destination: " + dir + "Decks\\" + GetFileName(s));
                    try
                    {
                        File.Move(s, dir + "Decks\\" + GetFileName(s));
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
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
                    AddNewDeck(PrepareWordDeck(words), GetDeckName(filePath));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("File could not be read.\n" + e.ToString());
                MessageBox.Show(e.ToString());
            }
        }


        public static List<string> PrepareWordDeck(string wordList)
        {
            char[] splitChars = new char[]{
                ',',
                '、',
                '，',
                ','
            };
            string[] words = wordList.Split(splitChars);
            List<string> newDeck = new List<string>();
            for(int i = 0; i < words.Length; i++)
            {
                //Clean the edges of the word
                words[i] = words[i].Trim();

                //Remove any newlines that may have found their way into the text
                words[i] = words[i].Replace(System.Environment.NewLine, "");
                
                if (!String.IsNullOrWhiteSpace(words[i]))
                {
                    newDeck.Add(words[i]);
                    Console.WriteLine(words[i]);
                }
                else
                    continue;
            }

            ShuffleWordDeck(newDeck, newDeck.Count);
            return newDeck;            
        }


        public static void AddNewDeck(List<string> deck, string deckName)
        {
            //Only add the deck to the display if it contains at least 1 word to show
            if (deck.Count > 0)
            {
                deckCollection.Add(deck);
                Program.form.AddDeckToSelection(deckName);
            }
        }


        public static void SetCurrentDeck(int i)
        {
            wordDeck = deckCollection[i];
            currentWordDeck = new List<string>(wordDeck);
            ShuffleWordDeck(currentWordDeck, currentWordDeck.Count);

            if (currentWordDeck.Count > 0)
                displayedWordIndex = 0;
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

            //ShuffleWordDeck(currentWordDeck, 25);
            
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

        public static void UpdateSettings()
        {
            spinSpeed = Settings.Default.ShuffleSpeed;
            Program.form.SetLabelFontSize(Settings.Default.FontSize);
            if(timer != null)
                timer.Interval = spinSpeed;
        }

    }
}

