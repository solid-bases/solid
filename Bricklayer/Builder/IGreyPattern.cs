namespace Bricklayer.Builder;

internal interface IGreyPattern
{
    bool IsRectangle { get; }
    RowPattern[] Pattern { get; }

    bool IsContainingBrick(int currentColNumber, int currentRowNumber);
    IGreyPattern SetAsRectangle();
}
