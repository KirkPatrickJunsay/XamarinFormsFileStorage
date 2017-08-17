using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFileReadWrite
{
    public class FileService
    {
        IFileReadWrite fileReadWrite;

        public FileService()
        {
            fileReadWrite = Xamarin.Forms.DependencyService.Get<IFileReadWrite>();
        }

        public async Task<bool> WriteToJsonFile(Person param)
        {
            bool result = true;

            try
            {
                string serialized = JsonConvert.SerializeObject(param);
                await fileReadWrite.WriteToFile(serialized);
            }
            catch(Exception ex)
            {
                result = false;
            }

            return result;
        }

        public async Task<Person> ReadFromJsonFile()
        {
            Person deserialized = new Person();

            try
            {
                deserialized = JsonConvert.DeserializeObject<Person>(await fileReadWrite.ReadFromFile());

                if (deserialized == null)
                    deserialized = new Person();
            }
            catch(Exception ex)
            {
                deserialized = new Person();
            }

            return deserialized;
        }
    }
}
