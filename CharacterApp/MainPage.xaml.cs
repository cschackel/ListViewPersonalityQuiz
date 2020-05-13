using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CharacterApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        

        IList<Characters> characters;
        IList<Questions> questions;
        public Questions currentQuestion { get; set; }
        PageViewModel pvm = new PageViewModel();
        //public int pvm.currentScore { get; set; } = 0;
        public bool[] answerArray = new bool[Questions.All.Count];

        public string testValue { get; set; } = "TEST";

        public MainPage()
        {
            InitializeComponent();
            //BindingContext = this;
            /*
            if (scoreLabel != null)
            {
                //scoreLabel.BindingContext = pvm.currentScore;
            }
            */
            
            questions = Questions.All;
            characters = Characters.All;
            questionListView.ItemsSource = questions;
            /*
            if (questions.Count > 0 && characters.Count > 0)
            {
                currentQuestion = questions.First();
                mainLabel.Text = currentQuestion.Text;
            }
            else
            {
                mainLabel.Text = "No Questions";
                //disableButtons();
            }
            currentQuestion = questions.First();
            */
            pvm.currentScore = 0;

        }
        /*
        private void disableButtons()
        {
            falseBtn.IsVisible = false;
            trueBtn.IsVisible = false;
        }
        */
        /*
        private void questionChange()
        {

            int currentElement = questions.IndexOf(currentQuestion);
            if (currentElement < questions.Count - 1)
            {
                currentQuestion = questions.ElementAt(questions.IndexOf(currentQuestion) + 1);
                mainLabel.Text = currentQuestion.Text;
            }
            else
            {
                //disableButtons();
                determineCharacter();
            }
        }
        */
        /*
        private void determineCharacter()
        {
            if(age_field.Text!=null && age_field.Text!="")
            {
                int age = 0;
                
                if (int.TryParse(age_field.Text, out age))
                {
                    if(age > 80)
                    {
                        pvm.currentScore -= 10;
                    }
                    else if(age > 40)
                    {
                        pvm.currentScore += 3;
                    }
                    else if (age > 30)
                    {
                        pvm.currentScore += 2;
                    }
                    else if (age > 20)
                    {
                        pvm.currentScore += 2;
                    }
                }
            }
            if(name_field.Text!=null && name_field.Text!="")
            {
                if(name_field.Text.First()=='T'||name_field.Text.Contains("'"))
                {
                    pvm.currentScore -= 10;
                } else if (name_field.Text.First() == 'S')
                {
                    pvm.currentScore += 1;
                }
                else if (name_field.Text.First() == 'D')
                {
                    pvm.currentScore -= 3;
                }
                else if (name_field.Text.First() == 'J')
                {
                    pvm.currentScore += 3;
                }
            }
            foreach(Characters c in characters)
            {
                if(pvm.currentScore >= c.MinScore && pvm.currentScore <= c.MaxScore)
                {
                    mainLabel.Text = "You are "+ c.Name;
                }
            }
        }
        */

        /*
        public void OnTrueClick(object sender, EventArgs args)
        {
            pvm.currentScore += currentQuestion.TrueValue;
            questionChange();
        }

        public void OnFalseClick(object sender, EventArgs args)
        {
            pvm.currentScore += currentQuestion.FalseValue;
            questionChange();
        }
        */
        /*
        public void OnSwipe(Object sender, SwipedEventArgs args)
        {
            if(args.Direction == SwipeDirection.Left)
            {
                pvm.currentScore += currentQuestion.FalseValue;
                questionChange();
            }
            else if (args.Direction == SwipeDirection.Right)
            {
                pvm.currentScore += currentQuestion.TrueValue;
                questionChange();
            }
        }
        */
        private void True_Button_Clicked(object sender, EventArgs e)
        {

            var b = (Button)sender;
            var t = b.CommandParameter;
            //await DisplayAlert("T","True"+t,"OK");
            int i = 0;
            foreach(Questions q in questions)
            {
                if(q.Text.Equals(t))
                {
                    DisplayAlert("", "True", "OK");
                    answerArray[i] = true;

                }
                else
                {
                    i++;
                }
            }

            b.BackgroundColor = Xamarin.Forms.Color.Red;

            

        }

        private void False_Button_Clicked(object sender, EventArgs e)
        {
            var b = (Button)sender;
            var t = b.CommandParameter;
            //await DisplayAlert("F", "False" + t, "OK");
            int i = 0;
            foreach (Questions q in questions)
            {
                if (q.Text.Equals(t))
                {
                    //DisplayAlert("","False","OK");
                    answerArray[i] = false;
                }
                else
                {
                    i++;
                }
            }

            b.BackgroundColor = Xamarin.Forms.Color.Red;
        }

        private async void List_Submit_Button_Clicked(object sender, EventArgs e)
        {
            pvm.currentScore = 0;
            for(int i = 0; i < questions.Count; i++)
            {
                if(answerArray[i]==true)
                {
                    pvm.currentScore += questions[i].TrueValue;
                }
                else if (answerArray[i] == false)
                {
                    pvm.currentScore += questions[i].FalseValue;
                }
            }

            if (age_field.Text != null && age_field.Text != "")
            {
                int age = 0;

                if (int.TryParse(age_field.Text, out age))
                {
                    if (age > 80)
                    {
                        pvm.currentScore -= 10;
                    }
                    else if (age > 40)
                    {
                        pvm.currentScore -= 3;
                    }
                    else if (age > 30)
                    {
                        pvm.currentScore += 2;
                    }
                    else if (age > 20)
                    {
                        pvm.currentScore += 7;
                    }
                }
            }
            if (name_field.Text != null && name_field.Text != "")
            {
                if (name_field.Text.First() == 'S' || name_field.Text.Contains("'"))
                {
                    pvm.currentScore -= 10;
                }
                else if (name_field.Text.First() == 'T')
                {
                    pvm.currentScore += 1;
                }
                else if (name_field.Text.First() == 'Q')
                {
                    pvm.currentScore -= 3;
                }
                else if (name_field.Text.First() == 'P')
                {
                    pvm.currentScore += 3;
                }
            }



            foreach (Characters c in characters)
            {
                if (pvm.currentScore >= c.MinScore && pvm.currentScore <= c.MaxScore)
                {
                    await DisplayAlert(""+pvm.currentScore, c.Name + c.MarvelAPIID, "OK");
                    await displayAPIInfo(c);
                    
                    break;

                    //mainLabel.Text = "You are " + c.Name;
                }
            }

            
        }

        private async Task displayAPIInfo(Characters c)
        {
            MarvelCharacter marvelCharacter = await App.MDM.GetCharacterByID(c.MarvelAPIID);

            mainLabel.Text = "You are " + marvelCharacter.Name;
            mainDesc.Text = marvelCharacter.Description;
        }

        async private void Button_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            await DisplayAlert("","Change","OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
