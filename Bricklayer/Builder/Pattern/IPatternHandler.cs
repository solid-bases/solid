namespace Bricklayer.Builder.Pattern;

internal interface IPatternHandler : ICanCheckContainingBrickAndRectangle, ICanAskForWallType
{
    RowPattern[] Pattern { get; }
}

// Following interfaces will be moved to proper file. They are here just for the sake of the example.
internal interface ICanAskForWallType
{
    void AskForWallType();
}

internal interface ICanCheckContainingBrick
{
    bool IsContainingBrick(int currentColNumber, int currentRowNumber);
}

internal interface ICanCheckRectangle
{
    bool IsRectangle { get; }
}

internal interface ICanCheckContainingBrickAndRectangle : ICanCheckContainingBrick, ICanCheckRectangle {}