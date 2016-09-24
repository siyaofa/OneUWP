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
        private WriteableBitmap _cover;
        public WriteableBitmap cover
        {
            get
            {
                return _cover;
            }
            set
            {
                _cover = value;
                OnPropertyChanged();
            }
        }
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
        private string _author_user_name;
        public string author_user_name
        {
            get
            {
                return _author_user_name;
            }
            set
            {
                _author_user_name = value;
                OnPropertyChanged();
            }
        }

        private WriteableBitmap _author_web_url;
        public WriteableBitmap author_web_url
        {
            get
            {
                return _author_web_url;
            }
            set
            {
                _author_web_url = value;
                OnPropertyChanged();
            }
        }

        private string _author_desc;
        public string author_desc
        {
            get
            {
                return _author_desc;
            }
            set
            {
                _author_desc = value;
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
        private string _story;
        public string story
        {
            get
            {
                return _story;
            }
            set
            {
                _story= value;
                OnPropertyChanged();
            }
        }

        private string _story_title;
        public string story_title
        {
            get
            {
                return _story_title;
            }
            set
            {
                _story_title = value;
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

        private string _charge_edt;
        public string charge_edt
        {
            get
            {
                return _charge_edt;
            }
            set
            {
                _charge_edt = value;
                OnPropertyChanged();
            }
        }


        

        private string _praisenum;
        public string praisenum
        {
            get
            {
                return _praisenum;
            }
            set
            {
                _praisenum = value;
                OnPropertyChanged();
            }
        }
        private string _maketime;
        public string maketime
        {
            get
            {
                return _maketime;
            }
            set
            {
                _maketime = value;
                OnPropertyChanged();
            }
        }
        private string _sharenum;
        public string sharenum
        {
            get
            {
                return _sharenum;
            }
            set
            {
                _sharenum = value;
                OnPropertyChanged();
            }
        }
        private string _commentnum;
        public string commentnum
        {
            get
            {
                return _commentnum;
            }
            set
            {
                _commentnum = value;
                OnPropertyChanged();
            }
        }
        private string _story_author;
        public string story_author
        {
            get
            {
                return _story_author;
            }
            set
            {
                _story_author = value;
                OnPropertyChanged();
            }
        }




        

   



    }
}
