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
    public class UsersRepository : IUsersRepository
    {
        private readonly HospitalContext db;

        public UsersRepository(HospitalContext db)
        {
            this.db = db;
        }

        public User AddUser(User user)
        {
            user.Role = user.Role.ToLower();

            if (db.Users.FirstOrDefault(
                u => u.Username == user.Username ||
                u.Password == user.Password ||
                u.PrivateId == user.PrivateId && u.Role == user.Role) != null ||
                user.Role == "patient" && db.Patients.FirstOrDefault(p => p.Id == user.PrivateId) == null ||
                user.Role == "doctor" && db.Doctors.FirstOrDefault(p => p.Id == user.PrivateId) == null ||
                user.Role == "nurse" && db.Nurses.FirstOrDefault(p => p.Id == user.PrivateId) == null)
            {
                return null;
            }
            
            user.UserId = db.Users.Count();

            db.Users.Add(user);

            db.SaveChanges();

            return user;
        }

        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsNoTracking().ToList();
        }

        public void UpdateUser(int id, User updatedUser)
        {
            var doctor = GetUser(id);

            if (doctor == null)
                throw new EntityNotFoundException<Doctor>(id);

            doctor.Username = updatedUser.Username;
            doctor.Password = updatedUser.Password;
            doctor.Role = updatedUser.Role;
            doctor.PrivateId = updatedUser.PrivateId;

            db.SaveChanges();
        }
    }
}