
using OneUWP.ViewModels;
using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using OneUWP.Tools;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///通过vol期号把所有的日期得到，并本地缓存，这样的对照表应该不大。然后反向通过日期得到序列号
    ///服务器的那帮孙子太恶心了

    public sealed partial class SettingPage : Page
    {
        public SettingPageViewModel settingPageViewModel;

        public SettingPage()
        {
            this.InitializeComponent();
            this.DataContext = settingPageViewModel = new SettingPageViewModel();
        }

        private void NightModelToggleButton_Toggled(object sender, RoutedEventArgs e)
        {
            settingPageViewModel.ExchangeDarkMode((sender as ToggleSwitch).IsOn);
            BackgroundTaskAction.ShowToastNotification("OneUWPlogo.png", "夜间模式已经更改");
        }

        private async void SendEmailTo(object sender, TappedRoutedEventArgs e)
        {
            //https://msdn.microsoft.com/windows/uwp/launch-resume/launch-default-app#call-app-uri-scheme
            string address = (sender as TextBlock).Text;
            string subject = "";
            string body = "";
            if (address == null)
                return;
            var mailto = new Uri($"mailto:{address}?subject={subject}&body={body}");
            var success = await Launcher.LaunchUriAsync(mailto);
            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }



        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
          

        }
    }
}
