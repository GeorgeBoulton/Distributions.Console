using Distributions.Models;

namespace Distributions.Distributions;

public interface IDistribution
{
    DistributionResult EvaluatePdf(double x, double mu, double sigmaSquared);
}