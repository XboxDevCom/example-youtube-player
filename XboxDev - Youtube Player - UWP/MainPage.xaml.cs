using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MyToolkit.Multimedia;
using XboxDev___Youtube_Player___UWP.Models;

namespace XboxDev___Youtube_Player___UWP
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<YouTubeVideo> YouTubeVideosCollection;

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var videoIds = new[]
            {
                "J--Zs64jMqw",
                "razaRCeATaw",
                "eHMUHwXG45s",
                "JlnMYbHm3tU",
                "QacWskCibnU",
                "QlAnthLUa5k"
            };

            var videos = await GetYouTubeVideosAsync(videoIds);
            YouTubeVideosCollection = new ObservableCollection<YouTubeVideo>(videos);
            LVVideos.ItemsSource = YouTubeVideosCollection;
        }

        private async Task<List<YouTubeVideo>> GetYouTubeVideosAsync(string[] videoIds)
        {
            var tasks = videoIds.Select(async id => new YouTubeVideo
            {
                YouTubeId = id,
                Title = await YouTube.GetVideoTitleAsync(id),
                ThumbnailUri = YouTube.GetThumbnailUri(id, YouTubeThumbnailSize.Large),
                VideoUri = await YouTube.GetVideoUriAsync(id, YouTubeQuality.QualityHigh)
            });

            var results = await Task.WhenAll(tasks);
            return results.ToList();
        }

        private void LVVideos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var video = (YouTubeVideo)e.ClickedItem;

            if (video?.VideoUri?.Uri == null)
            {
                TxtVideoName.Text = "Video konnte nicht geladen werden.";
                return;
            }

            try
            {
                Player.Source = video.VideoUri.Uri;
                TxtVideoName.Text = video.Title;
                Player.Play();
            }
            catch (Exception)
            {
                TxtVideoName.Text = "Fehler beim Abspielen des Videos.";
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (LVVideos.SelectedIndex > 0)
            {
                LVVideos.SelectedIndex--;
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (LVVideos.SelectedIndex < YouTubeVideosCollection.Count - 1)
            {
                LVVideos.SelectedIndex++;
            }
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            Player.IsFullWindow = !Player.IsFullWindow;
        }
    }
}
