<Query Kind="Program" />

void Main()
{
	Person me = new("Dan", 42);
	Console.WriteLine(me);
	Console.WriteLine(me.ToString());
}

// You can define other methods, fields, classes and namespaces here
public class Person // By default, a class will automatically inherit from the object class
{
	public string Name {get;set;}
	public int Age{get;set;}
	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}
	public override string ToString()
	{
		// We are changing the way the base class version of this method operates.
		return $"My name is {Name} and I am {Age} years old."; // base.ToString();
	}
}