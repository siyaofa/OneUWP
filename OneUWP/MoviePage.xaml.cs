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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            PageFresh();
        }

        private async void PageFresh()
        {
            var _movie_detail = await APIService.Get_movie_detail();

            for (int i = 0; i < _movie_detail.data.Count(); i++)
            {
                ImageCollection.Add(new MoviePageModel { wb = await ImageOperation.GetImage(_movie_detail.data[i].cover) });
            }
        }
    }
}
