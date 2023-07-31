using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal class RectangularBuiltRow : StandardBuiltRow, IBuiltRow {
    public RectangularBuiltRow(int totalWidth, IGreyPattern? greyPattern) : base(totalWidth, greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber)
    {
        var isNextBrickGrey = _greyPattern?.IsContainingBrick(CurrentColNumber + 1, currentRowNumber) ?? false;
        var isPreviousBrickGrey = _greyPattern?.IsContainingBrick(CurrentColNumber - 1, currentRowNumber) ?? false;
        return firstCol || LastCol(currentBrick) || isNextBrickGrey || isPreviousBrickGrey;
    }
}