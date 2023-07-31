using Bricklayer.Builder;
using Bricklayer.WallGenerators;

namespace Bricklayer;

internal static class Program
{
    private static void Main(string[] args)
    {
        GeneralWallConfiguration builder = new StandardWallConfiguration();
        RowBricks[] wall = builder.BuildWall();

        IWallGenerator printer = WallGeneratorFactory.NewGenerator(wall);
        printer.Generate();
    }
}
