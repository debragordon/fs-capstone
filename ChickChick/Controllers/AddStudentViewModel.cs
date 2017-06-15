using System;

namespace DuckDuck.Controllers
{
    public class AddStudentViewModel
    {
        public DateTime Birthday { get; set; }
        public bool Enrolled { get; internal set; }
        public string FullName { get; set; }
        public bool PaidDownPayment { get; internal set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; internal set; }
        public DateTime SubmissionDate { get; internal set; }
        public bool WaitingList { get; internal set; }
    }
}