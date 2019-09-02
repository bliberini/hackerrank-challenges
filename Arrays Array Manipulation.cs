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

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        var array = new long[n+1];

        // Read queries one by one. Get lower bound, higher bound and sum values. Register the rate change instead of every
        // element value: add the sum to the lower bound element and substract the sum to the first element to the right of the
        // interval, signaling the increase in value at the beginning of the interval and the decrease in value at the end.
        for (int i = 0; i < m; i++) {
            int[] queries = Array.ConvertAll(Console.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
            var a = queries[0];
            var b = queries[1];
            var k = queries[2];

            array[a] += k;
            if (b + 1 <= n)
            {
                array[b+1] -= k;
            }
        }

        long sum = 0;
        long max = 0;

        // Iterate the array and sum the final values. They will signal the increments registered in each interval, so if "x"
        // is followed by "y", the max value will be "x + y" somewhere after the "y" element in this array
        for (int i = 0; i <= n; i++)
        {
            sum += array[i];
            if (sum > max)
            {
                max = sum;
            }
        }
        textWriter.WriteLine(max);

        textWriter.Flush();
        textWriter.Close();
    }
}
