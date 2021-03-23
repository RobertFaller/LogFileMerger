using System;

namespace LogFileMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Program, lets see what happens here!");
            MergeLogFiles.Merge();
            Console.WriteLine("Hello World!");
        }
    }
}
