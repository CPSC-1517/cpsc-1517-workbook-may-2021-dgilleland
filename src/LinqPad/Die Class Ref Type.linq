<Query Kind="Program" />

void Main()
{
	Die FiveSided = new Die(5);
	Die TenSided = new Die(10);
	FiveSided.Dump("Five Sided Die"); // This is an "extension method" - more on those later
	TenSided.Dump("Ten Sided Die");
	Shake(FiveSided, 3);
	Shake(TenSided, 3);
	FiveSided.Dump("Five Sided Die"); // This is an "extension method" - more on those later
	TenSided.Dump("Ten Sided Die");
}


public void Shake(Die theDie, int count)
{
	do
	{
		theDie.Roll();
		count--;
	}while(count > 0);
}
// You can define other methods, fields, classes and namespaces here
public class Die
{
	private static Random rnd = new Random();
	
	public Die() : this(6)
	{
	}
	public Die(int sides)
	{
		if (sides < 4 || sides > 20)
			throw new System.Exception("A die can only have from 4 to 20 sides");
		this.Sides = sides;
		Roll();
	}
	public readonly int Sides;
	public int FaceValue { get; private set; }

	public void Roll()
	{
		FaceValue = rnd.Next(1, 7);
	}
}





