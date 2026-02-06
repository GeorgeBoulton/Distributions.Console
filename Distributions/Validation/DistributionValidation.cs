namespace Distributions.Validation;

public static class DistributionValidation
{
    public static void ValidateSigmaSquared(double sigmaSquared)
    {
        if (sigmaSquared <= 0) throw new ArgumentException("sigmaSquared must be > 0");
    }

    public static void ValidateXIsPositiveForLogNormal(double x)
    {
        if (x <= 0) throw new ArgumentException("x must be > 0 for Log-normal");
    }
}