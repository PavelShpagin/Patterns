using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure figure1 = new Rectangle(10, 20);
			IFigure figure2 = new Circle(15);
			IFigure figure3 = new Triangle(3, 4, 5);
            IFigure clonedFigure = figure1;//.Clone();
            figure1.GetInfo();
            clonedFigure.GetInfo();
            clonedFigure = figure2.Clone();
			figure2.GetInfo();
            figure1 = new Circle(5);
			clonedFigure.GetInfo();
            clonedFigure = figure3.Clone();
			figure3.GetInfo();
			clonedFigure.GetInfo();
			Console.Read();
		}
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", height, width);
        }
    }
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", radius);
        }
    }

	class Triangle : IFigure
	{
		int sideAB;
		int sideBC;
        int sideCA;
		public Triangle(int sideAB, int sideBC, int sideCA)
		{
			this.sideAB = sideAB;
			this.sideBC = sideBC;
			this.sideCA = sideCA;
		}
		public IFigure Clone()
		{
			return new Triangle(this.sideAB, this.sideBC, this.sideCA);
		}
		public void GetInfo()
		{
			Console.WriteLine("Трикутник зі сторонами AB: {0}, BC: {1}, CA: {2}", sideAB, sideBC, sideCA);
		}
	}
}
