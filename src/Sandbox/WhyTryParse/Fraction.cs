namespace Sandbox.WhyTryParse
{
    public class Fraction
    {
        public readonly int Numerator;
        public readonly int Denominator;
        public Fraction(int num, int denom)
        {
            Numerator = num;
            Denominator = denom;
        }
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        // I can write my own Parse and TryParse methods
        public static Fraction Parse(string input)
        {
            // Split the string based on a delimeter of /
            string[] parts = input.Split('/'); // Did you learn about the .Split method
            if(parts.Length != 2) throw new System.Exception("Invalid input");
            int first = int.Parse(parts[0]);
            int second = int.Parse(parts[1]);
            return new Fraction(first, second);
        }

        public static bool TryParse(string input, out Fraction result)
        {
            try
            {
                result = Parse(input);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}