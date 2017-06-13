using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChickChick.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual Room Room { get; set; }
        public string Location { get; set; }
        public virtual WaitingStudent WaitingStudent { get; set; }
    }
}