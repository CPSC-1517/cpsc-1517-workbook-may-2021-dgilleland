namespace Topic.C
{
    public class Person
    {
        public string _FirstName;
        public string _LastName;
        public int _Age;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}