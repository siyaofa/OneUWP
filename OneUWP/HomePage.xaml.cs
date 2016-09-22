using OneUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using OneUWP.ViewModels;
using System.Threading.Tasks;
using OneUWP.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        //  public HomepageData homepageData = new HomepageData();
        public double x;
        public HomePageViewModel homePageViewModel;

        public HomePage()
        {
            InitializeComponent();
            // homepageData = Resources["homepageData"] as HomepageData;
            this.DataContext = homePageViewModel = new HomePageViewModel();
            ManipulationCompleted += The_ManipulationCompleted;
            ManipulationDelta += The_ManipulationDelta;
        }

        private void The_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            x += e.Delta.Translation.X;//将滑动的值赋给x
        }
        private void The_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            int xR = 50;
            if (x > xR)//判断滑动的距离是否符合条件
            {
                App.currentDate = App.currentDate.AddDays(1);
                PageFresh(App.currentDate);
            }
            else if (x < -xR)
            {
                App.currentDate = App.currentDate.AddDays(-1);
                PageFresh(App.currentDate);
            }
            x = 0;
        }

        public async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.homepageSheet == null) { App.homepageSheet = await GetDateSheets.GetHomepageSheet(); }
            PageFresh(App.currentDate);
            homePageViewModel.Theme = App.appTheme;
        }

        public async void PageFresh(DateTime date)
        {
            homePageViewModel.ChangeProgressRing(Visibility.Visible);
            var hp_detail = await APIService.Get_hp_detail();
            if (hp_detail != null)
            {
                InfoTextBlock.Text = "请稍等";
                homePageViewModel.writeableBitmap = await ImageOperation.GetImage(hp_detail.data.hp_img_url);
                homePageViewModel.author = hp_detail.data.hp_author;
                homePageViewModel.date = hp_detail.data.hp_makettime;
                homePageViewModel.content = hp_detail.data.hp_content;
                InfoTextBlock.Visibility = Visibility.Collapsed;
                homePageViewModel.ChangeProgressRing(Visibility.Collapsed);
            }
            else
            {
                homePageViewModel.ChangeProgressRing(Visibility.Collapsed);
                InfoTextBlock.Visibility = Visibility.Visible;
                InfoTextBlock.Text = App.currentDate.ToString("yyyy-MM-dd") + " 暂无内容";
            }
        }



    }
}
