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

    //protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber, int currentColNumber) => false;
}