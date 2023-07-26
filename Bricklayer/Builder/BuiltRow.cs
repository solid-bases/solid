using Bricklayer.Bricks;

namespace Bricklayer.Builder;
internal class BuiltRow
{
    internal int BuiltWidth { get; private set; }
    internal int CurrentColNumber { get; private set; } = 1;

    internal int TotalWidth { get; set; }

    readonly List<Brick> _row = new();
    private readonly GreyPattern? _greyPattern;

    public BuiltRow(int totalWidth, GreyPattern? greyPattern)
    {
        TotalWidth = totalWidth;
        this._greyPattern = greyPattern;
    }

    internal void AppendNewBrick(int currentRowNumber) {
        var brick = DefineNewBrick(currentRowNumber);
        AppendBrickToRow(brick);
    }

    private Brick DefineNewBrick(int currentRowNumber)
    {
        Brick currentBrick = NewRedParallelepipedBrick();
        if (_greyPattern?.IsContainingBrick(CurrentColNumber, currentRowNumber) == true)
        {
            currentBrick = NewGreyParallelepipedBrick();
        }

        bool evenRow = currentRowNumber % 2 == 0;
        if (evenRow)
        {
            currentBrick = GetRedCubicBrickWhenNecessary(currentBrick);
        }

        return currentBrick;
    }

    private static Brick NewRedParallelepipedBrick() => new RedParallelepipedBrick
    {
        Width = 20
    };

    private static Brick NewGreyParallelepipedBrick() => new GreyParallelepipedBrick
    {
        Width = 20
    };

    private Brick GetRedCubicBrickWhenNecessary(Brick currentBrick)
    {
        bool firstCol = CurrentColNumber == 1;
        if (!firstCol && !LastCol(currentBrick))
        {
            return currentBrick;
        }

        return NewRedCubicBrick();
    }

    bool LastCol(Brick brick) => BuiltWidth + brick.Width >= TotalWidth;

    private static Brick NewRedCubicBrick() => new RedCubicBrick
    {
        Size = 10,
        Color = BrickColor.Red
    };

    private void AppendBrickToRow(Brick brick)
    {
        _row.Add(brick);

        IncreaseColNumber();
        IncreaseBuiltWidth(brick);
    }

    private void IncreaseColNumber()
    {
        CurrentColNumber++;
    }

    private void IncreaseBuiltWidth(Brick brick)
    {
        BuiltWidth += brick.Width;
    }

    internal Brick[] ToArray() => _row.ToArray();
}