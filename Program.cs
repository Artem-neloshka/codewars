using System;
using System.Security.Cryptography;

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


/*Greed is a dice game played with five six-sided dice.
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

public static class Kata
{
  public static int Score(int[] dice) {
		Dictionary<int, int> winningValues = new Dictionary<int, int>
		{
			{1, 0},
			{2, 0},
			{3, 0},
			{4, 0},
			{5, 0},
			{6, 0}
		};

		for (int i = 0; i < dice.Length; i++)
		{
			winningValues[dice[i]]++;
		}

		int result = 0;
		foreach (var item in winningValues)
		{
			if (item.Value > 2)
			{
				result += (item.Key != 1) ? item.Key * 100 : 1000;
				if (item.Key == 1)
				{
					result += 100 * (item.Value - 3);
				}
			}
			else if (item.Value > 0)
			{
				if (item.Key == 5)
				{
					result += 50 * item.Value;
				}
				else if (item.Key == 1)
				{
					result += 100 * item.Value;
				}
			}
		}
    return result;
  }
}

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine(Kata.Score(new int[] {2, 3, 4, 6, 2}));
	}
}