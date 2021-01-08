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
    public partial class AddPerson : ContentPage
    {
        PersonService _services;
        bool _isUpdate;
        int personID;
        public AddPerson()
        {
            InitializeComponent();
            _services = new PersonService();
            _isUpdate = false;
        }

        public AddPerson(PersonModel obj)
        {
            InitializeComponent();
            _services = new PersonService();
            if (obj != null)
            {
                personID = obj.Id;
                txtNombre.Text = obj.Nombre;
                txtFechaNacimiento.Text = obj.FechaNacimiento;
                txtEstado.Text= obj.Estado;
                _isUpdate = true;
            }
        }
        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            PersonModel obj = new PersonModel();
            obj.Nombre = txtNombre.Text;
            obj.FechaNacimiento = txtFechaNacimiento.Text;
            obj.Estado = txtEstado.Text;
            if (_isUpdate)
            {
                obj.Id = personID;
                await _services.UpdatePerson(obj);
            }
            else
            {
                _services.InsertPerson(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}