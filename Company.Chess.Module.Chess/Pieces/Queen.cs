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
        bool isNotMoveY = Math.Abs(int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) == 0;
        bool isNotMoveX = Math.Abs(newSquare.First().ToString().FindIndexInX() - _square.First().ToString().FindIndexInX()) == 0;
        bool isNotCorosMove = (int.Parse(newSquare.Last().ToString()) - int.Parse(_square.Last().ToString())) 
                            - (_square.First().ToString().FindIndexInX() - newSquare.First().ToString().FindIndexInX()) != 0;

        if(isNotCorosMove || isNotMoveX || isNotMoveY) throw new Exception("Yanlış hamle");
        
        _square = newSquare;
    }

    public string GetPieceName() => _color.StringValue() + " " + nameof(Queen);

}