using YourPixel.Core;

namespace YourPixel.Pages
{
    public partial class AllWallpapers
    {
        List<Wallpaper> wallpapers = new List<Wallpaper>();

        protected override async Task OnInitializedAsync()
        {
            wallpapers = await wallpaperFileService.GetWallpapers();
        }
        public void DisplayMemes()
        {
            for (int i = 0; i < 24; i++)
            {

            }
        }
    }
}
