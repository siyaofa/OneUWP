using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        // public WriteableBitmap writeableBitmap { get;set; }
        // public string author { get; set; }
        //  public string date { get; set; }
        //  public string content { get; set; }
        private ElementTheme _Theme = ElementTheme.Light;
        public ElementTheme Theme
        {
            get
            {
                return _Theme;
            }
            set
            {
                _Theme = value;
                OnPropertyChanged();
            }
        }

        private Visibility _progressRingVisibility;
        public Visibility ProgressRingVisibility
        {
            get
            {
                return _progressRingVisibility;
            }
            set
            {
                _progressRingVisibility = value;
                OnPropertyChanged();
            }
        }


        public void ChangeProgressRing(Visibility visibility)
        {
            DataShareManager.Current.UpdateProgressRingVisibility(visibility);
        }

        public HomePageViewModel()
        {
            Update();
            DataShareManager.Current.ShareDataChanged += Current_ShareDataChanged;
        }
        public void Update()
        {
            ProgressRingVisibility = DataShareManager.Current.ProgressRingVisibility;
        }
        private void Current_ShareDataChanged()
        {
            ProgressRingVisibility = DataShareManager.Current.ProgressRingVisibility;
        }



        private WriteableBitmap _writeableBitmap;
        public WriteableBitmap writeableBitmap
        {
            get
            {
                return _writeableBitmap;
            }
            set
            {
                _writeableBitmap = value;
                OnPropertyChanged();
            }
        }
        private string _author;
        public string author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private string _date;
        public string date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _content;
        public string content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }



    }
}
