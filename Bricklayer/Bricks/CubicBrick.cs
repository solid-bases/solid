namespace Bricklayer.Bricks;

internal class CubicBrick : Brick
{
    internal int Size { get; set; }
    internal override int Width { get => Size; set => Size = value; }
    internal override int Height { get => Size; set => Size = value; }
    internal override int Depth { get => Size; set => Size = value; }
}
