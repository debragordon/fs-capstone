using ChickChick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickChick.DAL.Interfaces
{
    public interface IRoom
    {
        void AddNewRoom(Room roomNew);
        void EditRoom(Room roomEdit);
        Room GetSingleRoom(int id);
        IEnumerable<Room> GetAllRooms();
        void DeleteSingleRoom(int id);
    }
}
