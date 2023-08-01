using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;
using Bricklayer.Builder.Row;

namespace Bricklayer.Builder;

// This class violates LSP because it does not behave like the base class.
internal class WrongLSPRectangularBuildRow : BuildRow, IBuildRow {
    public WrongLSPRectangularBuildRow(int totalWidth, IGreyPattern greyPattern, int currentRowNumber)
        : base(totalWidth, greyPattern, currentRowNumber)
    {
    }

    // This method is expected to append a brick to the row until the row is full, but it is actually only
    // logging the current column number.
    protected override void BuildCurrentRow()
    {
        for (var currentColNumber = 1; _builtWidth < _totalWidth; currentColNumber++)
        {
            Console.WriteLine($"currentColNumber: {currentColNumber}");
        }
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber, int currentColNumber) => false;
}