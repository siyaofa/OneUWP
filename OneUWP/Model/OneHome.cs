using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Model
{
    /// <summary>
    /// 获取相应Id的内容，如果本地没有缓存就连接服务器获取，如果有就读取本地内容。
    /// </summary>
    public class OneHome
    {
        public async static Task<HomeRootObject> GetHomepage(int vol)
        {
            if (vol < 1)
                return null;

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            string fileName = vol.ToString() + "hp.txt";
            var file = await localFolder.TryGetItemAsync(fileName);
            string result;
            ///若未获取到内容则初始化为空值
            try
            {
                //如果本地已经缓存则不链接服务器
                if (file == null)
                {
                    var homehttp = new HttpClient();
                    // api严重有问题，日期和并不是按照序列号来算的
                    var response = await homehttp.GetAsync("http://v3.wufazhuce.com:8000/api/hp/detail/" + vol.ToString());
                    result = await response.Content.ReadAsStringAsync();
                    //并把内容保存到本地文件夹
                    StorageFile sampleFile = await localFolder.CreateFileAsync(fileName);
                    await FileIO.WriteTextAsync(await localFolder.GetFileAsync(fileName), result);
                }
                else
                {
                    StorageFile sampleFile = await localFolder.GetFileAsync(fileName);
                    result = await FileIO.ReadTextAsync(sampleFile);
                }

                var serializer = new DataContractJsonSerializer(typeof(HomeRootObject));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var homedata = (HomeRootObject)serializer.ReadObject(ms);

                //针对图片再进行一次解析
                StorageFolder imageFolder = await localFolder.CreateFolderAsync("Pics", CreationCollisionOption.OpenIfExists);
                string imageName = vol.ToString() + ".jpg";
                var imagefile = await localFolder.TryGetItemAsync(imageName);
                if (imagefile == null)
                {
                    var wb = await ImageOperation.GetImage(homedata.data.hp_img_url);
                    await ImageOperation.SaveBitmapToFileAsync(wb, imageName);
                    homedata.writeableBitmap = wb;
                }
                else
                {
                    var wb = await ImageOperation.GetLocalPictureAsync(imageName);
                    homedata.writeableBitmap = wb;
                }

                return homedata;
            }
            catch
            {
                return null;
            }

        }
        public async static Task<HomeRootObject> GetHomepage(int vol, bool ReadOnly)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            string fileName = vol.ToString() + "hp.txt";
            var file = await localFolder.TryGetItemAsync(fileName);
            string result;
            ///若未获取到内容则初始化为空值
            try
            {
                //如果本地已经缓存则不链接服务器
                if (file == null)
                {
                    var homehttp = new HttpClient();
                    // api严重有问题，日期和并不是按照序列号来算的
                    var response = await homehttp.GetAsync("http://v3.wufazhuce.com:8000/api/hp/detail/" + vol.ToString());
                    result = await response.Content.ReadAsStringAsync();
                    if (!ReadOnly)
                    {
                        //并把内容保存到本地文件夹
                        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName);
                        await FileIO.WriteTextAsync(await localFolder.GetFileAsync(fileName), result);
                    }
                }
                else
                {
                    StorageFile sampleFile = await localFolder.GetFileAsync(fileName);
                    result = await FileIO.ReadTextAsync(sampleFile);
                }

                var serializer = new DataContractJsonSerializer(typeof(HomeRootObject));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var homedata = (HomeRootObject)serializer.ReadObject(ms);
                if (!ReadOnly)
                {                //针对图片再进行一次解析
                    StorageFolder imageFolder = await localFolder.CreateFolderAsync("Pics", CreationCollisionOption.OpenIfExists);
                    string imageName = vol.ToString() + ".jpg";
                    var imagefile = await localFolder.TryGetItemAsync(imageName);
                    if (imagefile == null)
                    {
                        var wb = await ImageOperation.GetImage(homedata.data.hp_img_url);
                        await ImageOperation.SaveBitmapToFileAsync(wb, imageName);
                        homedata.writeableBitmap = wb;
                    }
                    else
                    {
                        var wb = await ImageOperation.GetLocalPictureAsync(imageName);
                        homedata.writeableBitmap = wb;
                    }
                }


                return homedata;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// 把图片缓存到本地
        /// </summary>
        /// <param name="softwareBitmap"></param>
        /// <param name="_localFolder"></param>
        /// <param name="fileName"></param>
        public async void WriteToFile(SoftwareBitmap softwareBitmap, StorageFolder _localFolder, string fileName)
        {
            if (softwareBitmap != null)
            {
                StorageFile file = await _localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                    encoder.SetSoftwareBitmap(softwareBitmap);
                    await encoder.FlushAsync();
                }
            }
        }
        /// <summary>
        /// 从本地读取图片
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="_localFolder"></param>
        /// <returns></returns>
        public async Task<SoftwareBitmap> ReadFromFile(string filename, StorageFolder _localFolder)
        {
            StorageFile file = await _localFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            //var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri( filename));
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read))
            {
                // Create the decoder from the stream
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                // Get the SoftwareBitmap representation of the file
                SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                return softwareBitmap;
            }
        }
    }




}

