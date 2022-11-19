using CommunityToolkit.Maui.ImageSources;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGImageLoadSample.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ImageSource _image;

        [ObservableProperty]
        private string _text;

        public MainViewModel()
        {
            Image = "dotnet_bot.png";
            Text = "Load an SVG image";
        }

        [RelayCommand]
        public async Task LoadImage()
        {
            FileResult fileData = null;

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                var fileTypes =
                new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                { DevicePlatform.iOS, new[] { "UTType.Image" } }, // or general UTType values
                { DevicePlatform.Android, new[] { "application/png", "application/svg" } },
                { DevicePlatform.WinUI, new[] { ".png", ".svg" } },
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "png", "svg" } }, // or general UTType values
                });

                var options = new PickOptions()
                {
                    FileTypes = fileTypes,
                    PickerTitle = "Select image"
                };

                fileData = await FilePicker.PickAsync(options);
            }
            else
            {
                var options = new MediaPickerOptions
                {
                    Title = "Select image",
                };
                fileData = await MediaPicker.PickPhotoAsync(options);
            }

            if (fileData == null)
                return; // user canceled file picking

            try
            {
                var imageData = await fileData.OpenReadAsync();
                byte[] imageByteArray = new byte[imageData.Length];

                await imageData.ReadAsync(imageByteArray, 0, (int)imageData.Length);

                Image = ImageSource.FromStream(() => new MemoryStream(imageByteArray));

            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
