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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using OneUWP.Http;
using OneUWP.Tools;
using OneUWP.Models;
using OneUWP.Http.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoviePage : Page
    {
        public ObservableCollection<MoviePageModel> ImageCollection = new ObservableCollection<MoviePageModel>();
        public MoviePage()
        {
            this.InitializeComponent();
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {

            PageFresh();
        }

        public async void PageFresh()
        {
            var _movie_list = await APIService.Get_movie_list();

            for (int i = 0; i < _movie_list.data.Count(); i++)
            {
                ImageCollection.Add(new MoviePageModel {
                    wb = await ImageOperation.GetImage(_movie_list.data[i].cover),
                    id =_movie_list.data[i].id,
                    score=_movie_list.data[i].score
                });
            }
        }

        private void myListView_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            MoviePageModel item = (MoviePageModel)e.ClickedItem;
            // InfoTextBlock.Text =item.id;
            Frame.Navigate(typeof(MovieDetailPage), item.id);
        }
    }
}
