using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DuckDuck.DAL.Interfaces;
using DuckDuck.Models;
using DuckDuck;
using Microsoft.AspNet.Identity;

namespace DuckDuck.Controllers
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
            roomNew.Location = User.Location;
            _roomRepository.AddNewRoom(roomNew);
        }

        [HttpDelete]
        [Route("api/room/{id}")]
        public void DeleteSingleRoom(int id)
        {
            _roomRepository.DeleteSingleRoom(id);
        }

        [HttpPut]
        [Route("api/room")]
        public void EditRoom(Room roomEdit)
        {
            roomEdit.Location = User.Location;
            _roomRepository.EditRoom(roomEdit);
        }

        [HttpGet]
        [Route("api/room")]
        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms().Where(x => x.Location == User.Location);
        }

        [HttpGet]
        [Route("api/room/{id}")]
        public Room GetSingleRoom(int id)
        {
            return _roomRepository.GetSingleRoom(id);
        }
    }
}
