using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuckDuck.Models
{
    public class WaitingStudent
    {
        [Key, ForeignKey("Student")]
        public int Id { get; set; }
        public virtual Room Room { get; set; }
        public virtual Student Student { get; set; }
        public int Position { get; set; }
    }
}