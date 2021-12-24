using static System.Console;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var person = new Person
{
    FirstName = "Scott",
    LastName = "Hunter"
};

var otherPerson = person with { LastName = "Hanselman" };

Console.WriteLine(person);
WriteLine(otherPerson);


var originalPerson = otherPerson with { LastName = "Hunter1" };
WriteLine(originalPerson);

WriteLine($"Equals:{Equals(person, originalPerson)}");
WriteLine($"== operater:{person == originalPerson}");


