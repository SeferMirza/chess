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
    public Color Color => _color;

    public void Move(string newSquare)
    {
        bool isFalseMoveOnY = Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) > 1;
        bool isFalseMoveOnX = (Math.Abs(newSquare.First().ToString().FindIndexInX() - _square.First().ToString().FindIndexInX()) > 1);
        bool isNotMoveXY = newSquare == _square;

        if(isFalseMoveOnY || isFalseMoveOnX || isNotMoveXY) throw new Exception("Geçersiz hareket");

        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + nameof(Elephant);

    public List<string> GetSquareInPath(string newSquare)
    {
        return new();
    }
}