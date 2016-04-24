using Hipicapp.Model.Account;
using System;

namespace Hipicapp.Model.Participant
{
    public class AthleteFindFilter
    {
        public string Dni { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public Gender? Gender { get; set; }
    }
}