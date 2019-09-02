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

    // Complete the minimumBribes function below.
    static void minimumBribes(int[] q) {
        var bribes = 0;

        for (var i = 0; i < q.Length; i++)
        {
            var personZeroIndex = q[i] - 1;
            // Checks if it's too chaotic: if there's someone who's more than
            // two spots ahead of where it's supposed to be
            if (personZeroIndex - i > 2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }

            // Counts how many people ahead of the current person bribed him,
            // by counting how many people ahead of the current person have
            // a number bigger than him
            for (var j = Math.Max(personZeroIndex - 1, 0); j < i; j++)
            {
                if ((q[j] - 1) > personZeroIndex)
                {
                    bribes++;
                }
            }
        }
        Console.WriteLine(bribes);
    }

    static void Main(string[] args) {
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] q = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp))
            ;
            minimumBribes(q);
        }
    }
}
