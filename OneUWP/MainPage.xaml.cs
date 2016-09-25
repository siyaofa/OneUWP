using Microsoft.Toolkit.Uwp.UI.Animations;
using OneUWP.Model;
using OneUWP.Tools;
using OneUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.Globalization.DateTimeFormatting;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPageViewModel mainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            this.DataContext = mainPageViewModel = new MainPageViewModel();
            DispatcherManager.Current.Dispatcher = Dispatcher;
        }
        /// <summary>
        /// 订阅后退事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!mySplitView.IsPaneOpen)
            {
                if (this.myFrame.CanGoBack && !this.myFrame.Content.GetType().Equals(typeof(HomePage)))  //
                {
                    this.myFrame.GoBack();
                }
                else
                {
                    if (popTips.IsOpen)  //第二次按back键
                    {
                        Application.Current.Exit();
                    }
                    else
                    {
                        popTips.IsOpen = true;  //提示再按一次
                        popTips.HorizontalOffset = this.ActualWidth / 2 - 45;  //居中
                        popTips.VerticalOffset = this.ActualHeight / 2 - 5;
                        e.Handled = true;
                        await Task.Delay(1000);  //1000ms后关闭提示
                        popTips.IsOpen = false;
                    }
                }
            }
            else
            {
                mySplitView.IsPaneOpen = false;
            }
            e.Handled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //如果是手机的话就显示状态栏
            BackgroundTaskAction.ShowStatusBar(mainPageViewModel.APPTheme);
            myFrame.Navigate(typeof(HomePage));

        }

        private async void DatePickerFlyout_Closed(object sender, object e)
        {
            //if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            //{
            //    await myFrame.Blur(value: 0).StartAsync();
            //}
            //else
            //{
            //    await myFrame.Blur(value: 0).StartAsync();
            //}

            await myFrame.Blur(value: 0).StartAsync();
        }

        private  void DatePickerFlyout_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            AppTitle.Text = "One 一个";
            var date = args.NewDate.DateTime.ToString("yyyy-MM");
            myFrame.Navigate(typeof(HomeMonthPage),date);
            // myFrame.Navigate(typeof(HomePage));

            //if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            //{
            //    await myFrame.Blur(value: 0).StartAsync();
            //}
            //else
            //{
            //    await myFrame.Blur(value: 0).StartAsync();
            //}

            // await myFrame.Blur(value: 0).StartAsync();
        }


        /// 电脑端后台代码
        /// 电脑端后台代码
        /// 电脑端后台代码

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private async void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (sender as ListBox);
            var item = (listBox.SelectedItem as ListBoxItem).Name;
            if (item == "HomeListBoxItem")
            {
                myFrame.Navigate(typeof(HomePage));
                AppTitle.Text = "One 一个";
            }
            else if (item == "ReadingListBoxItem")
            {
                myFrame.Navigate(typeof(ReadingPage));
                AppTitle.Text = "阅 读";
            }
            else if (item == "SettingListBoxItem")
            {
                myFrame.Navigate(typeof(SettingPage));
                AppTitle.Text = "关 于";
            }
            else if (item == "MovieListBoxItem")
            {
                myFrame.Navigate(typeof(MoviePage));
                AppTitle.Text = "电影";
            }
            else if (item == "MusicListBoxItem")
            {
                myFrame.Navigate(typeof(MusicPage));
                AppTitle.Text = "音乐";
            }
            else if (item == "SetDateListBoxItem")
            {
                AppTitle.Text = "选择日期";
                //await myFrame.Blur(duration: 10, delay: 0, value: 5).StartAsync();
                DatePickerFlyout datePickerFlyout = new DatePickerFlyout();
                datePickerFlyout.DayVisible = false;
                datePickerFlyout.MinYear = DateTimeOffset.Now.AddYears(-4);
                datePickerFlyout.MaxYear = DateTimeOffset.Now;
                datePickerFlyout.Placement = FlyoutPlacementMode.Full;
                await datePickerFlyout.ShowAtAsync(myFrame);
                datePickerFlyout.Closed += DatePickerFlyout_Closed;
                datePickerFlyout.DatePicked += DatePickerFlyout_DatePicked;
            }

          //  AppTitle.Text = myFrame.CurrentSourcePageType.ToString();

        }






        /// 手机端后台代码
        /// 手机端后台代码

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var lable = (sender as AppBarButton).Label;
            if (lable == "图片")
            {
                myFrame.Navigate(typeof(HomePage));
                AppTitle.Text = "One 一个";
            }
            else if (lable == "阅读")
            {
                myFrame.Navigate(typeof(ReadingPage));
                AppTitle.Text = "阅 读";
            }
            else if (lable == "音乐")
            {
                myFrame.Navigate(typeof(MusicPage));
                AppTitle.Text = "音 乐";
            }
            else if (lable == "电影")
            {
                myFrame.Navigate(typeof(MoviePage));
                AppTitle.Text = "电 影";
            }

            else if (lable == "日期")
            {
                AppTitle.Text = "选择日期";
                await myFrame.Blur(duration: 10, delay: 0, value: 5).StartAsync();
                DatePickerFlyout datePickerFlyout = new DatePickerFlyout();
                datePickerFlyout.MinYear = DateTimeOffset.Now.AddYears(-4);
                datePickerFlyout.MaxYear = DateTimeOffset.Now;
                await datePickerFlyout.ShowAtAsync(myFrame);
                datePickerFlyout.Closed += DatePickerFlyout_Closed;
                datePickerFlyout.DatePicked += DatePickerFlyout_DatePicked;
            }
            else if (lable == "设置")
            {
                myFrame.Navigate(typeof(SettingPage));
                AppTitle.Text = "设 置";
            }
            else if (lable == "分享")
            {
                Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
            }
            else { }
        }

        private void Grid_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            //if (mainPageViewModel.AppBarDisplayMode == AppBarClosedDisplayMode.Minimal)
            //{
            //    mainPageViewModel.AppBarDisplayMode = AppBarClosedDisplayMode.Compact;
            //}
            //else if (mainPageViewModel.AppBarDisplayMode == AppBarClosedDisplayMode.Compact)
            //{
            //    mainPageViewModel.AppBarDisplayMode = AppBarClosedDisplayMode.Minimal;
            //}
        }
    }

}
