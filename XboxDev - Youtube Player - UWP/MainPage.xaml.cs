using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyToolkit.Multimedia;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XboxDev___Youtube_Player___UWP.Models;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace XboxDev___Youtube_Player___UWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
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

            List<YouTubeVideo> YouTubeVideos = await GetYouTubeVideos();


            YouTubeVideosCollection = new ObservableCollection<YouTubeVideo>(YouTubeVideos);

            LVVideos.ItemsSource = YouTubeVideos;
        }


        /// <summary>
        /// Return all YouTube videeos
        /// </summary>
        /// <returns></returns>
        private async Task<List<YouTubeVideo>> GetYouTubeVideos()
        {

            List<YouTubeVideo> LstVideos = new List<YouTubeVideo>()
           {
               new YouTubeVideo
               {
                   YouTubeId="J--Zs64jMqw",
                   Title=await YouTube.GetVideoTitleAsync("J--Zs64jMqw"),
                   ThumbnailUri= YouTube.GetThumbnailUri("J--Zs64jMqw",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("J--Zs64jMqw",YouTubeQuality.QualityHigh)
               },

               new YouTubeVideo
               {
                   YouTubeId="razaRCeATaw",
                   Title=await YouTube.GetVideoTitleAsync("razaRCeATaw"),
                   ThumbnailUri= YouTube.GetThumbnailUri("razaRCeATaw",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("razaRCeATaw",YouTubeQuality.QualityHigh)
               },

               new YouTubeVideo
               {
                   YouTubeId="eHMUHwXG45s",
                   Title=await YouTube.GetVideoTitleAsync("eHMUHwXG45s"),
                   ThumbnailUri= YouTube.GetThumbnailUri("eHMUHwXG45s",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("eHMUHwXG45s",YouTubeQuality.QualityHigh)
               },
               new YouTubeVideo
               {
                   YouTubeId="JlnMYbHm3tU",
                   Title=await YouTube.GetVideoTitleAsync("JlnMYbHm3tU"),
                   ThumbnailUri= YouTube.GetThumbnailUri("JlnMYbHm3tU",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("JlnMYbHm3tU",YouTubeQuality.QualityHigh)
               },
               new YouTubeVideo
               {
                   YouTubeId="QacWskCibnU",
                   Title=await YouTube.GetVideoTitleAsync("QacWskCibnU"),
                   ThumbnailUri= YouTube.GetThumbnailUri("QacWskCibnU",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("QacWskCibnU",YouTubeQuality.QualityHigh)
               },
               new YouTubeVideo
               {
                   YouTubeId="QlAnthLUa5k",
                   Title=await YouTube.GetVideoTitleAsync("QlAnthLUa5k"),
                   ThumbnailUri= YouTube.GetThumbnailUri("QlAnthLUa5k",YouTubeThumbnailSize.Large),
                   VideoUri=await YouTube.GetVideoUriAsync("QlAnthLUa5k",YouTubeQuality.Quality2160P)
               },

           };

            return LstVideos;
        }

        private void LVVideos_ItemClick(object sender, ItemClickEventArgs e)
        {
            YouTubeVideo video = (YouTubeVideo)e.ClickedItem;
            try
            {

                Player.Source = video.VideoUri.Uri;
                TxtVideoName.Text = video.Title;
                Player.Play();
            }
            catch (Exception)
            {
                // TODO show error (video uri not found)
            }
        }
    }
}
