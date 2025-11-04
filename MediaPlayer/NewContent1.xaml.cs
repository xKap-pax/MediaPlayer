using System.Collections.ObjectModel;
using System.Text.Json;
using CommunityToolkit.Maui.Core;

using CommunityToolkit.Maui.Media;
using CommunityToolkit.Maui.Views;
namespace MediaPlayer;

public partial class NewContent1 : ContentView
{
    public ObservableCollection<SongModel> Songs { get; set; }
    public NewContent1(ObservableCollection<SongModel> songs)
    {
        InitializeComponent();
        Songs = songs;
        SongsCollectionView.ItemsSource = Songs;

    }
    private readonly string _songsFilePath = Path.Combine(FileSystem.AppDataDirectory, "songs.json");
    private async Task SaveSongsAsync()
    {
        try
        {
            var json = JsonSerializer.Serialize(Songs);
            await File.WriteAllTextAsync(_songsFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"B³¹d zapisu piosenek: {ex.Message}");
        }
    }
    public async Task ShowAsync()
    {
        this.TranslationX = 300;
        this.IsVisible = true;
        await this.TranslateTo(0, 0, 250, Easing.CubicOut);
    }
    private async void BackgroundTapped(object sender, EventArgs e)
    {
        await this.TranslateTo(300, 0, 250, Easing.CubicIn);
        this.IsVisible = false;
    }
    private async Task SaveSongsAsync()
    {
        try
        {
            var json = JsonSerializer.Serialize(Songs);
            await File.WriteAllTextAsync(_songsFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"B³¹d zapisu piosenek: {ex.Message}");
        }
    }

    private async void Add_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Wybierz pliki muzyczne",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".mp3", ".wav", ".flac" } },
                        { DevicePlatform.Android, new[] { "audio/*" } },
                        { DevicePlatform.iOS, new[] { "public.audio" } }
                    })
            });

            if (result != null)
            {
                foreach (var file in result)
                {
                    Songs.Add(new SongModel
                    {
                        Title = System.IO.Path.GetFileNameWithoutExtension(file.FileName),
                        Path = file.FullPath
                    });
                }
            }
            await SaveSongsAsync();
        }
        catch (Exception ex)
        {
           
     
        }

    }
}