using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple St", "Rexburg", "ID", "USA");
        Address address2 = new Address("456 Oak Ave", "Boise", "ID", "USA");
        Address address3 = new Address("789 Pine Rd", "Island Park", "ID", "USA");


        Lecture lecture = new Lecture("C# Workshop", "Learning classes", "Aug 15", "10:00 AM", address1, "Dr. Smith", 50);
        Reception reception = new Reception("Networking Gala", "Meet industry pros", "Aug 20", "6:00 PM", address2, "rsvp@company.com");
        OutdoorGathering gathering = new OutdoorGathering("Summer Picnic", "Community fun", "Aug 25", "12:00 PM", address3, "Sunny with a chance of clouds");

        Console.WriteLine("--- LECTURE EVENT ---");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("--- Lecture Marketing Message ---");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(lecture.GetShortDescription("Lecture"));
        Console.WriteLine();


        Console.WriteLine("--- RECEPTION EVENT ---");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("--- Reception Marketing Message ---");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(reception.GetShortDescription("Reception"));
        Console.WriteLine();

      
        Console.WriteLine("--- OUTDOOR GATHERING EVENT ---");
        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine();
        Console.WriteLine("--- Outdoor Gathering Marketing Message ---");
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine();
        Console.WriteLine(gathering.GetShortDescription("Outdoor Gathering"));
        Console.WriteLine();
    }
}