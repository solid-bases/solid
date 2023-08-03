using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder;

internal class GeneralWallConfiguration
{
    private readonly int _totalWidth = 180;
    private readonly int _totalHeight = 90;
    protected ICanCheckContainingBrickAndRectangle _greyPattern;
    public GeneralWallConfiguration(IGreyPattern greyPattern)
    {
        _greyPattern = greyPattern;
        greyPattern.AskForWallType();
    }

    public virtual RowBricks[] BuildWall() => new BuildWall(_totalHeight, _totalWidth, _greyPattern).ToArray();
}
