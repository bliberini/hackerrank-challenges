'use strict';

const fs = require('fs');

process.stdin.resume();
process.stdin.setEncoding('utf-8');

let inputString = '';
let currentLine = 0;

process.stdin.on('data', inputStdin => {
    inputString += inputStdin;
});

process.stdin.on('end', _ => {
    inputString = inputString.replace(/\s*$/, '')
        .split('\n')
        .map(str => str.replace(/\s*$/, ''));

    main();
});

function readLine() {
    return inputString[currentLine++];
}

// Complete the sherlockAndAnagrams function below.
function sherlockAndAnagrams(s) {
    let anagrams = 0;

    // Two substrings can only be anagrams if they are of the same length.
    // Therefore, the outer loop is through all posible substring lengths,
    // so the function only compares substrings of the same length
    for (let i = 1; i < s.length; i++) { 

        // This variable will hold a dictionary { letters: string, occurrances: int }
        // that will register how many times a substrings with letters in 'letters'
        // appeared in the string
        let letterCollection = {};

        // Inner loop: start index of the substring
        for (let j = 0; j <= s.length - i; j++) { 
            let substring = s.substr(j, i);

            // Two substrings are anagrams if they share the same letters,
            // so the string's characters are ordered to make this check easier
            // by making use of the hashmap's O(1) access
            substring = substring.split('').sort().join('');

            // If the function has already found a string with the same letters
            // a new occurrance means there will be <times-it-was-found-before> new
            // anagrams. Increase number of occurrances
            if (letterCollection[substring]) {
                anagrams += letterCollection[substring];
                letterCollection[substring]++;
            } else {
                // Else, it's the first time found and it's registered in the hashmap
                letterCollection[substring] = 1;
            }
        }
    }

    return anagrams;
}

function main() {
    const ws = fs.createWriteStream(process.env.OUTPUT_PATH);

    const q = parseInt(readLine(), 10);

    for (let qItr = 0; qItr < q; qItr++) {
        const s = readLine();

        let result = sherlockAndAnagrams(s);

        ws.write(result + "\n");
    }

    ws.end();
}
