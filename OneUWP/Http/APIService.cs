using OneUWP.Http.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.hp_detail);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.hp_detail);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            string url = ServiceURL.essay_detail + id + "?";
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var url=ServiceURL.hp_detail+id+"?";
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(hp_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (hp_detail)serializer.ReadObject(ms);
            return data;
        }

        public async static Task<serial_detail> Get_serial_detail(string id)
        {
            var httpClient = new HttpClient();
            var url = ServiceURL.serial_detail + id + "?";
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.hp_idlist);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.movie_list);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(movie_list));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (movie_list)serializer.ReadObject(ms);
            return data;
        }
        public async static Task<movie_detail> Get_movie_detail(string id)
        {
            var httpClient = new HttpClient();
            string url = ServiceURL.movie_detail + id + "?";
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(movie_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (movie_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 音乐的评论
        /// </summary>
        public async static Task<music_comment> Get_music_comment()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.music_comment);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(music_comment));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_comment)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 音乐内容
        /// </summary>
        public async static Task<music_detail> Get_music_detail()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.music_detail);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(music_detail));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (music_detail)serializer.ReadObject(ms);
            return data;
        }
        /// <summary>
        /// 最近几期音乐
        /// </summary>
        public async static Task<music_idlist> Get_music_idlist()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.music_idlist);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.music_related);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.question_comment);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            string url = ServiceURL.question_detail+id+"?";
            var response = await httpClient.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.question_related);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.question_update);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.reading_idlist);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.serial_comment);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.serial_commentnum);
            var result = await response.Content.ReadAsStringAsync();
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
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ServiceURL.serial_related);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(serial_related));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (serial_related)serializer.ReadObject(ms);
            return data;
        }


    }
}

