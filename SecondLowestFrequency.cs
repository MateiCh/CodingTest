using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondLowestFrequency
{
    class SecondLowestFrequency
    {
        static void Main(string[] args)
        {
            Console.WriteLine(secondLowest(new int[] { 4, 3, 1, 1, 2 }) == 1);
            Console.WriteLine(secondLowest(new int[] { 4, 3, 1, 1, 2, 2 }) == 2);
            Console.WriteLine(secondLowest(new int[] { 4, 3, 1, 2 }) == 2);
            //extra test
            Console.WriteLine(secondLowest(new int[] { 4, 4, 3, 3, 1, 1, 2, 2, 3, 3, 4, 4, 1, 2, 3, 1, 3, 1, 2, 3 }) == 1);
        }

        public static int secondLowest(int[] array)
        {
            var lowestFreq = int.MaxValue;
            int lowestValue = int.MaxValue;
            var secondLowestFreq = int.MaxValue;
            int secondLowestValue = int.MaxValue;
            foreach (var i in array)
            {
                int freq = 0;
                //if (i != lowestValue && i != secondLowestValue)
                    foreach (var j in array)
                        if (i == j) freq++;
                if (freq != 0)
                {
                    if (freq < lowestFreq)
                    {
                        secondLowestFreq = lowestFreq;
                        lowestFreq = freq;
                        if (lowestValue == int.MaxValue)
                            lowestValue = i;
                    }
                    else if (lowestFreq < freq && freq < secondLowestFreq)
                    {
                        secondLowestFreq = freq;
                        lowestValue = i;
                        secondLowestValue = int.MaxValue;
                    }
                    else if (freq == lowestFreq && secondLowestFreq == int.MaxValue)
                        checkForLowestValues(ref lowestValue, ref secondLowestValue, i);
                    else if (freq == secondLowestFreq)
                        checkForLowestValues(ref lowestValue, ref secondLowestValue, i);
                }
            }
            if (secondLowestValue == int.MaxValue && lowestValue != int.MaxValue)
                return lowestValue;
            else
                return secondLowestValue;
        }

        private static void checkForLowestValues(ref int lowestValue, ref int secondLowestValue, int i)
        {
            if (i < lowestValue)
            {
                secondLowestValue = lowestValue;
                lowestValue = i;
            }
            else if (i < secondLowestValue && i != lowestValue)
            //else if (i < secondLowestValue)
                secondLowestValue = i;
        }
        //A faster way with collections
        public static int secondLowestDictionary(int[] array)
        {
            var frequencyDictionary = new Dictionary<int, int>();
            foreach (var i in array)
                if (!frequencyDictionary.ContainsKey(i))
                    frequencyDictionary.Add(i, array.Count(x => x == i));
            if (frequencyDictionary.Values.Distinct().Count() < 2)
                return frequencyDictionary.OrderBy(x => x.Key).ElementAt(1).Key;
            else
            {
                var secondLowestValue = frequencyDictionary.Values.Distinct().OrderBy(x => x).ElementAt(1);
                var secondLowestKeys = frequencyDictionary.Where(x => x.Value == secondLowestValue).ToList();
                if (secondLowestKeys.Count() > 1)
                    return secondLowestKeys.OrderBy(x => x.Key).ElementAt(1).Key;
                else
                    return secondLowestKeys.Single().Key;
            }
        }
    }
}
