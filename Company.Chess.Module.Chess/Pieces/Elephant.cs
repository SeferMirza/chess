namespace Company.Chess.Module.Chess.Pieces;

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
    public Color Color => _color;

    public void Move(string newSquare)
    {
        bool isCorosMove = int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString()) == Math.Abs(_square.First().ToString().FindIndexInX() - newSquare.First().ToString().FindIndexInX());

        if (!isCorosMove) throw new Exception("Geçersiz hamle");

        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + _direction.StringValue() + " " + nameof(Elephant);

    public List<string> GetSquareInPath(string newSquare)
    {
        List<string> result = new();
        bool isLowerThenOldSquareY = int.Parse(newSquare.Last().ToString()) < int.Parse(_square.Last().ToString());
        bool isLowerThenOldSquareX = _square.First().ToString().FindIndexInX() > newSquare.First().ToString().FindIndexInX();
        var xPose = _square.First().ToString().FindIndexInX();
        if (isLowerThenOldSquareY)
        {
            if (isLowerThenOldSquareX)
            {
                for (int i = int.Parse(_square.Last().ToString()); i > int.Parse(newSquare.Last().ToString()) && xPose > 0; i--)
                {
                    result.Add(Board.X[xPose - 1] + Board.Y[i]);
                    xPose--;
                }
            }
            else
            {
                for (int i = int.Parse(_square.Last().ToString()); i > int.Parse(newSquare.Last().ToString()) && xPose < 7; i--)
                {
                    result.Add(Board.X[xPose + 1] + Board.Y[i-1]);
                    xPose++;
                }
            }
        }
        else
        {
            if (isLowerThenOldSquareX)
            {

                for (int i = int.Parse(_square.Last().ToString()); i < int.Parse(newSquare.Last().ToString()) && xPose > 0; i++)
                {
                    result.Add(Board.X[xPose - 1] + Board.Y[i]);
                    xPose--;
                }
            }
            else
            {
                for (int i = int.Parse(_square.Last().ToString()); i < int.Parse(newSquare.Last().ToString()) && xPose < 7; i++)
                {
                    result.Add(Board.X[xPose + 1] + Board.Y[i-1]);
                    xPose++;
                }
            }
        }
        return result;
    }
}