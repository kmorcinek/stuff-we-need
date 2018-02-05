using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace StuffWeNeed.Console.GitignoreUpdater
{
    public class GitignoreUpdater
    {
        static void Main(string[] args)
        {
            string path = Debugger.IsAttached
                ? "../../GitignoreUpdater/IntegrationTests/"
                : "./";

            string folderPath = args.FirstOrDefault() ?? path;

            string filePath = Path.Combine(folderPath, ".gitignore");

            Run(filePath);
        }

        public static void Run(string gitignorePath)
        {
            // Download file as text from url
            string beforeEolNormalization = Downloader.Download();
            string downloadedContent = EnvironmentNewLinesConverter.Convert(beforeEolNormalization);

            // Read current .gitignore file
            string currentFile = File.ReadAllText(gitignorePath);

            // found border
            // TODO: It is possible that file will use different EOF, so it can fail. Change to Exception.
            string pattern =
                $"# End of core ignore list, below put you custom 'per project' settings (patterns or path){Environment.NewLine}#####{Environment.NewLine}";

            int patternStart = currentFile.IndexOf(pattern);
            int patternEnd = patternStart + pattern.Length;

            string afterPattern = currentFile.Substring(patternEnd);

            // Replace text
            string updatedContent = downloadedContent + afterPattern;
            File.WriteAllText(gitignorePath, updatedContent);
        }
    }
}