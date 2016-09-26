using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// http://v3.wufazhuce.com:8000/api/question/bymonth/2015-08-01%2000:00:00?
/// </summary>
namespace OneUWP.Http.Data
{
    [DataContract]
    public class question_month
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Datum[] data { get; set; }

        [DataContract]
        public class Datum
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
