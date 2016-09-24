using OneUWP.Http;
using OneUWP.Tools;
using OneUWP.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPageViewModel movieDetailPageViewModel = new MovieDetailPageViewModel();
        public string movieId;

        public MovieDetailPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            movieId = (string)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PageFresh();
        }

        private async void PageFresh()
        {
            var _movie_detail = await APIService.Get_movie_detail(movieId);
            if (_movie_detail != null)
            {
                movieDetailPageViewModel.video = _movie_detail.data.video;
                movieDetailPageViewModel.title = _movie_detail.data.title;
                movieDetailPageViewModel.keywords = _movie_detail.data.keywords;
                movieDetailPageViewModel.info = _movie_detail.data.info;
                movieDetailPageViewModel.detailcover =await ImageOperation.GetImage(_movie_detail.data.detailcover);
            }
            myMedia.Source = new Uri(movieDetailPageViewModel.video);
        }

     
    }
}
