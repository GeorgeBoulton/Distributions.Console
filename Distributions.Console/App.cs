using System.Globalization;
using Distributions.Distributions;
using Microsoft.Extensions.DependencyInjection;

namespace Distributions.Console;

public static class App
{
    public static int Run(string[] args)
    {
        var distributions = InjectDistributions();

        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        if (args.Length != 3)
        {
            System.Console.Error.WriteLine("Usage: <mu> <sigmaSquared> <x>");
            return 1;
        }

        if (!double.TryParse(args[0], out var mu) ||
            !double.TryParse(args[1], out var sigmaSquared) ||
            !double.TryParse(args[2], out var x))
        {
            System.Console.Error.WriteLine("Invalid numeric input.");
            return 1;
        }

        // Run distributions
        foreach (var dist in distributions)
        {
            var label = CreateLabel(dist, x, mu, sigmaSquared);
            
            EvaluatePdf(dist, x, mu, sigmaSquared, label);
        }

        return 0;
    }

    private static string CreateLabel(IDistribution dist, double x, double mu, double sigmaSquared)
    {
        var name = dist switch
        {
            NormalDistribution => "Normal",
            LogNormalDistribution => "Log-normal",
            _ => dist.GetType().Name
        };

        var label = $"{name}({x};{mu},{sigmaSquared})";
        return label;
    }

    private static void EvaluatePdf(IDistribution dist, double x, double mu, double sigmaSquared, string label)
    {
        try
        {
            var r = dist.EvaluatePdf(x, mu, sigmaSquared);
            System.Console.WriteLine($"{label} = {r.Pdf:0.0000} (Mean : {r.Mean:0.0000}, Variance : {r.Variance:0.0000})");
        }
        catch (Exception e)
        {
            System.Console.Error.WriteLine($"{label} error: {e.Message}");
        }
    }

    private static IEnumerable<IDistribution> InjectDistributions()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IDistribution, NormalDistribution>();
        services.AddSingleton<IDistribution, LogNormalDistribution>();

        var provider = services.BuildServiceProvider();

        var distributions = provider.GetRequiredService<IEnumerable<IDistribution>>();
        return distributions;
    }
}