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
        internal static music_idlist musicIDList;

        public MusicPage()
        {
            this.InitializeComponent();
            this.DataContext = musicPageViewModel = new MusicPageViewModel();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            musicIDList = await Http.APIService.Get_music_idlist();
            FreshPage(musicIDList.data[0]);
        }

        private async void FreshPage(string id)
        {
           
            try
            {
                music_detail _music_detail = await Http.APIService.Get_music_detail(id);
                var writeableBitmap = await ImageOperation.GetImage(_music_detail.data.cover);
                musicPageViewModel.cover = writeableBitmap;
                writeableBitmap = await ImageOperation.GetImage(_music_detail.data.author.web_url);
                //音乐作者
                musicPageViewModel.author_web_url = writeableBitmap;
                musicPageViewModel.title = _music_detail.data.title;
                musicPageViewModel.author_user_name = _music_detail.data.author.user_name;
                musicPageViewModel.author_desc = _music_detail.data.author.desc;

                //音乐故事
                musicPageViewModel.story_title = _music_detail.data.story_title;
                musicPageViewModel.story_author = _music_detail.data.story_author.user_name;
                musicPageViewModel.story = Regex.Replace(_music_detail.data.story, "<br>", Environment.NewLine);
                //音乐歌词
                musicPageViewModel.lyric = Regex.Replace(_music_detail.data.lyric, "<br>", Environment.NewLine);
                //音乐信息
                musicPageViewModel.info = _music_detail.data.info;
                //责任编辑
                musicPageViewModel.charge_edt = _music_detail.data.charge_edt;
                //评论点赞分享数
                musicPageViewModel.praisenum = _music_detail.data.praisenum.ToString();
                musicPageViewModel.sharenum = _music_detail.data.sharenum.ToString();
                musicPageViewModel.commentnum = _music_detail.data.commentnum.ToString();


            } catch { }
           
        }
    }
}
