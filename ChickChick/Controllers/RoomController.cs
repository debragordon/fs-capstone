﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;
using Microsoft.AspNet.Identity;

namespace ChickChick.Controllers
{
    [Authorize]
    public class RoomController : ApiController
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ApplicationUserManager _userManager;

        private new ApplicationUser User => _userManager.FindById(base.User.Identity.GetUserId());

        public RoomController(IRoomRepository roomRepository,ApplicationUserManager userManager)
        {
            _roomRepository = roomRepository;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("api/room")]
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
        [HttpGet]
        [Route("api/room")]
        public IEnumerable<Room> GetAllRooms()
        {
            //getting students from location rooms
            //_roomRepository.GetAllRooms().Where(x => x.Location == User.Location).SelectMany(x => x.Students);

            return _roomRepository.GetAllRooms().Where(x => x.Location == User.Location);
        }

        public Room GetSingleRoom(int id)
        {
            return _roomRepository.GetSingleRoom(id);
        }
    }
}
