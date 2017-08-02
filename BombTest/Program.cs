using System;

namespace BombTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            BombTest bt = new BombTest(rand);
            bt.CalculateAverage();
        }
    }
}