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
    public sealed partial class ReadingMonthPage : Page
    {
        public ObservableCollection<ReadingMonthPageModel> readingMonthPageData = new ObservableCollection<ReadingMonthPageModel>();
        public ReadingMonthPage()
        {
            this.InitializeComponent();

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<string> para = (List<string>)e.Parameter;
            FreshPage(para[0], para[1]);
        }

        private async void FreshPage(string mytype, string date)
        {
            if (mytype == "问题")
            {
                var _question_month = await APIService.Get_question_month(date);
                for (int i = 0; i < _question_month.data.Count(); i++)
                {
                    readingMonthPageData.Add(new ReadingMonthPageModel
                    {
                        title = _question_month.data[i].question_title,
                        who = _question_month.data[i].answer_title,
                        content = _question_month.data[i].answer_content,
                        type = mytype,
                        id = _question_month.data[i].question_id
                    });
                }
            }
            else if (mytype == "连载")
            {
                var _serial_month = await APIService.Get_serial_month(date);
                for (int i = 0; i < _serial_month.data.Count(); i++)
                {
                    readingMonthPageData.Add(
                        new ReadingMonthPageModel
                        {
                            title = _serial_month.data[i].title,
                            who = _serial_month.data[i].author.user_name,
                            content = _serial_month.data[i].excerpt,
                            type = mytype,
                            id = _serial_month.data[i].serial_id
                        });
                }
            }
            else if (mytype == "短篇")
            {
                var _essay_month = await APIService.Get_essay_month(date);
                for(int i = 0; i < _essay_month.data.Count(); i++)
                {
                    readingMonthPageData.Add(new ReadingMonthPageModel
                    {
                        title = _essay_month.data[i].hp_title,
                        who = _essay_month.data[i].author[0].user_name,
                        content = _essay_month.data[i].guide_word,
                        type = mytype,
                        id = _essay_month.data[i].content_id
                    });
                }

            }



        }
    }
}
