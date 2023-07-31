using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal abstract class StandardBuiltRow : IBuiltRow
{
    public virtual int BuiltWidth { get; private set; }
    public virtual int CurrentColNumber { get; private set; } = 1;

    public virtual int TotalWidth { get; }

    readonly List<Brick> _row = new();
    protected readonly IGreyPattern? _greyPattern;

    protected StandardBuiltRow(int totalWidth, IGreyPattern? greyPattern)
    {
        TotalWidth = totalWidth;
        _greyPattern = greyPattern;
    }

    public static IBuiltRow Create(int totalWidth, IGreyPattern? greyPattern)
    {
        return greyPattern?.IsRectangle == true ? new RectangularBuiltRow(totalWidth, greyPattern) : new RhombusBuiltRow(totalWidth, greyPattern);
    }

    public virtual void AppendNewBrick(int currentRowNumber)
    {
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
            currentBrick = GetRedCubicBrickWhenNecessary(currentBrick, currentRowNumber);
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

    private Brick GetRedCubicBrickWhenNecessary(Brick currentBrick, int currentRowNumber)
    {
        bool firstCol = CurrentColNumber == 1;
        return IsCubicBrickNecessary(currentBrick, firstCol, currentRowNumber) ? NewRedCubicBrick() : currentBrick;
    }

    protected abstract bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber);

    protected bool LastCol(Brick brick) => BuiltWidth + brick.Width >= TotalWidth;

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

    public virtual Brick[] ToArray() => _row.ToArray();
}