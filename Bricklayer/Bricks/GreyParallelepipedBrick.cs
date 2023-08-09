namespace Bricklayer.Bricks;

// Composition + Delegation
internal class GreyParallelepipedBrick : Brick
{
    private readonly ParallelepipedBrick _parallelepipedBrick = new(new GreyBrick());

    // Forwarding
    internal override int Width { get => _parallelepipedBrick.Width; set => _parallelepipedBrick.Width = value; }
    internal override int Height { get => _parallelepipedBrick.Height; set => _parallelepipedBrick.Height = value; }
    internal override int Depth { get => _parallelepipedBrick.Depth; set => _parallelepipedBrick.Depth = value; }
    internal override BrickColor Color { get => _parallelepipedBrick.Color; set => _parallelepipedBrick.Color = value; }
}
