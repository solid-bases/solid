using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder;

internal class StandardWallBuilder : GeneralWallBuilder
{
    public StandardWallBuilder(IPatternHandler greyPattern) : base(greyPattern) { }
}
