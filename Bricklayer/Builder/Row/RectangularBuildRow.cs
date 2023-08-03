using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal class RectangularBuildRow : BuildRow, IBuildRow
{
    public RectangularBuildRow(int totalWidth, ICanCheckContainingBrick greyPattern, int currentRowNumber)
        : base(totalWidth, greyPattern, currentRowNumber)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber, int currentColNumber)
    {
        var isNextBrickGrey = _greyPattern?.IsContainingBrick(currentColNumber + 1, currentRowNumber) ?? false;
        var isPreviousBrickGrey = _greyPattern?.IsContainingBrick(currentColNumber - 1, currentRowNumber) ?? false;
        return firstCol || LastCol(currentBrick) || isNextBrickGrey || isPreviousBrickGrey;
    }
}