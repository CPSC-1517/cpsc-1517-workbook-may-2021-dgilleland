namespace Topic
{
    public class Fraction
    {
        public Fraction(int num, int denom)
        {
            Numerator = num;
            Denominator = denom;
        }

        public int Numerator { get; }
        public int Denominator { get; }
        public Fraction Reciprocal
        {
            get
            {
                return new Fraction(Numerator, Denominator);
            }
        }
    }
}