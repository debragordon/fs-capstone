using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChickChick.Models
{
    public class WaitingStudent
    {
        [Key]
        public int Id { get; set; }
        public virtual Room Room { get; set; }
        public virtual Student Student { get; set; }
        public int Position { get; set; }
    }
}