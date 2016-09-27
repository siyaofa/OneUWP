using OneUWP.Http;
using OneUWP.Http.Data;
using OneUWP.Models;
using OneUWP.Tools;
using OneUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<MovieDetailPageSlideModel> slide = new ObservableCollection<MovieDetailPageSlideModel>();
        public string movieId;

        public MovieDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            movieId = (string)e.Parameter;
            PageFresh(movieId);
        }


        public async void PageFresh(string movieId)
        {
            var _movie_detail = await APIService.Get_movie_detail(movieId);
            movieDetailPageViewModel.video = _movie_detail.data.video;
            movieDetailPageViewModel.title = _movie_detail.data.title;
            movieDetailPageViewModel.keywords = _movie_detail.data.keywords;
            movieDetailPageViewModel.info = _movie_detail.data.info;
            movieDetailPageViewModel.detailcover = await ImageOperation.GetImage(_movie_detail.data.detailcover);
            for (int i = 0; i < _movie_detail.data.photo.Count(); i++)
                slide.Add(new MovieDetailPageSlideModel { slide = await ImageOperation.GetImage(_movie_detail.data.photo[i]) });
            var _movie_story = await APIService.Get_movie_story(movieId);
            movieDetailPageViewModel.story_web_url = await ImageOperation.GetImage(_movie_story.data.data[0].user.web_url);
            movieDetailPageViewModel.story_input_date = _movie_story.data.data[0].input_date;
            movieDetailPageViewModel.story_user_name = _movie_story.data.data[0].user.user_name;
            movieDetailPageViewModel.story_content = _movie_story.data.data[0].content;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MovieStoryPage), movieId);
        }

        private void MovieButton_Click(object sender, RoutedEventArgs e)
        {
            if (myMedia == null)
            {
                this.FindName(nameof(myMedia));
                if (myMedia.Source == null)
                    myMedia.Source = new Uri(movieDetailPageViewModel.video);
            }
            if ((sender as ToggleButton).IsChecked == true)
                myMedia.Visibility = Visibility.Visible;
            else
            {
                myMedia.Pause();
                myMedia.Visibility = Visibility.Collapsed;
            }
        }
    }
}
