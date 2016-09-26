using System;
using System.Collections.Generic;
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
    public sealed partial class ReadingChoicePage : Page
    {
        public List<string> para;
        public DateTime date;
        public ReadingChoicePage()
        {
            this.InitializeComponent();
            para = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var type = (sender as Button).Content.ToString();
            para.Add(type);
            para.Add(date.ToString("yyyy-MM"));
            Frame.Navigate(typeof(ReadingMonthPage), para);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            date = (DateTime)e.Parameter;
            DateTime serialDate = new DateTime(2016, 1, 1);
            if (date.CompareTo(serialDate) >= 0)
                serialButton.Visibility = Visibility.Visible;
        }
    }
}
