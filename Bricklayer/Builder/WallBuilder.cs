namespace Bricklayer.Builder;

internal class WallBuilder
{
    private readonly GreyPattern greyPattern;
    private int totalWidth = 180;
    private int totalHeight = 90;

    public WallBuilder(GreyPattern greyPattern)
    {
        this.greyPattern = greyPattern;
    }

    public RowBricks[] BuildWall()
    {
        var builtWall = new BuiltWall(totalWidth, greyPattern);

        while (builtWall.BuiltHeight < totalHeight)
        {
            builtWall.AppendNewRow();
        }

        return builtWall.ToArray();
    }

}
