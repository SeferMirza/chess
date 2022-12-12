namespace Company.Chess.Module.Chess;

public class Elephant : IPiece
{
    private string _square;

    private readonly Color _color;
    private readonly Direction _direction;

    public Elephant(string square, Color color, Direction direction)
    {
        _square = square;
        _color = color;
        _direction = direction;
    }

    string IPiece.Square => _square;

    public void Move(string newSquare)
    {
        bool isCorosMove = int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString()) == 0
                        && _square.First().ToString().FindIndexInX() - newSquare.First().ToString().FindIndexInX() == 0;

        if(!isCorosMove) throw new Exception("Geçersiz hamle");

        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Elephant);

    public List<string> GetSquareInPath(string newSquare)
    {
        throw new NotImplementedException();
    }
}