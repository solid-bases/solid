namespace Bricklayer.Builder.Pattern;

internal class AvailablePatterns : IAvailablePatterns
{
    public RowPattern[] RhombusPattern => new[] {
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

    public RowPattern[] RectangularPattern => new[] {
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
}
