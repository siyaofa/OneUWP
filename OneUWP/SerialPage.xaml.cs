using OneUWP.Http;
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
    public sealed partial class SerialPage : Page
    {
        public SerialPageViewModel serialPageViewModel = new SerialPageViewModel();
        public string serialId;
        public SerialPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PageFresh();
        }

        private async void PageFresh()
        {

            var _serial_detail = await APIService.Get_serial_detail(serialId);
            if (_serial_detail != null)
            {
                serialPageViewModel.audio = _serial_detail.data.audio;
                serialPageViewModel.content = System.Text.RegularExpressions.Regex.Replace(_serial_detail.data.content, "<br>", "");
                serialPageViewModel.excerpt = _serial_detail.data.excerpt;
                serialPageViewModel.maketime = _serial_detail.data.maketime;
                serialPageViewModel.number = _serial_detail.data.number;
                serialPageViewModel.title = _serial_detail.data.title;
                serialPageViewModel.user_name = _serial_detail.data.author.user_name;
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            serialId = (string)e.Parameter;
        }
    }
}
