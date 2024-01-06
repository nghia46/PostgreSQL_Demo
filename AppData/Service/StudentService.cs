using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Service
{
    public class StudentService(AppDbContext dbContext) : ServiceBase<Student>(dbContext)
    {
        // Additional methods or logic specific to the Person entity can be added here.
    }
}
