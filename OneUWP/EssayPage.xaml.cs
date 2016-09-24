using OneUWP.Http;
using OneUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class EssayPage : Page
    {
        public EssayPageViewModel essayPageViewModel = new EssayPageViewModel();
        public string essayId;
        public EssayPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var _essay_detail = await APIService.Get_essay_detail(essayId);
            if (_essay_detail != null)
            {
                essayPageViewModel.hp_title = _essay_detail.data.hp_title;
                essayPageViewModel.hp_author = _essay_detail.data.hp_author;
                essayPageViewModel.hp_makettime = _essay_detail.data.hp_makettime;
                essayPageViewModel.hp_content = Regex.Replace(_essay_detail.data.hp_content, "<br>", Environment.NewLine);
                essayPageViewModel.guide_word = _essay_detail.data.guide_word;
                essayPageViewModel.audio = _essay_detail.data.audio;
            }

            musicPlayer.Source = new Uri(essayPageViewModel.audio);

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            essayId = (string)e.Parameter;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Name == "stop")
            {
                musicPlayer.Stop();
            }
            else if ((sender as Button).Name == "play")
            {
                musicPlayer.Play();
            }
            else
            {
                musicPlayer.Pause();
            }
        }


    }
}
