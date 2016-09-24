using OneUWP.Http;
using OneUWP.Http.Data;
using OneUWP.Models;
using OneUWP.Tools;
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
    public sealed partial class MovieStoryPage : Page
    {
        public ObservableCollection<MovieStoryPageModel> movieStoryPageData = new ObservableCollection<MovieStoryPageModel>();
        public string movieId;

        public MovieStoryPage()
        {
            this.InitializeComponent();
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            movieId = (string)e.Parameter;
            FreshPage();
        }

        private async void FreshPage()
        {
            var _movie_story = await APIService.Get_movie_story(movieId);
            InfoTextBlock.Text = _movie_story.data.data.Count().ToString();
            for (int i = 0; i < _movie_story.data.data.Count(); i++)
            {
                movieStoryPageData.Add(new MovieStoryPageModel
                {
                    userName = _movie_story.data.data[i].user.user_name,
                    userImage = await ImageOperation.GetImage(_movie_story.data.data[i].user.web_url),
                    makeTime = _movie_story.data.data[i].input_date,
                    praiseNum = _movie_story.data.data[i].praisenum.ToString(),
                    title = _movie_story.data.data[i].title,
                    content=_movie_story.data.data[i].content
                });
            }

            
        }
    }
}
