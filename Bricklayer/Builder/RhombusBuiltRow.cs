using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal class RhombusBuiltRow : StandardBuiltRow, IBuiltRow {
    public RhombusBuiltRow(int totalWidth, IGreyPattern? greyPattern) : base(totalWidth, greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber) => firstCol || LastCol(currentBrick);
}