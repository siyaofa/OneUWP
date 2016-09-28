using OneUWP.Http;
using OneUWP.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ObservableCollection<ReadingPageModel> readingPageData = new ObservableCollection<ReadingPageModel>();
        public ObservableCollection<ReadingPageCarouselModel> readingPageCarouselData = new ObservableCollection<ReadingPageCarouselModel>();
        public ReadingPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Http.Data.reading_idlist _reading_idlist = await APIService.Get_reading_idlist();
            for (int i = 0; i < _reading_idlist.data.essay.Count(); i++)
            {
                readingPageData.Add(
                    new ReadingPageModel
                    {
                        essay = _reading_idlist.data.essay[i].guide_word,
                        essayId = _reading_idlist.data.essay[i].content_id,
                        serial = _reading_idlist.data.serial[i].title,
                        serialId = _reading_idlist.data.serial[i].id,
                        question = _reading_idlist.data.question[i].question_title,
                        questionId = _reading_idlist.data.question[i].question_id,
                        date = _reading_idlist.data.essay[i].hp_makettime
                    }
                );
            }


            Http.Data.reading_carousel _reading_carousel = await APIService.Get_reading_carousel();
            InfoTextBlock.Text = _reading_carousel.data.Count().ToString();
            for (int i = 0; i < _reading_carousel.data.Count(); i++)
            {
                readingPageCarouselData.Add(
                    new ReadingPageCarouselModel
                    {
                        cover = await Tools.ImageOperation.GetImage(_reading_carousel.data[i].cover),
                        pvId = _reading_carousel.data[i].id
                    });
            }



        }

        private void SmallListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //InfoTextBlock.Text = (e.ClickedItem as Grid).Name;
            // InfoTextBlock.Text = sender.GetType().ToString();
            //string type;
            // if((e.ClickedItem as Grid).Name=="essayGrid")
            switch ((e.ClickedItem as Grid).Name)
            {
                case "essayGrid":
                    Frame.Navigate(typeof(EssayPage), (e.ClickedItem as Grid).Tag);
                    break;
                case "serialGrid":
                    Frame.Navigate(typeof(SerialPage), (e.ClickedItem as Grid).Tag);
                    break;
                case "questionGrid":
                    Frame.Navigate(typeof(QuestionPage), (e.ClickedItem as Grid).Tag);
                    break;
            }

          //  InfoTextBlock.Text = (e.ClickedItem as Grid).Name + "      " + (sender as ListView).Tag.ToString();
        }


        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var item = (sender as Image);
            Frame.Navigate(typeof(ReadingCarouselPage), item.Tag.ToString());
        }
    }
}
