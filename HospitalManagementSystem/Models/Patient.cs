using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Models
{
    public partial class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Disease { get; set; }
        public bool Admitted { get; set; }
        public DateTime? DateAdmitted { get; set; }
        public DateTime? DateDischarged { get; set; }
        public int? Bill { get; set; }
        public int? DoctorId { get; set; }
        public int? NurseId { get; set; }
        public int? RoomId { get; set; }
        
        public Doctor Doctor { get; set; }
        public Nurse Nurse { get; set; }
        public Room Room { get; set; }
    }
}
