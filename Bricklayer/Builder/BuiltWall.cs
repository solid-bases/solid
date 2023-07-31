using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal class BuiltWall
{
    internal int BuiltHeight { get; private set; }
    internal int CurrentRowNumber { get; private set; } = 1;

    private readonly List<RowBricks> _wall = new();
    private readonly int _totalWidth;
    private readonly IGreyPattern? _greyPattern;

    public BuiltWall(int totalWidth, IGreyPattern? greyPattern)
    {
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;
    }

    internal void AppendNewRow()
    {
        var newRow = CreateNewBricksRow();
        AppendRowToWall(newRow);
    }

    private RowBricks CreateNewBricksRow()
    {
        IBuiltRow builtRow = StandardBuiltRow.Create(_totalWidth, _greyPattern);

        while (builtRow.BuiltWidth < _totalWidth)
        {
            builtRow.AppendNewBrick(CurrentRowNumber);
        }

        return new RowBricks
        {
            RowNumber = CurrentRowNumber,
            Bricks = builtRow.ToArray()
        };
    }

    private void AppendRowToWall(RowBricks row)
    {
        _wall.Add(row);
        IncreaseRowNumber();
        IncreaseBuiltHeight(row.Bricks[0]);
    }

    private void IncreaseRowNumber()
    {
        CurrentRowNumber++;
    }

    private void IncreaseBuiltHeight(Brick brick)
    {
        BuiltHeight += brick.Height;
    }

    internal RowBricks[] ToArray() => _wall.ToArray();
}
