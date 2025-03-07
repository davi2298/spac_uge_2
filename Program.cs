class Program
{
    private static string path = $"./wordle_ord.txt";
    public static void Main(string[] args)
    {
        try
        {
            var goal = FileReader.GetRandomWordFromFilePath(path);
            Veiw veiw = new();
            Modle modle = new();
            Controler controler = new(modle, veiw, goal);
            veiw.ShowReady();
            Console.WriteLine(goal);
            while (!controler.IsDone)
            {
                controler.MakeGuess();
            }
            Console.WriteLine(goal);
        }
        catch (IOException)
        {
            Console.WriteLine("Word file not found");
        }

    }
}