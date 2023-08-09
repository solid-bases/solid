using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder;

internal class GeneralWallBuilder : IWallBuilder
{
    private readonly int _totalWidth = 180;
    private readonly int _totalHeight = 90;
    protected ICanCheckContainingBrickAndRectangle _greyPattern;
    public GeneralWallBuilder(IPatternHandler greyPattern)
    {
        _greyPattern = greyPattern;
        greyPattern.AskForWallType();
    }

    public virtual RowBricks[] BuildWall() => new Wall(_totalHeight, _totalWidth, _greyPattern).ToArray();
}
