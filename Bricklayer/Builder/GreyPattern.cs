namespace Bricklayer.Builder;

internal class GreyPattern
{
    private RowPattern[] pattern;

    internal RowPattern[] Pattern
    {
        get => pattern;
        set
        {
            if (value == null)
            {
                pattern = new RowPattern[0];
                return;
            }
            pattern = value;
        }
    }

    public GreyPattern(RowPattern[] pattern)
    {
        this.pattern = pattern;
    }


    public bool IsContainingBrick(int currentColNumber, int currentRowNumber)
    {
        return pattern
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
