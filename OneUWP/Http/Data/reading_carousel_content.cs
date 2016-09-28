using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class reading_carousel_content
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Datum[] data { get; set; }

        [DataContract]
        public class Datum
        {
            [DataMember]
            public string item_id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string introduction { get; set; }
            [DataMember]
            public string author { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public int number { get; set; }
            [DataMember]
            public string type { get; set; }
        }

    }


}
