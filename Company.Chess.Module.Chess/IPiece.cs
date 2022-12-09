namespace Company.Chess.Module.Chess;

public interface IPiece
{
    string Square => "Empty";
    void Move(string newSquare);
    string GetPieceName();
}