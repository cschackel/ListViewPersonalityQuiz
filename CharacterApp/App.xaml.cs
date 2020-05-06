using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharacterApp
{
    public partial class App : Application
    {
        public static MarvelDataManager MDM { get; private set; }
        public App()
        {
            var hashService = DependencyService.Get<IHashService>();
            InitializeComponent();
            MDM = new MarvelDataManager(new Rest_Service(hashService));
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
