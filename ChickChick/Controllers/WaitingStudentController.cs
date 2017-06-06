using ChickChick.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChickChick.Models;

namespace ChickChick.Controllers
{
    public class WaitingStudentController : ApiController
    {
        private readonly IWaitingStudentRepository _waitingStudentRepository;

        public WaitingStudentController(IWaitingStudentRepository waitingStudentRepository)
        {
            _waitingStudentRepository = waitingStudentRepository;
        }

        public void AddNewWaitingStudent(WaitingStudent waitingStudentNew)
        {
            _waitingStudentRepository.AddNewWaitingStudent(waitingStudentNew);
        }

        public void DeleteSingleWaitingStudent(int id)
        {
            _waitingStudentRepository.DeleteSingleWaitingStudent(id);
        }

        public void EditWaitingStudent(WaitingStudent waitingStudent)
        {
            _waitingStudentRepository.EditWaitingStudent(waitingStudent);
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents()
        {
            return _waitingStudentRepository.GetAllWaitingStudents();
        }

        public IEnumerable<WaitingStudent> GetAllWaitingStudents(int roomId)
        {
            return _waitingStudentRepository.GetAllWaitingStudents(roomId);
        }

        public WaitingStudent GetSingleWaitingStudent(int id)
        {
            return _waitingStudentRepository.GetSingleWaitingStudent(id);
        }
    }
}
