using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;
using System.Data.Entity.Migrations;

namespace ChickChick.DAL.Repos
{
    public class WaitingStudentRepository : IWaitingStudentRepository
    {
        readonly ApplicationDbContext _context;

        public WaitingStudentRepository(ApplicationDbContext connection)
        {
            _context = connection;
        }
        public void AddNewWaitingStudent(WaitingStudent waitingStudentNew)
        {
            _context.WaitingStudents.Add(waitingStudentNew);
            _context.SaveChanges();
        }

        public void DeleteSingleWaitingStudent(int id)
        {
            var deleteThis = _context.WaitingStudents.Find(id);
            _context.WaitingStudents.Remove(deleteThis);
        }

        public void EditWaitingStudent(WaitingStudent waitingStudentEdit)
        {
            _context.WaitingStudents.AddOrUpdate(waitingStudentEdit);
            _context.SaveChanges();
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents()
        {
            return _context.WaitingStudents;
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents(int roomId)
        {
            return _context.WaitingStudents.Where(x => x.Room.Id == roomId);
        }

        public WaitingStudent GetSingleWaitingStudent(int id)
        {
            return _context.WaitingStudents.Find(id);
        }
    }
}