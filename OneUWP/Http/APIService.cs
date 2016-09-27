using OneUWP.Http.Data;
using OneUWP.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Media.Imaging;

namespace OneUWP.Http
{
    /// <summary>
    /// api服务类  将接收到json字符串格式化成实体类
    /// </summary>
    public class APIService
    {

        /// <summary>
        /// 短篇评论
        /// </summary>
        public async static Task<essay_comment> Get_essay_comment()
        {
            string url = ServiceURL.hp_detail;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(essay_comment));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (essay_comment)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 短篇评论数
        /// </summary>
        public async static Task<essay_commentnum> Get_essay_commentnum()
        {
            string url = ServiceURL.hp_detail;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(essay_commentnum));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (essay_commentnum)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 短篇内容
        /// </summary>
        public async static Task<essay_detail> Get_essay_detail(string id)
        {
            string url = string.Format(ServiceURL.essay_detail, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(essay_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (essay_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 首页内容
        /// </summary>
        public async static Task<hp_detail> Get_hp_detail(string id)
        {
            var url = ServiceURL.hp_detail + id + "?";
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(hp_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (hp_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 首页月份列表
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async static Task<hp_month> Get_hp_month(string date)
        {
            var url = string.Format(ServiceURL.hp_month, date);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(hp_month));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (hp_month)serializer.ReadObject(ms);
            return data;
        }

        public async static Task<serial_detail> Get_serial_detail(string id)
        {
            var url = string.Format(ServiceURL.serial_detail, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(serial_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 最近几期的id lists首页
        /// </summary>
        public async static Task<hp_idlist> Get_hp_idlist()
        {
            string url = string.Format(ServiceURL.hp_idlist, "0");
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(hp_idlist));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (hp_idlist)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 电影内容
        /// </summary>
        public async static Task<movie_list> Get_movie_list()
        {
            string url = string.Format(ServiceURL.movie_list, "0");
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(movie_list));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (movie_list)serializer.ReadObject(ms);
            return data;
        }
        public async static Task<movie_detail> Get_movie_detail(string id)
        {
            string url = string.Format(ServiceURL.movie_detail, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(movie_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (movie_detail)serializer.ReadObject(ms);
            return data;
        }
        public async static Task<movie_story> Get_movie_story(string id)
        {
            //需要根据不同的需求选择
            //"/story/0/0?"
            //"/story/1/0?"
            string url = string.Format(ServiceURL.movie_story, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(movie_story));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (movie_story)serializer.ReadObject(ms);
            return data;
        }


        /// <summary>
        /// 音乐的评论
        /// </summary>
        public async static Task<music_comment> Get_music_comment(string id)
        {
            //1024
            id = "1024";
            string url = string.Format(ServiceURL.music_comment, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(music_comment));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_comment)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 音乐内容
        /// </summary>
        public async static Task<music_detail> Get_music_detail(string id)
        {
            string url = string.Format(ServiceURL.music_detail, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(music_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 最近几期音乐
        /// </summary>
        public async static Task<music_idlist> Get_music_idlist(string id)
        {
            string url = string.Format(ServiceURL.music_idlist, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(music_idlist));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_idlist)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 相关音乐
        /// </summary>
        public async static Task<music_related> Get_music_related()
        {
            string url = ServiceURL.music_related;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(music_related));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_related)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 问题的点赞、评论内容
        /// </summary>
        public async static Task<question_comment> Get_question_comment()
        {
            var url = ServiceURL.question_comment;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(question_comment));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (question_comment)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 问题内容
        /// </summary>
        public async static Task<question_detail> Get_question_detail(string id)
        {
            string url = string.Format(ServiceURL.question_detail, id);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(question_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (question_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 相关问题
        /// </summary>
        public async static Task<question_related> Get_question_related()
        {
            string url = ServiceURL.question_related;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(question_related));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (question_related)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 问题的更新
        /// </summary>
        public async static Task<question_update> Get_question_update()
        {
            string url = ServiceURL.question_update;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(question_update));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (question_update)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 最近几期的 id list阅读
        /// </summary>
        public async static Task<reading_idlist> Get_reading_idlist()
        {
            string url = ServiceURL.reading_idlist;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(reading_idlist));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (reading_idlist)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 连载评论内容
        /// </summary>
        public async static Task<serial_comment> Get_serial_comment()
        {
            string url = ServiceURL.serial_comment;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(serial_comment));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_comment)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 连载评论数
        /// </summary>
        public async static Task<serial_commentnum> Get_serial_commentnum()
        {
            string url = ServiceURL.serial_commentnum;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(serial_commentnum));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_commentnum)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 连载相关
        /// </summary>
        public async static Task<serial_related> Get_serial_related()
        {
            string url = ServiceURL.serial_related;
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(serial_related));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_related)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 连载月份
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async static Task<serial_month> Get_serial_month(string date)
        {
            string url = string.Format(ServiceURL.serial_month, date);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(serial_month));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_month)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 短篇月份
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async static Task<essay_month> Get_essay_month(string date)
        {
            string url = string.Format(ServiceURL.essay_month, date);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(essay_month));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (essay_month)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 问题月份
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async static Task<question_month> Get_question_month(string date)
        {
            string url = string.Format(ServiceURL.question_month, date);
            var result = await GetStringFromURL(url);
            var serializer = new DataContractJsonSerializer(typeof(question_month));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (question_month)serializer.ReadObject(ms);
            return data;
        }




        public async static Task<string> GetStringFromURL(string url)
        {
            try
            {
                var httpClient = new HttpClient();
                string fileName = FileNameFromURL(url);
                try
                {
                    var response = await httpClient.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();
                    await FileHelper.Current.WriteObjectAsync(result, fileName);
                    return result;
                }
                catch
                {
                    var result = await FileHelper.Current.ReadObjectAsync<string>(fileName);
                    return result;
                }
            }

            catch
            {
                return null;
            }


        }
        public static string FileNameFromURL(string str)
        {
            str = Regex.Replace(str, @"\\", string.Empty);
            str = Regex.Replace(str, @"\/", string.Empty);
            str = Regex.Replace(str, @"\:", string.Empty);
            str = Regex.Replace(str, @"\*", string.Empty);
            str = Regex.Replace(str, @"\?", string.Empty);
            str = Regex.Replace(str, @"\<", string.Empty);
            str = Regex.Replace(str, @"\>", string.Empty);
            str = Regex.Replace(str, @"\|", string.Empty);
            //str=Regex.Replace(str, @"[^\d]*", "");
            return str;
        }


    }
}

