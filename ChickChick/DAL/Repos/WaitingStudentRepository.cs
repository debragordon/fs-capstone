using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;

namespace ChickChick.DAL.Repos
{
    public class WaitingStudentRepository : IWaitingStudent
    {
        public void AddNewWaitingStudent(WaitingStudent roomNew)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleWaitingStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditWaitingStudent(WaitingStudent rooEdit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents(int roomId)
        {
            throw new NotImplementedException();
        }

        public Room GetSingleWaitingStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}