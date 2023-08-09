namespace Bricklayer.Builder.Pattern;

internal class AlternativeAvailablePatterns : IAvailablePatterns
{
    public RowPattern[] RhombusPattern => new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 5 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 5 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 4,6 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 6 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 5 }
            },
        };

    public RowPattern[] RectangularPattern => new[] {
            new RowPattern {
                RowNumber = 3,
                ColumnsNumber = new[] { 3,4,5,6 }
            },
            new RowPattern {
                RowNumber = 4,
                ColumnsNumber = new[] { 4,8 }
            },
            new RowPattern {
                RowNumber = 5,
                ColumnsNumber = new[] { 3,6 }
            },
            new RowPattern {
                RowNumber = 6,
                ColumnsNumber = new[] { 4,8 }
            },
            new RowPattern {
                RowNumber = 7,
                ColumnsNumber = new[] { 3,4,5,6 }
            },
        };
}
