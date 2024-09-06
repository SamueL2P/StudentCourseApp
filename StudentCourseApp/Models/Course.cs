using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;  
using System.Web;

namespace StudentCourseApp.Models
{
    public class Course
    {
        public virtual int Id { get; set; }

        [Required]
        [NameValidator]
        [Display(Name = "Course Name")]
        public virtual string Name { get; set; }
        [Required]
        [Display(Name = "Course Duration")]
        public virtual int Duration { get; set; }
        
        public virtual Student Student { get; set; }
    }
}