namespace YourPixel.Core
{
    public record Wallpaper(string FileName, string FullFileName, ImageResolution ImageResolution);
    public record ImageResolution(int Width, int Height);
}
