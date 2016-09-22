using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;

namespace OneUWP.Model
{
    /// <summary>
    /// 读取在写入本地文件之前需要校验文件完整性。
    /// </summary>
    public class OneProxy
    {
        public async static Task<QuestionRootObject> GetQuestion(int vol)
        {
            if (vol < 1)
            {
                return null;
            }
            else
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                string fileName = vol.ToString() + "q.txt";
                var file = await localFolder.TryGetItemAsync(fileName);
                string result;
                //本地如果已经缓存则不联网
                try
                {
                    if (file == null)
                    {
                        var questionHttp = new HttpClient();
                        //API日期和并不是按照序列号来算的
                        var response = await questionHttp.GetAsync("http://v3.wufazhuce.com:8000/api/question/" + vol.ToString());
                        result = await response.Content.ReadAsStringAsync();
                        //写入本地文件
                        if (result.Length > 30)
                        {
                            StorageFile sampleFile = await localFolder.CreateFileAsync(fileName);
                            await FileIO.WriteTextAsync(await localFolder.GetFileAsync(fileName), result);
                        }
                    }
                    else
                    {
                        StorageFile sampleFile = await localFolder.GetFileAsync(fileName);
                        result = await FileIO.ReadTextAsync(sampleFile);
                    }
                    var serializer = new DataContractJsonSerializer(typeof(QuestionRootObject));
                    var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                    var questionData = (QuestionRootObject)serializer.ReadObject(ms);
                    questionData.data.answer_content = Regex.Replace(questionData.data.answer_content, "<br>", "");
                    return questionData;
                }
                catch
                {
                    return null;
                }
            }
        }

        public async static Task<QuestionRootObject> GetQuestion(int vol, bool ReadOnly)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            string fileName = vol.ToString() + "q.txt";
            var file = await localFolder.TryGetItemAsync(fileName);
            string result;
            //本地如果已经缓存则不联网

            try
            {
                if (file == null)
                {
                    var questionHttp = new HttpClient();
                    //API日期和并不是按照序列号来算的
                    var response = await questionHttp.GetAsync("http://v3.wufazhuce.com:8000/api/question/" + vol.ToString());
                    result = await response.Content.ReadAsStringAsync();
                    if (!ReadOnly)
                    {
                        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName);
                        await FileIO.WriteTextAsync(await localFolder.GetFileAsync(fileName), result);
                    }
                }
                else
                {
                    StorageFile sampleFile = await localFolder.GetFileAsync(fileName);
                    result = await FileIO.ReadTextAsync(sampleFile);
                }

                var serializer = new DataContractJsonSerializer(typeof(QuestionRootObject));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
                var questionData = (QuestionRootObject)serializer.ReadObject(ms);
                questionData.data.answer_content = Regex.Replace(questionData.data.answer_content, "<br>", "");
                return questionData;
            }
            catch
            {
                return null;
            }


        }
    }





}



