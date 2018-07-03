using System;
using Core.Interfaces;
using EmailParsersFactory.Tasks.Factory;
using EmailReader.Infrastructure;

namespace EmailReader
{
    /// <summary>
    /// Main class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments of main method.</param>
        public static void Main(string[] args)
        {
            // string command = args.FirstOrDefault();
            string command = "download";        // delete later

            AutofacConfig.Configuration();

            ITask task = new TaskFactory().GetTask(command, AutofacConfig.Container);
            task.Execute();

            #region Delete later
            // ---------
            command = "parse";

            task = new TaskFactory().GetTask(command, AutofacConfig.Container);
            task.Execute();

            // ---------
            #endregion

            Console.WriteLine("End.");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
