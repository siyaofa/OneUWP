using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http.Data
{
    [DataContract]
    public class serial_commentnum
    {
        [DataMember]
        public int res { get; set; }
        [DataMember]
        public Data data { get; set; }

        [DataContract]
        public class Data
        {
            [DataMember]
            public int praisenum { get; set; }
            [DataMember]
            public int sharenum { get; set; }
            [DataMember]
            public int commentnum { get; set; }
        }
    }



}
