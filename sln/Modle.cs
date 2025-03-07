public class Modle
{
    public string? Goal { get; set; }


    /// <summary>
    /// Takes a guess in for of a string and return a list of color and char pairs that, 
    /// reflect what chars were in the goal and if they were placed correctly
    /// </summary>
    /// <param name="guess"></param>
    /// <returns>An array with the color char pair of the guess</returns>
    public (ConsoleColor, char)[] NewGuess(string guess)
    {
        var guessChars = guess.ToLower().ToArray();
        var goalChars = Goal!.ToLower().ToArray();
        var result = new (ConsoleColor, char)[5];

        for (int i = 0; i < 5; i++)
        {
            if (guessChars[i] == goalChars[i])
            {
                result[i] = (ConsoleColor.Green, guessChars[i]);
                goalChars[i] = ' ';
                continue;
            }
        }
        for (int i = 0; i < 5; i++)
        {
            if (!result[i].Item2.Equals('\0'))
            {
                continue;
            }
            if (goalChars.Contains(guessChars[i]))
            {
                goalChars[Goal.IndexOf(guessChars[i])] = ' ';
                result[i] = (ConsoleColor.Yellow, guessChars[i]);
                continue;
            }
            result[i] = (ConsoleColor.Red, guessChars[i]);
        }
        return result;
    }
}
