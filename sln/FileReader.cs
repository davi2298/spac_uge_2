public class FileReader
{
    public static string GetRandomWordFromFilePath(string path)
    {

        using (var streamReader = new StreamReader(path))
        {
            List<string> words = [];
            var line = "";
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith("#")) continue;
                words.Add(line);
            }
            return words[Random.Shared.Next(0, words.Count - 1)];
        }
    }
}