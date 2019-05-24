using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Linq.Expressions;

namespace ConsoleApplication2
{
    class Program
    {
        private static object obj1 = new object();
        public static int count = 0;
        public static void Main()
        {

            Console.WriteLine(D);
            Console.ReadLine();
        }

        public static IEnumerable<int> Power(int number, int exponent, string s)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
            yield return 3;
            yield return 4;
            yield return 5;
        }

        public class PositionEvent : EventArgs
        {
            public string PositionCondition { get; set; }

            public string PositionDirection { get; set; }

            public string PositionErr { get; set; }

            public string PositionIDX { get; set; }

            public PositionEvent(string _PositionCondition, string _PositionDirection, string _PositionErr, string _PositionIDX)
            {
                PositionCondition = _PositionCondition;
                PositionDirection = _PositionDirection;
                PositionErr = _PositionErr;
                PositionIDX = _PositionIDX;
            }
        }
        /// <summary>  
        /// 获取拼音  
        /// </summary>  
        /// <param name="str"></param>  
        /// <returns></returns>  
        public static string GetPYString(string str)
        {
            string tempStr = "";
            foreach (char c in str)
            {
                if ((int)c >= 33 && (int)c <= 126)
                {//字母和符号原样保留     
                    tempStr += c.ToString();
                }
                else
                {//累加拼音声母     
                    tempStr += GetPYChar(c.ToString());
                }
            }
            return tempStr;
        }
        ///      
        /// 取单个字符的拼音声母     
        ///      
        /// 要转换的单个汉字     
        /// 拼音声母     
        public static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "a";
            if (i < 0xB2C1) return "b";
            if (i < 0xB4EE) return "c";
            if (i < 0xB6EA) return "d";
            if (i < 0xB7A2) return "e";
            if (i < 0xB8C1) return "f";
            if (i < 0xB9FE) return "g";
            if (i < 0xBBF7) return "h";
            if (i < 0xBFA6) return "j";
            if (i < 0xC0AC) return "k";
            if (i < 0xC2E8) return "l";
            if (i < 0xC4C3) return "m";
            if (i < 0xC5B6) return "n";
            if (i < 0xC5BE) return "o";
            if (i < 0xC6DA) return "p";
            if (i < 0xC8BB) return "q";
            if (i < 0xC8F6) return "r";
            if (i < 0xCBFA) return "s";
            if (i < 0xCDDA) return "t";
            if (i < 0xCEF4) return "w";
            if (i < 0xD1B9) return "x";
            if (i < 0xD4D1) return "y";
            if (i < 0xD7FA) return "z";
            return "*";
        }

        static void PoolFunc(object state)
        {

            int workerThreads, completionPortThreads;

            ThreadPool.GetAvailableThreads(out workerThreads,

                out completionPortThreads);

            Console.Write("WorkerThreads: {0}, CompletionPortThreads: {1}",

                workerThreads, completionPortThreads);
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("MaxWorkerThreads: {0}, CompletionPortThreads: {1}",

                workerThreads, completionPortThreads);

            Thread.Sleep(5000);




            string url = "http://www.baidu.com";




            HttpWebRequest myHttpWebRequest;

            HttpWebResponse myHttpWebResponse = null;

            // Creates an HttpWebRequest for the specified URL.

            myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            // Sends the HttpWebRequest, and waits for a response.

            myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            myHttpWebResponse.Close();

        }
    }
    public class Test
    {
        public string str { get; set; }
        public string age { get; set; }
    }
    public static class Pollution
    {

        public static T GetTop1<T>(this List<T> l, Func<T, object> sortBy = null, Func<T, bool> filter = null)
        {
            IEnumerable<T> queryRst = l.Where(t => true);
            if (filter != null)
            {
                queryRst = queryRst.Where(filter);
            }
            if (sortBy != null)
            {
                queryRst = queryRst.OrderBy(sortBy);
            }
            T r = queryRst.FirstOrDefault();
            return r;
        }
    }
}
