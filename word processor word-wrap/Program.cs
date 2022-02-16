using System;
using System.Collections.Generic;
using System.Text;

/*
We are building a word processor and we would like to implement a "word-wrap" functionality.

Given a list of words followed by a maximum number of characters in a line, return a collection of strings where each string element represents a line that contains as many words as possible, with the words in each line being concatenated with a single '-' (representing a space, but easier to see for testing). The length of each string must not exceed the maximum character length per line.

Your function should take in the maximum characters per line and return a data structure representing all lines in the indicated max length.

Examples:

words1 = [ "The", "day", "began", "as", "still", "as", "the",
          "night", "abruptly", "lighted", "with", "brilliant",
          "flame" ]

wrapLines(words1, 13) "wrap words1 to line length 13" =>

  [ "The-day-began",
    "as-still-as",
    "the-night",
    "abruptly",
    "lighted-with",
    "brilliant",
    "flame" ]

wrapLines(words1, 20) "wrap words1 to line length 20" =>

  [ "The-day-began-as",
    "still-as-the-night",
    "abruptly-lighted",
    "with-brilliant-flame" ]
    
words2 = [ "Hello" ]

wrapLines(words2, 5) "wrap words2 to line length 5" =>

  [ "Hello" ]

words3 = [ "Hello", "world" ]

wrapLines(words3, 5) "wrap words3 to line length 5" =>

  [ "Hello", 
  "world" ]

words4 = ["Well", "Hello", "world" ]

wrapLines(words4, 5) "wrap words4 to line length 5" =>

  [ "Well",
  "Hello", 
  "world" ]

words5 = ["Hello", "HelloWorld", "Hello", "Hello"]

wrapLines(words5, 20) "wrap words 5 to line length 20 =>

  [ "Hello-HelloWorld",
    "Hello-Hello" ]


n = number of words OR total characters
        String[] words2 = new String[] {"Hello"};
        int lineLength2_1 = 5;

        String[] words3 = new String[] {"Hello", "world"};
        int lineLength3_1 = 5;

        String[] words4 = new String[] {"Well", "Hello", "world"};
        int lineLength4_1 = 5;

        String[] words5 = new String[] {"Hello", "HelloWorld", "Hello", "Hello"};
        int lineLength5_1 = 20;
        
        int lineLength1_2 = 20;
*/


class Solution
{
  static void Main(string[] args)
  {
    string[] words = new string[] { "Hello", "HelloWorld", "Hello", "Hello" };
    int lineLength = 20;

    var result = Justify(words, lineLength);
    foreach (var line in result)
      Console.WriteLine(line);
  }

  private static List<string> Justify(string[] words, int wordLength)
  {
    List<string> result = new List<string>();
    int charRemaining = wordLength - 0;
    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < words.Length; i++)
    {
      string word = words[i];
      int length = word.Length;
      if (length <= charRemaining)
      {
        builder.Append(word);
        builder.Append("-");
      }
      else
      {
        builder.Remove(builder.Length - 1, 1);
        result.Add(builder.ToString());
        builder = new StringBuilder();
        charRemaining = wordLength;
        i--;
        continue;
      }

      charRemaining = charRemaining - length - 1;
    }

    if (builder.Length > 0)
    {
      builder.Remove(builder.Length - 1, 1);
      result.Add(builder.ToString());
    }

    return result;
  }
}
