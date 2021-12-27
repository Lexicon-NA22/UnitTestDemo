using System;

namespace UnitTestDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Account("Mikael Persbrandt", 100);
            Console.WriteLine(customer.PointBalance);

            customer.SpendPoints(200);


        }
    }
}
