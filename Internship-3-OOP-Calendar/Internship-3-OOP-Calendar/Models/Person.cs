using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP_Calendar.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public Dictionary<Guid, bool> Attendance { get; private set; }

        public Person(string surname, string email)
        {
            Surname = surname;
            Email = email;
            Attendance = new Dictionary<Guid, bool>();
        }

        public void AddAttendance(Guid id, bool isPresent)
        {
            if (id == Guid.Empty)
                Console.WriteLine("Potrebno je poslati id eventa!");
            else
                Attendance.Add(id, isPresent);
        }

        public void EditAttendance(Guid id, bool isPresent)
        {
            if (id == Guid.Empty)
                Console.WriteLine("Potrebno je poslati id eventa!");
            else
                this.Attendance[id] = isPresent;
        }
    }
}
