using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XamarinFileReadWrite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            bool result = true;
            Person temp = new Person();

            temp = await App.FileHandler.ReadFromJsonFile();

            temp.PersonDetail.Add(new PersonDetails()
            {
                Name = newName.Text,
                Age = Convert.ToInt32(newAge.Text),
                Gender = newGender.Text
            });

            result = await App.FileHandler.WriteToJsonFile(temp);

            if (result == true)
                await DisplayAlert("Information", "Successfully Added Person", "OK");
            else
                await DisplayAlert("Error", "Error in Adding Person", "OK");
        }

        private async void btnRefresh_Clicked(object sender, EventArgs e)
        {
            Person temp = new Person();
            temp = await App.FileHandler.ReadFromJsonFile();
            if (temp.PersonDetail.Count == 0)
            {
                await DisplayAlert("Information", "No Record to be shown", "OK");
            }
            else
            {
                
                lstDisplay.ItemsSource = temp.PersonDetail;
            }

        }
    }
}
