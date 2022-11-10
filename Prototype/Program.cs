using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Prototype prototype = new Triangle(1, 2,3 , 4);
            Prototype clone = prototype.Clone();
        }
    }
    abstract class Prototype
    {
        public int Id { get; private set; }
        public Prototype(int id)
        {
            Id = id;
        }
        public abstract Prototype Clone();
    }

    class Triangle : Prototype
    {
        private double side1;
        private double side2;

        private double angleBetweenSides;

        public Triangle(int id, double side1, double side2, double angleBetweenSides)
            : base(id)
        {
            this.side1 = side1;
            this.side2 = side2;
            if (angleBetweenSides >= 180) throw new ArgumentException("Angle is too big");
            this.angleBetweenSides = angleBetweenSides;
        }
        public override Prototype Clone()
        {
            return new Triangle(Id, side1, side2, angleBetweenSides);
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id)
        : base(id)
        { }
        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }

}
