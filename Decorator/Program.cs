using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create XmasTree and two Decorators
            XmasTree c = new XmasTree();
            BeautifyXmasTree d1 = new BeautifyXmasTree();
            EnlightenXmasTree d2 = new EnlightenXmasTree();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class Component
    {
        public abstract void Operation();
    }

    // "XmasTree"
    class XmasTree : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Created the Christmas tree!");
        }
    }
    // "Decorator"
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    // "BeautifyXmasTree"
    class BeautifyXmasTree : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "Tree is decorated now.";
            Console.WriteLine("Christmas tree is now beautiful!");
        }
    }

    // "EnlightenXmasTree" 
    class EnlightenXmasTree : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("Let there be beautiful colors!");
        }

        void AddedBehavior()
        {
            Random random = new Random();
            int color = random.Next(0, 10);
            if (color < 3)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (color < 6)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (color < 9)
                Console.ForegroundColor = ConsoleColor.Magenta;
        }
    }
}
