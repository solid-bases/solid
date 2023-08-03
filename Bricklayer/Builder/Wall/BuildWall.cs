using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;
using Bricklayer.Builder.Row;

namespace Bricklayer.Builder;

internal class BuildWall : IBuildWall
{
    private readonly List<RowBricks> _wall = new();
    private readonly int _totalHeight;
    private readonly int _totalWidth;
    private readonly ICanCheckContainingBrickAndRectangle _greyPattern;
    private int _builtHeight = 0;

    public BuildWall(int totalHeight, int totalWidth, ICanCheckContainingBrickAndRectangle greyPattern)
    {
        _totalHeight = totalHeight;
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;

        BuildCurrentWall();
    }

    public RowBricks[] ToArray() => _wall.ToArray();

    private void BuildCurrentWall()
    {
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

    private void AppendRowToWall(int currentRowNumber, Brick[] currentRow)
    {
        _wall.Add(new RowBricks
        {
            RowNumber = currentRowNumber,
            Bricks = currentRow
        });

        _builtHeight += currentRow[0].Height;
    }

    private Brick[] NewBricksRow(int currentRowNumber)
    {
        var rowBuilder = BuildRow.Create(_totalWidth, _greyPattern, currentRowNumber);
        return rowBuilder.ToArray();
    }
}