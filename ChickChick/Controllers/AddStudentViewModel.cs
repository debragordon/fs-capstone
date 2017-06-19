using System;

namespace DuckDuck.Controllers
{
    public class AddStudentViewModel
    {
        public DateTime Birthday { get; set; }
        public bool Enrolled { get; set; }
        public string FullName { get; set; }
        public bool PaidDownPayment { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public bool WaitingList { get; set; }
        public int Rate { get; set; }
    }
}