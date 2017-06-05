using ChickChick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickChick.DAL.Interfaces
{
    public interface IWaitingStudent
    {
        void AddNewWaitingStudent(WaitingStudent roomNew);
        void EditWaitingStudent(WaitingStudent rooEdit);
        Room GetSingleWaitingStudent(int id);
        IEnumerable<WaitingStudent> GetAllWaitingStudents();
        IEnumerable<WaitingStudent> GetAllWaitingStudents(int roomId);
        void DeleteSingleWaitingStudent(int id);
    }
}
