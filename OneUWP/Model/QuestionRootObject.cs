using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Model
{

    [DataContract]
    public class QuestionRootObject
    {
        [DataMember]
        public QuestionData data { get; set; }
    }
    [DataContract]
    public class QuestionData
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

        //[DataMember]
        //public int ipraisenum { get; set; }

        //[DataMember]
        //public int sharenum { get; set; }

        //[DataMember]
        //public int commentnum { get; set; }

    }
}


//public class Rootobject
//{
//    public int res { get; set; }
//    public Data data { get; set; }
//}

//public class Data
//{
//    public string question_id { get; set; }
//    public string question_title { get; set; }
//    public string question_content { get; set; }
//    public string answer_title { get; set; }
//    public string answer_content { get; set; }
//    public string question_makettime { get; set; }
//    public string recommend_flag { get; set; }
//    public string charge_edt { get; set; }
//    public string last_update_date { get; set; }
//    public string web_url { get; set; }
//    public string read_num { get; set; }
//    public object guide_word { get; set; }
//    public int praisenum { get; set; }
//    public int sharenum { get; set; }
//    public int commentnum { get; set; }
//}
