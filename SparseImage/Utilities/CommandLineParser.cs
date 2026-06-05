using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class CommandLineParser
    {
        private static int IndexOfArgumentSeparator(string str)
        {
            return IndexOfArgumentSeparator(str, 0);
        }

        private static int IndexOfArgumentSeparator(string str, int startIndex)
        {
            int index = QuotedStringUtils.IndexOfUnquotedChar(str, ' ', startIndex);
            if (index >= 0)
            {
                while (index + 1 < str.Length && str[index + 1] == ' ')
                {
                    index++;
                }
            }
            return index;
        }

        /// <summary>
        /// The method ignore backspace as escape character,
        /// this way "C:\Driver\" I: are turned into two arguments instead of one.
        /// </summary>
        public static string[] GetCommandLineArgsIgnoreEscape()
        {
            string commandLine = Environment.CommandLine;
            List<string> argsList = new List<string>();
            int startIndex = 0;
            int endIndex = IndexOfArgumentSeparator(commandLine);
            while (endIndex != -1)
            {
                int length = endIndex - startIndex;
                string nextArg = commandLine.Substring(startIndex, length).Trim();
                nextArg = QuotedStringUtils.Unquote(nextArg);
                argsList.Add(nextArg);
                startIndex = endIndex + 1;
                endIndex = IndexOfArgumentSeparator(commandLine, startIndex);
            }

            string lastArg = commandLine.Substring(startIndex).Trim();
            lastArg = QuotedStringUtils.Unquote(lastArg);
            if (lastArg != String.Empty)
            {
                argsList.Add(lastArg);
            }

            argsList.RemoveAt(0); // remove the executable name
            return argsList.ToArray();
        }
    }
}
