using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class reading_idlist
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }



        [DataContract]
        public class Data
        {
            [DataMember]
            public Essay[] essay { get; set; }
            [DataMember]
            public Serial[] serial { get; set; }
            [DataMember]
            public Question[] question { get; set; }
        }
        [DataContract]
        public class Essay
        {
            [DataMember]
            public string content_id { get; set; }
            [DataMember]
            public string hp_title { get; set; }
            [DataMember]
            public string hp_makettime { get; set; }
            [DataMember]
            public string guide_word { get; set; }
            [DataMember]
            public Author[] author { get; set; }
            [DataMember]
            public bool has_audio { get; set; }
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
        [DataContract]
        public class Serial
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
            public string read_num { get; set; }
            [DataMember]
            public string maketime { get; set; }
            [DataMember]
            public Author1 author { get; set; }
            [DataMember]
            public bool has_audio { get; set; }
        }
        [DataContract]
        public class Author1
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string web_url { get; set; }
            public string desc { get; set; }
        }
        [DataContract]
        public class Question
        {
            [DataMember]
            public string question_id { get; set; }
            [DataMember]
            public string question_title { get; set; }
            [DataMember]
            public string answer_title { get; set; }
            [DataMember]
            public string answer_content { get; set; }
            [DataMember]
            public string question_makettime { get; set; }
        }
    }

}


