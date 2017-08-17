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
using System.Threading.Tasks;

[assembly:Xamarin.Forms.Dependency(typeof(FileReadWrite))]
namespace XamarinFileReadWrite.Droid
{
    public class FileReadWrite : IFileReadWrite
    {
        public async Task<string> ReadFromFile()
        {
            string result = string.Empty;
            TextReader reader = null;

            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, "PersonList.json");

                reader = new StreamReader(filePath);
               
                if (File.Exists(filePath))
                    result = await reader.ReadToEndAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("File Reading Error Occured",ex.InnerException);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            return result;
        }

        public async Task<bool> WriteToFile(string text)
        {
            bool result = true;
            TextWriter writer = null;
            try
            {
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, "PersonList.json");

                writer = new StreamWriter(filePath);
                await writer.WriteAsync(text);

            }
            catch(Exception ex)
            {
                throw new Exception("File Writing Error Occured",ex.InnerException);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return result;
        }
    }
}