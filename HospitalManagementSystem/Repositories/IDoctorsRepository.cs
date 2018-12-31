using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface IDoctorsRepository
    {

        IEnumerable<Doctor> GetDoctors();

        IEnumerable<Patient> GetPatients(int id);

        Doctor GetDoctor(int id);

        Doctor AddDoctor(Doctor doctor);

        void UpdateDoctor(int id, Doctor doctor);

        void DeleteDoctor(int id);

    }
}
