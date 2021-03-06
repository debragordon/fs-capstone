﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DuckDuck.DAL.Interfaces;
using DuckDuck.Models;
using Microsoft.AspNet.Identity;
using DuckDuck;
using DuckDuck.Controllers;

namespace DuckDuck.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ApplicationUserManager _userManager;
        private IRoomRepository _roomRepository;

        private new ApplicationUser User => _userManager.FindById(base.User.Identity.GetUserId());

        public StudentController(IStudentRepository studentRepository, ApplicationUserManager userManager, IRoomRepository roomRepository)
        {
            _studentRepository = studentRepository;
            _roomRepository = roomRepository;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("api/student")]
        public void AddNewStudent([FromBody]AddStudentViewModel studentNew)
        {
            var student = new Student
            {
                FullName = studentNew.FullName.ToUpper(),
                Birthday = studentNew.Birthday,
                Enrolled = studentNew.Enrolled,
                WaitingList = studentNew.WaitingList,
                PaidDownPayment = studentNew.PaidDownPayment,
                Rate = studentNew.Rate,
                Room = _roomRepository.GetSingleRoom(studentNew.RoomId)
            };
            student.Location = User.Location;
            _studentRepository.AddNewStudent(student);
        }

        [HttpPut]
        [Route("api/student")]
        public void EditStudent([FromBody]UpdateStudentViewModel studentEdit)
        {
            var student = _studentRepository.GetSingleStudent(studentEdit.Id);

            student.FullName = studentEdit.FullName.ToUpper();
            student.Birthday = studentEdit.Birthday;
            student.Enrolled = studentEdit.Enrolled;
            student.WaitingList = studentEdit.WaitingList;
            student.PaidDownPayment = studentEdit.PaidDownPayment;
            student.Rate = studentEdit.Rate;
            student.Room = _roomRepository.GetSingleRoom(studentEdit.RoomId);
            student.Location = User.Location;
            _studentRepository.EditStudent(student);
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public void DeleteSingleStudent(int id)
        {
            _studentRepository.DeleteSingleStudent(id);
        }

        [HttpGet]
        [Route("api/studentsInCenter")]
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents().Where(x => x.Location == User.Location);
        }

        [HttpGet]
        [Route("api/student/room/{roomId}")]
        public IEnumerable<Student> GetAllStudents(int roomId)
        {
            return _studentRepository.GetAllStudents(roomId);
        }

        [HttpGet]
        [Route("api/student/enrolled/{roomId}")]
        public IEnumerable<Student> GetAllStudentsEnrolledInRoom(int roomId)
        {
            return _studentRepository.GetAllStudents(roomId).Where(x => x.Enrolled == true);
        }

        [HttpGet]
        [Route("api/student/enrolled")]
        public IEnumerable<Student> GetAllStudentsEnrolled()
        {
            var allStudents = _studentRepository.GetAllStudents();
            var studentsEnrolled = allStudents.Where(x => x.Location == User.Location && x.Enrolled == true);
            return studentsEnrolled;
        }

        [HttpGet]
        [Route("api/student/waiting")]
        public IEnumerable<Student> GetAllStudentsWaiting()
        {
            return _studentRepository.GetAllStudents().Where(x => x.Location == User.Location && x.WaitingList == true);
        }

        [HttpGet] 
        [Route("api/student/waiting/{roomId}")] 
        public IEnumerable<Student> GetAllStudentsWaiting(int roomId)
        {
            return _studentRepository.GetAllStudents(roomId).Where(x => x.Location == User.Location && x.WaitingList == true);
        }

        [HttpGet]
        [Route("api/student/{id}")]
        public Student GetSingleStudent(int id)
        {
            return _studentRepository.GetSingleStudent(id);
        }
    }
}
