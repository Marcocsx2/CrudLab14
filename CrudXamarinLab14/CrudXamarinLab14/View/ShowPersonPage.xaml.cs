using CrudXamarinLab14.Models;
using CrudXamarinLab14.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudXamarinLab14.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPersonPage : ContentPage
    {
        PersonService services;
        public ShowPersonPage()
        {
            InitializeComponent();
            services = new PersonService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showPerson();
        }

        private void showPerson()
        {
            var res = services.GetAllPerson().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddPerson());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                PersonModel obj = (PersonModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddPerson(obj));
                        break;
                    case "Delete":
                        services.DeletePerson(obj);
                        showPerson();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}