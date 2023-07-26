namespace Bricklayer.Builder;

internal abstract class GeneralWallBuilder
{
    protected GreyPattern? _greyPattern;
    protected readonly int _totalWidth = 180;
    protected readonly int _totalHeight = 90;

    public virtual RowBricks[] BuildWall()
    {
        var builtWall = new BuiltWall(_totalWidth, _greyPattern);

        while (builtWall.BuiltHeight < _totalHeight)
        {
            builtWall.AppendNewRow();
        }

        return builtWall.ToArray();
    }
}
