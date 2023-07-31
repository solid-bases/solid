using Bricklayer.Bricks;

namespace Bricklayer.Builder;

internal interface IBuiltRow
{
    int BuiltWidth { get; }
    int CurrentColNumber { get; }
    int TotalWidth { get; }

    void AppendNewBrick(int currentRowNumber);
    Brick[] ToArray();
}
