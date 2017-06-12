using ChickChick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickChick.DAL.Interfaces
{
    public interface IStudentRepository
    {
        void AddNewStudent(Student studentNew);
        void EditStudent(Student studentEdit);
        Student GetSingleStudent(int id);
        IEnumerable<Student> GetAllStudents(int roomId);
        void DeleteSingleStudent(int id);
    }
}
