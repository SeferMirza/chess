using Gazel;
using Gazel.UnitTesting;
using Company.Chess.Module.Chess;

namespace Company.Chess.Test.Chess;

public class ChessTestBase : TestBase
{
    protected ChessManager chessManager;
    public override void SetUp()
    {
        chessManager = Context.Get<ChessManager>();
        base.SetUp();
    }

    static ChessTestBase()
    {
        Config.RootNamespace = "Company";
    }

    protected string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    protected string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    protected List<IPiece> PiecesList(params IPiece[] pieces){
        var result = new List<IPiece>();
        foreach(var piece in pieces){
            result.Add(piece);
        }
        return result;
    }

    protected Game CreateCustomGame(List<IPiece> piecesList) => chessManager.CreateGame(piecesList);
}