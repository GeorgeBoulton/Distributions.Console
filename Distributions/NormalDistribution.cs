namespace Distributions;

public sealed class NormalDistribution : IDistribution
{
    public DistributionResult EvaluatePdf(double x, double mu, double sigmaSquared)
    {
        var denominator = Math.Sqrt(2 * Math.PI * sigmaSquared);
        var exponent = Math.Pow(x - mu, 2) / (2 * sigmaSquared);
        
        var pdf = Math.Exp(exponent) / denominator;
        
        return new DistributionResult(pdf, mu, sigmaSquared);
    }
}