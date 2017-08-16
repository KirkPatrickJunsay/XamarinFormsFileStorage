using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using XamarinFileReadWrite.Droid;

[assembly:Xamarin.Forms.Dependency(typeof(FileReadWrite))]
namespace XamarinFileReadWrite.Droid
{
    public class FileReadWrite : IFileReadWrite
    {
        public string ReadFromFile()
        {
            string result = string.Empty;

            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, "ListOfPersons7.json");

                if (File.Exists(filePath))
                    result =  System.IO.File.ReadAllText(filePath);
            }
            catch(Exception ex)
            {
                throw new Exception("File Reading Error Occured");
            }

            return result;
        }

        public bool WriteToFile(string text)
        {
            bool result = true;

            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, "ListOfPersons7.json");
                System.IO.File.WriteAllText(filePath, text);

            }
            catch(Exception ex)
            {
                throw new Exception("File Writing Error Occured");
            }

            return result;
        }
    }
}