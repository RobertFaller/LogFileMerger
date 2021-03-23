using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LogFileMerger
{
    public class MergeLogFiles
    {
        public static Action Merge()
        {
            //Defining the input folder
            string inputFolder = "C:\\PersonalDev\\TestLogs\\";

            //collecting the files
            string[] files = Directory.GetFiles(inputFolder);

            //opening the data model
            List<Data> data = new List<Data>();
           
            //initiating IEnumerable of lines to store the lines from the files.
            IEnumerable<String> lines;
            
            //foreach loop to loop through the files
            foreach (var fd in files)
            {
                lines = File.ReadAllLines(fd);
                //adding the data to the data model - so this can be sorted later
                foreach (var l in lines)
                {
                    Data d = new Data
                    {
                        Date = l.Substring(0, 23),
                        Value = l
                    };
                    data.Add(d);
                }
            }
            //writing to the output file
            Console.WriteLine("Writing to output file");
            using (TextWriter tw = new StreamWriter(string.Concat(inputFolder + "\\Results\\testOutput.txt")))
            {
                foreach (var d in data.OrderBy(x => x.Date))
                {
                    tw.WriteLine(d.Value);
                }
            }
            Console.WriteLine("Writing finished");

            return null;
        }

        //Would normally put this into it's own model folder, but for speed, and the fact this is the only model in the program i left it here.
        public class Data
        {
            public string Date { get; set; }

            public string Value { get; set; }
        }



    }
}
