# Distributions Console Application

Console application implements **Normal** and **Log-normal** probability Distributions

## Projects

### Distributions
Contains distribution calculation logic

### Distributions.Console
* Calls distributions
* formats and prints output
* Handles exceptions

### Distributions.Test
Contains tests for the logic

## Requirements
* .NET 10.0

## How to Run
From the solution root, run:

```powershell
dotnet run --project Distributions.Console -- <mu> <sigmaSquared> <x>
```

Example

```powershell
dotnet run --project Distributions.Console -- 3 1.5 3.6
```

Where:
mu = μ (mean)
sigmaSquared = σ² (variance, must be > 0)
x = value to evaluate the PDF at