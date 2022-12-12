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

        if (isCrossMove) throw new Exception("Geçersiz hareket");

        _square = newSquare;
    }

    public List<string> GetSquareInPath(string newSquare)
    {
        List<string> result = new List<string>();

        int yOldSquare = int.Parse(_square.Last().ToString());
        int yNewSquare = int.Parse(newSquare.Last().ToString());
        int yFark = Math.Abs(yOldSquare - yNewSquare);

        int xOldSquare = _square.First().ToString().FindIndexInX();
        int xNewSquare = newSquare.First().ToString().FindIndexInX();
        int xFark = Math.Abs(xOldSquare - xNewSquare);

        bool ilerimiGidecek = xFark > yFark;
        // Y eksenininde hareket ediliyorsa
        if (!ilerimiGidecek && newSquare.First() == _square.First())
        {
            foreach (var ySquare in Board.Y.Skip(yOldSquare < yNewSquare ? yOldSquare : yNewSquare).Take(yFark - 1))
            {
                result.Add(_square.First().ToString() + ySquare);
            }
        }
        else if (ilerimiGidecek && _square.Last() == newSquare.Last())
        {
            foreach (var ySquare in Board.X.Skip(xOldSquare < xNewSquare ? xOldSquare : xNewSquare).Take(xFark - 1))
            {
                result.Add(_square.Last().ToString() + ySquare);
            }
        }

        return result;
    }

    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Castle);
}