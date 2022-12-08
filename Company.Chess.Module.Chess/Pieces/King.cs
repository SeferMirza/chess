namespace Company.Chess.Module.Chess;

public class King : IPiece
{
    private string _square;
    private readonly Color _color;

    public King(string square, Color color)
    {
        _square = square;
        _color = color;
    }
    string IPiece.Square => _square;

    public void Move(string newSquare)
    {
        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + nameof(Elephant);

}