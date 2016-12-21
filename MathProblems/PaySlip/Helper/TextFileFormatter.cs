using System.Collections.Generic;
using System.IO;

namespace MathProblems.PaySlip
{
    public  class TextFileFormatter : IResultFormatter
    {

        public List<string> List { get; private set; }
        public void Format(IEnumerable<string> inputs)
        {
            using (var streamWriter = new StreamWriter("output.csv"))
            {
                foreach (var item in inputs)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }


        public List<string> ReadConvert(string filePath)
        {
            
            List = new List<string>();
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
                List.Add(line);

            file.Close();

            return List;

        }
    }
}
