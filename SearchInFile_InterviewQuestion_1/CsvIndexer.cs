using System;
using System.Collections.Generic;
using System.IO;

namespace SearchInFile_InterviewQuestion_1
{
    public class CsvIndexer
    {
        #region FIELDS
        private     string                              csvPath;
        private     Dictionary<string, List<long>>      emailIndices;
        private     Dictionary<string, List<long>>      nameIndices;
        #endregion


        #region CONSTRUCTORS
        public CsvIndexer(string _csvPath)
        {
            csvPath = _csvPath;

            if (!File.Exists(csvPath))
            {
                throw new FileNotFoundException("Csv Path not valid");
            }
        }
        #endregion


        #region METHODS
        public void Index()
        {
            string[] lines = File.ReadAllLines(csvPath);

            // Defining dictionaries becuase now we have an upper bound on number of unique records in csv
            emailIndices = new Dictionary<string, List<long>>((int)lines.Length);
            nameIndices = new Dictionary<string, List<long>>((int)lines.Length);

            foreach (string line in lines)
            {
                long currId;

                string[] lineSplit = line.Split(',');
                long.TryParse(lineSplit[0], out currId);

                string currName = lineSplit[1];

                if (currName[0] == ' ')
                {
                    currName = currName.Substring(1, (currName.Length - 1));
                }
                string currEmail = lineSplit[2].Trim();
                
                // Adding new index to current email
                if (!emailIndices.ContainsKey(currEmail))
                {
                    emailIndices.Add(currEmail, new List<long>());
                }
                emailIndices[currEmail].Add(currId);

                // Adding new index to current name
                if (!nameIndices.ContainsKey(currName))
                {
                    nameIndices.Add(currName, new List<long>());
                }
                nameIndices[currName].Add(currId);
            }
        }

        public List<long> ProcessQuery(string query)
        {
            List<long> matchingIndices = new List<long>();

            if (query.Length == 0)
            {
                throw new Exception("Query is empty");
            }

            if (query.Contains("@"))
            {
                if (emailIndices.ContainsKey(query))
                {
                    matchingIndices = emailIndices[query];
                }
            }
            else
            {
                if (nameIndices.ContainsKey(query))
                {
                    matchingIndices = nameIndices[query];
                }
            }
        
            return matchingIndices;
        }
        #endregion
    }
}
