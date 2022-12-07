namespace Company.Chess.Module.Chess;

public interface IPiece
{
    public Piece Move(string oldSquare, string newSquare);
}