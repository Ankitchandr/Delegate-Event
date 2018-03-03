using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDelegateExample
{
    class DelegateEventDemo
    {

        public delegate void Transformer(int x);
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            DelegateEventDemo obj = new DelegateEventDemo();
            obj.eventDelegateCall();
            Console.ReadLine();

        }

        /// <summary>
        ///  This method is used for finding the area of square
        /// </summary>
        /// <param name="x"></param>
        static void square(int x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateEventDemo));
            log.Info("Area of Square = "+ x*x);
        }
        /// <summary>
        /// This method is used for finding the area of cube
        /// </summary>
        /// <param name="x"></param>
        static void cube(int x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateEventDemo));
            log.Info("Area of cube = " + x*x*x);
        }
/// <summary>
/// Enter valid number except Zero
/// </summary>
        public void eventDelegateCall()
        {
            
            lebal:
            Console.WriteLine("enter one numbeer");
            int i = Convert.ToInt32(Console.ReadLine());
            if (i == 0)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(typeof(DelegateEventDemo));
                log.Error("Zero is not valid");
                goto lebal;

            }
            Transformer t;
            t = square;
            t += cube;
            t.Invoke(i);
            notificationMethod obj = new notificationMethod();
            obj.transformerEvent += usere1.xhandler;
            obj.transformerEvent += usere2.yhandler;
            obj.notifyOnCell(i);

        }

    }

    class notificationMethod
    {
        public DelegateEventDemo.Transformer transformerEvent;
        public void notifyOnCell(int x)
        {
            if (transformerEvent != null)
            {
                transformerEvent(x);
            }
        }

    }
    /// <summary>
    /// notify by user1
    /// </summary>
    class usere1
    {
        public static void xhandler(int x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(usere1));
            log.Info("Event received by user1 object");
        }
    }
    /// <summary>
    /// notify by user2
    /// </summary>
    class usere2
    {
        public static void yhandler(int x)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(usere2));
            log.Info("Event received by user2 object");
        }
    }
}
