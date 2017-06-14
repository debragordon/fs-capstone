using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuckDuck.DAL.Interfaces;
using DuckDuck.Models;
using System.Data.Entity.Migrations;

namespace DuckDuck.DAL.Repos
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

            var studentsToRemove = deleteThis.Students.ToList();

            foreach (var student in studentsToRemove)
            {
                student.Room = null;
                _context.Students.AddOrUpdate(student);
            }
            _context.SaveChanges();

            _context.Rooms.Remove(deleteThis);
            _context.SaveChanges();
        }

        public void EditRoom(Room roomEdit)
        {
            var room = GetSingleRoom(roomEdit.Id);
            room.RoomName = roomEdit.RoomName;
            room.OccupancyMax = roomEdit.OccupancyMax;
            _context.Rooms.AddOrUpdate(room);
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