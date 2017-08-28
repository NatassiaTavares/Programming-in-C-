using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        /// <summary>
        /// Método 1 - Threads
        /// </summary>
        public static void ThreadMethod()
        {
            for (var i=0;i<10;i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Método 2 - Threads com parâmetros
        /// </summary>
        public static void ThreadMethod(object o)
        {
            for (var i=0; i<(int)o;i++)
            {
                Console.WriteLine("ThreadProcParam: {0}", i);
                Thread.Sleep(0);
            }
        }

        static void Main(string[] args)
        {
            //Chamada sem parâmetro
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            //Quando é backgroud as threads são fechadas no fim do main.
            //Quando não é, o main espera as threads serem executadas.
            t.IsBackground = false;
            t.Start();

            //Chamada com parâmetro
            Thread t2 = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t2.Start(5);
            t2.Join();

            
        }
    }
}
