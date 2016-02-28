using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInFile_InterviewQuestion_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // Get number of logical processors, for future multithreading
            Console.WriteLine("Available cores {0}", Environment.ProcessorCount);
            string path = @"C:\Users\User\Desktop\InterviewQuestions\simulation.csv";
            CsvIndexer csvToQuery = new CsvIndexer(path);
            csvToQuery.Index();

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
                    List<long> queryResult = csvToQuery.ProcessQuery(query);

                    if (queryResult.Count == 0)
                    {
                        Console.WriteLine("Query returned 0 matches");
                    }
                    else
                    {
                        string printedResult = "";
                        for (int i = 0; i < queryResult.Count; i++)
                        {
                            printedResult += queryResult[i].ToString();

                            if (i != queryResult.Count - 1)
                            {
                                printedResult += ", ";
                            }
                        }

                        Console.WriteLine(printedResult);
                    }
                }
            }          
        }
    }
}
