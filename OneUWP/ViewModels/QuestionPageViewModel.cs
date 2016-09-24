using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace OneUWP.ViewModels
{
    public class QuestionPageViewModel : ViewModelBase
    {


       

        private string _questionTitle;
        public string questionTitle
        {
            get
            {
                return _questionTitle;
            }
            set
            {
                _questionTitle = value;
                OnPropertyChanged();
            }
        }


        private string _answerTitle;
        public string answerTitle
        {
            get
            {
                return _answerTitle;
            }
            set
            {
                _answerTitle = value;
                OnPropertyChanged();
            }
        }

        private string _answerContent;
        public string answerContent
        {
            get
            {
                return _answerContent;
            }
            set
            {
                _answerContent = value;
                OnPropertyChanged();
            }
        }

        private string _questionMakettime;
        public string questionMakettime
        {
            get
            {
                return _questionMakettime;
            }
            set
            {
                _questionMakettime = value;
                OnPropertyChanged();
            }
        }

        private string _questionContent;
        public string questionContent
        {
            get
            {
                return _questionContent;
            }
            set
            {
                _questionContent = value;
                OnPropertyChanged();
            }
        }



    }
}
