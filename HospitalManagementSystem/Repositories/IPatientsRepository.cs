using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Repositories
{
    public interface IPatientsRepository
    {

        IEnumerable<Patient> GetPatients();

        Patient GetPatient(int id);

        Patient AddPatient(Patient oatient);

        void UpdatePatient(int id, Patient patient);

        void DeletePatient(int id);

        void AdmitToHospital(int patientId);

        void DischargeFromHospital(int patientId);

    }
}
