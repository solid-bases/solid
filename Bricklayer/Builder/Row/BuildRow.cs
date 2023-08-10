using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal abstract class BuildRow : IBuildRow
{
    private const int ParallepipedSize = 20;
    private readonly int _cubicSize = ParallepipedSize / 2;

    protected readonly ICanCheckContainingBrick _greyPattern;

    protected readonly List<Brick> _row = new();
    protected readonly int _totalWidth;
    protected readonly int _currentRowNumber;
    protected int _builtWidth = 0;

    protected BuildRow(int totalWidth, int currentRowNumber, ICanCheckContainingBrick greyPattern)
    {
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;
        _currentRowNumber = currentRowNumber;

        BuildCurrentRow();
    }

    public static IBuildRow Create(int totalWidth, ICanCheckContainingBrickAndRectangle greyPattern, int currentRowNumber)
    {
        return greyPattern.IsRectangle
            ? new RectangularBuildRow(totalWidth, currentRowNumber, greyPattern)
            : new RhombusBuildRow(totalWidth, currentRowNumber, greyPattern);
    }

    public Brick[] ToArray() => _row.ToArray();

    protected void BuildCurrentRow()
    {
        for (var currentColNumber = 1; _builtWidth < _totalWidth; currentColNumber++)
        {
            AppendProperNewBrick(currentColNumber);
        }
    }

    protected virtual void AppendProperNewBrick(int currentColNumber)
    {
        var currentBrick = DefineNewBrick(currentColNumber);
        AppendBrickToRow(currentBrick);
    }

    protected virtual Brick DefineNewBrick(int currentColNumber)
    {
        Brick currentBrick = NewBrick<RedParallelepipedBrick>(ParallepipedSize);
        currentBrick = GetGreyBrickWhenInPattern(currentColNumber, currentBrick);

        return DefineRowsWithCubicBricks(currentColNumber, currentBrick);
    }

    protected static Brick NewBrick<T>(int size) where T : Brick, new() => new T
    {
        Width = size
    };

    protected virtual Brick GetGreyBrickWhenInPattern(int currentColNumber, Brick currentBrick)
    {
        if (_greyPattern.IsContainingBrick(currentColNumber, _currentRowNumber))
        {
            currentBrick = NewBrick<GreyParallelepipedBrick>(ParallepipedSize);
        }

        return currentBrick;
    }

    protected virtual Brick DefineRowsWithCubicBricks(int currentColNumber, Brick currentBrick)
    {
        bool evenRow = _currentRowNumber % 2 == 0;
        if (evenRow)
        {
            currentBrick = DefineWhenCubicBrickIsNecessaryInARow(currentColNumber, currentBrick);
        }

        return currentBrick;
    }

    protected virtual Brick DefineWhenCubicBrickIsNecessaryInARow(int currentColNumber, Brick currentBrick)
    {
        bool firstCol = currentColNumber == 1;
        if (IsCubicBrickNecessary(currentBrick, firstCol, currentColNumber))
        {
            currentBrick = NewBrick<RedCubicBrick>(_cubicSize);
        }

        return currentBrick;
    }

    protected abstract bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentColNumber);

    protected virtual bool LastCol(Brick brick) => _builtWidth + brick.Width >= _totalWidth;

    protected virtual void AppendBrickToRow(Brick currentBrick)
    {
        _row.Add(currentBrick);

        _builtWidth += currentBrick.Width;
    }
}
