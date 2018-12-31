using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
