using Gazel;

namespace Company.Chess.Module.Chess;

public class ChessManager
{
    private const int MAX_PLAYER = 2;
    private Guid[] _playes = { };

    private string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    private readonly IModuleContext _context;

    public ChessManager(IModuleContext context)
    {
        _context = context;
    }

    public Guid Auth(Guid guid)
    {
        if (_playes.Count() == MAX_PLAYER) throw new Exception("2 kişi kafi");

        _playes.Append(guid);
        
        return guid;
    }

    public Dictionary<string, string> CreateBoard()
    {
        Dictionary<string, string> board = new();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.Add(x[i] + y[j], "Empty");
            }
        }

        return board;
    }
}