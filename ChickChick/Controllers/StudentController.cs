using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;
using Microsoft.AspNet.Identity;

namespace ChickChick.Controllers
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
        public void AddNewStudent(AddStudentViewModel studentNew)
        {
            var student = new Student
            {
                FullName = studentNew.FullName,
                Birthday = studentNew.Birthday,
                Room = _roomRepository.GetSingleRoom(studentNew.RoomId)
            };
            student.Location = User.Location;
            _studentRepository.AddNewStudent(student);
        }

        [HttpDelete]
        [Route("api/student/{id}")]
        public void DeleteSingleStudent(int id)
        {
            _studentRepository.DeleteSingleStudent(id);
        }

        public void EditStudent(Student studentEdit)
        {
            _studentRepository.EditStudent(studentEdit);
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
        [Route("api/student/{id}")]
        public Student GetSingleStudent(int id)
        {
            return _studentRepository.GetSingleStudent(id);
        }
    }
}
