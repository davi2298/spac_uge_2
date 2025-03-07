using static System.Console;
public class Controler
{
    private int numGuesses = 0;
    public bool IsDone { get; private set; } = false;
    Modle modle;
    IVeiw veiw;

    public Controler(Modle modle, IVeiw veiw, string goal)
    {
        this.modle = modle;
        this.modle.Goal = goal;
        this.veiw = veiw;
    }
    public void MakeGuess()
    {
        numGuesses++;
        var guess = ReadLine();
        if (guess!.Length != 5)
        {
            if (guess.Length < 5)
                WriteLine("gues to short");
            else
                WriteLine("guess to long");
            veiw.ShowReady();
            return;
        }
        if (guess.Any(char.IsDigit))
        {
            WriteLine("guess contains a number");
            veiw.ShowReady();
            return;
        }
        var guessResult = modle.NewGuess(guess!);
        var done = true;
        foreach (var guessPart in guessResult)
        {
            if (guessPart.Item1 != ConsoleColor.Green)
            {
                done = false;
                break;
            }
        }
        IsDone = done;
        veiw.ShowGuessResult(guessResult);
        if (IsDone)
        {
            veiw.ShowDone();
            return;
        }
        if (numGuesses < 6)
        {
            veiw.ShowReady();
            return;
        }
        IsDone = true;
        veiw.ShowDone();
    }
}