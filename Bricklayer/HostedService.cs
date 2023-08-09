using Bricklayer.Builder;
using Bricklayer.WallGenerators;

using Microsoft.Extensions.Hosting;

namespace Bricklayer;

internal class HostedService : IHostedService
{
    private readonly IWallBuilder _builder;
    private readonly IHost _host;

    public HostedService(IWallBuilder builder, IHost host)
    {
        _builder = builder;
        _host = host;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        RowBricks[] wall = _builder.BuildWall();

        IWallGenerator printer = WallGeneratorFactory.NewGenerator(wall);
        printer.Generate();

        await _host.StopAsync(default);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // Do nothing, no async operations
    }
}
