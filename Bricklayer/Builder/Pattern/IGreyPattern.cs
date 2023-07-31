namespace Bricklayer.Builder.Pattern;

internal interface IGreyPattern
{
    bool IsRectangle { get; }
    RowPattern[] Pattern { get; }

    bool IsContainingBrick(int currentColNumber, int currentRowNumber);
    void AskForWallType();
}
