using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day2: Day
    {
        private IEnumerable<string> lines;

        public void ReadInputFile(string inputFile)
        {
            // Get a list of passwords from the input file
            lines = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1()
        {
            // Validate passwords based on character counts
            return Solve<CountCharsPasswordRule>(lines);
        }

        public Int64 SolvePart2()
        {
            // Validate passwords based on exactly one character match in given positions
            return Solve<PositionCharsPasswordRule>(lines);
        }

        public int Solve<TRule>(IEnumerable<string> passwords) where TRule : IPasswordRule
        {
            return passwords.Select(password => PasswordWithRule.Parse<TRule>(password))
                            .Where(password => password.IsValid())
                            .Count();
        }
    }
}
