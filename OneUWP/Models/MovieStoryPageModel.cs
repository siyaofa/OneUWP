using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Models
{
   public class MovieStoryPageModel
    {
        public string userName { get; set; }
        public string content { get; set; }
        public string title { get; set; }
        public string makeTime { get; set; }
        public string praiseNum { get; set; }
        public WriteableBitmap userImage { get; set; }
    }
}
