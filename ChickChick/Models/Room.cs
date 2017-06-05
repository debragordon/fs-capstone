using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChickChick.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int OccupancyMax { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<WaitingStudent> WaitingStudents { get; set; }
    }
}