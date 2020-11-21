using System;
using static System.Console;

namespace PatternState
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Behavior 1:");
            Order order1 = new Order();
            order1.Next();
            order1.Next();

            WriteLine("\nBehavior 2:");
            Order order2 = new Order();
            order2.CancelOrder();
            order2.Next();

            WriteLine("\nBehavior 3:");
            Order order3 = new Order();
            order3.Next();
            order3.CancelOrder();
            order3.Next();

            WriteLine("Behavior 1:");
            order1 = new Order();
            order1.Next();
            order1.Next();

            WriteLine("\nBehavior 2:");
            order2 = new Order();
            order2.CancelOrder();
            order2.Next();

            WriteLine("\nBehavior 3:");
            order3 = new Order();
            order3.Next();
            order3.CancelOrder();
            order3.Next();
            Console.ReadLine();
        }
    }
}