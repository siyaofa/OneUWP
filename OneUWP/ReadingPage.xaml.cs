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
        public ReadingPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Http.Data.reading_idlist _reading_idlist = await APIService.Get_reading_idlist();
            for (int i = 0; i < _reading_idlist.data.essay.Count() - 1; i++)
            {
                // var _question = new ReadingPageModel.question { question_title = _reading_idlist.data.question[i].question_title };

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

            InfoTextBlock.Text = (e.ClickedItem as Grid).Name + "      " + (sender as ListView).Tag.ToString();
        }
    }
}
