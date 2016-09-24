using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.ViewModels
{
    public class SerialPageViewModel : ViewModelBase
    {

        private string _number;
        public string number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
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
        private string _excerpt;
        public string excerpt
        {
            get
            {
                return _excerpt;
            }
            set
            {
                _excerpt = value;
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


        private string _audio;
        public string audio
        {
            get
            {
                return _audio;
            }
            set
            {
                _audio = value;
                OnPropertyChanged();
            }
        }

        private string _user_name;
        public string user_name
        {
            get
            {
                return _user_name;
            }
            set
            {
                _user_name = value;
                OnPropertyChanged();
            }
        }


    }
}
