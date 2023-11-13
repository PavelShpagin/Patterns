using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine, Wheels wheels)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
			Console.WriteLine("Set Wheels: ");
			wheels.GetWheels();
		}
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

	public class Mersedes : Car
	{
		public override void Info()
		{
			Console.WriteLine("Mersedes");
		}
	}

	// AbstractProductB
	public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

	public class MersedesEngine : Engine
	{
		public override void GetPower()
		{
			Console.WriteLine("Mersedes Engine");
		}
	}

	public abstract class Wheels
	{
		public virtual void GetWheels()
		{
		}
	}
	public class FordWheels : Wheels
	{
		public override void GetWheels()
		{
			Console.WriteLine("Ford Wheels");
		}
	}
	public class ToyotaWheels : Wheels
	{
		public override void GetWheels()
		{
			Console.WriteLine("Toyota Wheels");
		}
	}

	public class MersedesWheels : Wheels
	{
		public override void GetWheels()
		{
			Console.WriteLine("Mersedes Wheels");
		}
	}

	// AbstractFactory
	public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
		Wheels CreateWheels();
	}

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }

		Wheels ICarFactory.CreateWheels()
		{
			return new FordWheels();
		}
	}

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }

		Wheels ICarFactory.CreateWheels()
		{
			return new ToyotaWheels();
		}
	}

	public class MersedesFactory : ICarFactory
	{
		// from CarFactory
		Car ICarFactory.CreateCar()
		{
			return new Mersedes();
		}

		Engine ICarFactory.CreateEngine()
		{
			return new MersedesEngine();
		}

		Wheels ICarFactory.CreateWheels()
		{
			return new MersedesWheels();
		}
	}

	public class ClientFactory
    {
        private Car car;
        private Engine engine;
		private Wheels wheels;

		public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
			wheels = factory.CreateWheels();
		}

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine, wheels);
		}
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);
            client1.Run();

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();

			carFactory = new MersedesFactory();
			ClientFactory client3 = new ClientFactory(carFactory);
			client3.Run();

			Console.ReadKey();
        }
    }
}
