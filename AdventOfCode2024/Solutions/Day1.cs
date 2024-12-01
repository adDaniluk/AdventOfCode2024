using System.Text.RegularExpressions;
using static System.Int32;

namespace AdventOfCode2024.Solutions;

public class Day1
{
    private static readonly IList<string> InputList = InputReader.GetInputList(nameof(Day1));

    private readonly List<int> _leftListOrdered;
    private readonly List<int> _rightListOrdered;
    
    public Day1()
    {
        var leftList = new List<int>();
        var rightList = new List<int>();
        
        Regex reg = new("\\d+");
        foreach (var line in InputList)
        {
            var matches = reg.Matches(line);
            leftList.Add(Parse(matches[0].Value));
            rightList.Add(Parse(matches[1].Value));
        }

        _leftListOrdered = leftList.Order().ToList();
        _rightListOrdered = rightList.Order().ToList();
    }
    
    public int Task1()
    {
        var result = 0;

        for (int i = 0; i < _leftListOrdered.Count; i++)
        {
            result += Math.Abs(_leftListOrdered[i] - _rightListOrdered[i]);
        }
        
        return result;
    }

    public int Task2()
    {
        var result = 0;

        foreach (var number in _leftListOrdered)
        {
            result += _rightListOrdered.Count(x => x == number) * number;
        }

        return result;
    }
}