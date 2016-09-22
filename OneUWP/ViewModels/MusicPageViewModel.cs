using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.ViewModels
{
  public  class MusicPageViewModel : ViewModelBase
    {
        private WriteableBitmap _wb;
        public WriteableBitmap wb
        {
            get
            {
                return _wb;
            }
            set
            {
                _wb = value;
                OnPropertyChanged();
            }
        }
        private string _lyric;
        public string lyric
        {
            get
            {
                return _lyric;
            }
            set
            {
                _lyric = value;
                OnPropertyChanged();
            }
        }



     
    }
}
