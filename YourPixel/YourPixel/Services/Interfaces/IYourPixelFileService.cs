using YourPixel.Core;

namespace YourPixel.Services.Interfaces
{
    public interface IYourPixelFileService
	{
        Task<string> GetYourPixelFolderPath();
        Task<List<Wallpaper>> GetWallpapers();
    }
}
