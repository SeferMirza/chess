namespace Company.Chess.Module.Chess;

public class Castle : IPiece
{
    private string _square;
    private readonly Color _color;
    private readonly Direction _direction;

    public Castle(string square, Color color, Direction direction)
    {
        _square = square;
        _color = color;
        _direction = direction;
    }

    string IPiece.Square => _square;

    public void Move(string newSquare)
    {
        bool isCrossMove = Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) >= 1 && _square.First() != newSquare.First();

        if(isCrossMove) throw new Exception("Geçersiz hareket");
        
        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Castle);
}