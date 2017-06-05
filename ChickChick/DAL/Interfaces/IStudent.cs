using ChickChick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickChick.DAL.Interfaces
{
    public interface IStudent
    {
        void AddNewStudent(Student roomNew);
        void EditStudent(Student rooEdit);
        Room GetSingleStudent(int id);
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Student> GetAllStudents(int roomId);
        void DeleteSingleStudent(int id);
    }
}
