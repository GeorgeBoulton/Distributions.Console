using Distributions.Distributions;

namespace Distributions.Test;

[TestFixture]
public class LogNormalDistributionTests
{
    private readonly LogNormalDistribution _sut = new();
    
    [Test]
    public void LogNormalDistribution_WhenGivenInvalidParameters_ThrowArgumentException()
    {
        // Arrange
        var x = 3.6;
        var mean = 3.0;
        var variance = -1.5;
        
        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.EvaluatePdf(x, mean, variance));
        
        // Assert
        Assert.That(result.Message, Is.EqualTo("sigmaSquared must be > 0"));
    }
    
    [Test]
    public void LogNormalDistribution_WhenGivenXLessThanZero_ThrowArgumentException()
    {
        // Arrange
        var x = -3.6;
        var mean = 3.0;
        var variance = 1.5;
        
        // Act
        var result = Assert.Throws<ArgumentException>(() => _sut.EvaluatePdf(x, mean, variance));
        
        // Assert
        Assert.That(result.Message, Is.EqualTo("x must be > 0 for Log-normal"));
    }
    
    [Test]
    public void LogNormalDistribution_WhenGivenValidParameters_ReturnsExpected()
    {
        // Arrange
        var x = 3.6;
        var mean = 3.0;
        var variance = 1.5;
        
        // Act
        var result = _sut.EvaluatePdf(x, mean, variance);
        
        // Assert
        Assert.That(result.Mean, Is.EqualTo(42.5211).Within(0.0001));
        Assert.That(result.Variance, Is.EqualTo(6295.0415).Within(0.0001));
        Assert.That(result.Pdf, Is.EqualTo(0.0338).Within(0.0001));
    }
}