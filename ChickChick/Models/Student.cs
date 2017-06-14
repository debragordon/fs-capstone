using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuckDuck.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual Room Room { get; set; }
        public string Location { get; set; }
        public bool Enrolled { get; set; }
        public bool WaitingList { get; set; }
        public bool PaidDownPayment { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime StartDate { get; set; }
    }
}