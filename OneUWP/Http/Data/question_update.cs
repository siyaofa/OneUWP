using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class question_update
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }

        [DataContract]
        public class Data
        {
            [DataMember]
            public string question_id { get; set; }
            [DataMember]
            public string question_title { get; set; }
            [DataMember]
            public string question_content { get; set; }
            [DataMember]
            public string answer_title { get; set; }
            [DataMember]
            public string answer_content { get; set; }
            [DataMember]
            public string question_makettime { get; set; }
            [DataMember]
            public string recommend_flag { get; set; }
            [DataMember]
            public string charge_edt { get; set; }
            [DataMember]
            public string last_update_date { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public string read_num { get; set; }
            [DataMember]
            public string guide_word { get; set; }
            [DataMember]
            public int praisenum { get; set; }
            [DataMember]
            public int sharenum { get; set; }
            [DataMember]
            public int commentnum { get; set; }
        }
    }

  

}
