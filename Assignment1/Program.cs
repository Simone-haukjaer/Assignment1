using System;

namespace BDSA2020.Assignment01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Predicate<int> even = Even;
        }

        public static bool Even(int i)
        {
            return i % 2 == 0;
        }
    }
}
