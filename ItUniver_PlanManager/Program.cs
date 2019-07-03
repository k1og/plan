using System;
using models;
using System.Linq;

namespace ItUniver_PlanManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IStore<Event> store = new EventStore();

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

                        store.Add(evt);
                        Console.WriteLine("Done. {0} event added", AddOrdinal(store.Entities.Count()));
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
                                Console.WriteLine("{0}. Title: {1}\n", eventNumber, evnt.Title);
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
                            return num + "th";
                    }

                    switch(num % 10)
                    {
                        case 1:
                            return num + "st";
                        case 2:
                            return num + "nd";
                        case 3:
                            return num + "rd";
                        default:
                            return num + "th";
                    }

                }
    }
}
