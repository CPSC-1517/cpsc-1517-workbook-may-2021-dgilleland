<Query Kind="Program" />

void Main()
{
	int myAge = 42; // The age when I knew everything
	Student meAsAStudent = new("Dan Gilleland", myAge, 1234567);
	meAsAStudent.Dump("Before the name change");
	ChangeName(meAsAStudent, "Daniel Gilleland");
	meAsAStudent.Dump("After the name change");
}

public void ChangeName(Student person, string name)
{
	person.Name = name;
}

// You can define other methods, fields, classes and namespaces here
public class Student
{
	public string Name { get; set; }
	public int Age { get; set; }
	public readonly int StudentId;
	public Student(string Name, int age, int StudentId)
	{
		this.Name = Name;
		this.Age = age;
		this.StudentId = StudentId;
	}
}