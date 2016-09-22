using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class music_related
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
            public string platform { get; set; }
            [DataMember]
            public string music_id { get; set; }
            [DataMember]
            public Author author { get; set; }
        }
        [DataContract]
        public class Author
        {
            [DataMember]
            public string user_id { get; set; }
            [DataMember]
            public string user_name { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public string desc { get; set; }
        }

    }


}
