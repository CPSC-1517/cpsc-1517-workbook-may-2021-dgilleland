<Query Kind="Program" />

void Main()
{
	Person me = new("Dan Gilleland", 42); // The age when you really know everything
	Student meAsAStudent = new(me, 1234567);
	CheckEquals(me, meAsAStudent.Person).Dump("Equals Check on me and student");
	CheckObjectReferenceEquals(me, meAsAStudent.Person).Dump("Reference Check on me and student");

	meAsAStudent.ChangeName("Dan Gilleland");
	CheckEquals(me, meAsAStudent.Person).Dump("Equals Check on me and student after name change");
	CheckObjectReferenceEquals(me, meAsAStudent.Person).Dump("Reference Check on me and student after name change");

	Person doplganger = new("Dan Gilleland", 42);
	CheckEquals(me, doplganger).Dump("Equals Check on me and doplganger");
	CheckObjectReferenceEquals(me, doplganger).Dump("Reference Check on me and doplganger");
}

string CheckEquals(Person firstObject, Person secondObject)
{
	if(firstObject == secondObject)
		return "The people are equal";
	else
		return "These are different people";
}

string CheckObjectReferenceEquals(Person firstObject, Person secondObject)
{
	if (object.ReferenceEquals(firstObject, secondObject))
		return "Both variables reference the same object";
	else
		return "The variables reference different objects";
}

// You can define other methods, fields, classes and namespaces here
// The record keyword is new in C# 9. It was introduced to give us something that was
// like a class but would be immutable like strings are immutable. Another thing we get
// is automatic comparison of the objects using Value semantics.
public record Person(string Name, int Age);
public class Student
{
	public Person Person {get; private set;}
	public readonly int StudentId;
	public Student(Person personalInformation, int StudentId)
	{
		Person = personalInformation;
		this.StudentId = StudentId;
	}
	public void ChangeName(string name)
	{
		this.Person = Person with {Name = name};
	}
}