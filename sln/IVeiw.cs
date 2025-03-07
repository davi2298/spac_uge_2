
public interface IVeiw
{
    public void ShowReady();
    public void ShowGuessResult((ConsoleColor,char)[] result);
    public void ShowDone();
}