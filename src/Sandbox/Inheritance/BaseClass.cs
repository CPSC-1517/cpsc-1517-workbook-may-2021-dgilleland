using System.Collections.Generic;

namespace Sandbox.Inheritance
{
    public abstract class BaseClass
    {
        public List<string> CallHistory { get; } = new List<string>();
        public readonly double PI;
        private readonly string _Title;
        public string Title
        {
            get {return _Title;}
            init
            {
                _Title = value;
            }
        }
        private int _Number;
        public int Number
        {
            get { return _Number; }
            init 
            {
                CallHistory.Add($"Initializing {nameof(Number)} with {value}");
                _Number = value;
            }
        }

        public BaseClass()
        {
            CallHistory.Add(this.ToString());
            CallHistory.Add("Base Class Constructor");
        }

        public BaseClass(int startingValue) : this()
        {
            CallHistory.Add("Base Class Constructor with a single int parameter");
            Number = startingValue;
        }
    }
}