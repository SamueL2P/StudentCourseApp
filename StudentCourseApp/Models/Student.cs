using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCourseApp.Models
{
    public class Student
    {
        public virtual int Id { get; set; }

        [Required]
        [NameValidator]
        public virtual string Name { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public virtual int Age { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        public virtual Course Course { get; set; }
    }
}