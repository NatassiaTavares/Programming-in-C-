﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Parallels
    {
        public static void ParallelManager()
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });

            ParallelLoopResult result = Parallel.
                For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Breaking loop");
                        loopState.Break();
                    }
                    return;
                });
        }

    }
}
