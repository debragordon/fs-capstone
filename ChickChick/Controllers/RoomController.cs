using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChickChick.DAL.Interfaces;
using ChickChick.DAL.Repos;
using ChickChick.Models;

namespace ChickChick.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void AddNewRoom(Room roomNew)
        {
            _roomRepository.AddNewRoom(roomNew);
        }

        public void DeleteSingleRoom(int id)
        {
            _roomRepository.DeleteSingleRoom(id);
        }

        public void EditRoom(Room roomEdit)
        {
            _roomRepository.EditRoom(roomEdit);
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Room GetSingleRoom(int id)
        {
            return _roomRepository.GetSingleRoom(id);
        }
    }
}
