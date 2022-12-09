namespace Company.Chess.Module.Chess;

public class Horse : IPiece
{
    private string _square;
    private readonly Color _color;
    private readonly Direction _direction;

    public Horse(string square, Color color, Direction direction)
    {
        _square = square;
        _color = color;
        _direction = direction;
    }
    string IPiece.Square => _square;

    public void Move(string newSquare)
    {
        bool isNotMove = _square == newSquare;
        _square = newSquare;
    }
    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Horse);

}