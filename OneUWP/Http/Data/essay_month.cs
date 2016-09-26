using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// http://v3.wufazhuce.com:8000/api/essay/bymonth/2015-12-01%2000:00:00?
/// </summary>
namespace OneUWP.Http.Data
{
    [DataContract]
    public class essay_month
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Datum[] data { get; set; }

        [DataContract]
        public class Datum
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
    }



}
