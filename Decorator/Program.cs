using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
			ConcreteChristmasTree c = new ConcreteChristmasTree();
			ConcreteChristmasTreeA d1 = new ConcreteChristmasTreeA();
			ConcreteChristmasTreeB d2 = new ConcreteChristmasTreeB();

            // Link decorators
            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Decorate();

            // Wait for user
            Console.Read();
        }
    }

    abstract class ChristmasTree
    {
        protected bool decorationsSet = false;
        public abstract void Decorate();
    }

    class ConcreteChristmasTree : ChristmasTree
	{
        public override void Decorate()
        {
            decorationsSet = true;
			Console.WriteLine("ConcreteChristmasTree decorated!");
        }
    }
    // "Decorator"
    abstract class Decorator : ChristmasTree
	{
        protected ChristmasTree component;
        protected string garland;

		public void SetComponent(ChristmasTree component)
        {
            this.component = component;
        }
        public override void Decorate()
        {
            if (component != null)
            {
                component.Decorate();
            }
        }
    }

    class ConcreteChristmasTreeA : Decorator
    {
		public override void Decorate()
        {
            base.Decorate();
			garland = "Red garland";
            Console.WriteLine($"{garland} set with ConcreteChristmasTreeA.Decorate()");
        }
    }

    class ConcreteChristmasTreeB : Decorator
    {
		public override void Decorate()
		{
			base.Decorate();
			garland = "Blue garland";
			Console.WriteLine($"{garland} set with ConcreteChristmasTreeA.Decorate()");
		}
    }
}
