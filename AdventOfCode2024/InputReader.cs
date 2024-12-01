using System.Text;

namespace AdventOfCode2024;

public static class InputReader
{
    public static IList<string> GetInputList(string fileName)
    {
        var path = Path.Combine(Environment.CurrentDirectory, @"Input/", fileName + ".txt");
        var list = new List<string>();

        using var streamReader = new StreamReader(path, Encoding.UTF8);
        while (!streamReader.EndOfStream)
        {
            list.Add(streamReader.ReadLine()!);
        }

        return list;
    }
}