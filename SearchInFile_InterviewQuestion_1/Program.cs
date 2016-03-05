using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchInFile_InterviewQuestion_1
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[2];
            args[0] = @"C:\Users\User\Desktop\InterviewQuestions\simulation.csv";
            args[1] = "/t";
            IOHandeObject runInstance = new IOHandeObject(args);
            runInstance.ProcessQueries();        
        }
    }
}
