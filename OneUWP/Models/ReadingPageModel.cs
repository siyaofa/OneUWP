using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Models
{
    public class ReadingPageModel
    {
        public string essay { set; get; }
        public string essayId { set; get; }
        public string serial { set; get; }
        public string serialId { set; get; }
        public string question { set; get; }
        public string questionId { set; get; }
        public string date { set; get; }
    }
}
