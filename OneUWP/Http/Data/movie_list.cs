using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class movie_list
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
            public string title { get; set; }
            [DataMember]
            public string verse { get; set; }
            [DataMember]
            public string verse_en { get; set; }
            [DataMember]
            public string score { get; set; }
            [DataMember]
            public string revisedscore { get; set; }
            [DataMember]
            public string releasetime { get; set; }
            [DataMember]
            public string scoretime { get; set; }
            [DataMember]
            public string cover { get; set; }
            [DataMember]
            public int servertime { get; set; }
        }
    }

   

}
