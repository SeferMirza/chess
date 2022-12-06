using Gazel;

namespace Company.Chess.Module.Chess;

public class ChessManager
{
    private string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    private readonly IModuleContext _context;

    public ChessManager(IModuleContext context)
    {
        _context = context;
    }

    public Guid Auth(Guid guid)
    {
        return guid;
    }

    public Dictionary<string,string> CreateBoard()
    {
        Dictionary<string,string> board = new();
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                board.Add(x[i]+y[j], "Empty");
            }
        }

        return board;
    }
}