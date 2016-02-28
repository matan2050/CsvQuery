using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SearchInFile_InterviewQuestion_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

			// Check input argument
			if (args.Length == 0)
			{
				Console.WriteLine("Missing Csv Path");
				return;
			}

			string path = @args[0];


            // Get number of logical processors, for future multithreading
            Console.WriteLine("Available cores {0}", Environment.ProcessorCount);
            //string path = @"C:\Temp\simulationCsv - Copy.csv";

			Stopwatch timer = new Stopwatch();
			timer.Start();
            CsvIndexer csvToQuery = new CsvIndexer(path);
            csvToQuery.Index();
			timer.Stop();

			TimeSpan timeToInit = timer.Elapsed;

			timer.Reset();

			Console.WriteLine("Time to load csv: {0}", timeToInit.ToString());
            Console.WriteLine("Enter email or name for querying:");
            string query;

            bool keepQuerying = true;

            while (keepQuerying)
            {
                query = Console.ReadLine();

                if (query.Length == 0)
                {
                    keepQuerying = false;
                }
                else
                {
					timer.Start();
                    List<long> queryResult = csvToQuery.ProcessQuery(query);

					timer.Stop();
					TimeSpan timeToQuery = timer.Elapsed;

					string printedResult = "";

					if (queryResult.Count == 0)
                    {
						printedResult = "Query returned 0 matches";
                    }
                    else
                    {
                        
                        for (int i = 0; i < queryResult.Count; i++)
                        {
                            printedResult += queryResult[i].ToString();

                            if (i != queryResult.Count - 1)
                            {
                                printedResult += ", ";
                            }
                        }
                    }

					Console.WriteLine(printedResult);
					Console.WriteLine("Time to query: {0}", timeToQuery.ToString());
				}
            }          
        }
    }
}
