using DuckDuck.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckDuck.DAL.Interfaces
{
    public interface IRoomRepository
    {
        void AddNewRoom(Room roomNew);
        void EditRoom(Room roomEdit);
        Room GetSingleRoom(int id);
        IEnumerable<Room> GetAllRooms();
        void DeleteSingleRoom(int id);
    }
}
