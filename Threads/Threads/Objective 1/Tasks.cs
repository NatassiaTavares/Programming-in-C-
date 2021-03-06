﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Tasks
    {
        public static void TasksManager()
        {
            // Simples task
            //Task t = Task.Run(() =>
            //{
            //    for (int x = 0; x < 100; x++)
            //    {
            //        Console.Write('*');
            //    }
            //});
            //t.Wait();

            // Task with return
            //Task<int> t = Task.Run(() =>
            //{
            //    return 42;
            //});
            //Console.WriteLine(t.Result); // Displays 42

            // Task with return and continuation
            //Task<int> t = Task.Run(() =>
            //{
            //    return 42;
            //}).ContinueWith((i) =>
            //{
            //    return i.Result * 2;
            //});
            //Console.WriteLine(t.Result);

            // Continuation overloads
            //Task<int> t = Task.Run(() =>
            //{
            //    return 42;
            //});
            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Canceled");
            //}, TaskContinuationOptions.OnlyOnCanceled);
            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Faulted");
            //}, TaskContinuationOptions.OnlyOnFaulted);
            //var completedTask = t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Completed");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);
            //completedTask.Wait();

            //Task with childs
            //Task<Int32[]> parent = Task.Run(() =>
            //{
            //    var results = new Int32[3];
            //    new Task(() => results[0] = 0,
            //    TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[1] = 1,
            //    TaskCreationOptions.AttachedToParent).Start();
            //    new Task(() => results[2] = 2,
            //    TaskCreationOptions.AttachedToParent).Start();
            //    return results;
            //});

            // Using Task Factory
            //Task<Int32[]> parent = Task.Run(() =>
            //{
            //    var results = new Int32[3];
            //    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent,
            //    TaskContinuationOptions.ExecuteSynchronously);
            //    tf.StartNew(() => results[0] = 0);
            //    tf.StartNew(() => results[1] = 1);
            //    tf.StartNew(() => results[2] = 2);
            //    return results;
            //});
            //var finalTask = parent.ContinueWith(
            //parentTask => {
            //    foreach (int i in parentTask.Result)
            //        Console.WriteLine(i);
            //});

            //finalTask.Wait();

            // Using Wait All
            //Task[] tasks = new Task[3];
            //tasks[0] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("1");
            //    return 1;
            //});
            //tasks[1] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("2");
            //    return 2;
            //});
            //tasks[2] = Task.Run(() => {
            //    Thread.Sleep(1000);
            //    Console.WriteLine("3");
            //    return 3;
            //}
            //);
            //Task.WaitAll(tasks);

            // Using Wait Any
            Task<int>[] tasks = new Task<int>[3];
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });
            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }
    }
}
