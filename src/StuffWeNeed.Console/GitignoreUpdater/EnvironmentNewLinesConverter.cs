using System;

namespace StuffWeNeed.Console.GitignoreUpdater
{
    /// <summary>
    /// Files downloaded from internet can have Unix line endings (LF) so we convert it to Windows (CR,LF)
    /// </summary>
    public static class EnvironmentNewLinesConverter
    {
        public static string Convert(string input)
        {
            return input.Replace(Environment.NewLine, "\n").Replace("\n", Environment.NewLine);
        }
    }
}