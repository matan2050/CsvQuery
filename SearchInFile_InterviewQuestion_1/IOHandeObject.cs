using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchInFile_InterviewQuestion_1
{
    public class IOHandeObject
    {
        #region FIELDS
        private string      pathToCsv;
        private bool        keepQuerying;
        private bool        timeOperations;
        Stopwatch           timer;
        TimeSpan            timeToInit;
        CsvIndexer          csvToQuery;
        #endregion


        #region CONSTRUCTORS
        public IOHandeObject(string[] inputArgs)
        {
            timeOperations = false;
            keepQuerying = true;

            Console.Clear();

            // Check input argument
            if (inputArgs.Length == 0)
            {
                Console.WriteLine("Missing Csv Path");
                return;
            }

            pathToCsv = inputArgs[0];

            if (inputArgs.Length == 2)
            {
                if (inputArgs[1] == "/t")
                {
                    timeOperations = true;
                    Console.WriteLine("Timing load and query operations");
                }
            }

            if (timeOperations)
            {
                timer = new Stopwatch();
                timer.Start();
            }

            csvToQuery = new CsvIndexer(pathToCsv);
            csvToQuery.Index();

            if (timeOperations)
            {
                timer.Stop();
                timeToInit = timer.Elapsed;
                timer.Reset();
                Console.WriteLine("Time to load csv: {0}", timeToInit.ToString());
            }
        }
        #endregion


        #region PUBLIC_METHODS
        public void ProcessQueries()
        {
            Console.WriteLine("Enter email or name for querying:");

            string      query;
            TimeSpan    timeToQuery;

            while (keepQuerying)
            {
                query = Console.ReadLine();

                if (query == "exit")
                {
                    keepQuerying = false;
                    break;
                }

                if (timeOperations)
                {
                    timer.Start();
                }
                
                List<long> queryResult = csvToQuery.ProcessQuery(query);

                if (timeOperations)
                {
                    timer.Stop();
                    timeToQuery = timer.Elapsed;
                    Console.WriteLine("Time to query: {0}", timeToQuery.ToString());
                }

                string printedResult = CreateResponseString(ref queryResult);
                Console.WriteLine(printedResult);
                
            }
        }
        #endregion


        #region PRIVATE_METHODS
        private string CreateResponseString(ref List<long> queryResults)
        {
            string printedResult = "";

            if (queryResults.Count == 0)
            {
                printedResult = "Query returned 0 matches";
            }
            else
            {
                for (int i = 0; i < queryResults.Count; i++)
                {
                    printedResult += queryResults[i].ToString();

                    if (i != queryResults.Count - 1)
                    {
                        printedResult += ", ";
                    }
                }
            }

            return printedResult;
        }
        #endregion
    }
}
