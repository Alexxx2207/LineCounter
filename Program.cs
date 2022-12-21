namespace LineCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            var files = Directory.GetFileSystemEntries("E:\\Programming\\GitHub\\Profitable-main\\Profitable");
            int lines = 0;

            for (int i = 0; i < files.Length; i++)
            {
                lines += CountLines(files[i]);
            }

            Console.WriteLine($"Lines: {lines}");
        }

        private static char DirectoryCharSeparator = Path.DirectorySeparatorChar;

        private static int CountLines(string location)
        {
            int lines = 0;

            if (Directory.Exists(location) &&
                !location.Contains("node_modules") &&
                !location.Contains($"{DirectoryCharSeparator}obj") &&
                !location.Contains($"{DirectoryCharSeparator}bin{DirectoryCharSeparator}Debug"))
            {
                foreach (var entry in Directory.GetFileSystemEntries(location))
                {
                    lines += CountLines(entry);
                }
            }

            if (!location.EndsWith(".cs") &&
                !location.EndsWith(".java") &&
                !location.EndsWith(".c") &&
                !location.EndsWith(".cpp") &&
                !location.EndsWith(".js") &&
                !location.EndsWith(".jsx") &&
                !location.EndsWith(".css"))
            {
                return lines;
            }

            var read = File.ReadAllLines(location).Count();

            Console.WriteLine($"Lines: {read} - \"{location}\"");

            return lines + read;
        }
    }
}
