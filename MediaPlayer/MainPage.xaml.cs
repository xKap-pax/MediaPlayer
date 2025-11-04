using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace MediaPlayer
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<SongModel> _songs = new();
        private bool isPlaying = false;
        public MainPage()
        {
            InitializeComponent();
           
        }
        private void OnPlayPauseClicked(object sender, EventArgs e)
        {
            isPlaying = !isPlaying;
            
            (sender as Button).Text = isPlaying ? "⏸" : "⏯";
        }

        private void OnPrevClicked(object sender, EventArgs e)
        {
        }
        private async void OpenSongListClicked(object sender, EventArgs e)
        {
            if (PopupHost.Content == null)
            {
                var popup = new NewContent1(_songs);
                PopupHost.IsVisible = true;
                PopupHost.Content = popup;
            }

            PopupHost.IsVisible = true;
            await ((NewContent1)PopupHost.Content).ShowAsync();
        }
        private void OnNextClicked(object sender, EventArgs e)
        {
        }

    }
}
