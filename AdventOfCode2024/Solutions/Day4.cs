namespace AdventOfCode2024.Solutions;

/*
--- Day 4: Ceres Search ---
"Looks like the Chief's not here. Next!" One of The Historians pulls out a device and pushes the only button on it. After a brief flash, you recognize the interior of the Ceres monitoring station!

As the search for the Chief continues, a small Elf who lives on the station tugs on your shirt; she'd like to know if you could help her with her word search (your puzzle input). She only has to find one word: XMAS.

This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words. It's a little unusual, though, as you don't merely need to find one instance of XMAS - you need to find all of them. Here are a few ways XMAS might appear, where irrelevant characters have been replaced with .:


..X...
.SAMX.
.A..A.
XMAS.S
.X....
The actual word search will be full of letters instead. For example:

MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX
In this word search, XMAS occurs a total of 18 times; here's the same word search again, but where letters not involved in any XMAS have been replaced with .:

....XXMAS.
.SAMXMS...
...S..A...
..A.A.MS.X
XMASAMX.MM
X.....XA.A
S.S.S.S.SS
.A.A.A.A.A
..M.M.M.MM
.X.X.XMASX
Take a look at the little Elf's word search. How many times does XMAS appear?

Your puzzle answer was 2468.

The first half of this puzzle is complete! It provides one gold star: *

--- Part Two ---
The Elf looks quizzically at you. Did you misunderstand the assignment?

Looking for the instructions, you flip over the word search to find that this isn't actually an XMAS puzzle; it's an X-MAS puzzle in which you're supposed to find two MAS in the shape of an X. One way to achieve that is like this:

M.S
.A.
M.S
Irrelevant characters have again been replaced with . in the above diagram. Within the X, each MAS can be written forwards or backwards.

Here's the same example from before, but this time all of the X-MASes have been kept instead:

.M.S......
..A..MSMS.
.M.S.MAA..
..A.ASMSM.
.M.S.M....
..........
S.S.S.S.S.
.A.A.A.A..
M.M.M.M.M.
..........
In this example, an X-MAS appears 9 times.

Flip the word search from the instructions back over to the word search side and try again. How many times does an X-MAS appear?
*/

public class Day4 : IDay
{
    private static readonly IList<string> InputList = InputReader.GetInputList("Day4");
    private const string word = "XMAS";
    private readonly List<List<char>> _inputListChars = [];
    
    public Day4()
    {
        foreach (var line in InputList)
        {
            _inputListChars.Add(line.ToCharArray().ToList());
        }
    }

    private int Task1()
    {
        var results = 0;
        
        for (int i = 0; i < _inputListChars.Count; i++)
        {
            for (int j = 0; j < _inputListChars[i].Count; j++)
            {
                if (CheckEast(i, j))
                    results++;
                if (CheckWest(i, j))
                    results++;
                if (CheckNorth(i, j))
                    results++;
                if (CheckSouth(i, j))
                    results++;
                if (CheckNorthEast(i, j))
                    results++;
                if (CheckNorthWest(i, j))
                    results++;
                if (CheckSouthEast(i, j))
                    results++;
                if (CheckSouthWest(i, j))
                    results++;
            }
        }
        
        return results;
    }
    
    private bool CheckWest(int i, int j)
    {
        if (j - 3 < 0)
            return false;

        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i][j - 1],
            _inputListChars[i][j - 2],
            _inputListChars[i][j - 3]
        ]);
    }
    
    private bool CheckEast(int i, int j)
    {
        if (j + 3 >= _inputListChars[0].Count)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i][j + 1],
            _inputListChars[i][j + 2],
            _inputListChars[i][j + 3]
        ]);
    }
    
    private bool CheckNorth(int i, int j)
    {
        if (i - 3 < 0)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i - 1][j],
            _inputListChars[i - 2][j],
            _inputListChars[i - 3][j]
        ]);
    }
    
    private bool CheckSouth(int i, int j)
    {
        if (i + 3 >= _inputListChars.Count)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i + 1][j],
            _inputListChars[i + 2][j],
            _inputListChars[i + 3][j]
        ]);
    }
    
    private bool CheckNorthWest(int i, int j)
    {
        if (i - 3 < 0 || j - 3 < 0)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i - 1][j - 1],
            _inputListChars[i - 2][j - 2],
            _inputListChars[i - 3][j - 3]
        ]);
    }
    
    private bool CheckNorthEast(int i, int j)
    {
        if (i - 3 < 0 || j + 3 >= _inputListChars[0].Count)
            return false;
            
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i - 1][j + 1],
            _inputListChars[i - 2][j + 2],
            _inputListChars[i - 3][j + 3]
        ]);
    }
    
    private bool CheckSouthEast(int i, int j)
    {
        if (i + 3 >= _inputListChars.Count || j + 3 >= _inputListChars[0].Count)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i + 1][j + 1],
            _inputListChars[i + 2][j + 2],
            _inputListChars[i + 3][j + 3]
        ]);
    }
    
    private bool CheckSouthWest(int i, int j)
    {
        if (i + 3 >= _inputListChars.Count || j - 3 < 0)
            return false;
        
        return FindXmas([
            _inputListChars[i][j],
            _inputListChars[i + 1][j - 1],
            _inputListChars[i + 2][j - 2],
            _inputListChars[i + 3][j - 3]
        ]);
    }

    private bool FindXmas(List<int> chars)
    {
        if (4 != chars.Count)
            return false;

        return chars[0] == 'X' && chars[1] == 'M' && chars[2] == 'A' && chars[3] == 'S';
    }
    
    
    public void GetTask1()
    {
        Console.WriteLine(Task1().ToString());
    }

    public void GetTask2()
    {
        throw new NotImplementedException();
    }
}