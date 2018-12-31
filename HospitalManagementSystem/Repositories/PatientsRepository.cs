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
    public class PatientsRepository : IPatientsRepository
    {
        private readonly HospitalContext db;

        public PatientsRepository(HospitalContext db)
        {
            this.db = db;
        }

        public Patient AddPatient(Patient patient)
        {
            patient.Id = db.Patients.Count();

            if (patient.DoctorId != null)
            {
                var doctor = db.Doctors.FirstOrDefault(d => d.Id == patient.DoctorId);
                patient.Doctor = doctor;
                doctor.Patients.Add(patient);
            }

            if (patient.NurseId != null)
            {
                var nurse = db.Nurses.FirstOrDefault(d => d.Id == patient.NurseId);
                patient.Nurse = nurse;
                nurse.Patients.Add(patient);
            }

            if (patient.RoomId != null)
            {
                var room = db.Rooms.FirstOrDefault(d => d.Id == patient.RoomId);
                patient.Room = room;
                room.Patients.Add(patient);
            }
            
            db.Patients.Add(patient);

            db.SaveChanges();

            return patient;
        }

        public void AdmitToHospital(int patientId)
        {
            var patient = GetPatient(patientId);

            if (patient == null)
                throw new EntityNotFoundException<Patient>(patientId);

            patient.Admitted = true;
            patient.DateAdmitted = DateTime.Now;
            
            db.SaveChanges();
        }

        public void DischargeFromHospital(int patientId)
        {
            var patient = GetPatient(patientId);

            if (patient == null)
                throw new EntityNotFoundException<Patient>(patientId);

            patient.Admitted = false;
            patient.DateDischarged = DateTime.Now;

            var days = (patient.DateDischarged - patient.DateAdmitted).Value.Days;
            // normal - icu - theatre
            var cost = (patient.Room.Type == "normal") ? 20 : (patient.Room.Type == "icu") ? 100 : 1000;
            
            patient.Bill = cost * days;

            db.SaveChanges();
        }

        public void DeletePatient(int patientId)
        {
            var patient = GetPatient(patientId);
            if (patient != null)
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public Patient GetPatient(int patientId)
        {
            return db.Patients.FirstOrDefault(p => p.Id == patientId);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return db.Patients.AsNoTracking().ToList();
        }

        public void UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = GetPatient(id);

            if (patient == null)
                throw new EntityNotFoundException<Patient>(id);

            patient.Name = updatedPatient.Name;
            patient.Mobile = updatedPatient.Mobile;
            patient.Address = updatedPatient.Address;
            patient.Gender = updatedPatient.Gender;
            patient.Disease = updatedPatient.Disease;
            patient.Admitted = updatedPatient.Admitted;
            patient.DateAdmitted = updatedPatient.DateAdmitted != null ? updatedPatient.DateAdmitted : patient.DateAdmitted;
            patient.DateDischarged = updatedPatient.DateDischarged != null ? updatedPatient.DateDischarged  : patient.DateDischarged;
            patient.Bill = updatedPatient.Bill;
            patient.DoctorId = db.Doctors.Count(d => d.Id == updatedPatient.DoctorId) >= 1 ? updatedPatient.DoctorId : null;
            patient.NurseId = db.Nurses.Count(d => d.Id == updatedPatient.NurseId) >= 1 ? updatedPatient.NurseId : null;
            patient.RoomId = db.Rooms.Count(d => d.Id == updatedPatient.RoomId) >= 1 ? updatedPatient.RoomId : null;
            
            db.SaveChanges();
        }        

    }
}