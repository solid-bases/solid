using Bricklayer.Bricks;

namespace Bricklayer.Builder;

// TODO: implement the violation «This class violates LSP because it does not behave like the base class.»
internal class WrongLSPRectangularBuiltRow : StandardBuiltRow, IBuiltRow {
    public WrongLSPRectangularBuiltRow(int totalWidth, GreyPattern? greyPattern) : base(totalWidth, greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber)
    {
        var isNextBrickGrey = _greyPattern?.IsContainingBrick(CurrentColNumber, currentRowNumber + 1) ?? false;
        var isPreviousBrickGrey = _greyPattern?.IsContainingBrick(CurrentColNumber, currentRowNumber - 1) ?? false;
        return firstCol || LastCol(currentBrick) || isNextBrickGrey || isPreviousBrickGrey;
    }
}