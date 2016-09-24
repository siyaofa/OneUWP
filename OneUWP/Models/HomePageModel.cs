using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Models
{
  public  class HomePageModel
    {
        public WriteableBitmap writeableBitmap { get; set; }
        public string author { get; set; }
        public string date { get; set; }
        public string content { get; set; }
    }
}
