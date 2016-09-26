using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Web.Http;

namespace OneUWP.Tools
{


    // http://stackoverflow.com/questions/34362838/storing-a-bitmapimage-in-localfolder-uwp


    public class ImageOperation
    {
        public static async Task<WriteableBitmap> GetLocalPictureAsync(string FileName)
        {
            try
            {
                StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Pics", CreationCollisionOption.OpenIfExists);
                StorageFile pictureFile = await pictureFolder.GetFileAsync(FileName);

                using (IRandomAccessStream stream = await pictureFile.OpenAsync(FileAccessMode.Read))
                {
                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                    WriteableBitmap bmp = new WriteableBitmap((int)decoder.PixelWidth, (int)decoder.PixelHeight);
                    await bmp.SetSourceAsync(stream);
                    return bmp;
                }
            }
            catch { return null; }
        }
        /// <summary>
        /// 在windows runtime component项目中使用  下载图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected async Task GetImageInRuntimeComponent(string url, string name)
        {
            try
            {
                var folder = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFolderAsync("images_cache", CreationCollisionOption.OpenIfExists);

                var file = await StorageFile.CreateStreamedFileFromUriAsync(name, new Uri(url), RandomAccessStreamReference.CreateFromUri(new Uri(url)));
                file = await file.CopyAsync(folder);
            }
            catch
            {

            }
        }

        public static async Task SaveBitmapToFileAsync(WriteableBitmap wb, string fileName)
        {
            StorageFolder pictureFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Pics", CreationCollisionOption.OpenIfExists);
            var file = await pictureFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            try
            {
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream.AsRandomAccessStream());
                    var pixelStream = wb.PixelBuffer.AsStream();
                    byte[] pixels = new byte[wb.PixelBuffer.Length];
                    await pixelStream.ReadAsync(pixels, 0, pixels.Length);
                    encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Ignore, (uint)wb.PixelWidth, (uint)wb.PixelHeight, 96, 96, pixels);
                    await encoder.FlushAsync();
                }
            }
            catch { }
        }



        public static async Task<WriteableBitmap> GetImage(string url)
        {
            string fileName = Http.APIService.FileNameFromURL(url)+".jpg";

            WriteableBitmap wb = await GetLocalPictureAsync(fileName);
            if (wb == null)
            {
                try
                {
                    IBuffer buffer = await SendGetRequestAsBytes(url);
                    if (buffer != null)
                    {
                        BitmapImage bi = new BitmapImage();
                        wb = null;
                        Stream stream2Write;
                        using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                        {

                            stream2Write = stream.AsStreamForWrite();

                            await stream2Write.WriteAsync(buffer.ToArray(), 0, (int)buffer.Length);

                            await stream2Write.FlushAsync();
                            stream.Seek(0);

                            await bi.SetSourceAsync(stream);

                            wb = new WriteableBitmap(bi.PixelWidth, bi.PixelHeight);
                            stream.Seek(0);
                            await wb.SetSourceAsync(stream);
                            //保存在本地
                            await SaveBitmapToFileAsync(wb, fileName);
                            return wb;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return wb;
            }

        }

        public async static Task<IBuffer> SendGetRequestAsBytes(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsBufferAsync();
            }
            catch
            {
                return null;
            }

        }



    }
}

