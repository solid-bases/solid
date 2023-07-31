namespace Bricklayer.Builder;

internal class WallConfigurator
{
    private readonly int _totalWidth = 180;
    private readonly int _totalHeight = 90;
    private readonly GreyPattern _greyPattern;

    public WallConfigurator()
    {
        _greyPattern = new GreyPattern(new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 5 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 4,6 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 5,6 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 5 }
            },
        });
    }

    public RowBricks[] BuildWall() => new BuildWall(_totalHeight, _totalWidth, _greyPattern).ToArray();
}
