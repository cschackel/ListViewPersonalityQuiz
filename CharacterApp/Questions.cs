using System;
using System.Collections.Generic;

namespace CharacterApp
{
    public class Questions
    {
        public Questions(string text, int posScore, int negScore)
        {

            //Type = type;
            Text = text;
            TrueValue = posScore;
            FalseValue = negScore;
        }

        //public Type Type { private set; get; }

        public string Text { private set; get; }

        public int  TrueValue { private set; get; }

        public int  FalseValue { private set; get; }

        static Questions()
        {
            All = new List<Questions>
            {
                // Part 1. Getting Started with XAML
                new Questions("You want to kill people",
                                      -5,5),
                new Questions("Are you a scientist?",
                                      2,-2),
                new Questions("Is your uncle named Ben?",
                                      5,-5),
                new Questions("Are you kind of mean?",
                                      -2,2)
            };
        }

        public static IList<Questions> All { private set; get; }
    }
    
}

