using Gazel;

namespace Company.Chess.Module.Chess;

public class ChessManager
{
    private const int MAX_PLAYER = 2;
    private List<List<Guid>> _players = new List<List<Guid>>();

    private string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    private List<Piece> startPiece = new List<Piece>()
    {
        new Piece("A1", "WhiteCastleLeft"),
        new Piece("H1", "WhiteCastleRight"),
        new Piece("B1", "WhiteHorseLeft"),
        new Piece("G1", "WhiteHorseRight"),
        new Piece("C1", "WhiteElephantLeft"),
        new Piece("F1", "WhiteElephantRight"),
        new Piece("D1", "WhiteQueen"),
        new Piece("E1", "WhiteKing"),
        new Piece("A8", "BlackCastleLeft"),
        new Piece("H8", "BlackCastleRight"),
        new Piece("B8", "BlackHorseLeft"),
        new Piece("G8", "BlackHorseRight"),
        new Piece("C8", "BlackElephantLeft"),
        new Piece("F8", "BlackElephantRight"),
        new Piece("D8", "BlackQueen"),
        new Piece("E8", "BlackKing"),
        new Piece("A2", "WhitePawn1"),
        new Piece("B2", "WhitePawn2"),
        new Piece("C2", "WhitePawn3"),
        new Piece("D2", "WhitePawn4"),
        new Piece("E2", "WhitePawn5"),
        new Piece("F2", "WhitePawn6"),
        new Piece("G2", "WhitePawn7"),
        new Piece("H2", "WhitePawn8"),
        new Piece("A7", "BlackPawn1"),
        new Piece("B7", "BlackPawn2"),
        new Piece("C7", "BlackPawn3"),
        new Piece("D7", "BlackPawn4"),
        new Piece("E7", "BlackPawn5"),
        new Piece("F7", "BlackPawn6"),
        new Piece("G7", "BlackPawn7"),
        new Piece("H7", "BlackPawn8")
    };

    private readonly IModuleContext _context;

    public ChessManager(IModuleContext context)
    {
        _context = context;
    }

    // Kullanıcı bağlantıları
    public Guid Auth(Guid guid)
    {
        foreach (var loby in _players)
        {
            if (loby.Contains(guid) && loby.Count == 2) throw new Exception("max 2 player");
            else if (loby.Contains(guid) && loby.Count == 1)
            {
                loby.Add(guid);
                return guid;
            }
        }

        _players.Add(new List<Guid>() { guid });

        return guid;
    }

    // Bağlantı başına bir oyun oluşur.
    public void CreateGame() { }

    // Taş hareketi. Not: json yada class dönülebilir. Client tarafında işler kolaylaşır
    public string Move(Guid guid, string oldSquare, string newSquare)
    {

        return "";
    }

    
    # region TEST İÇİN 
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

    // ToDo - Test için boardı görmek adına
    public Dictionary<string, string> GetBoardWithPieces()
    {
        var emptyBoard = CreateBoard();
        foreach (var square in emptyBoard)
        {
            foreach (var piece in startPiece)
            {
                if (square.Key == piece.Square)
                {
                    emptyBoard[square.Key] = piece.Name;
                }
            }
        }

        return emptyBoard;
    }

    // ToDo - Test için yazılmış method iş bitince kaldırılacak yada private alınacak
    public List<string> GetListForTest()
    {
        var board = GetBoardWithPieces();
        var result = new List<string>();

        foreach(var square in board)
        {
            result.Add(square.Key + " - " + square.Value);
        }

        return result;
    }
    # endregion
}