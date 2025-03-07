using static System.Console;
public class Veiw : IVeiw
{
    public Veiw() {

    }
    public void ShowReady(){
        WriteLine("Ready for input\n--------------");
    }

    public void ShowDone()
    {
        WriteLine("Done");
    }

    public void ShowGuessResult((ConsoleColor, char)[] result)
    {
        var nortmalBackground = BackgroundColor;
        foreach(var subResult in result)
        {
            BackgroundColor = subResult.Item1;
            Write(subResult.Item2);
        }

        BackgroundColor = nortmalBackground;
        WriteLine("");
    }
}
