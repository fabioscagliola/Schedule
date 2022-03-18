using com.fabioscagliola.Core.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;

namespace com.fabioscagliola.Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            Trace.AutoFlush = true;
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new CustomTextWriterTraceListener(Path.Combine(Path.GetTempPath(), $"{assemblyName}.{ DateTime.Now:yyyyMMdd}.log")));

            Timer timer = new Timer(1000);

            try
            {
                Trace.WriteLine(string.Format("{0} began.", assemblyName));

                Trace.WriteLine("");
                Trace.WriteLine("Press Q to quit");
                Trace.WriteLine("");

                List<Activity> activitiyList = new List<Activity>
                {
                    new FiboActivity() { Period = 20 },
                    new HashActivity() { Period = 30 },
                };

                timer.Elapsed += (object sender, ElapsedEventArgs e) =>
                {
                    foreach (Activity activity in activitiyList)
                    {
                        try
                        {
                            if (e.SignalTime.Second % activity.Period == 0)  // This is an oversimplification 
                            {
                                if (activity is FiboActivity fiboActivity)
                                {
                                    Guid guid = Guid.NewGuid();  // This serves as a correlation identifier 
                                    uint position = 9;  // This could be read each time from a config file or database table 
                                    Trace.WriteLine($"[{guid}] Executing {nameof(FiboActivity)} ({nameof(FiboActivityParameters.Position)} is {position})...");
                                    FiboActivityParameters fiboActivityParameters = new FiboActivityParameters { Position = position };
                                    fiboActivity.Do(ref fiboActivityParameters);
                                    Trace.WriteLine($"[{guid}] {nameof(FiboActivityParameters.Number)} is {fiboActivityParameters.Number}");
                                }
                                if (activity is HashActivity hashActivity)
                                {
                                    Guid guid = Guid.NewGuid();
                                    string inputString = "Soci forever!";
                                    Trace.WriteLine($"[{guid}] Executing {nameof(HashActivity)} ({nameof(HashActivityParameters.InputString)} is \"{inputString}\")...");
                                    HashActivityParameters hashActivityParameters = new HashActivityParameters { InputString = inputString };
                                    hashActivity.Do(ref hashActivityParameters);
                                    Trace.WriteLine($"[{guid}] {nameof(HashActivityParameters.Hash)} is {hashActivityParameters.Hash}");
                                }
                            }
                        }
                        catch
                        {
                            Trace.WriteLine($"Something went wrong while attempting to execute an activity of type \"{activity.GetType()}\"!");
                        }
                    }

                };

                timer.Start();

                while (true)
                {
                    Task.Delay(500);
                    if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                }

                timer.Stop();
            }
            catch (Exception e)
            {
                Trace.WriteLine("The following error has occurred!");
                Trace.WriteLine(e.Message);
            }
            finally
            {
                timer.Dispose();

                Trace.WriteLine("");
                Trace.WriteLine(string.Format("{0} ended.", assemblyName));
                Trace.WriteLine("");
            }
        }

    }
}

