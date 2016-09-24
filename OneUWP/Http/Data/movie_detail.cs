using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class movie_detail
    {
       [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }

        [DataContract]
        public class Data
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string indexcover { get; set; }
            [DataMember]
            public string detailcover { get; set; }
            [DataMember]
            public string video { get; set; }
            [DataMember]
            public string verse { get; set; }
            [DataMember]
            public string verse_en { get; set; }
            [DataMember]
            public object score { get; set; }
            [DataMember]
            public string revisedscore { get; set; }
            [DataMember]
            public string review { get; set; }
            [DataMember]
            public string keywords { get; set; }
            [DataMember]
            public string movie_id { get; set; }
            [DataMember]
            public string info { get; set; }
            [DataMember]
            public string officialstory { get; set; }
            [DataMember]
            public string charge_edt { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public int praisenum { get; set; }
            [DataMember]
            public string sort { get; set; }
            [DataMember]
            public string releasetime { get; set; }
            [DataMember]
            public string scoretime { get; set; }
            [DataMember]
            public string maketime { get; set; }
            [DataMember]
            public string last_update_date { get; set; }
            [DataMember]
            public string read_num { get; set; }
            [DataMember]
            public string[] photo { get; set; }
            [DataMember]
            public int sharenum { get; set; }
            [DataMember]
            public int commentnum { get; set; }
            [DataMember]
            public int servertime { get; set; }
        }

    }


}
