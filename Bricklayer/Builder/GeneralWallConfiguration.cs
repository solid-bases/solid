namespace Bricklayer.Builder;

internal class GeneralWallConfiguration
{
    private readonly int _totalWidth = 180;
    private readonly int _totalHeight = 90;
    protected GreyPattern _greyPattern = new(Array.Empty<RowPattern>());

    public RowBricks[] BuildWall() => new BuildWall(_totalHeight, _totalWidth, _greyPattern).ToArray();
}
