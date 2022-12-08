namespace Company.Chess.Module.Chess;

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

    public void Move(string newSquare)
    {
        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + _name;

}