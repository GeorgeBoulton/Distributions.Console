using Distributions.Models;
using Distributions.Validation;

namespace Distributions.Distributions;

public sealed class NormalDistribution : IDistribution
{
    public DistributionResult EvaluatePdf(double x, double mu, double sigmaSquared)
    {
        DistributionValidation.ValidateSigmaSquared(sigmaSquared);
        
        var denominator = Math.Sqrt(2 * Math.PI * sigmaSquared);
        var exponent = -Math.Pow(x - mu, 2) / (2 * sigmaSquared);
        
        // PDF(x) = 1 / sqrt(2 * pi * sigmaSquared) * exp(-(x - mu)^2 / 2 * sigmaSquared)
        var pdf = Math.Exp(exponent) / denominator;
        
        return new DistributionResult(pdf, mu, sigmaSquared);
        
        // todo might need extending because we have to do 1 over denominator
    }
}