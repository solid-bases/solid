using Bricklayer.Builder;
using Bricklayer.WallGenerators;

namespace Bricklayer;

internal static class Program
{
    private static void Main(string[] args)
    {
        IGreyPattern greyPattern = new GreyPattern();

        AskForWallType(greyPattern);

        GeneralWallBuilder builder = new StandardWallBuilder(greyPattern);
        RowBricks[] wall = builder.BuildWall();

        IWallGenerator printer = WallGeneratorFactory.NewGenerator(wall);
        printer.Generate();
    }

    private static void AskForWallType(IGreyPattern greyPattern)
    {
        string? input = UserInputPrompter.AskAndVerifyValidInputs(new Dictionary<string, string> { { "1", "Rhombus" }, { "2", "Rectangle" } });

        if (UserInputPrompter.IsEqualsIc(input ?? string.Empty, "2"))
        {
            greyPattern.SetAsRectangle();
        }
    }
}
