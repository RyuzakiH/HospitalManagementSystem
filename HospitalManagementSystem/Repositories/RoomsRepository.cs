//using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using HospitalManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly HospitalContext db;

        public RoomsRepository(HospitalContext db)
        {
            this.db = db;
        }

        public Room AddRoom(Room room)
        {
            room.Id = db.Rooms.Count();

            db.Rooms.Add(room);

            db.SaveChanges();

            return room;
        }

        public void DeleteRoom(int id)
        {
            var room = GetRoom(id);
            if (room != null)
            {
                foreach (var patient in db.Patients.Where(p => p.RoomId == id))
                {
                    patient.RoomId = null;
                    patient.Room = null;
                }

                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }

        public Room GetRoom(int id)
        {
            return db.Rooms.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Room> GetRooms()
        {
            return db.Rooms.AsNoTracking().ToList();
        }

        public void UpdateRoom(int id, Room updatedRoom)
        {
            var room = GetRoom(id);

            if (room == null)
                throw new EntityNotFoundException<Nurse>(id);

            room.Type = updatedRoom.Type;

            db.SaveChanges();
        }

    }
}