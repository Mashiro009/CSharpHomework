using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag;
            Shape myShape;
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.Triangle      2.Circle");
            Console.WriteLine("3.Square        4.Rectangle");
            Console.WriteLine("---------------------------");
            Console.Write("请选择一种图形:");
            flag = Int32.Parse(Console.ReadLine());
            while(flag<1||flag>4)
            {
                Console.Write("请重新输入:");
                flag = Int32.Parse(Console.ReadLine());
            }

            switch (flag)
            {
                case 1:
                    myShape = ShapeFactory.createShape("Triangle");
                    myShape.showArea();
                    break;
                case 2:
                    myShape = ShapeFactory.createShape("Circle");
                    myShape.showArea();
                    break;
                case 3:
                    myShape = ShapeFactory.createShape("Square");
                    myShape.showArea();
                    break;
                case 4:
                    myShape = ShapeFactory.createShape("Rectangle");
                    myShape.showArea();
                    break;
            }


        }
    }
    abstract public class Shape
    {
        abstract public void showArea();//显示面积
        abstract public void setElement();//设置图形的元素
        abstract public bool isExist();//检验图形是否存在
    }

    public class ShapeFactory
    {
        public static Shape createShape(string str)
        {
            Shape shape = null;
            if(str.Equals("Triangle"))
            {
                shape = new Triangle();
            }
            else if(str.Equals("Rectangle"))
            {
                shape = new Rectangle();
            }
            else if(str.Equals("Circle"))
            {
                shape = new Circle();
            }
            else if(str.Equals("Square"))
            {
                shape = new Square();
            }
            return shape;
        }
    }

    public class Square:Shape
    {
        private double a;
        public Square()
        {
            setElement();
            while (!isExist())
            {
                Console.WriteLine("你输入的正方形不存在，请重新输入");
                setElement();
            }
        }
        public override void setElement()
        {
            Console.Write("请输入正方形的一条边：");
            this.a = double.Parse(Console.ReadLine());
            //throw new NotImplementedException();
        }
        public override bool isExist()
        {
            if (a > 0)
                return true;
            else
                return false;
            //throw new NotImplementedException();
        }
        public override void showArea()
        {
            Console.WriteLine("正方形的面积：" + a * a);
            //throw new NotImplementedException();
        }
    }

    public class Rectangle:Shape
    {
        //矩形的两条边
        private double a, b;
        public Rectangle()
        {
            setElement();
            while (!isExist())
            {
                Console.WriteLine("你输入的矩形不存在，请重新输入");
                setElement();
            }
        }
        public override void setElement()
        {
            Console.Write("请输入矩形的一条边：");
            this.a = double.Parse(Console.ReadLine());
            Console.Write("请输入矩形的一条边：");
            this.b = double.Parse(Console.ReadLine());
            //throw new NotImplementedException();
        }
        public override bool isExist()
        {
            if (a > 0 && b > 0)
                return true;
            else
                return false;
            //throw new NotImplementedException();
        }
        public override void showArea()
        {
            Console.WriteLine("矩形的面积：" + a * b);
            //throw new NotImplementedException();
        }
    }

    public class Circle:Shape
    {
        //半径
        private double radius;
        public Circle()
        {
            setElement();
            while (!isExist())
            {
                Console.WriteLine("你输入的圆形不存在，请重新输入");
                setElement();
            }
        }
        public override void setElement()
        {
            //throw new NotImplementedException();
            Console.Write("请输入圆形的半径：");
            this.radius = double.Parse(Console.ReadLine());
        }
        public override bool isExist()
        {
            //throw new NotImplementedException();
            if (radius > 0)
                return true;
            else
                return false;
        }
        public override void showArea()
        {
            const double PI = 3.1415926;
            Console.WriteLine("圆形的面积:" + PI * radius * radius);
            //throw new NotImplementedException();
        }
    }

    public class Triangle:Shape
    {
        //三条边
        private double a, b, c;

        public Triangle()
        {
            setElement();
            while(!isExist())
            {
                Console.WriteLine("你输入的三角形不存在，请重新输入");
                setElement();
            }
        }

        //检验三条边是否能构成三角形
        public override bool isExist()
        {
            if ((a > 0) && (b > 0) && (c > 0) && (a + b > c) && (a + c > b) && (b + c > a)) 
                return true;
            else
                return false;
        }

        //设置三角形的三条边
        public override void setElement()
        {
            Console.Write("请输入三角形的一条边：");
            this.a = double.Parse(Console.ReadLine());
            Console.Write("请输入三角形的一条边：");
            this.b = double.Parse(Console.ReadLine());
            Console.Write("请输入三角形的一条边：");
            this.c = double.Parse(Console.ReadLine());
        }
        
        //展示三角形的面积
        public override void showArea()
        {
            double cosi = (b * b + c * c - a * a) / (2 * b * c);
            double sini = Math.Sqrt(1 - cosi * cosi);
            Console.WriteLine("三角形的面积："+ 0.5 * b * c * sini);
        }
    }
}
