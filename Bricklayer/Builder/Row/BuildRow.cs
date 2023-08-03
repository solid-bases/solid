using Bricklayer.Bricks;
using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder.Row;

internal abstract class BuildRow : IBuildRow
{
    protected readonly ICanCheckContainingBrick _greyPattern;

    protected readonly List<Brick> _row = new();
    protected readonly int _totalWidth;
    protected readonly int _currentRowNumber;
    protected int _builtWidth = 0;

    protected BuildRow(int totalWidth, ICanCheckContainingBrick greyPattern, int currentRowNumber)
    {
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;
        _currentRowNumber = currentRowNumber;

        BuildCurrentRow();
    }

    public static IBuildRow Create(int totalWidth, ICanCheckContainingBrickAndRectangle greyPattern, int currentRowNumber)
    {
        return greyPattern.IsRectangle
            ? new RectangularBuildRow(totalWidth, greyPattern, currentRowNumber)
            : new RhombusBuildRow(totalWidth, greyPattern, currentRowNumber);
    }

    public Brick[] ToArray() => _row.ToArray();

    protected virtual void BuildCurrentRow()
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
        Brick currentBrick = NewRedParallelepipedBrick();
        currentBrick = GetGreyBrickWhenInPattern(currentColNumber, currentBrick);

        return DefineRowsWithCubicBricks(currentColNumber, currentBrick);
    }

    protected static Brick NewRedParallelepipedBrick() => new RedParallelepipedBrick
    {
        Width = 20
    };

    protected virtual Brick GetGreyBrickWhenInPattern(int currentColNumber, Brick currentBrick)
    {
        if (_greyPattern.IsContainingBrick(currentColNumber, _currentRowNumber))
        {
            currentBrick = NewGreyParallelepipedBrick();
        }

        return currentBrick;
    }

    protected static Brick NewGreyParallelepipedBrick() => new GreyParallelepipedBrick
    {
        Width = 20
    };

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
        if (IsCubicBrickNecessary(currentBrick, firstCol, _currentRowNumber, currentColNumber))
        {
            currentBrick = NewRedCubicBrick();
        }

        return currentBrick;
    }

    protected abstract bool IsCubicBrickNecessary(Brick currentBrick, bool firstCol, int currentRowNumber, int currentColNumber);

    protected virtual bool LastCol(Brick brick) => _builtWidth + brick.Width >= _totalWidth;

    protected static Brick NewRedCubicBrick() => new RedCubicBrick
    {
        Size = 10,
        Color = BrickColor.Red
    };

    protected virtual void AppendBrickToRow(Brick currentBrick)
    {
        _row.Add(currentBrick);

        _builtWidth += currentBrick.Width;
    }
}
