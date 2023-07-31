using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal class RhombusBuildRow : BuildRow, IBuildRow
{
    public RhombusBuildRow(int totalWidth, IGreyPattern greyPattern, int currentRowNumber)
        : base(totalWidth, greyPattern, currentRowNumber)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber, int currentColNumber) => firstCol || LastCol(currentBrick);
}