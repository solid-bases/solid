using Bricklayer.Builder.Pattern;

namespace Bricklayer.Builder;

internal class StandardWallConfiguration : GeneralWallConfiguration
{
    public StandardWallConfiguration() : base(new GreyPattern()) { }
}
