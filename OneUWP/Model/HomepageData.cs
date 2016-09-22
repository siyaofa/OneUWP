using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OneUWP.Model
{
    public class HomepageData : INotifyPropertyChanged
    {
        // public WriteableBitmap writeableBitmap { get;set; }
        // public string author { get; set; }
        //  public string date { get; set; }
        //  public string content { get; set; }

    

        private WriteableBitmap _writeableBitmap;
        public WriteableBitmap writeableBitmap
        {
            get { return _writeableBitmap; }
            set
            {
                if (value != _writeableBitmap)
                {
                    _writeableBitmap = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _author;
        public string author
        {
            get { return _author; }
            set
            {
                if (value != _author)
                {
                    _author = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string _date;
        public string date
        {
            get { return _date; }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _content;
        public string content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    _content = value;
                    NotifyPropertyChanged();
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
