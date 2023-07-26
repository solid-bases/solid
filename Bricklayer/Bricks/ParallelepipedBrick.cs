namespace Bricklayer.Bricks;

internal class ParallelepipedBrick : Brick
{
    internal override int Width { get => base.Width; set => SetSizesFromLongEdge(value); }
    internal override int Height { get => base.Height; set => SetSizesFromShortEdge(value); }
    internal override int Depth { get => base.Depth; set => SetSizesFromShortEdge(value); }
    internal override BrickColor Color { get => _brickColor.Color; set => _brickColor.Color = value; }

    private readonly Brick _brickColor;
    public ParallelepipedBrick(Brick brickColor)
    {
        this._brickColor = brickColor;
    }

    private void SetSizesFromLongEdge(int value)
    {
        base.Height = base.Depth = value / 2;
        base.Width = value;
    }

    private void SetSizesFromShortEdge(int value)
    {
        base.Width = value * 2;
        base.Height = base.Depth = value;
    }
}
