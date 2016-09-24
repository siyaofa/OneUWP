﻿using OneUWP.Http;
using OneUWP.Http.Data;
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
        public movie_story _movie_story;

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

        public async void PageFresh()
        {
            var _movie_detail = await APIService.Get_movie_detail(movieId);
            movieDetailPageViewModel.video = _movie_detail.data.video;
            movieDetailPageViewModel.title = _movie_detail.data.title;
            movieDetailPageViewModel.keywords = _movie_detail.data.keywords;
            movieDetailPageViewModel.info = _movie_detail.data.info;
            movieDetailPageViewModel.detailcover = await ImageOperation.GetImage(_movie_detail.data.detailcover);

            myMedia.Source = new Uri(movieDetailPageViewModel.video);

            _movie_story = await APIService.Get_movie_story(movieId);
            movieDetailPageViewModel.story_web_url = await ImageOperation.GetImage(_movie_story.data.data[0].user.web_url);
            movieDetailPageViewModel.story_input_date = _movie_story.data.data[0].input_date;
            movieDetailPageViewModel.story_user_name= _movie_story.data.data[0].user.user_name;
            movieDetailPageViewModel.story_content = _movie_story.data.data[0].content;



        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MovieStoryPage), movieId);
        }
    }
}
