using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace ConsoleAppDelegateExample
{
    class GenericDelegate
    {

        log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            GenericDelegate gd = new GenericDelegate();
            gd.useGenericDelegate();
            Console.Read();
        }

        /// <summary>
        /// AddNums1 Method use for adding three no. and its return type is double
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        /// 
        public static double AddNums1(int x, float y, double z)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("AddNums1() method is used for Additon of threee diffrent data type and its return types is double");
            log.Info("Sum =");
            return  ( x + y + z); 
        }
       
        /// <summary>
        /// AddNums2 Method use for adding three no. and its no return type
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddNums2(int x, float y, double z)
        {

            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("AddNums2() method is used for Additon of threee diffrent data type and its return types is void");
            log.Info("Addition = " +(x + y + z) );
        }
        /// <summary>
        /// checkLength Method use for checking string length. and its return type is bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool checkLength(String str)
        {

            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("checkLength() method is used for checking of string length and its return types is bool");
            if (str.Length > 5)
                return true;
            return false;
        }

        /// <summary>
        /// useGenericDelegate method is used for call all the method through generic delegate. 
        /// </summary>
        public void useGenericDelegate()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(GenericDelegate));
            log.Info("if method have return Type except bool then we use Func generic deledate");
            Func<int, float, double, double> obj1 = AddNums1;
            double retust = obj1.Invoke(10, 34.5f, 12.32);
            log.Info(retust);
            log.Info("if method have return Type void then we use Action generic deledate");
            Action<int, float, double> obj2 = AddNums2;
            obj2.Invoke(4, 54.6f, 12.32);
            log.Info("if method have return Type bool then we use predicate generic deledate");
            Predicate<string> obj3 = checkLength;
            bool status = obj3.Invoke("HelloWorld");
            Console.WriteLine(status);

        }


    }
}
