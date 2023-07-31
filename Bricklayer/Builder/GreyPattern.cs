namespace Bricklayer.Builder;

internal class GreyPattern : IGreyPattern
{
    public RowPattern[] Pattern { get => IsRectangle ? _rectangularPattern : _rhombusPattern; }

    private readonly RowPattern[] _rhombusPattern = new[] {
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
        };

    private readonly RowPattern[] _rectangularPattern = new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 3,4,5,6,7 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 4,9 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 3,7 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 4,9 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 3,4,5,6,7 }
            },
        };

    public bool IsRectangle { get; private set; }

    public IGreyPattern SetAsRectangle()
    {
        IsRectangle = true;
        return this;
    }

    public bool IsContainingBrick(int currentColNumber, int currentRowNumber)
    {
        return Pattern
            .Where(RowNumberIsCurrentRow(currentRowNumber))
            .Any(CurrentColumnInGreyColumn(currentColNumber));
    }

    private Func<RowPattern, bool> RowNumberIsCurrentRow(int currentRowNumber)
    {
        bool IsCurrentRow(RowPattern greyRow) => greyRow.RowNumber == currentRowNumber;
        return IsCurrentRow;
    }

    private Func<RowPattern, bool> CurrentColumnInGreyColumn(int currentColNumber)
    {
        bool ContainsCurrentColumn(RowPattern greyRow) => greyRow.ColumnsNumber.Any(IsCurrentColumn);
        bool IsCurrentColumn(int greyCol) => greyCol == currentColNumber;

        return ContainsCurrentColumn;
    }
}
