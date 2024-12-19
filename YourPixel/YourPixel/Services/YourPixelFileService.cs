using System.Drawing;
using YourPixel.Core;
using YourPixel.Services.Interfaces;

namespace YourPixel.Services
{
    public class YourPixelFileService : IYourPixelFileService
	{
        string YourPixelFolderPath = "D:\\YourPixelAppPicture";

		public async Task<string> GetYourPixelFolderPath()
		{
            return YourPixelFolderPath;
		}

		public async Task<List<Wallpaper>> GetWallpapers()
        {
            List<string> files;
			List<Wallpaper> wallpapers = new List<Wallpaper>();

			try
            {
				files = Directory.GetFiles(YourPixelFolderPath, "*.jpg").ToList();
				foreach (var file in files)
				{
                    using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        Image image = Image.FromStream(stream);
                        var imageResolution = new ImageResolution(image.Width, image.Height);
                        wallpapers.Add(new Wallpaper(Path.GetFileName(file), Path.Combine("/StaticFiles", Path.GetFileName(file)), imageResolution));
                    }
				}
			}
            catch(Exception ex)
            {
				throw new ApplicationException("An exception has been thrown during retrieval of wallpapers.", ex);
			}

			if (!wallpapers.Any())
            {
                throw new ApplicationException("No files has been found in the provided directory.");
            }

            return wallpapers;
        }
    }
}
