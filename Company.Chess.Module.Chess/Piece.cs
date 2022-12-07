namespace Company.Chess.Module.Chess;

public class Piece : IPiece
{
    private string _square;
    public string Square {
        get => _square;
    }

    public readonly string Name;

    // ToDo - Daha sonra 'rule' da verilecek. 'rule' ile 'Move' methodunda kontrol yapılacak
    public Piece(string square, string name)
    {
        Name = name;
        _square = square;
    }

    public Piece Move(string oldSquare, string newSquare)
    {
        _square = newSquare;
        return this;
    }
}