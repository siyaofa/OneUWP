using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.ViewModels
{
    public class MovieDetailPageViewModel : ViewModelBase
    {
        private string _title;
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }


        private string _video;
        public string video
        {
            get
            {
                return _video;
            }
            set
            {
                _video = value;
                OnPropertyChanged();
            }
        }

        private string _keywords;
        public string keywords
        {
            get
            {
                return _keywords;
            }
            set
            {
                _keywords = value;
                OnPropertyChanged();
            }
        }
        private string _info;
        public string info
        {
            get
            {
                return _info;
            }
            set
            {
                _info = value;
                OnPropertyChanged();
            }
        }
        private WriteableBitmap _detailcover;
        public WriteableBitmap detailcover
        {
            get
            {
                return _detailcover;
            }
            set
            {
                _detailcover = value;
                OnPropertyChanged();
            }
        }
        private WriteableBitmap _indexcover;
        public WriteableBitmap indexcover
        {
            get
            {
                return _indexcover;
            }
            set
            {
                _indexcover = value;
                OnPropertyChanged();
            }
        }
        

    }
}
