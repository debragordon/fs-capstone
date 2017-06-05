using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;

namespace ChickChick.DAL.Repos
{
    public class RoomRepository : IRoom
    {
        public void AddNewRoom(Room roomNew)
        {
            throw new NotImplementedException();
        }

        public void DeleteSingleRoom(int id)
        {
            throw new NotImplementedException();
        }

        public void EditRoom(Room roomEdit)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public Room GetSingleRoom(int id)
        {
            throw new NotImplementedException();
        }
    }
}