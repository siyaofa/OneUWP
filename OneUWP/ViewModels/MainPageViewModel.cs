using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OneUWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ElementTheme _APPTheme = ElementTheme.Light;
        public ElementTheme APPTheme
        {
            get
            {
                return _APPTheme;
            }
            set
            {
                _APPTheme = value;
                OnPropertyChanged();
            }
        }

        private Visibility _progressRingVisibility=Visibility.Collapsed;
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

        private bool _is_loading;
        public bool IsLoading
        {
            get
            {
                return _is_loading;
            }
            set
            {
                _is_loading = value;
                OnPropertyChanged();
            }
        }

        private AppBarClosedDisplayMode _AppBarDisplayMode;
        public AppBarClosedDisplayMode AppBarDisplayMode
        {
            get
            {
                return _AppBarDisplayMode;
            }
            set
            {
                _AppBarDisplayMode = value;
                OnPropertyChanged();
            }
        }



        public MainPageViewModel()
        {
            Update();
            DataShareManager.Current.ShareDataChanged += Current_ShareDataChanged;
        }
        private void Current_ShareDataChanged()
        {
            APPTheme = DataShareManager.Current.APPTheme;
            ProgressRingVisibility = DataShareManager.Current.ProgressRingVisibility;
        }

        public void Update()
        {
            APPTheme = DataShareManager.Current.APPTheme;
            ProgressRingVisibility = DataShareManager.Current.ProgressRingVisibility;
        }


    }
}
