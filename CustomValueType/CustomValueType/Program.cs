using System;

namespace CustomValueType
{
    public struct Month
    {
        internal readonly byte m_value;
        public const byte MaxValue = 12;
        public const byte MinValue = 1;

        public static implicit operator Month(byte v) => new Month(v); // va retorna una instancia del objeto
        public override string ToString() => $"{m_value}";

        public Month(byte digit)
        {
            if (digit > MaxValue)
            {

                throw new ArgumentOutOfRangeException(nameof(digit), $"Value too big - Max is {MaxValue}.");
            }
            if (digit < MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(digit), $"Value too small - Min is {MinValue}.");
            }
            this.m_value = digit;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Month monthNumber = 1;
            Console.WriteLine(monthNumber.GetType() + ": " + monthNumber);
            Console.WriteLine(Month.MinValue);
            Console.WriteLine(Month.MaxValue);
        }
    }
}
