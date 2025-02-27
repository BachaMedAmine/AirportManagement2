// See https://aka.ms/new-console-template for more information
using AM.Core.Domaine;

//Console.WriteLine("Hello, World!");
Plane p = new();

PlaneType pt = PlaneType.Boing;

Plane p1 = new(pt, 15, DateTime.Now);

p.Capacity = 14;
p.ManufactureDate = DateTime.Now;


Passenger p2 = new();
Staff staff = new();
Traveller traveller = new();
//p2.CheckProfile();
//staff.CheckProfile();
//traveller.CheckProfile();
int calculatedAge = 0;
p2.GetAge(new DateTime(2000, 3, 6), calculatedAge);
Console.WriteLine($"age before modification is {calculatedAge}");

p2.BirthDate = new DateTime(2000,3,6);
//Console.WriteLine($"age before modification is {p2.Age}");

p2.GetAge(p2);
Console.WriteLine($"age after modification is {p2.Age}");
//Console.WriteLine(p2.GetPassengerType());
//Console.WriteLine(staff.GetPassengerType());
//Console.WriteLine(traveller.GetPassengerType());