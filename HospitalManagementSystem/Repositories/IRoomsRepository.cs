using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IRoomsRepository
    {

        IEnumerable<Room> GetRooms();

        Room GetRoom(int id);

        Room AddRoom(Room room);

        void UpdateRoom(int id, Room nurse);

        void DeleteRoom(int id);

    }
}
