using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinFileReadWrite
{
    public partial class App : Application
    {
        private static FileService _fileHandler;
        public static FileService FileHandler
        {
            get
            {
                if (_fileHandler == null)
                {
                    _fileHandler = new FileService();
                }

                return _fileHandler;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new XamarinFileReadWrite.MainPage();
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
