using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{


    [DataContract]
    public class serial_detail
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
            public string serial_id { get; set; }
            [DataMember]
            public string number { get; set; }
            [DataMember]
            public string title { get; set; }
            [DataMember]
            public string excerpt { get; set; }
            [DataMember]
            public string content { get; set; }
            [DataMember]
            public string charge_edt { get; set; }
            [DataMember]
            public string read_num { get; set; }
            [DataMember]
            public string maketime { get; set; }
            [DataMember]
            public string last_update_date { get; set; }
            [DataMember]
            public string audio { get; set; }
            [DataMember]
            public string web_url { get; set; }
            [DataMember]
            public string input_name { get; set; }
            [DataMember]
            public string last_update_name { get; set; }
            [DataMember]
            public Author author { get; set; }
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
        }
    }



}
