using Internship_3_OOP_Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP_Calendar
{
    public class Program
    {
        #region initialize list of persons
        public static List<Person> persons = new List<Person>
        {
            new Person("Matic", "maticmato@gmail.com")
            {
                Name = "Mato"
            },
            new Person("Iva", "iviciva@gmail.com")
            {
                Name = "Iva"
            },
            new Person("Lukci", "lukicluka@gmail.com")
            {
                Name = "Luka"
            },
            new Person("Maric", "maricmarija@gmail.com")
            {
                Name = "Marija"
            },
            new Person("Petric", "petricpetar@gmail.com")
            {
                Name = "Petar"
            },
            new Person("Maric", "maricmarko@gmail.com")
            {
                Name = "Marko"
            },
            new Person("Vitic", "viticvito@gmail.com")
            {
                Name = "Vito"
            },
            new Person("Sandric", "sandricsandra@gmail.com")
            {
                Name = "Sandra"
            },
            new Person("Tomic", "tomictomo@gmail.com")
            {
                Name = "Tomo"
            },
            new Person("Jukic", "jukiclea@gmail.com")
            {
                Name = "Lea"
            },
        };
        #endregion

        #region initialize list of events
        public static List<Event> events = new List<Event>
        {
            new Event()
            {
                Location = "Location 1",
                Name = "Event 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(4)
            },
            new Event()
            {
                Location = "Location 2",
                Name = "Event 2",
                StartDate = DateTime.Now.AddDays(4),
                EndDate = DateTime.Now.AddDays(5)
            },
            new Event()
            {
                Location = "Location 3",
                Name = "Event 3",
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddDays(6)
            },
            new Event()
            {
                Location = "Location 4",
                Name = "Event 4",
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-2)
            },
            new Event()
            {
                Location = "Location 5",
                Name = "Event 5",
                StartDate = DateTime.Now.AddDays(-7),
                EndDate = DateTime.Now.AddDays(-4)
            },
        };

        #endregion
        public static void Main()
        {
            #region Add participants on events
            var event1 = events.FirstOrDefault(x => x.Location == "Location 1");
            var event2 = events.FirstOrDefault(x => x.Location == "Location 2");
            var event3 = events.FirstOrDefault(x => x.Location == "Location 3");
            var event4 = events.FirstOrDefault(x => x.Location == "Location 4");
            var event5 = events.FirstOrDefault(x => x.Location == "Location 5");


            var person1 = persons.FirstOrDefault(x => x.Email == "maticmato@gmail.com");
            var person2 = persons.FirstOrDefault(x => x.Email == "iviciva@gmail.com");
            var person3 = persons.FirstOrDefault(x => x.Email == "lukicluka@gmail.com");
            var person4 = persons.FirstOrDefault(x => x.Email == "maricmarija@gmail.com");
            var person5 = persons.FirstOrDefault(x => x.Email == "petricpetar@gmail.com");
            var person6 = persons.FirstOrDefault(x => x.Email == "maricmarko@gmail.com");
            var person7 = persons.FirstOrDefault(x => x.Email == "viticvito@gmail.com");
            var person8 = persons.FirstOrDefault(x => x.Email == "sandricsandra@gmail.com");
            var person9 = persons.FirstOrDefault(x => x.Email == "tomictomo@gmail.com");
            var person10 = persons.FirstOrDefault(x => x.Email == "jukiclea@gmail.com");

            event1.AddParticipants(person1);
            event1.AddParticipants(person2);
            event2.AddParticipants(person3);
            event2.AddParticipants(person4);
            event3.AddParticipants(person5);
            event3.AddParticipants(person6);
            event4.AddParticipants(person7);
            event4.AddParticipants(person8);
            event5.AddParticipants(person9);
            event5.AddParticipants(person10);
            #endregion

            MainMenu();
        }

        private static void MainMenu()
        {
            var options = "\n1 - Aktivni eventi\n2 - Nadolazeci eventi\n3 - Eventi koji su zavrsili\n4 - Kreiraj event\n0 - Izađi iz programa";
            Selection(Menu(options, "", 0, 4));

            Console.ReadKey();
        }

        private static int Menu(string options, string optionally, int lowerLimit, int upperLimit)
        {
            Console.WriteLine(optionally);

            Console.WriteLine("\nIzaberite jednu od ponuđenih mogućnosti upisom broja: ");
            bool correctInput;
            int userChoice;
            do
            {
                Console.WriteLine(options);
                correctInput = int.TryParse(Console.ReadLine(), out userChoice);

            } while (correctInput == false || userChoice < lowerLimit || userChoice > upperLimit);

            return userChoice;
        }

        private static void Selection(int choice)
        {
            switch (choice)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    ShowActiveEvents();
                    break;
                case 2:
                    ShowUpcomingEvents();
                    break;
                case 3:
                    EndedEvents();
                    break;
                case 4:
                    CreateNewEvent();
                    break;
            }
        }

        private static void CreateNewEvent()
        {

            Console.WriteLine("\nOdabrali ste opciju : Kreiraj novi event. \n");
            var closeApp = "";
            do
            {
                Console.WriteLine("Jeste li sigurni da želite kreirati novi event? (DA -> nastavi/NE-> Glavni izbornik)");
                closeApp = Console.ReadLine().Trim();

            } while (closeApp != "DA" && closeApp != "NE");
            if (closeApp == "NE")
                MainMenu();

            Console.WriteLine("Izabrali ste opciju kreiraj novi event.");

            Console.WriteLine("Unesi naziv eventa : ");
            var eventName = Console.ReadLine();

            Console.WriteLine("Unesi lokaciju eventa : ");
            var eventLocation = Console.ReadLine();

            DateTime eventStartDate;
            bool correctInput;
            do
            {
                Console.WriteLine("Unesi datum pocetka eventa :");
                correctInput = DateTime.TryParse(Console.ReadLine(), out eventStartDate);
            }while (correctInput == false || eventStartDate <= DateTime.Now.Date);

            DateTime eventEndDate;
            bool correctInputEndDate;
            do
            {
                Console.WriteLine("Unesi datum kraja eventa :");
                correctInputEndDate = DateTime.TryParse(Console.ReadLine(), out eventEndDate);
            } while (correctInput == false || eventEndDate < eventStartDate);

            Console.WriteLine("Upisi sudionike: ");
            var eventParticipants = Console.ReadLine().Trim().Split(' ').ToList();

            //Pri kreaciji, za osobe koje su već postavljene kao sudionici na nekom drugom eventu koji se vremenski preklapa s novim eventom je potrebno ispisati poruku da su zauzete te na novi event dodati samo one koji su slobodni

            var newEvent = new Event();
            newEvent.Name = eventName;
            newEvent.Location = eventLocation;
            newEvent.StartDate = eventStartDate;
            newEvent.EndDate = eventEndDate;

            Person person;
            foreach (var personEmail in eventParticipants)
            {
                person = persons.FirstOrDefault(x => x.Email == personEmail);

                if (person != null)
                {
                    foreach (var personsEvent in person.Attendance.ToList())
                    {
                        
                        var searchEvent = events.FirstOrDefault(x => x.Id == personsEvent.Key);

                        if ((newEvent.StartDate > searchEvent.StartDate
                            && newEvent.StartDate < searchEvent.EndDate)
                            ||
                            ( newEvent.EndDate < searchEvent.EndDate)
                            && newEvent.EndDate > searchEvent.StartDate)
                            Console.WriteLine($"{person.Email} ne moze sudjelovati u {newEvent.Name}");
                        else
                            newEvent.AddParticipants(person);
                    }
                }
            }
            events.Add(newEvent);
            MainMenu();
        }

        private static void EndedEvents()
        {
            foreach (var eventItem in events.Where(x => x.StartDate.Date < DateTime.Today))
            {
                Console.Write($"\n\nEvent ID : {eventItem.Id}\n" +
                    $"Naziv eventa : {eventItem.Name} - " +
                    $"Lokacija eventa : {eventItem.Location} - " +
                    $"Zavrsio je prije : {Math.Round((DateTime.Now.Date - eventItem.EndDate).TotalDays, 1)} dana\n" +
                    $"Trajao je : { Math.Round((eventItem.EndDate - eventItem.StartDate).TotalHours, 1)} sati\n" +
                    $"Prisutni sudionici :  ");

                if (eventItem.ParticipantsEmails.Count() > 0)
                    foreach (var participantEmail in eventItem.ParticipantsEmails)
                    {
                        var person = persons.FirstOrDefault(x => x.Email == participantEmail);

                        if(person != null)
                        {
                            if (person.Attendance.FirstOrDefault(x => x.Key == eventItem.Id).Value == true)
                                Console.Write($"{person.Email}, ");
                            else
                                Console.Write($"{person.Email}, ");
                        }
                    }
                else
                    Console.WriteLine("Nema prisutnih sudionika");

                Console.Write($"\nNeprisutni sudionici : ");
            }

            MainMenu();
        }

        private static void ShowUpcomingEvents()
        {
            foreach (var eventItem in events.Where(x => x.StartDate.Date > DateTime.Today))
            {
                Console.Write($"\n\nEvent ID : {eventItem.Id}\n" +
                    $"Naziv eventa : {eventItem.Name} - " +
                    $"Lokacija eventa : {eventItem.Location} - " +
                    $"Pocinje za : {Math.Round((eventItem.StartDate - DateTime.Now.Date).TotalDays, 1)} dana " +
                    $"Traje: { Math.Round((eventItem.EndDate - eventItem.StartDate).TotalHours, 1)} sati\n" +
                    $"Popis sudionika : ");

                if (eventItem.ParticipantsEmails.Count() > 0)
                    foreach (var participant in eventItem.ParticipantsEmails)
                        Console.Write($"{participant}, ");
            }

            var options = "\n1 - Izbriši event\n2 - Ukloni osobe s eventa\n0 - Povratak na glavni menu";
            Selection2(Menu(options, "", 0, 2));
        }

        private static void Selection1(int choice)
        {
            switch (choice)
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    EditAttendance();
                    break;
            }
        }

        private static void Selection2(int choice)
        {
            switch (choice)
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    DeleteEvent();
                    break;
                case 2:
                    RemovePersonsFromEvent();
                    break;
            }
        }

        private static void RemovePersonsFromEvent()
        {
            Console.WriteLine("\nOdabrali ste opciju : Ukloni osobe sa eventa. \n");
            var closeApp = "";
            do
            {
                Console.WriteLine("Jeste li sigurni da želite ukloniti osobe sa eventa? (DA -> nastavi/NE-> Glavni izbornik)");
                closeApp = Console.ReadLine().Trim();

            } while (closeApp != "DA" && closeApp != "NE");
            if (closeApp == "NE")
                MainMenu();

            Console.WriteLine("Unesite id eventa kojemu želite izbrisati sudionike: ");
            var eventId = Console.ReadLine();

            var searchedEvent = events.FirstOrDefault(x => x.Id.ToString() == eventId);

            if (searchedEvent != null)
            {
                Console.WriteLine("Unesite osobe koje želite ukloniti sa eventa(odvojite osobe razmakom) : ");

                var personsToRemove = Console.ReadLine().Split(' ').ToList();
                foreach (var mail in personsToRemove)
                {
                    var person = persons.FirstOrDefault(x => x.Email == mail);
                    if (person != null)
                    {
                        if (person.Attendance.ContainsKey(searchedEvent.Id))
                        {
                            searchedEvent.ParticipantsEmails.Remove(person.Email);
                            person.Attendance.Remove(searchedEvent.Id);
                            Console.WriteLine($"Osoba {person.Email} uklonjena sa eventa");
                        }
                        else
                            Console.WriteLine($"{person.Email} nije ukljucen na event");
                    }
                }
            }
            MainMenu();
        }

        private static void DeleteEvent()
        {
            Console.WriteLine("\nOdabrali ste opciju : Izbrisi event i njegove sudionike. \n");
            var closeApp = "";
            do
            {
                Console.WriteLine("Jeste li sigurni da želite izbrisati event i njegove sudionike? (DA -> nastavi/NE-> Glavni izbornik)");
                closeApp = Console.ReadLine().Trim();

            } while (closeApp != "DA" && closeApp != "NE");
            if (closeApp == "NE")
                MainMenu();

            Console.WriteLine("Unesite id eventa koji želite izbrisati : ");
            var eventId = Console.ReadLine().Trim();

            var searchedEvent = events.FirstOrDefault(x => x.Id.ToString() == eventId);

            if (searchedEvent != null)
            {
                foreach (var participant in searchedEvent.ParticipantsEmails)
                {
                    var person = persons.FirstOrDefault(x => x.Email == participant);
                    if (person != null)
                    {
                        person.Attendance.Remove(searchedEvent.Id);
                    }
                }

                events.Remove(searchedEvent);

                Console.WriteLine("Event je izbrisan.");
            }
            Console.WriteLine("Pritisnite enter za povratak u izbornik.");
            Console.ReadKey();
            MainMenu();
        }

        private static void EditAttendance()
        {
            Console.WriteLine("\nOdabrali ste opciju : Zabiljezi neprisutnost. \n");
            var closeApp = "";
            do
            {
                Console.WriteLine("Jeste li sigurni da želite zabiljeziti neprisutnost? (DA -> nastavi/NE-> Glavni izbornik)");
                closeApp = Console.ReadLine().Trim();

            } while (closeApp != "DA" && closeApp != "NE");
            if (closeApp == "NE")
                MainMenu();

            Console.WriteLine("Unesi id eventa za koji želiš zabilježiti neprisutnost :");
            var idEvent = Console.ReadLine();

            var searchedEvent = events.FirstOrDefault(x => x.Id.ToString() == idEvent);
            var listToEditAttendance = new List<string>();
            if (searchedEvent != null)
            {
                List<string> emailsInput;
                Console.WriteLine("Unesi emailove sudionika za koje želiš zabilježiti neprisutnost.\nEmailove odvoji razmakom");    
                emailsInput = Console.ReadLine().Split(' ').ToList();

                foreach (var email in emailsInput)
                {
                    var personToEdit = persons.FirstOrDefault(x => x.Email == email);

                    if (personToEdit != null)
                    {
                        personToEdit.EditAttendance(searchedEvent.Id, false);
                        Console.WriteLine($"{personToEdit.Email} - promijenjeno na neprisutno");
                    }
                }
            }

            MainMenu();
        }

        private static void ShowActiveEvents()
        {
            foreach (var eventItem in events.Where(x => x.StartDate.Date == DateTime.Today))
            {
                Console.Write($"\n\nEvent ID : {eventItem.Id}\n" +
                    $"Naziv eventa : {eventItem.Name} - " +
                    $"Lokacija eventa : {eventItem.Location} - " +
                    $"Ends in : {Math.Round((eventItem.EndDate - DateTime.Now.Date).TotalDays,1)} days\n" +
                    $"Popis sudionika : ");

                if(eventItem.ParticipantsEmails.Count() > 0)
                    foreach(var participant in eventItem.ParticipantsEmails)
                        Console.Write($"{participant}, ");
            }

            var options = "\n1 - Zabilježi neprisutnosti\n0 - Povratak na glavni menu";
            Selection1(Menu(options, "", 0, 1));
        }

        private static void Exit()
        {
            Console.WriteLine("\nOdabrali ste opciju : 0 - Izlaz iz aplikacije.\n");
            var closeApp = "";
            do
            {
                Console.WriteLine("Jeste li sigurni da želite izaći iz aplikacije? (DA/NE)");
                closeApp = Console.ReadLine().Trim();

            } while (closeApp != "DA" && closeApp != "NE");
            if (closeApp == "DA")
                Environment.Exit(0);
            else
                MainMenu();
        }
    }
}
