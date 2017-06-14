using DuckDuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuck.DAL.Interfaces
{
    public interface IWaitingStudentRepository
    {
        void AddNewWaitingStudent(WaitingStudent waitingStudentNew);
        void EditWaitingStudent(WaitingStudent waitingStudentEdit);
        WaitingStudent GetSingleWaitingStudent(int id);
        IEnumerable<WaitingStudent> GetAllWaitingStudents();
        IEnumerable<WaitingStudent> GetAllWaitingStudents(int roomId);
        void DeleteSingleWaitingStudent(int id);
    }
}
