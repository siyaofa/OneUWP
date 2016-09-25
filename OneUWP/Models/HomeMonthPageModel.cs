using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Models
{
   public class HomeMonthPageModel
    {
        public WriteableBitmap wb { set; get; }
        public string date { set; get; }
        public string hpId { set; get; }
    }
}
