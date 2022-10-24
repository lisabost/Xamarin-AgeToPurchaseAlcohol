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

        void Handle_Clicked(object sender, EventArgs e)
        {
            int legalAge = 21;
            var today = DateTime.Today;
            var birthdate = pickedAge.Date;

            var age = today.Year - birthdate.Year;

            var countryName = picker.SelectedItem;
            Console.WriteLine(countryName);
            switch(countryName)
            {
                case "United States":
                    legalAge = 21;
                    break;
                case "Japan":
                    legalAge = 20;
                    break;
                case "France":
                    legalAge = 18;
                    break;
                case "United Kingdom":
                    legalAge = 18;
                    break;
            }

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
            else if(age >= legalAge)
            {
                Lbl_Years.Text = $"You are {age} years old. The legal age to buy alcohol in {countryName} is {legalAge}. Congratulations you can legally buy alcohol";
                Inp_age.Text = "";
                pickedAge.Date = today;
                picker.SelectedIndex = 0;
            }
            else
            {
                int waiting = legalAge - age;
                Lbl_Years.Text = $"You are {age} years old. The legal age to buy alcohol in {countryName} is {legalAge}. You must wait {waiting} years before you can legally buy alcohol. ";
                Inp_age.Text = "";
                pickedAge.Date = today;
                picker.SelectedIndex = 0;
            }
        }
    }
}
