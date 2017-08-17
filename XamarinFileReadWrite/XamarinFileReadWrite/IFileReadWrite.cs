using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFileReadWrite
{
    public interface IFileReadWrite
    {
        Task<bool> WriteToFile(string text);
        Task<string> ReadFromFile();
    }
}
