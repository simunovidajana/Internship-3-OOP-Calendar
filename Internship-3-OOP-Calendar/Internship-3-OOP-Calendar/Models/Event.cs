using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP_Calendar.Models
{
    public class Event
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> ParticipantsEmails { get; private set; }

        public Event()
        {
            Id = Guid.NewGuid();
            ParticipantsEmails = new List<string>();
        }

        public void AddParticipants(Person person)
        {
            ParticipantsEmails.Add(person.Email);
            person.AddAttendance(this.Id, true);
        }
    }
}
