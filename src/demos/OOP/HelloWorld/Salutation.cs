namespace HelloWorld
{
    public class Salutation
    {
        public string Greeting()
        {
            return "Hello World!";
        }

        public string Greeting(string name)
        {
            return $"Hello {name}"; // Note the use of String Interpolation
        }
    }
}
