using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace OneUWP.Model
{
    /// <summary>
    /// Sheet.XML存放于Assets下
    /// 先读取本地对照表，找到接口id。如果没有，在线读取，一边读一边写。最后还是没找到再报无法获取内容
    /// </summary>
    public class GetDateSheets
    {

        //得到主页的id与日期之间的本地对照表
        public async static Task<List<Sheet>> GetHomepageSheet()
        {
            //先在安装目录寻找，再去asset下找最早的列表
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder XMLLocation = await localFolder.CreateFolderAsync("XMLSheets", CreationCollisionOption.OpenIfExists);
            StorageFile sampleFile = await XMLLocation.TryGetItemAsync("homepageSheet.XML") as StorageFile;
            if (sampleFile == null)
            {
                StorageFolder XMLFolderLocation = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                XMLLocation = await XMLFolderLocation.GetFolderAsync("XMLSheets");
                sampleFile = await XMLLocation.GetFileAsync("homepageSheet.XML");
            }
            var s = await FileIO.ReadTextAsync(sampleFile);
            List<Sheet> sheet = XmlUtil.Deserialize(typeof(List<Sheet>), s) as List<Sheet>;
            return sheet;

        }

        public async static Task<List<Sheet>> GetQuestionpageSheet()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFolder XMLLocation = await localFolder.CreateFolderAsync("XMLSheets", CreationCollisionOption.OpenIfExists);
            StorageFile sampleFile = await XMLLocation.TryGetItemAsync("questionpageSheet.XML") as StorageFile;
            if (sampleFile == null)
            {
                StorageFolder XMLFolderLocation = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                XMLLocation = await XMLFolderLocation.GetFolderAsync("XMLSheets");
                sampleFile = await XMLLocation.GetFileAsync("questionpageSheet.XML");
            }
            var s = await FileIO.ReadTextAsync(sampleFile);
            List<Sheet> sheet = XmlUtil.Deserialize(typeof(List<Sheet>), s) as List<Sheet>;
            return sheet;
        }




    }
}
