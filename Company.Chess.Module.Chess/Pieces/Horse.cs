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
        bool isMoveLPattern1 = Math.Abs(newSquare.FindIndexInX() - _square.FindIndexInX()) == 2 && Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == 1;
        bool isMoveLPattern2 = Math.Abs(newSquare.FindIndexInX() - _square.FindIndexInX()) == 1 && Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == 2;
        bool isNotMove = _square == newSquare;

        if(!(isMoveLPattern1 || isMoveLPattern2) || isNotMove) throw new Exception("Yanlış hareket");

        _square = newSquare;
    }
    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Horse);

    public List<string> GetSquareInPath(string newSquare)
    {
        throw new NotImplementedException();
    }
}