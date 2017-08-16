using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFileReadWrite
{
    public class PersonDetails
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }

    public class Person
    {
        public List<PersonDetails> PersonDetail { get; set; }

        public Person()
        {
            PersonDetail = new List<PersonDetails>();
        }
    }
    
}
