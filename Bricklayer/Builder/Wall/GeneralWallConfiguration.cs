using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder;

internal class GeneralWallConfiguration
{
    private readonly int _totalWidth = 180;
    private readonly int _totalHeight = 90;
    protected GreyPattern _greyPattern;
    public GeneralWallConfiguration(GreyPattern greyPattern)
    {
        _greyPattern = greyPattern;
        _greyPattern.AskForWallType();
    }

    public virtual RowBricks[] BuildWall() => new BuildWall(_totalHeight, _totalWidth, _greyPattern).ToArray();
}
