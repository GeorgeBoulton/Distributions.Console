using Distributions.Models;
using Distributions.Validation;

namespace Distributions.Distributions;

public sealed class LogNormalDistribution : IDistribution
{
    public DistributionResult EvaluatePdf(double x, double mu, double sigmaSquared)
    {
        DistributionValidation.ValidateSigmaSquared(sigmaSquared);
        DistributionValidation.ValidateXIsPositiveForLogNormal(x);
        
        // Mean = exp(mu + sigmaSquared / 2)
        var mean = Math.Exp(mu + sigmaSquared / 2);
        // Variance = (exp(sigmaSquared) - 1) * exp(-ln(x) - mu)^2 / (2 * sigmaSquared)
        var variance = (Math.Exp(sigmaSquared) - 1) * Math.Exp(2 * mu + sigmaSquared);
        
        var denominator = x * Math.Sqrt(2 * Math.PI * sigmaSquared);
        var exponent = -Math.Pow(Math.Log(x) - mu, 2) / (2 * sigmaSquared);
        
        // PDF(x) = 1 / (x * sqrt(2 * pi * sigmaSquared)) * exp(-ln(x)-mu)^2 / (2 * sigmaSquared))
        var pdf = Math.Exp(exponent) / denominator;
        
        return new DistributionResult(pdf, mean, variance);
    }
}