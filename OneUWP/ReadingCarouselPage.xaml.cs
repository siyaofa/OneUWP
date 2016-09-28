using OneUWP.Http;
using OneUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadingCarouselPage : Page
    {
        public ObservableCollection<ReadingCarouselPageModel> readingCarouselPageData = new ObservableCollection<ReadingCarouselPageModel>();

        public ReadingCarouselPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (string)e.Parameter;
            FreshPage(id);
        }

        private async void FreshPage(string id)
        {
            var _reading_carousel_content = await APIService.Get_reading_carousel_content(id);
            for(int i=0; i < _reading_carousel_content.data.Count(); i++)
            {
                readingCarouselPageData.Add(new ReadingCarouselPageModel
                {
                    number =(i+1).ToString(),
                    title = _reading_carousel_content.data[i].title,
                    author = _reading_carousel_content.data[i].author,
                    introduction = _reading_carousel_content.data[i].introduction
                });
            }
        }
    }
}
