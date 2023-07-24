using Bricklayer.Bricks;

namespace Bricklayer.Builder;
internal class BuiltRow
{
    internal int BuiltWidth { get; private set; }
    internal int CurrentColNumber { get; private set; } = 1;

    internal int TotalWidth { get; set; }

    List<Brick> row = new();
    private readonly GreyPattern greyPattern;

    public BuiltRow(int totalWidth, GreyPattern greyPattern)
    {
        TotalWidth = totalWidth;
        this.greyPattern = greyPattern;
    }

    internal void AppendNewBrick(int currentRowNumber) {
        var brick = DefineNewBrick(currentRowNumber);
        AppendBrickToRow(brick);
    }

    private Brick DefineNewBrick(int currentRowNumber)
    {
        Brick currentBrick = NewRedParallelepipedBrick();
        if (greyPattern.IsContainingBrick(CurrentColNumber, currentRowNumber))
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

    private Brick NewRedParallelepipedBrick() => new RedParallelepipedBrick
    {
        Width = 20
    };

    private Brick NewGreyParallelepipedBrick() => new GreyParallelepipedBrick
    {
        Width = 20
    };

    private Brick GetRedCubicBrickWhenNecessary(Brick currentBrick)
    {
        bool firstCol = CurrentColNumber == 1;
        if (!firstCol && !lastCol(currentBrick))
        {
            return currentBrick;
        }

        return NewRedCubicBrick();
    }

    bool lastCol(Brick brick) => BuiltWidth + brick.Width >= TotalWidth;

    private Brick NewRedCubicBrick() => new RedCubicBrick
    {
        Size = 10,
        Color = BrickColor.Red
    };

    private void AppendBrickToRow(Brick brick)
    {
        row.Add(brick);

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

    internal Brick[] ToArray() => row.ToArray();
}