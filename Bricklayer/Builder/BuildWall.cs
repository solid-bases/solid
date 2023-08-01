using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal class BuildWall {
    private readonly List<RowBricks> _wall = new();
    private readonly int _totalHeight;
    private readonly int _totalWidth;
    private readonly GreyPattern _greyPattern;
    private int _builtHeight = 0;

    public BuildWall(int totalHeight, int totalWidth, GreyPattern greyPattern) {
        _totalHeight = totalHeight;
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;

        BuildCurrentWall();
    }

    public RowBricks[] ToArray() => _wall.ToArray();

    private void BuildCurrentWall() {
        for (int currentRowNumber = 1; _builtHeight < _totalHeight; currentRowNumber++)
        {
            AppendRow(currentRowNumber);
        }
    }

    private void AppendRow(int currentRowNumber)
    {
        var currentRow = NewBricksRow(currentRowNumber);
        AppendRowToWall(currentRowNumber, currentRow);
    }

    private Brick[] NewBricksRow(int currentRowNumber)
    {
        var rowBuilder = new BuildRow(_totalWidth, _greyPattern, currentRowNumber);
        return rowBuilder.ToArray();
    }

    private void AppendRowToWall(int currentRowNumber, Brick[] currentRow)
    {
        _wall.Add(new RowBricks
        {
            RowNumber = currentRowNumber,
            Bricks = currentRow
        });

        _builtHeight += currentRow[0].Height;
    }
}
