using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///按月份选择连载（2016年开始有连载）http://v3.wufazhuce.com:8000/api/serialcontent/bymonth/2016-02-01%2000:00:00?
/// </summary>
namespace OneUWP.Http.Data
{
    [DataContract]
    public class serial_month
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
            public Author author { get; set; }
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
        }
    }



}
