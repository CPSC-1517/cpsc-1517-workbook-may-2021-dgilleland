namespace Sandbox.Inheritance
{
    public class DerivedClass : BaseClass
    {
        public DerivedClass() // If I don't specify the parameterless constructor, then it will be called automatically
        {
            CallHistory.Add("Derived Class Constructor");
        }

        public DerivedClass(int num) : base(num)
        {
            CallHistory.Add("Derived Class Constructor with int parameter");
        }
    }
}