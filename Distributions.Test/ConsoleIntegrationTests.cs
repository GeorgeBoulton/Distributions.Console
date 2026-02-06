using Distributions.Console;
using static System.Console;

namespace Distributions.Test;

[TestFixture]
public class ConsoleIntegrationTests
{
    private TextWriter _origOut = null!;
    private TextWriter _origErr = null!;

    [SetUp]
    public void SetUp()
    {
        _origOut = Out;
        _origErr = Error;
    }

    [TearDown]
    public void TearDown()
    {
        SetOut(_origOut);
        SetError(_origErr);
    }

    [Test]
    public void Console_WhenGivenValidInput_PrintsBothDistributions()
    {
        // Arrange
        var stdout = new StringWriter();
        var stderr = new StringWriter();

        SetOut(stdout);
        SetError(stderr);

        // Act
        var code = App.Run(["3", "1.5", "3.6"]);

        // Assert
        var lines = stdout
            .ToString()
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        Assert.That(code, Is.EqualTo(0));
        Assert.That(stderr.ToString(), Is.Empty);

        Assert.That(lines[0], Is.EqualTo(
        "Normal(3.6;3,1.5) = 0.2889 (Mean : 3.0000, Variance : 1.5000)"));

        Assert.That(lines[1], Is.EqualTo(
            "Log-normal(3.6;3,1.5) = 0.0338 (Mean : 42.5211, Variance : 6295.0415)"));
    }
}