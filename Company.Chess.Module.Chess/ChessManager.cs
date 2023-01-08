using Company.Chess.Module.Chess.Pieces;
using Gazel;

namespace Company.Chess.Module.Chess;

public class ChessManager
{
    private const int MAX_PLAYER = 2;
    private List<Game> _games = new List<Game>();
    private string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    private List<IPiece> startPiece = new List<IPiece>()
    {
        new Castle("A1", Color.White, Direction.Left),
        new Castle("H1", Color.White, Direction.Rigth),
        new Horse("B1",Color.White, Direction.Left),
        new Horse("G1", Color.White, Direction.Rigth),
        new Elephant("C1", Color.White, Direction.Left),
        new Elephant("F1",Color.White, Direction.Rigth),
        new Queen("D1",Color.White),
        new King("E1", Color.White),
        new Castle("A8", Color.Black, Direction.Left),
        new Castle("H8", Color.Black, Direction.Rigth),
        new Horse("B8", Color.Black, Direction.Left),
        new Horse("G8", Color.Black, Direction.Rigth),
        new Elephant("C8", Color.Black, Direction.Left),
        new Elephant("F8", Color.Black, Direction.Rigth),
        new Queen("D8", Color.Black),
        new King("E8", Color.Black),
        new Pawn("A2", Color.White, "Pawn1"),
        new Pawn("B2", Color.White, "Pawn2"),
        new Pawn("C2", Color.White, "Pawn3"),
        new Pawn("D2", Color.White, "Pawn4"),
        new Pawn("E2", Color.White, "Pawn5"),
        new Pawn("F2", Color.White, "Pawn6"),
        new Pawn("G2", Color.White, "Pawn7"),
        new Pawn("H2", Color.White, "Pawn8"),
        new Pawn("A7", Color.Black, "Pawn1"),
        new Pawn("B7", Color.Black, "Pawn2"),
        new Pawn("C7", Color.Black, "Pawn3"),
        new Pawn("D7", Color.Black, "Pawn4"),
        new Pawn("E7", Color.Black, "Pawn5"),
        new Pawn("F7", Color.Black, "Pawn6"),
        new Pawn("G7", Color.Black, "Pawn7"),
        new Pawn("H7", Color.Black, "Pawn8")
    };

    private readonly IModuleContext _context;

    public ChessManager(IModuleContext context)
    {
        _context = context;
    }

    // Kullanıcı bağlantıları
    public Guid Auth(Guid guid)
    {
        return guid;
    }

    // Bağlantı başına bir oyun oluşur.
    public Game CreateGame(List<IPiece> pieces = default!)
    {
        pieces = (pieces == null ? startPiece : (pieces.FirstOrDefault() == default ? startPiece : pieces));
        var game = new Game(Guid.Empty, Guid.Empty, pieces);
        _games.Add(game);
        return game;
    }

    // Taş hareketi. Not: json yada class dönülebilir. Client tarafında işler kolaylaşır
    public Game Move(string oldSquare, string newSquare, Game game = default!)
    {
        game = game ??= _games.First();
        foreach (var piece in game.Pieces)
        {
            if (piece.Square == oldSquare)
            {
                if (!piece.CanMove(game, newSquare)) { throw new Exception("İşlem geçersiz"); }
                var isEmpty = piece.SquareIsEmpty(game, newSquare);

                if (isEmpty)
                {
                    piece.Move(newSquare);
                }
                else if (!isEmpty && piece.CanEat(game, newSquare))
                {
                    piece.Move(newSquare);
                    game.Pieces.Remove(game.Pieces.Find(p => p.Square == newSquare)!);
                }
                return _games.First();
            }
        }
        throw new Exception("İşlem geçersiz");
    }
}