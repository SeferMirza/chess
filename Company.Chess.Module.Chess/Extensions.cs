namespace Company.Chess.Module.Chess;

public static class Extensions
{
    public static bool CanMove(this IPiece piece, Game game, string newSquare)
    {
        var paths = piece.GetSquareInPath(newSquare);
        if (game.Pieces.Where(p => paths.Contains(p.Square)).Count() > 0) throw new Exception("Yolda engel var");
        if(!piece.SquareIsEmpty(game, newSquare) && !piece.CanEat(game, newSquare)) return false;
        return true;
    }

    public static bool CanEat(this IPiece piece, Game game, string newSquare)
    {
        return game.Pieces.Where(p => p.Square == newSquare && p.Color == piece.Color).Count() > 0;
    }

    public static bool SquareIsEmpty(this IPiece piece, Game game, string newSquare)
    {
        return game.Pieces.Where(p => p.Square == newSquare).Count() > 0;
    }
}