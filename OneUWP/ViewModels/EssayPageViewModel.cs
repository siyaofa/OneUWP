using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.ViewModels
{
    public class EssayPageViewModel : ViewModelBase
    {

        private string _hp_title;
        public string hp_title
        {
            get
            {
                return _hp_title;
            }
            set
            {
                _hp_title = value;
                OnPropertyChanged();
            }
        }

        private string _hp_author;
        public string hp_author
        {
            get
            {
                return _hp_author;
            }
            set
            {
                _hp_author = value;
                OnPropertyChanged();
            }
        }

        private string _hp_content;
        public string hp_content
        {
            get
            {
                return _hp_content;
            }
            set
            {
                _hp_content = value;
                OnPropertyChanged();
            }
        }

        private string _hp_makettime;
        public string hp_makettime
        {
            get
            {
                return _hp_makettime;
            }
            set
            {
                _hp_makettime = value;
                OnPropertyChanged();
            }
        }

        private string _guide_word;
        public string guide_word
        {
            get
            {
                return _guide_word;
            }
            set
            {
                _guide_word = value;
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

    }
}
