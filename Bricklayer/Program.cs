using Bricklayer.Builder;
using Bricklayer.WallGenerators;

namespace Bricklayer;

internal static class Program
{
    private static void Main(string[] args)
    {
        WallConfigurator builder = new();
        RowBricks[] wall = builder.BuildWall();

        IWallGenerator printer = WallGeneratorFactory.NewGenerator(wall);
        printer.Generate();
    }
}
