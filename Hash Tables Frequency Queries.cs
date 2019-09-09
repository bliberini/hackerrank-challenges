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

    static void addAndRemove(Dictionary<int, int> dict, int key, int value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] += value;
            if (dict[key] == 0)
            {
                dict.Remove(key);
            }
        }
        else
        {
            dict.Add(key, value);
        }
    }

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries)
    {
        var results = new List<int>();
        var elementsDictionary = new Dictionary<int, int>();
        var frequenciesDictionary = new Dictionary<int, int>();
        foreach (var query in queries)
        {
            switch (query[0])
            {
                case 1:
                    if (!elementsDictionary.ContainsKey(query[1]))
                    {
                        addAndRemove(elementsDictionary, query[1], 1);
                    }
                    else
                    {
                        addAndRemove(frequenciesDictionary, elementsDictionary[query[1]], -1);
                        addAndRemove(elementsDictionary, query[1], 1);
                    }

                    addAndRemove(frequenciesDictionary, elementsDictionary[query[1]], 1);

                    break;
                case 2:
                    if (elementsDictionary.ContainsKey(query[1]))
                    {
                        if (elementsDictionary[query[1]] != 1)
                        {
                            addAndRemove(frequenciesDictionary, elementsDictionary[query[1]], -1);
                            addAndRemove(elementsDictionary, query[1], -1);
                            addAndRemove(frequenciesDictionary, elementsDictionary[query[1]], 1);
                        }
                        else
                        {
                            addAndRemove(frequenciesDictionary, elementsDictionary[query[1]], -1);
                            addAndRemove(elementsDictionary, query[1], -1);
                        }
                    }
                    break;
                case 3:
                    var output = frequenciesDictionary.ContainsKey(query[1]) && frequenciesDictionary[query[1]] > 0 ? 1 : 0;
                    results.Add(output);
                    break;
                default:
                    break;
            }
        }
        return results;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++) {
            queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        textWriter.WriteLine(String.Join("\n", ans));

        textWriter.Flush();
        textWriter.Close();
    }
}
