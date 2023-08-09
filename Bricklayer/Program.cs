using Bricklayer.Builder;
using Bricklayer.Builder.Pattern;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bricklayer;

internal static class Program
{
    private static void Main(string[] args)
    {
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(RemoveAllLogs)
            .ConfigureServices(AddAllServices)
            .Build()
            .Run();
    }

    private static void RemoveAllLogs(HostBuilderContext context, ILoggingBuilder builder)
    {
        builder.ClearProviders();
    }

    private static void AddAllServices(HostBuilderContext context, IServiceCollection collection)
    {
        collection.AddSingleton<IPatternHandler, PatternHandler>();
        collection.AddSingleton<IAvailablePatterns, AvailablePatterns>();
        //collection.AddSingleton<IAvailablePatterns, AlternativeAvailablePatterns>();
        collection.AddSingleton<IWallBuilder, StandardWallBuilder>();

        collection.AddHostedService<HostedService>();
    }
}
