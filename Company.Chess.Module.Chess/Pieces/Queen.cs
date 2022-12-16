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
    public Color Color => _color;

    public void Move(string newSquare)
    {
        bool isNotMoveY = Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == 0;
        bool isNotMoveX = Math.Abs(newSquare.First().ToString().FindIndexInX() - _square.First().ToString().FindIndexInX()) == 0;
        bool isNotCorosMove = (int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString()))
                            - (_square.First().ToString().FindIndexInX() - newSquare.First().ToString().FindIndexInX()) != 0;

        if (isNotCorosMove && isNotMoveX && isNotMoveY) throw new Exception("Yanlış hamle");

        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + nameof(Queen);

    public List<string> GetSquareInPath(string newSquare)
    {
        // ToDo - Burda sıkıntı var 1 kare ileri giderken çaprazı hesaplıyor
        List<string> result = new();
        bool isMoveX = Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == 0;
        bool isMoveY = Math.Abs(newSquare.First().ToString().FindIndexInX() - _square.First().ToString().FindIndexInX()) == 0;
        bool isCorosMove =  isMoveY || isMoveX;//Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == Math.Abs(newSquare.First().ToString().FindIndexInX() - _square.First().ToString().FindIndexInX());

        if (isCorosMove)
        {
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
        }
        else
        {
            bool isLowerThenOldSquareY = int.Parse(newSquare.Last().ToString()) < int.Parse(_square.Last().ToString());
            bool isLowerThenOldSquareX = _square.First().ToString().FindIndexInX() > newSquare.First().ToString().FindIndexInX();
            var xPose = _square.First().ToString().FindIndexInX();
            if (isLowerThenOldSquareY)
            {
                if (isLowerThenOldSquareX)
                {

                    for (int i = int.Parse(_square.Last().ToString()); i >= int.Parse(newSquare.Last().ToString()) && xPose > 0; i--)
                    {
                        result.Add(Board.X[xPose - 1] + Board.Y[i]);
                        xPose--;
                    }
                }
                else
                {
                    for (int i = int.Parse(_square.Last().ToString()); i >= int.Parse(newSquare.Last().ToString()) && xPose < 8; i--)
                    {
                        result.Add(Board.X[xPose + 1] + Board.Y[i]);
                        xPose++;
                    }
                }
            }
            else
            {
                if (isLowerThenOldSquareX)
                {

                    for (int i = int.Parse(_square.Last().ToString()); i <= int.Parse(newSquare.Last().ToString()) && xPose > 0; i++)
                    {
                        result.Add(Board.X[xPose - 1] + Board.Y[i]);
                        xPose--;
                    }
                }
                else
                {
                    for (int i = int.Parse(_square.Last().ToString()); i <= int.Parse(newSquare.Last().ToString()) && xPose < 8; i++)
                    {
                        result.Add(Board.X[xPose + 1] + Board.Y[i]);
                        xPose++;
                    }
                }
            }
        }
        return result;
    }
}