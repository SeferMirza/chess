namespace Company.Chess.Module.Chess;

public class Queen : IPiece
{
    private string _square;
    private readonly Color _color;

    public Queen(string square, Color color)
    {
        _square = square;
        _color = color;
    }
    string IPiece.Square => _square;

    public void Move(string newSquare)
    {
        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + nameof(Queen);

}