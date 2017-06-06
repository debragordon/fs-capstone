using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChickChick.DAL.Interfaces;
using ChickChick.Models;
using System.Data.Entity.Migrations;

namespace ChickChick.DAL.Repos
{
    public class RoomRepository : IRoomRepository
    {
        readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext connection)
        {
            _context = connection;
        }

        public void AddNewRoom(Room roomNew)
        {
            _context.Rooms.Add(roomNew);
            _context.SaveChanges();
        }

        public void DeleteSingleRoom(int id)
        {
            var deleteThis = _context.Rooms.Find(id);
            _context.Rooms.Remove(deleteThis);
        }

        public void EditRoom(Room roomEdit)
        {
            _context.Rooms.AddOrUpdate(roomEdit);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms;
        }

        public Room GetSingleRoom(int id)
        {
            return _context.Rooms.Find(id);
        }
    }
}