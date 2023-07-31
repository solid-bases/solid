namespace Bricklayer.Builder;

internal class StandardWallBuilder : GeneralWallBuilder
{
    public StandardWallBuilder(IGreyPattern greyPattern)
    {
        _greyPattern = greyPattern;
    }
}
