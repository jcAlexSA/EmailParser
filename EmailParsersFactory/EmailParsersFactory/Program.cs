using System;
using System.Linq;
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
            string command = args.FirstOrDefault();
            if (string.IsNullOrEmpty(command))
            {
                var log = NLog.LogManager.GetLogger("database");
                var ex = new ArgumentNullException("There is no argument in the command line.");
                log.Fatal(ex, ex.Message);
                throw ex;
            }

            AutofacConfig.Configuration();

            ITask task = new TaskFactory().GetTask(command, AutofacConfig.Container);
            task.Execute();

            Console.WriteLine("End.");
            System.Threading.Thread.Sleep(5000);
        }
    }
}
