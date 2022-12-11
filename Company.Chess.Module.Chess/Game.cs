using Gazel;

namespace Company.Chess.Module.Chess;

public class Game
{
    public Game(Guid player1, Guid player2, List<IPiece> pieces)
    {
        Player1 = player1;
        Player2 = player2;
        Pieces = pieces;
    }

    public Guid Player1 { get; }
    public Guid Player2 { get; }
    public List<IPiece> Pieces { get; }
}