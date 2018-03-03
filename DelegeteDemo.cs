using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDelegateExample
{
    /// <summary>
    /// delegate decleration
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public delegate void addDelegete(int a , int b);
    public delegate string sayDelegete(string name);
    public delegate void rectDelegete(int a, int b);

    class DelegeteDemo
    {
        /// <summary>
        /// main method is calling.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            DelegeteDemo ob = new DelegeteDemo();
            ob.useDelegate();
            ob.useAnonymousDelegate();
            Rectangle re = new Rectangle();
            re.useRectDelegate();
            ob.useDelegateLambdaExp();
            Console.Read();
        }

       public void addNums(int x, int y)
        {
           log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
           log.Info("Additon of two no= " + (x+y));
        }
        public static string sayHello(string name)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("commint = ");
            return "Hello" + " " + name;
        }
        /// <summary>
        /// invoke the method with the help of delegate
        /// </summary>
        public void useDelegate()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("Delegate is used for invoking the method");
            DelegeteDemo obj = new DelegeteDemo();
            addDelegete ad = new addDelegete(obj.addNums);
            ad.Invoke(125, 50);

            sayDelegete sd = new sayDelegete(DelegeteDemo.sayHello);
            string str = sd.Invoke("Atish chandra");
            Console.WriteLine(str);
         }

        /// <summary>
        /// we use Anonymous method  through delegate  
        /// </summary>
        public void useAnonymousDelegate()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("delegate use with the help of  Anonymous class ");
            addDelegete ad = delegate (int x, int y)
            {

                Console.WriteLine("Additon of two no= " + (x + y));

            };
            ad.Invoke(125, 50);

            sayDelegete sd = delegate (string name)
            {
                return "Hello" + " " + name;
            };

            string str = sd.Invoke("Scott raj");
            Console.WriteLine(str);
           
        }


        /// <summary>
        /// we use Lambda Expresition in delegates
        /// </summary>
        public void useDelegateLambdaExp()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("delegate use with the help of Lambda Expression ");
            addDelegete ad = (int x, int y)=>
            {

                Console.WriteLine("Additon of two no= " + (x + y));

            };
            ad.Invoke(10, 50);

            sayDelegete sd =(string name)=>
            {
                return "Hello" + " " + name;
            };

            string str = sd.Invoke("Gautan raj");
            Console.WriteLine(str);

        }


       class Rectangle
        {
            public void rectArea(int width, int Height)
            {
                Console.WriteLine("Area of Rectfangle = " + (width * Height));
            }

            public void rectPerimeter(int width, int Height)
            {
                Console.WriteLine("Perimeter of Rectangle = " + 2 * (width + Height));
            }


            /// <summary>
            /// multicast delegate we use
            /// </summary>
            public void useRectDelegate()
            {
                Rectangle rect = new Rectangle();
                rectDelegete obj = new rectDelegete(rect.rectArea);
                obj += rect.rectPerimeter;
                obj.Invoke(2,3);
                Console.WriteLine();
                obj.Invoke(2, 5);
            }
        }

    }



}

