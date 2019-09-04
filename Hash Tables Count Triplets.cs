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

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r) {

        // Dictionary to store the amount of tuples (x, y) waiting for number z to form a triplet
        var doublets = new Dictionary<long, long>();

        // Dictionary to store the amount of tuples (x, y) waiting for number z to form a triplet
        var triplets = new Dictionary<long, long>();
        var count = 0L;

        foreach(var number in arr)
        {
            // If Z is in this dictionary, it means there are tuples (x, y) waiting for it to become a triplet,
            // namely (Z / r^2, Z / r). The dictionary's value is the number of said tuples already found.
            if (triplets.ContainsKey(number)) {
                count += triplets[number];
            }

            // If Z is in this dictionary, it means there program has already found a number X (namely, Z / r)
            // which would form a doublet if it found Z.
            if (doublets.ContainsKey(number)) {

                // The program registers this new tuple by adding it to the triplets dictionary, meaning
                // it's waiting for Z * r to form a triplet. It registers the number of tuples (Z / r, Z)
                // already found in this entry.
                if (triplets.ContainsKey(number * r))
                {
                    triplets[number * r] += doublets[number]; 
                }
                else
                {
                    triplets.Add(number * r, doublets[number]);
                }
            }

            // Finally, it registers in the doublets dictionary that it's waiting for Z * r to form a doublet
            if (doublets.ContainsKey(number * r))
            {
                doublets[number * r]++;
            }
            else
            {
                doublets.Add(number * r, 1);
            }
        }

        return count;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
