using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class PLINQ
    {
        /// <summary>
        /// First example with Plinq (page 22)
        /// </summary>
        public static void Example1()
        {
            var numbers = Enumerable.Range(0, 10);

            try {
                var parallelResult = numbers.AsParallel()//.AsOrdered() function for ordering. Your query still runs unordered, but then results are buffered and ordered storaged.
                    .Where(i => i % 2 == 0);//.AsSequential() function for running code sequentially
                                            //.ToArray();

                Console.WriteLine("Using normal foreach");

                foreach (int i in parallelResult)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("Using For All");

                parallelResult.ForAll(e => Console.WriteLine(e)); //Remove any order. Doesn't wait for all results to start executing
            }
            catch (AggregateException e) //Aggregate Exceptions are all execptions ocurred during a parallel code grouped together
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count());
            }
        }

    }
}
