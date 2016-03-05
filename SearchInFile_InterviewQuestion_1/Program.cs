using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchInFile_InterviewQuestion_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IOHandeObject runInstance = new IOHandeObject(ref args);
            runInstance.ProcessQueries();        
        }
    }
}
