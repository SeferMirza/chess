namespace Company.Chess.Module.Chess.Pieces;

public class Pawn : IPiece
{
    private string _square;
    private readonly Color _color;
    private readonly string _name;

    public Pawn(string square, Color color, string name)
    {
        _square = square;
        _color = color;
        _name = name;
    }

    string IPiece.Square => _square;
    public Color Color => _color;

    public void Move(string newSquare)
    {
        bool isOneSquareMove = int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString()) == 1;
        bool isSameLine = newSquare.First() == _square.First();

        if(isOneSquareMove && isSameLine) throw new Exception("Geçersiz hamle");

        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + _name;

    public List<string> GetSquareInPath(string newSquare)
    {
        return new();
    }
}