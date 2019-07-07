using System;
using models;
using System.Linq;
using System.Globalization;
using interfaces;
using implementations;

namespace ItUniver_PlanManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IStore<Event> store = new EventFileStore();

            var dateformat = "dd/MM/yyyy HH:mm";

            while (true) 
            {
                Console.WriteLine("1. Add event");
                Console.WriteLine("2. Show all events");
                var input = Console.ReadLine();
                if (input == "exit") 
                {
                    Console.WriteLine("Bye! Have a good time!");
                    break;
                }
                switch (input.ToLower())
                {
                    case "add":
                        var evt = new Event(); //add constructor later perhaps
                        Console.WriteLine("Enter the title");
                        evt.Title = Console.ReadLine();

                        Console.WriteLine("Give it some description");
                        evt.Description = Console.ReadLine();

                        bool invalidDate = true;
                        while (invalidDate)
                        {
                            Console.WriteLine("Enter the start date (dd/mm/yyyy hh:mm)");
                            Console.WriteLine("(To skip a date leave the input empty)");
                            var date = Console.ReadLine();
                            if (date != "") 
                            {
                                try 
                                {
                                    evt.StartDate = DateTime.ParseExact(date, dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid date format");                                    
                                }
                            }
                            else
                            {
                                invalidDate = false;                                
                            }
                            if (evt.StartDate != null)
                            {
                                invalidDate = false;
                            }
                        }
                        
                        invalidDate = true;
                        while (invalidDate && evt.StartDate != null)
                        {
                            Console.WriteLine("Enter the end date (dd/mm/yyyy hh:mm)");
                            Console.WriteLine("(To skip a date leave the input empty)");
                            var date = Console.ReadLine();
                            if (date != "") 
                            {
                                try 
                                {
                                    evt.EndDate = DateTime.ParseExact(date, dateformat, CultureInfo.CreateSpecificCulture("en-US"));
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid date format");                                    
                                }

                                if (evt.EndDate.Value != null) 
                                {
                                    if (DateTime.Compare(evt.StartDate.Value, evt.EndDate.Value) > 0) 
                                    {
                                        Console.WriteLine("Error! End time is earlier than start time");
                                    }
                                    else
                                    {
                                        invalidDate = false;
                                    }
                                }
                            }
                            else
                            {
                                invalidDate = false;
                            }
                        }
                        store.Add(evt);
                        Console.WriteLine("Well done. {0} event added", AddOrdinal(store.Entities.Count()));
                        break;
                    case "show":
                        var evts = store.Entities;
                        var eventNumber = 0;
                        Console.WriteLine("Events:\n");
                        if (evts.Count() != 0) 
                        {
                            foreach (var evnt in evts)
                            {
                                ++eventNumber;
                                 Console.WriteLine("{0}. Title: {1}\nDescription: {2}", eventNumber, evnt.Title, evnt.Description);
                                if (evnt.StartDate != null) 
                                {
                                    if (evnt.EndDate != null) 
                                    {
                                        Console.WriteLine("Date: {0}\nDuration {1} ", 
                                        DateToString(evnt.StartDate.Value), DateToString(evnt.EndDate.Value.Subtract(evnt.StartDate.Value)));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Date: {0}\n", DateToString(evnt.StartDate.Value));                                        
                                    }
                                }
                            }
                        }
                        else 
                        {
                            Console.WriteLine("No events yet");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
                
            }
            
        }
        public static string AddOrdinal(int num)
        {
            if( num <= 0 ) return num.ToString();

            switch(num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "-th";
            }

            switch(num % 10)
            {
                case 1:
                    return num + "-st";
                case 2:
                    return num + "-nd";
                case 3:
                    return num + "-rd";
                default:
                    return num + "-th";
            }
        }

        public static string DateToString(DateTime date) 
        {   
            if (date.Year - DateTime.Now.Year > 0) 
            {
                return string.Format("{0:dddd}, {1} of {0:MMMM yyyy HH:mm}", date, AddOrdinal(date.Day));
            }
                return string.Format("{0:dddd}, {1} of {0:MMMM HH:mm}", date, AddOrdinal(date.Day));
        }

        public static string DateToString(TimeSpan duration) 
        {   
            return duration.ToString(@"dd") + " day(s) " + duration.ToString(@"hh") + " hour(s) " + duration.ToString(@"hh") + " minute(s)";
        }
    }
}
