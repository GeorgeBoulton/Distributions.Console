using System.Globalization;
using System.Runtime.CompilerServices;
using Distributions.Distributions;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("MyConsoleApp.Tests")]

var services = new ServiceCollection();

services.AddSingleton<IDistribution, NormalDistribution>();
services.AddSingleton<IDistribution, LogNormalDistribution>();

var provider = services.BuildServiceProvider();

var distributions = provider.GetRequiredService<IEnumerable<IDistribution>>();

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

// Validate input
if (args.Length != 3)
{
    Console.Error.WriteLine("Usage: <mu> <sigmaSquared> <x>");
    return;
}

if (!double.TryParse(args[0], out var mu) ||
    !double.TryParse(args[1], out var sigmaSquared) ||
    !double.TryParse(args[2], out var x))
{
    Console.Error.WriteLine("Invalid numeric input.");
    return;
}

// Run distributions
foreach (var dist in distributions)
{
    var name = dist switch
    {
        NormalDistribution => "Normal",
        LogNormalDistribution => "Log-normal",
        _ => dist.GetType().Name
    };

    var label = $"{name}({x};{mu},{sigmaSquared})";

    try
    {
        var r = dist.EvaluatePdf(x, mu, sigmaSquared);
        Console.WriteLine($"{label}: {r.Pdf:0.0000} : (Mean : {r.Mean:0.0000}, Variance : {r.Variance:0.0000})");
    }
    catch (Exception e)
    {
        Console.Error.WriteLine($"{label} error: {e.Message}");
    }
}
