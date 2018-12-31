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
    public class NursesRepository : INursesRepository
    {
        private readonly HospitalContext db;

        public NursesRepository(HospitalContext db)
        {
            this.db = db;
        }

        public Nurse AddNurse(Nurse nurse)
        {
            nurse.Id = db.Nurses.Count();

            db.Nurses.Add(nurse);

            db.SaveChanges();

            return nurse;
        }

        public void DeleteNurse(int id)
        {
            var nurse = GetNurse(id);
            if (nurse != null)
            {
                foreach (var patient in db.Patients.Where(p => p.NurseId == id))
                {
                    patient.NurseId = null;
                    patient.Nurse = null;
                }

                db.Nurses.Remove(nurse);
                db.SaveChanges();
            }
        }

        public Nurse GetNurse(int id)
        {
            return db.Nurses.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<Nurse> GetNurses()
        {
            return db.Nurses.AsNoTracking().ToList();
        }

        public void UpdateNurse(int id, Nurse updatedNurse)
        {
            var nurse = GetNurse(id);

            if (nurse == null)
                throw new EntityNotFoundException<Nurse>(id);

            nurse.Name = updatedNurse.Name;

            db.SaveChanges();
        }

    }
}