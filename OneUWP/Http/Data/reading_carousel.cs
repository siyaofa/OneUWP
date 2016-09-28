using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class reading_carousel
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Datum[] data { get; set; }

        [DataContract]
        public class Datum
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string cover { get; set; }
            [DataMember]
            public string bottom_text { get; set; }
            [DataMember]
            public string bgcolor { get; set; }
            [DataMember]
            public string pv_url { get; set; }
        }
    }


}
