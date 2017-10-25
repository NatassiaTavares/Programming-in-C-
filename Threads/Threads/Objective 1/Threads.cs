using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Threads
    {

        /// <summary>
        /// Cada thread tem a sua própria cópia do campo (_field vai de 1 a 10 para cada thread)
        /// </summary>
        //[ThreadStatic]
        //public static int _field;

        /// <summary>
        /// Inicializa uma variável local para cada thread
        /// </summary>
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() => {
                return Thread.CurrentThread.ManagedThreadId;
            });

        /// <summary>
        /// Método 1 - Threads
        /// </summary>
        public static void ThreadMethod()
        {
            for (var i = 0; i < 10; i++)
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
            for (var i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProcParam: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void ThreadManager()
        {
            ////Chamada sem parâmetro
            //Thread t = new Thread(new ThreadStart(ThreadMethod));
            ////Quando é backgroud as threads são fechadas no fim do main.
            ////Quando não é, o main espera as threads serem executadas.
            //t.IsBackground = false;
            //t.Start();

            ////Chamada com parâmetro
            //Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //t.Start(5);
            //t.Join();

            ////Chamada com variável pra parar a execução
            //bool stopped = false;

            //Thread t = new Thread(new ThreadStart(() => {
            //    while (!stopped)
            //    {
            //        Console.WriteLine("Running...");
            //        Thread.Sleep(1000);
            //    }
            //}));

            //t.Start();
            //Console.WriteLine("Press any key to exit");
            //Console.ReadKey();

            //stopped = true;

            //t.Join();

            //new Thread(()=>
            //{
            //    for (int x = 0; x<10; x++)
            //    {
            //        _field++;
            //        Console.WriteLine("Thread A: {0}", _field);
            //    }
            //}).Start();

            //new Thread(() =>
            //{
            //    for (int x = 0; x < 10; x++)
            //    {
            //        _field++;
            //        Console.WriteLine("Thread B: {0}", _field);
            //    }
            //}).Start();

            //Console.ReadKey();

            //Variável local para cada thread
            //new Thread(() =>
            //{
            //    for (int x = 0; x < _field.Value; x++)
            //    {
            //        Console.WriteLine("Thread A: {0}", x);
            //    }
            //}).Start();

            //new Thread(() =>
            //{
            //    for (int x = 0; x < _field.Value; x++)
            //    {
            //        Console.WriteLine("Thread B: {0}", x);
            //    }
            //}).Start();

            //Console.ReadKey();

            //Thread Pool
            //ThreadPool.QueueUserWorkItem((s) =>
            //{
            //    Console.WriteLine("Working on a thread from threadpool");

            //    Console.ReadLine();
            //});

            //new Thread(() =>
            //{
            //    Console.WriteLine("Thread");
            //}).Start();
        }
    }
}
