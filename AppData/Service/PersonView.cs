using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class PersonView
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public int FamilyNumber { get; set; }
    }
}
