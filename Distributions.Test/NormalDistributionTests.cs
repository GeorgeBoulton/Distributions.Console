using Distributions.Distributions;

namespace Distributions.Test;

[TestFixture]
public class NormalDistributionTests
{
    
    private readonly NormalDistribution _sut = new();

    [Test]
    public void NormalDistribution_WhenGivenInvalidParameters_ThrowArgumentException()
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
    public void NormalDistribution_WhenGivenValidParameters_ReturnsExpected()
    {
        // Arrange
        var x = 3.6;
        var mean = 3.0;
        var variance = 1.5;
        
        // Act
        var result = _sut.EvaluatePdf(x, mean, variance);
        
        // Assert
        Assert.That(result.Mean, Is.EqualTo(3.0).Within(0.0001));
        Assert.That(result.Variance, Is.EqualTo(1.5).Within(0.0001));
        Assert.That(result.Pdf, Is.EqualTo(0.2889).Within(0.0001));
    }
}