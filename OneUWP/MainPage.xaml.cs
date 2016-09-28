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
using Windows.UI.Popups;
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
            this.DataContext = mainPageViewModel = new MainPageViewModel();
            //如果是手机的话就显示状态栏
            ShowStatusBar();
            //订阅后退
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            //订阅导航完成时事件
            myFrame.Navigated += myFrame_Navigated;
            DispatcherManager.Current.Dispatcher = Dispatcher;

        }

        public async void ShowStatusBar()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                var statusbar = StatusBar.GetForCurrentView();
                await statusbar.ShowAsync();
                if (mainPageViewModel.APPTheme == ElementTheme.Dark)
                    statusbar.BackgroundColor = Windows.UI.Colors.Black;
                else
                statusbar.BackgroundColor = Windows.UI.Colors.SkyBlue;
                statusbar.BackgroundOpacity = 1;
                statusbar.ForegroundColor = Windows.UI.Colors.White;

            }
        }

        private void myFrame_Navigated(object sender, NavigationEventArgs e)
        {
            // 每次完成导航 确定下是否显示系统后退按钮
            // ReSharper disable once PossibleNullReferenceException
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = myFrame.BackStack.Any() ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
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

            myFrame.Navigate(typeof(HomePage));

        }

        private void DatePickerFlyout_Closed(object sender, object e)
        {

        }

        private void DatePickerFlyout_DatePicked(DatePickerFlyout sender, DatePickedEventArgs args)
        {
            AppTitle.Text = "One 一个";
            var date = args.NewDate.DateTime.ToString("yyyy-MM");
            string currentFrame = myFrame.CurrentSourcePageType.ToString();
            if (currentFrame == "OneUWP.HomePage")
            {
                myFrame.Navigate(typeof(HomeMonthPage), date);
            }
            else if (currentFrame == "OneUWP.ReadingPage")
            {
                myFrame.Navigate(typeof(ReadingChoicePage), args.NewDate.DateTime);
            }
            else if (currentFrame == "OneUWP.SerialPage")
            {
                List<string> para = new List<string>();
                para.Add("连载");
                para.Add(date);
                DateTime serialDate = new DateTime(2016, 1, 1);
                if (args.NewDate.DateTime.CompareTo(serialDate) >= 0)
                    myFrame.Navigate(typeof(ReadingMonthPage), para);
            }
            else if (currentFrame == "OneUWP.EssayPage")
            {
                List<string> para = new List<string>();
                para.Add("短篇");
                para.Add(date);
                myFrame.Navigate(typeof(ReadingMonthPage), para);
            }
            else if (currentFrame == "OneUWP.QuestionPage")
            {
                List<string> para = new List<string>();
                para.Add("问题");
                para.Add(date);
                myFrame.Navigate(typeof(ReadingMonthPage), para);
            }


        }


        /// 电脑端后台代码
        /// 电脑端后台代码
        /// 电脑端后台代码
        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (e.ClickedItem as StackPanel).Name;
            if (item == "HamburgerButton")
            {
                mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            }
            else if (item == "Home")
            {
                myFrame.Navigate(typeof(HomePage));
                AppTitle.Text = "One 一个";
            }
            else if (item == "Reading")
            {
                myFrame.Navigate(typeof(ReadingPage));
                AppTitle.Text = "阅 读";
            }
            else if (item == "Setting")
            {
                myFrame.Navigate(typeof(SettingPage));
                AppTitle.Text = "关 于";
            }
            else if (item == "Movie")
            {
                myFrame.Navigate(typeof(MoviePage));
                AppTitle.Text = "电影";
            }
            else if (item == "Music")
            {
                myFrame.Navigate(typeof(MusicPage));
                AppTitle.Text = "音乐";
            }
            else if (item == "SetDate")
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

        }


    }

}
