using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class movie_story
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }
        [DataContract]
        public class Data
        {
            [DataMember]
            public int count { get; set; }
            [DataMember]
            public Datum[] data { get; set; }
        }
        [DataContract]
        public class Datum
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string movie_id { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string content { get; set; }
            [DataMember]
            public string user_id { get; set; }
            [DataMember]
            public string sort { get; set; }
            [DataMember]
            public int praisenum { get; set; }
            [DataMember]
            public string input_date { get; set; }
            [DataMember]
            public string story_type { get; set; }
            [DataMember]
            public User user { get; set; }
        }
        [DataContract]
        public class User
        {
            [DataMember]
            public string user_id { get; set; }
            [DataMember]
            public string user_name { get; set; }
            [DataMember]
            public string web_url { get; set; }
        }
    }
}
