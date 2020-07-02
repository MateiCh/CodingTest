using System;

namespace LongestSequence
{
    class LongestSequenceTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestSequence("dghhhmhmx").Equals(new Tuple<string, int>("h", 3)));
            Console.WriteLine(LongestSequence("dhkkhhKKKt").Equals(new Tuple<string, int>("k", 3)));
            Console.WriteLine(LongestSequence("aBbBadddadd").Equals(new Tuple<string, int>("b", 3)));
            //extra
            //Console.WriteLine(LongestSequence("aBbBadddaddaaa").Equals(new Tuple<string, int>("a", 3)));
        }

        public static Tuple<string, int> LongestSequence(string sequence)
        {
            //initialise with lowest values
            char maxChar = char.MinValue;
            int maxLength = 0;
            char currentChar = maxChar;
            int currentLength = maxLength;
            
            //normalize string
            string lowerSequence = sequence.ToLower();
            foreach (var s in lowerSequence)
            {
                if (currentChar == s)
                    currentLength++;
                else
                {
                    currentChar = s;
                    currentLength = 1;
                }
                if(currentLength > maxLength)
                {
                    maxChar = currentChar;
                    maxLength = currentLength;
                }    
                if(currentLength == maxLength)
                    if (currentChar < maxChar)
                        maxChar = currentChar;
            }
            return new Tuple<string, int>($"{maxChar}", maxLength);
        }
    }
}
