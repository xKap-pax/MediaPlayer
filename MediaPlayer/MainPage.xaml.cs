namespace MediaPlayer
{
    public partial class MainPage : ContentPage
    {
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

        private void OnNextClicked(object sender, EventArgs e)
        {
        }

    }
}
