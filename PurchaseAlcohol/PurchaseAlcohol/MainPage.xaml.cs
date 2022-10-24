using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PurchaseAlcohol
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        DatePicker datePicker = new DatePicker
        {
            MinimumDate = new DateTime(1920, 1, 1),
            MaximumDate = new DateTime(2023, 12, 31),
            Date = new DateTime(2018, 6, 21)
        };

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var today = DateTime.Today;
            var birthdate = pickedAge.Date;

            var age = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-age)) age--;

            if(!String.IsNullOrWhiteSpace(Inp_age.Text))
            {
                int typedAge = Int32.Parse(Inp_age.Text);
                age = typedAge;
            }

            if(today == birthdate && String.IsNullOrWhiteSpace(Inp_age.Text))
            {
                Lbl_Years.Text = "You must enter a birthdate or an age to find out when you can legally buy alcohol";
            }
            else if(age >= 21)
            {
                Lbl_Years.Text = $"You are {age} years old. Congratulations you can legally buy alcohol";
                Inp_age.Text = "";
                pickedAge.Date = today;
            }
            else
            {
                int waiting = 21 - age;
                Lbl_Years.Text = $"You are {age} years old. You must wait {waiting} years before you can legally buy alcohol. ";
                Inp_age.Text = "";
                pickedAge.Date = today;
            }

            
        }
    }
}
