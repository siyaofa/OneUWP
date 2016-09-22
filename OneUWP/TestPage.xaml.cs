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
using OneUWP.Model;
using Windows.Storage;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OneUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public int homepageVol = 1400;
        internal string testInfo = "111";

        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        public ObservableCollection<Sheet> sheet;


        public TestPage()
        {
            this.InitializeComponent();
            sheet = new ObservableCollection<Sheet>();
        }

        public async void TestButton_Click(object sender, RoutedEventArgs e)
        {
            //var questionSheet = await GetDateSheets.GetHomepageSheet();
            //IEnumerable<Sheet> items = from Sheet in questionSheet where Sheet.date== "20160803" select Sheet;
            //var newItems=  items.ToList();
            //TestInfoTextBlock.Text = newItems[0].id.ToString();
            //newItems.count.tostring();
            //sheet.add(items);
            QuestionRootObject questionpage;
            for (int i = 1; i < 1470; i++)
            {
                questionpage = await OneProxy.GetQuestion(i);
                try
                {
                    string dateText = questionpage.data.question_makettime;
                    string dateTextNumOnly = Regex.Replace(dateText, @"\D*", "");//用正则表达式将非数字全部替换成""(空）；
                    dateTextNumOnly = dateTextNumOnly.Substring(0, 8);//去数组的前两位
                    sheet.Add(new Sheet { id = i, date = dateTextNumOnly });
                }
                catch
                {
                    sheet.Add(new Sheet { id = i,  date = "" });
                }

            }

            XmlDocument xd = new XmlDocument();
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(sheet.GetType());
                xz.Serialize(sw, sheet);
                xd.LoadXml(sw.ToString());
               // StorageFolder XMLFolderLocation = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
               // StorageFolder XMLLocation = await XMLFolderLocation.GetFolderAsync("XMLSheets");
                StorageFile sampleFile = await localFolder.CreateFileAsync("questionpageSheet.XML",CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(sampleFile, xd.InnerXml);
            }


        }

    }


}
