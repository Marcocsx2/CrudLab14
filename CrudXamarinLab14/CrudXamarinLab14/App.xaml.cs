using CrudXamarinLab14.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarinLab14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ShowPersonPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
