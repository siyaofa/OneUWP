using OneUWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Xml.Dom;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Input;
using OneUWP.ViewModels;
using System.Threading.Tasks;
using OneUWP.Http;
using OneUWP.Models;
using System.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        //  public HomepageData homepageData = new HomepageData();
        public double x;
        public HomePageViewModel homePageViewModel;
        public ObservableCollection<HomePageModel> homePageData = new ObservableCollection<HomePageModel>();
        public static Http.Data.hp_idlist hpIDList;
        public string hpId;
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = homePageViewModel = new HomePageViewModel();

        }

        public async void PageFresh()
        {
            hpIDList = await Http.APIService.Get_hp_idlist();
            for (int i = 0; i < hpIDList.data.Count() - 1; i++)
            {
                var hp_detail = await APIService.Get_hp_detail(hpIDList.data[i]);
                homePageData.Add(
                    new HomePageModel
                    {
                        writeableBitmap = await ImageOperation.GetImage(hp_detail.data.hp_img_url),
                        author = hp_detail.data.hp_author,
                        date = hp_detail.data.hp_makettime,
                        content = hp_detail.data.hp_content
                    }
                    );
            }

        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            string hpId = (string)e.Parameter;
            if (!string.IsNullOrEmpty(hpId))
            {
                homePageData.Clear();
                var hp_detail = await APIService.Get_hp_detail(hpId);
                homePageData.Add(
                    new HomePageModel
                    {
                        writeableBitmap = await ImageOperation.GetImage(hp_detail.data.hp_img_url),
                        author = hp_detail.data.hp_author,
                        date = hp_detail.data.hp_makettime,
                        content = hp_detail.data.hp_content
                    }
                    );
            }
            else
            {
                PageFresh();
            }

        }


    }
}
