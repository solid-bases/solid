using Bricklayer.Builder;

namespace Bricklayer.WallGenerators;

internal static class WallGeneratorFactory
{
    public static IWallGenerator NewGenerator(RowBricks[] wall)
    {
        string? input = UserInputPrompter.AskAndVerifyValidInputs(new Dictionary<string, string> { { "c", "Console" }, { "h", "HTML" } });

        return UserInputPrompter.IsEqualsIc(input ?? string.Empty, "c") ? new ConsoleWallGenerator(wall) : new HtmlWallGenerator(wall);
    }
}
