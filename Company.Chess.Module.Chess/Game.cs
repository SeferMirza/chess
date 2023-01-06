using Gazel;

namespace Company.Chess.Module.Chess;

public class Game
{
    public Game(Guid whitePlayer, Guid blackPlayer, List<IPiece> pieces)
    {
        WhitePlayer = whitePlayer;
        BlackPlayer = blackPlayer;
        Pieces = pieces;
    }

    public Guid WhitePlayer { get; }
    public Guid BlackPlayer { get; }
    public List<IPiece> Pieces { get; }
}