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

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            bool result = true;
            Person temp = new Person();

            temp = App.FileHandler.ReadFromJsonFile();

            temp.PersonDetail.Add(new PersonDetails()
            {
                Name = newName.Text,
                Age = Convert.ToInt32(newAge.Text),
                Gender = newGender.Text
            });

            result = App.FileHandler.WriteToJsonFile(temp);

            if (result == true)
                DisplayAlert("Information", "Successfully Added Person", "OK");
            else
                DisplayAlert("Error", "Error in Adding Person", "OK");
        }

        private void btnRefresh_Clicked(object sender, EventArgs e)
        {
            Person temp = new Person();
            temp = App.FileHandler.ReadFromJsonFile();
            if (temp.PersonDetail.Count == 0)
            {
                DisplayAlert("Information", "No Record to be shown", "OK");
            }
            else
            {
                
                lstDisplay.ItemsSource = temp.PersonDetail;
            }

        }
    }
}
