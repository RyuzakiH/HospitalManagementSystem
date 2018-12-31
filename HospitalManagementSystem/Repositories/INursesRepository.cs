using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Repositories
{
    public interface INursesRepository
    {

        IEnumerable<Nurse> GetNurses();

        Nurse GetNurse(int id);

        Nurse AddNurse(Nurse nurse);

        void UpdateNurse(int id, Nurse nurse);

        void DeleteNurse(int id);

    }
}
