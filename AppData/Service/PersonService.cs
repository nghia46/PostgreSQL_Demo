using Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class PersonService : ServiceBase<Person>
    {
        public PersonService(AppDbContext dbContext) : base(dbContext)
        {
        }

        // Additional methods or logic specific to the Person entity can be added here.

    }
}
