using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Just check each string's common chars. That defines if it has common substrings or not
    static Dictionary<char, int> stringToDictionaryOfChars(string str)
    {
        return str.AsEnumerable().Select(x => x).GroupBy(y => y).ToDictionary(ch => ch.Key, ch => ch.Count());
    }

    // Complete the twoStrings function below.
    static string twoStrings(string s1, string s2) {
        var s1Dictionary = stringToDictionaryOfChars(s1);
        var s2Dictionary = stringToDictionaryOfChars(s2);

        foreach (var s1Substring in s1Dictionary.Keys)
        {
            if (s2Dictionary.ContainsKey(s1Substring))
            {
                return "YES";
            }
        }
        return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
