﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Models
{
    public class MoviePageModel
    {
        public WriteableBitmap wb { get; set; }
        public string id { get; set; }
        public string score { get; set; }
    }
}
