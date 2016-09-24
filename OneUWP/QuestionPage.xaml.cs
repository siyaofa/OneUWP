using OneUWP.Http;
using OneUWP.Model;
using OneUWP.ViewModels;
using System;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        public double x;
        public QuestionPageViewModel questionPageViewModel;
        public string questionId;

        public QuestionPage()
        {
            this.InitializeComponent();
            this.DataContext = questionPageViewModel = new QuestionPageViewModel();
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
                PageFresh();
            }
            else if (x < -xR)
            {
                App.currentDate = App.currentDate.AddDays(-1);
                PageFresh();
            }
            x = 0;
        }

        private  void Page_Loaded(object sender, RoutedEventArgs e)
        {

            PageFresh();
        }

        private void ContentShare()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }

        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest request = args.Request;
            request.Data.SetText("Hello world!");
            request.Data.Properties.Title = "Share Example";
            request.Data.Properties.Description = "A demonstration on how to share";
        }

        private async void PageFresh()
        {
            InfoTextBlock.Visibility = Visibility.Visible;
            InfoTextBlock.Text = "请稍等";
            var question_detail = await APIService.Get_question_detail(questionId);
            if (question_detail != null)
            {
                questionPageViewModel.questionTitle = question_detail.data.question_title;
                questionPageViewModel.questionContent = question_detail.data.question_content;
                questionPageViewModel.questionMakettime = question_detail.data.question_makettime;
                questionPageViewModel.answerTitle = question_detail.data.answer_title;
                questionPageViewModel.answerContent = Regex.Replace(question_detail.data.answer_content, "<br>", "");
                InfoTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                InfoTextBlock.Visibility = Visibility.Visible;
                InfoTextBlock.Text = App.currentDate.ToString("yyyy-MM-dd") + " 暂无内容";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           questionId = (string)e.Parameter;
        }
    }


}
