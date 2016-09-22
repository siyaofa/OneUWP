using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace OneUWP.ViewModels
{
    public class SettingPageViewModel : ViewModelBase
    {
      

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

        private bool _dark_mode;
        public bool DarkMode
        {
            get
            {
                return _dark_mode;
            }
            set
            {
                _dark_mode = value;
                OnPropertyChanged();
            }
        }

        public void ExchangeDarkMode(bool dark)
        {
            DataShareManager.Current.UpdateAPPTheme(dark);
        }

        public SettingPageViewModel()
        {
            Update();
            DataShareManager.Current.ShareDataChanged += Current_ShareDataChanged;
        }
        public  void Update()
        {
            DarkMode = DataShareManager.Current.APPTheme ==ElementTheme.Dark ? true : false;
        }
        private void Current_ShareDataChanged()
        {
            DarkMode = DataShareManager.Current.APPTheme == ElementTheme.Dark ? true : false;
        }
    }
}
