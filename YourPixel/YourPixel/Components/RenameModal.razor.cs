using Microsoft.AspNetCore.Components;
using YourPixel.Core;

namespace YourPixel.Components
{
	public partial class RenameModal
	{
		private Modal modal { get; set; }
		private string FileName { get; set; }
		private string NewName { get; set; }
		private string PathOfFolder { get; set; }

		[Parameter]
		public EventCallback OnSubmit { get; set; }

		private List<Wallpaper> Wallpapers { get; set; }

		protected override async Task OnParametersSetAsync()
		{
			PathOfFolder = await yourPixelFileService.GetYourPixelFolderPath();
		}
		public async void Open(string fileName, List<Wallpaper> wallpapers)
		{
			Wallpapers = wallpapers;
			FileName = fileName;
			modal.Open();
			StateHasChanged();
		}


		async void Submit()
		{
			var path = Path.Combine(PathOfFolder, FileName);
			var newPath = Path.Combine(PathOfFolder, NewName + Path.GetExtension(path));
			
			if (File.Exists(path))
			{
				File.Move(path, newPath);
				var wallpaper = Wallpapers.First(f => f.FileName == FileName);
				var newWallpaper = new Wallpaper(NewName, newPath, wallpaper.ImageResolution);
				Wallpapers.Remove(Wallpapers.First(x => x.FileName == FileName));
				Wallpapers.Add(newWallpaper);
			}
			this.StateHasChanged();
			await OnSubmit.InvokeAsync();
			modal.Close();
		}



	}

}
