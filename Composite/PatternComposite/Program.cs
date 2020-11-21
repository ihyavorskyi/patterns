using System;
using System.Collections.Generic;
using static System.Console;

namespace PatternComposite
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            NewCar.create("Mersedes x5", 50);
            NewCar.create("Ferrari Sergio", 30);

            string lol = "1agc";
            char kok = lol[0];
            WriteLine(Char.IsDigit(kok));

            Read();
        }
    }

    internal abstract class Equipment
    {
        protected string name;
        protected int price;

        protected Equipment(string name)
        {
            this.name = name;
        }

        public virtual void Add(Equipment equiptment)
        {
        }

        public virtual int Print()
        {
            WriteLine("Leaf\t\t" + name + " - " + price + "$");
            return price;
        }
    }

    internal class Composite : Equipment
    {
        private int fullPrice;
        private List<Equipment> equiptments = new List<Equipment>();

        public Composite(string name)
            : base(name)
        { }

        public override void Add(Equipment equiptment)
        {
            equiptments.Add(equiptment);
        }

        public override int Print()
        {
            WriteLine("\nBranch\t" + name + ":");
            for (int i = 0; i < equiptments.Count; i++)
            {
                fullPrice += equiptments[i].Print();
            }
            return fullPrice;
        }
    }

    internal class Tools : Equipment
    {
        public Tools(string name, int price)
            : base(name)
        { this.price = price; }
    }

    internal class NewCar
    {
        public static void create(string name, int x)
        {
            Equipment car = new Composite(name);

            Equipment wheels = new Composite("Wheels");
            Equipment discs = new Tools("Discs", 50 + x);
            Equipment tires = new Tools("Tires", 70 + x);
            wheels.Add(discs);
            wheels.Add(tires);
            car.Add(wheels);

            Equipment engine = new Composite("Engine");
            Equipment connectingRods = new Tools("Connecting rods", 40 + x);
            Equipment radiator = new Tools("Radiator", 100 + x);
            Equipment pump = new Tools("Pump", 100 + x);
            engine.Add(connectingRods);
            engine.Add(radiator);
            engine.Add(pump);
            car.Add(engine);

            Equipment body = new Composite("Body");
            Equipment electricity = new Tools("electricity", 50 + x);
            Equipment seats = new Tools("Seats", 150 + x);
            body.Add(seats);
            body.Add(electricity);
            car.Add(engine);

            int fullPrice = car.Print();
            WriteLine("\n" + name + " price - " + fullPrice +
                "$\n------------------------");
        }
    }
}