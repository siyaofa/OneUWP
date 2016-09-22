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
        public string[] data { get; set; }
    }

}
