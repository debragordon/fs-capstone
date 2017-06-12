using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;
using System.Data.Entity.Migrations;

namespace ChickChick.DAL.Repos
{
    public class StudentRepository : IStudentRepository
    {
        readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext connection)
        {
            _context = connection;
        }

        public void AddNewStudent(Student studentNew)
        {
            _context.Students.Add(studentNew);
            _context.SaveChanges();
        }

        public void DeleteSingleStudent(int id)
        {
            var deleteThis = _context.Students.Find(id);
            _context.Students.Remove(deleteThis);
            _context.SaveChanges();

        }

        public void EditStudent(Student studentEdit)
        {
            _context.Students.AddOrUpdate(studentEdit);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents(int roomId)
        {
            return _context.Students.Where(x => x.Room.Id == roomId);
        }

        public Student GetSingleStudent(int id)
        {
            return _context.Students.Find(id);
        }
    }
}