namespace Bricklayer.Builder.Pattern;

internal class GreyPattern : IGreyPattern
{
    public RowPattern[] Pattern
    {
        get
        {
            return IsRectangle ? AvailableGreyPatterns.RectangularPattern : AvailableGreyPatterns.RhombusPattern;
        }
    }

    public bool IsRectangle { get; private set; }

    public void AskForWallType()
    {
        string? input = UserInputPrompter.AskAndVerifyValidInputs(new Dictionary<string, string> { { "1", "Rhombus" }, { "2", "Rectangle" } });
        IsRectangle = UserInputPrompter.IsEqualsIc(input ?? string.Empty, "2");
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
