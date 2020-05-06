using System;
using System.Collections.Generic;

namespace CharacterApp
{
    public class Characters
    {
        public string Name { private set; get; }

        public int MinScore { private set; get; }

        public int MaxScore { private set; get; }

        public int MarvelAPIID { get; set; }

        public Characters(string name, int minScore, int maxScore, int marvelID)
        {
            Name = name;

            MinScore = minScore;
            MaxScore = maxScore;

            MarvelAPIID = marvelID;


        }

        static Characters()
        {
            All = new List<Characters>
            {
                // Part 1. Getting Started with XAML
                new Characters("Super-Skrull",-100,-6,1009639),
                new Characters("Mysterio",-5,-1, 1009464),
                new Characters("Iron Man",0,5,1009368),
                new Characters("SpiderMan",6,100, 1009610),
            };
        }

        public static IList<Characters> All { private set; get; }
    }
}
