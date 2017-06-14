using System;

namespace DuckDuck.Controllers
{
    public class AddStudentViewModel
    {
        public DateTime Birthday { get; set; }
        
        public string FullName { get; set; }

        public int RoomId { get; set; }
    }
}