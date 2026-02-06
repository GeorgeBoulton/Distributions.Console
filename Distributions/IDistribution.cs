namespace Distributions;

public interface IDistribution
{
    DistributionResult EvaluatePdf(double x, double mu, double sigmaSquared);
}