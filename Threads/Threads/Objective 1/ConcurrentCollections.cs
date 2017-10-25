using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class ConcurrentCollections
    {
        /// <summary>
        /// Example using Blocking Collection. Page 26
        /// </summary>
        public static void BlockingCollectionExample()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            //Task read = Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine(col.Take());
            //    }
            //});

            Task read = Task.Run(() =>
            {
                foreach (var v in col.GetConsumingEnumerable())
                    Console.WriteLine(col.Take());
                
            });

            Task write = Task.Run( () =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);
                }
            });

            write.Wait();
        }

        public static void ConcurrentBagExample()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            int result;
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            if (bag.TryPeek(out result)) //not thread safe
                Console.WriteLine("There is a next item: {0}", result);


            //Once it starts iterate over the item, system creates a snapshot of it. Items added later are not visible.
        }

        public static void ConcurrentBagEnumerateExample()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                //21 isn't printed because is added after start of iteration
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();
        }

        public static void ConcurrentStackExample()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);

            stack.PushRange(new int[] { 1, 2, 3});

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
                Console.WriteLine(i);
        }

        public static void ConcurrentQueueExample()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine("Dequeued: {0}", result);


        }

        public static void ConcurrentDictionaryExample() {

            var dict = new ConcurrentDictionary<string, int>();
            if (dict.TryAdd("k1", 42))
                Console.WriteLine("Added");

            if (dict.TryUpdate("k1", 21, 42))
                Console.WriteLine("42 updated to 21");

            dict["k1"] = 42;

            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);

        }

    }
}
