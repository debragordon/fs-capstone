﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;

namespace ChickChick.DAL.Repos
{
    public class StudentRepository : IStudent
    {
        public void AddNewStudent(Student roomNew)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleStudent(int id)
        {
            throw new NotImplementedException();
        }

        public void EditStudent(Student rooEdit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents(int roomId)
        {
            throw new NotImplementedException();
        }

        public Room GetSingleStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}