using Gazel;
using Gazel.UnitTesting;
using Company.Chess.Module.Chess;

namespace Company.Chess.Test.Chess;

[TestFixture]
public class ChessManagerTest : ChessTestBase
{
    [Test]
    public void bir_kisi_baglaninca_digeri_beklenir()
    {
        Assert.Fail("yazılacak...");
    }

    [Test]
    public void iki_kisi_baglaninca_default_oyun_baslatilir()
    {
        Assert.Fail("yazılacak...");
    }

    [Test]
    public void tas_verilen_yeni_konuma_oynatilir()
    {
        var pawnExpected = "A4";
        var castleExpected = "A2";
        var horseExpected = "C3";
        var elephantExpected = "B2";
        var queenExpected = "D2";
        var kingExpected = "E2";

        BeginTest();
        Prepare();

        Assert.DoesNotThrow(() => chessManager.Move("A2", pawnExpected));
        Assert.DoesNotThrow(() => chessManager.Move("A1", castleExpected));
        Assert.DoesNotThrow(() => chessManager.Move("B1", horseExpected));
        Assert.DoesNotThrow(() => chessManager.Move("C1", elephantExpected));
        Assert.DoesNotThrow(() => chessManager.Move("D1", queenExpected));
        Assert.DoesNotThrow(() => chessManager.Move("E1", kingExpected));
    }

    [Test]
    public void konum_gecersizse_exception_atilir()
    {
        BeginTest();
        Prepare();

        Assert.Throws<Exception>(() => chessManager.Move("A8", "C1"));
        Assert.Throws<Exception>(() => chessManager.Move("B8", "C1"));
        Assert.Throws<Exception>(() => chessManager.Move("C8", "C1"));
        Assert.Throws<Exception>(() => chessManager.Move("D8", "C4"));
        Assert.Throws<Exception>(() => chessManager.Move("F1", "C1"));
        Assert.Throws<Exception>(() => chessManager.Move("H1", "C1"));
    }
}