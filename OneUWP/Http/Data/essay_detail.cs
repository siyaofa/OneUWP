using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class essay_detail
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }


        [DataContract]
        public class Data
        {
            [DataMember]
            public string content_id { get; set; }
            [DataMember]
            public string hp_title { get; set; }
            [DataMember]
            public string sub_title { get; set; }
            [DataMember]
            public string hp_author { get; set; }
            [DataMember]
            public string auth_it { get; set; }
            [DataMember]
            public string hp_author_introduce { get; set; }
            [DataMember]
            public string hp_content { get; set; }
            [DataMember]
            public string hp_makettime { get; set; }
            [DataMember]
            public string wb_name { get; set; }
            [DataMember]
            public string wb_img_url { get; set; }
            [DataMember]
            public string last_update_date { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public string guide_word { get; set; }
            [DataMember]
            public string audio { get; set; }
            [DataMember]
            public Author[] author { get; set; }
            [DataMember]
            public int praisenum { get; set; }
            [DataMember]
            public int sharenum { get; set; }
            [DataMember]
            public int commentnum { get; set; }
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
            [DataMember]
            public string wb_name { get; set; }
        }
    }

   

}
