using System;

namespace LineCounter 
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            string loc = "";
            if (args.Length < 1) 
            {
                Console.WriteLine("No arguments. Scanning current folder.");
                loc = ".";
            }
            else loc = args[0];
            var files = Directory.GetFileSystemEntries(loc);
            int lines = 0;
            for (int i = 0; i < files.Length; i++)
            {
                lines += CountLines(files[i]);
            }
            Console.WriteLine($"Lines: {lines}");
        }
        private static int CountLines(string location) 
        {
            int lines = 0;
            if (Directory.Exists(location)) 
            {
                foreach (var entry in Directory.GetFileSystemEntries(location)) 
                {
                    lines += CountLines(entry);
                }
            }
            if (!location.EndsWith(".cs") && !location.EndsWith(".java") && !location.EndsWith(".c") && !location.EndsWith(".cpp")) 
            {
                return lines;
            }
            var read = File.ReadAllLines(location).Count();
            Console.WriteLine($"Lines: {read} - \"{location}\"");
            return lines + read;
        }
    }
}
