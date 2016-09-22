using OneUWP.Models;
using OneUWP.Http.Data;
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
using OneUWP.Tools;
using System.Text.RegularExpressions;
using OneUWP.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MusicPage : Page
    {
        public ObservableCollection<MusicPageModel> musicPageData = new ObservableCollection<MusicPageModel>();
        public MusicPageViewModel musicPageViewModel;

        public MusicPage()
        {
            this.InitializeComponent();
            this.DataContext = musicPageViewModel = new MusicPageViewModel();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FreshPage();
        }

        private async void FreshPage()
        {
            music_detail _music_detail = await Http.APIService.Get_music_detail();

            var writeableBitmap = await ImageOperation.GetImage(_music_detail.data.cover);

            musicPageViewModel.wb = writeableBitmap;
            musicPageViewModel.lyric = Regex.Replace(_music_detail.data.lyric, "<br>", Environment.NewLine);
        
          
        }
    }
}
