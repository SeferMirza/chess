namespace Company.Chess.Module.Chess;

public interface IPiece
{
    string Square => string.Empty;
    Color Color {get;}
    void Move(string newSquare);
    string GetPieceName();
    List<string> GetSquareInPath(string newSquare);// Todo - default verilebilir
}