using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal class RectangularBuildRow : BuildRow
{
    public RectangularBuildRow(int totalWidth, int currentRowNumber, ICanCheckContainingBrick greyPattern)
        : base(totalWidth, currentRowNumber, greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentColNumber)
    {
        var isNextBrickGrey = _greyPattern?.IsContainingBrick(currentColNumber + 1, _currentRowNumber) ?? false;
        var isPreviousBrickGrey = _greyPattern?.IsContainingBrick(currentColNumber - 1, _currentRowNumber) ?? false;
        return firstCol || LastCol(currentBrick) || isNextBrickGrey || isPreviousBrickGrey;
    }
}