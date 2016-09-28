using OneUWP.Http;
using OneUWP.Http.Data;
using OneUWP.Models;
using OneUWP.Tools;
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
    public sealed partial class HomeMonthPage : Page
    {
        public ObservableCollection<HomeMonthPageModel> homeMonthPageData = new ObservableCollection<HomeMonthPageModel>();
        public HomeMonthPage()
        {
            this.InitializeComponent();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            HomeMonthPageModel item = (HomeMonthPageModel)e.ClickedItem;
            Frame.Navigate(typeof(HomePage), item.hpId);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string hpDate = (string)e.Parameter;
            FreshPage(hpDate);
        }

        private async void FreshPage(string hpDate)
        {
            hp_month _hp_month = await APIService.Get_hp_month(hpDate);
            for (int i = 0; i < _hp_month.data.Count(); i++)
            {
                homeMonthPageData.Add(new HomeMonthPageModel
                {
                    wb = await ImageOperation.GetImage(_hp_month.data[i].hp_img_url),
                    hpId = _hp_month.data[i].hpcontent_id,
                    date = _hp_month.data[i].hp_makettime
                });
            }
        }
    }
}
