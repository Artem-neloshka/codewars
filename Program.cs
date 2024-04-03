using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/*5 kyu
I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it?
According to Wikipedia, ROT13 is frequently used to obfuscate jokes on USENET.

For this task you're only supposed to substitute characters. Not spaces, punctuation, numbers, etc.

Test examples:

"EBG13 rknzcyr." -> "ROT13 example."

"This is my first ROT13 excercise!" -> "Guvf vf zl svefg EBG13 rkprepvfr!"*/

// public class Kata
// {
//   public static string Rot13(string input)
//   {
// 		char[] letters = input.ToCharArray();
// 		for (int i = 0; i < letters.Length; i++)
// 		{
// 			if (char.IsLetter(letters[i]))
// 			{
// 				char offset = char.IsUpper(letters[i]) ? 'A' : 'a';
//       	letters[i] = (char)(((letters[i] - offset + 13) % 26) + offset);
// 			}
// 		}
//     return string.Concat(letters);
//   }
// }




/* 5 kyu
Greed is a dice game played with five six-sided dice.
Your mission, should you choose to accept it, is to score a throw according to these rules.
You will always be given an array with five six-sided dice values.

 Three 1's => 1000 points
 Three 6's =>  600 points
 Three 5's =>  500 points
 Three 4's =>  400 points
 Three 3's =>  300 points
 Three 2's =>  200 points
 One   1   =>  100 points
 One   5   =>   50 point
A single die can only be counted once in each roll. For example,
a given "5" can only count as part of a triplet (contributing to the 500 points) or as a single 50 points,
but not both in the same roll.

Example scoring

 Throw       Score
 ---------   ------------------
 5 1 3 4 1   250:  50 (for the 5) + 2 * 100 (for the 1s)
 1 1 1 3 1   1100: 1000 (for three 1s) + 100 (for the other 1)
 2 4 4 5 4   450:  400 (for three 4s) + 50 (for the 5)
In some languages, it is possible to mutate the input to the function.
This is something that you should never do. If you mutate the input, you will not be able to pass all the tests.*/

// public static class Kata
// {
//   public static int Score(int[] dice) {
// 		Dictionary<int, int> winningValues = new Dictionary<int, int>
// 		{
// 			{1, 0},
// 			{2, 0},
// 			{3, 0},
// 			{4, 0},
// 			{5, 0},
// 			{6, 0}
// 		};

// 		for (int i = 0; i < dice.Length; i++)
// 		{
// 			winningValues[dice[i]]++;
// 		}

// 		int result = 0;
// 		foreach (var item in winningValues)
// 		{
// 			if (item.Value > 2)
// 			{
// 				result += (item.Key != 1) ? item.Key * 100 : 1000;
// 				if (item.Key == 1)
// 				{
// 					result += 100 * (item.Value - 3);
// 				}
// 			}
// 			else if (item.Value > 0)
// 			{
// 				if (item.Key == 5)
// 				{
// 					result += 50 * item.Value;
// 				}
// 				else if (item.Key == 1)
// 				{
// 					result += 100 * item.Value;
// 				}
// 			}
// 		}
//     return result;
//   }
// }




/* 4 kyu (i finally did it!!!!!!)
Your task in this Kata is to emulate text justification in monospace font. You will be given
a single-lined text and the expected justification width. The longest word will never be greater than this width.

Here are the rules:

Use spaces to fill in the gaps between words.
Each line should contain as many words as possible.
Use '\n' to separate lines.
Gap between words can't differ by more than one space.
Lines should end with a word not a space.
'\n' is not included in the length of a line.
Large gaps go first, then smaller ones ('Lorem--ipsum--dolor--sit-amet,' (2, 2, 2, 1 spaces)).
Last line should not be justified, use only one space between words.
Last line should not contain '\n'
Strings with one word do not need gaps ('somelongword\n').
Example with width=30:

Lorem  ipsum  dolor  sit amet,
consectetur  adipiscing  elit.
Vestibulum    sagittis   dolor
mauris,  at  elementum  ligula
tempor  eget.  In quis rhoncus
nunc,  at  aliquet orci. Fusce
at   dolor   sit   amet  felis
suscipit   tristique.   Nam  a
imperdiet   tellus.  Nulla  eu
vestibulum    urna.    Vivamus
tincidunt  suscipit  enim, nec
ultrices   nisi  volutpat  ac.
Maecenas   sit   amet  lacinia
arcu,  non dictum justo. Donec
sed  quam  vel  risus faucibus
euismod.  Suspendisse  rhoncus
rhoncus  felis  at  fermentum.
Donec lorem magna, ultricies a
nunc    sit    amet,   blandit
fringilla  nunc. In vestibulum
velit    ac    felis   rhoncus
pellentesque. Mauris at tellus
enim.  Aliquam eleifend tempus
dapibus. Pellentesque commodo,
nisi    sit   amet   hendrerit
fringilla,   ante  odio  porta
lacus,   ut   elementum  justo
nulla et dolor.
Also you can always take a look at how justification works in your text editor or directly in HTML
(css: text-align: justify).

Have fun :)*/

public class Kata
{
  private static string WriteSpacesInLine(string line, int AmountOfSpacesToWrite)
  {
    string[] wordsInLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (wordsInLine.Length == 1)
    {
      return line.Substring(0, line.Length - 1) + "\n";
    }
    int counter = 0;

    while (AmountOfSpacesToWrite > 0)
    {
      wordsInLine[counter % (wordsInLine.Length - 1)] += " ";
      AmountOfSpacesToWrite--;
      counter++;
    }

    return string.Join(" ", wordsInLine) + "\n";
  }
	public static string WriteSpaces(string str, int TotalAmountOfSpaces)
  {
    string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    StringBuilder line = new StringBuilder();
    StringBuilder result = new StringBuilder();
    for (int i = 0; i < words.Length; i++)
    {
      if ((line + words[i]).Length > TotalAmountOfSpaces)
      {
        result.Append(WriteSpacesInLine(line.ToString(), TotalAmountOfSpaces - line.Length));
        line.Clear();
      }
      line.Append((i == words.Length - 1) ? words[i] : words[i] + " ");
    }
    
		return result.Append(line).ToString();
  }
}

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine(Kata.WriteSpaces("123 45 6 98q5984 9q32 q q9 q 2q 43fq 2 3r32", 8));
	}
}