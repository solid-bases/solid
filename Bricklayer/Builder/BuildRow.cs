using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal class BuildRow
{
    private readonly List<Brick> _row = new();
    private readonly int _totalWidth;
    private readonly GreyPattern _greyPattern;
    private readonly int _currentRowNumber;
    private int _builtWidth = 0;

    public BuildRow(int totalWidth, GreyPattern greyPattern, int currentRowNumber)
    {
        _totalWidth = totalWidth;
        _greyPattern = greyPattern;
        _currentRowNumber = currentRowNumber;

        BuildCurrentRow();
    }

    public Brick[] ToArray() => _row.ToArray();

    private void BuildCurrentRow()
    {
        for (var currentColNumber = 1; _builtWidth < _totalWidth; currentColNumber++)
        {
            AppendProperNewBrick(currentColNumber);
        }
    }

    private void AppendProperNewBrick(int currentColNumber)
    {
        var currentBrick = DefineNewBrick(currentColNumber);
        AppendBrickToRow(currentBrick);
    }

    public Brick DefineNewBrick(int currentColNumber)
    {
        Brick currentBrick = NewRedParallelepipedBrick();
        currentBrick = GetGreyBrickWhenInPattern(currentColNumber, currentBrick);

        return DefineRowsWithCubicBricks(currentColNumber, currentBrick);
    }

    private static Brick NewRedParallelepipedBrick() => new RedParallelepipedBrick
    {
        Width = 20
    };

    private Brick GetGreyBrickWhenInPattern(int currentColNumber, Brick currentBrick)
    {
        if (_greyPattern.IsContainingBrick(currentColNumber, _currentRowNumber))
        {
            currentBrick = NewGreyParallelepipedBrick();
        }

        return currentBrick;
    }

    private static Brick NewGreyParallelepipedBrick() => new GreyParallelepipedBrick
    {
        Width = 20
    };

    private Brick DefineRowsWithCubicBricks(int currentColNumber, Brick currentBrick)
    {
        bool evenRow = _currentRowNumber % 2 == 0;
        if (evenRow)
        {
            currentBrick = DefineWhenCubicBrickIsNecessaryInARow(currentColNumber, currentBrick);
        }

        return currentBrick;
    }

    private Brick DefineWhenCubicBrickIsNecessaryInARow(int currentColNumber, Brick currentBrick)
    {
        bool firstCol = currentColNumber == 1;
        if (firstCol || LastCol(currentBrick))
        {
            currentBrick = NewRedCubicBrick();
        }

        return currentBrick;
    }

    private bool LastCol(Brick brick) => _builtWidth + brick.Width >= _totalWidth;

    private static Brick NewRedCubicBrick() => new RedCubicBrick
    {
        Size = 10,
        Color = BrickColor.Red
    };

    private void AppendBrickToRow(Brick currentBrick)
    {
        _row.Add(currentBrick);

        _builtWidth += currentBrick.Width;
    }
}
