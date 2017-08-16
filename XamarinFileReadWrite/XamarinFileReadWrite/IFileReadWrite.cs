using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFileReadWrite
{
    public interface IFileReadWrite
    {
        bool WriteToFile(string text);
        string ReadFromFile();
    }
}
