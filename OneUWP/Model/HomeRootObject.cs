using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Model
{
    [DataContract]
    public class HomeRootObject
    {
        [DataMember]
        public HomeData data { get; set; }

        [DataMember]
        public WriteableBitmap writeableBitmap { get; set; }

        [DataContract]
        public class HomeData
        {
            [DataMember]
            public string hpcontent_id { get; set; }

            [DataMember]
            public string hp_title { get; set; }
            [DataMember]
            public string hp_img_url { get; set; }
            [DataMember]
            public string hp_author { get; set; }
            [DataMember]
            public string hp_makettime { get; set; }
            [DataMember]
            public string hp_content { get; set; }
        }
    }


}
