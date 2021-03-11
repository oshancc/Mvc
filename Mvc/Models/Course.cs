using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
}
