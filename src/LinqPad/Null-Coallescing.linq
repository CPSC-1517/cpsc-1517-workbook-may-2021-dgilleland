<Query Kind="Program" />

void Main()
{
	// Null coalessing operator
	Person nobody = null;
	Person somebody = nobody ?? new Person("Dan", 42);
	Console.WriteLine(somebody);
}

// You can define other methods, fields, classes and namespaces here
public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
	public Person(string name, int age)
	{
		Name = name;
		Age = age;
	}
	public override string ToString()
	{
		return $"My name is {Name} and I am {Age} years old."; // base.ToString();
	}
}