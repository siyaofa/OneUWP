using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class hp_month
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Datum[] data { get; set; }
    }
    [DataContract]
    public class Datum
    {
        [DataMember]
        public string hpcontent_id { get; set; }
        [DataMember]
        public string hp_title { get; set; }
        [DataMember]
        public string author_id { get; set; }
        [DataMember]
        public string hp_img_url { get; set; }
        [DataMember]
        public string hp_img_original_url { get; set; }
        [DataMember]
        public string hp_author { get; set; }
        [DataMember]
        public string ipad_url { get; set; }
        [DataMember]
        public string hp_content { get; set; }
        [DataMember]
        public string hp_makettime { get; set; }
        [DataMember]
        public string last_update_date { get; set; }
        [DataMember]
        public string web_url { get; set; }
        [DataMember]
        public string wb_img_url { get; set; }
        [DataMember]
        public int praisenum { get; set; }
        [DataMember]
        public int sharenum { get; set; }
        [DataMember]
        public int commentnum { get; set; }
    }
}


