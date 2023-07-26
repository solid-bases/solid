namespace Bricklayer.Builder;

internal class GreyPattern
{
    private RowPattern[] _pattern;
    internal RowPattern[] Pattern
    {
        get => _pattern;
        set
        {
            if (value == null)
            {
                _pattern = Array.Empty<RowPattern>();
                return;
            }
            _pattern = value;
        }
    }

    public GreyPattern(RowPattern[] pattern)
    {
        this._pattern = pattern;
    }


    public bool IsContainingBrick(int currentColNumber, int currentRowNumber)
    {
        return _pattern
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
