using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Models
{
    public class ReadingPageCarouselModel
    {
        public WriteableBitmap cover { set; get; }
        public string pvId { set; get; }
    }
}
