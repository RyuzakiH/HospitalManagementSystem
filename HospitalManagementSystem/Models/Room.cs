using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public partial class Room
    {
        public Room()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
