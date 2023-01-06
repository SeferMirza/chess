namespace Company.Chess.Module.Chess;

public static class Board
{
    public static string[] X = { "A", "B", "C", "D", "E", "F", "G", "H" };
    public static string[] Y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    public static int FindIndexInX(this string elem)
    {
        for (var i = 0; i < 8; i++)
        {
            if (X[i] == elem)
            {
                return i;
            }
        }
        return 0;
    }
}