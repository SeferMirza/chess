using Gazel;
using Gazel.UnitTesting;
using Company.Chess.Module.Chess;

namespace Company.Chess.Test.Chess;

[TestFixture]
public class ChessManagerTest : TestBase
{

    private string[] x = { "A", "B", "C", "D", "E", "F", "G", "H" };
    private string[] y = { "1", "2", "3", "4", "5", "6", "7", "8" };

    private Dictionary<string, string> EmptyBoard()
    {
        Dictionary<string, string> board = new();
        for (int i = 1; i <= 8; i++)
        {
            for (int j = 1; j <= 8; j++)
            {
                board.Add(x[i] + y[j], "Empty");
            }
        }

        return board;
    }

    static ChessManagerTest()
    {
        Config.RootNamespace = "Company";
    }

    [Test]
    public void When_client_auth_request_send_with_guid__return_a_board()
    {
        var chessManager = Context.Get<ChessManager>();
        var expected = new Guid("a30cc9ff-e9de-4c09-a056-b2d55a835515");
        var actual = chessManager.Auth(new Guid("a30cc9ff-e9de-4c09-a056-b2d55a835515"));

        BeginTest();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GiveEmptyBoard()
    {
        var emptyBoard = EmptyBoard();
        var chessManager = Context.Get<ChessManager>();

        BeginTest();

        Assert.That(chessManager.CreateBoard(), Is.EqualTo(emptyBoard));
    }
}