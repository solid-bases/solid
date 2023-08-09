using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal class RhombusBuildRow : BuildRow
{
    public RhombusBuildRow(int totalWidth, int currentRowNumber, ICanCheckContainingBrick greyPattern)
        : base(totalWidth, currentRowNumber, greyPattern)
    {
    }

    protected override bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentColNumber) => firstCol || LastCol(currentBrick);
}