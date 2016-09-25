using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneUWP.Http
{
    /// <summary>
    /// 以下api参照android官方客户端 返回json
    /// </summary>
    static class ServiceURL
    {
        /// <summary>
        /// 最近几期的idlists首页
        /// </summary>
        public static string hp_idlist = "http://v3.wufazhuce.com:8000/api/hp/idlist/0?";
        /// <summary>
        /// 最近几期的idlist音乐
        /// </summary>
        public static string music_idlist = "http://v3.wufazhuce.com:8000/api/music/idlist/0?";
        /// <summary>
        /// 最近几期的idlist阅读
        /// </summary>
        public static string reading_idlist = "http://v3.wufazhuce.com:8000/api/reading/index/?";
        /// <summary>
        /// 首页内容
        /// </summary>
        public static string hp_detail = "http://v3.wufazhuce.com:8000/api/hp/detail/";
        /// <summary>
        /// 首页每月内容
        /// </summary>
        public static string hp_month = "http://v3.wufazhuce.com:8000/api/hp/bymonth/2016-07-01%2000:00:00?";
        /// <summary>
        /// 短篇评论
        /// </summary>
        public static string essay_comment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/essay/1533/0?";
        /// <summary>
        /// 短篇评论数
        /// </summary>
        public static string essay_commentnum = "http://v3.wufazhuce.com:8000/api/essay/update/1533/2016-09-20%2011:19:59?";
        /// <summary>
        /// 短篇内容
        /// </summary>
        public static string essay_detail = "http://v3.wufazhuce.com:8000/api/essay/";
        /// <summary>
        /// 连载评论数
        /// </summary>
        public static string serial_commentnum = "http://v3.wufazhuce.com:8000/api/serialcontent/update/177/2016-09-21%2008:50:28?";
        /// <summary>
        /// 连载相关
        /// </summary>
        public static string serial_related = "http://v3.wufazhuce.com:8000/api/related/serial/177?";
        /// <summary>
        /// 连载评论内容
        /// </summary>
        public static string serial_comment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/serial/177/0?";
        /// <summary>
        /// 相关问题
        /// </summary>
        public static string question_related = "http://v3.wufazhuce.com:8000/api/related/question/1478?";
        /// <summary>
        /// 问题的点赞、评论内容
        /// </summary>
        public static string question_comment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/question/1478/0?";
        /// <summary>
        /// 问题的更新
        /// </summary>
        public static string question_update = "http://v3.wufazhuce.com:8000/api/question/update/1478/2016-09-21%2010:02:23?";
        /// <summary>
        /// 连载内容
        /// </summary>
        public static string serial_detail = "http://v3.wufazhuce.com:8000/api/serialcontent/";
        /// <summary>
        /// 问题内容
        /// </summary>
        public static string question_detail = "http://v3.wufazhuce.com:8000/api/question/";
        /// <summary>
        /// 电影内容列表
        /// </summary>
        public static string movie_list = "http://v3.wufazhuce.com:8000/api/movie/list/0?";
        /// <summary>
        /// 电影详细内容
        /// </summary>
        public static string movie_detail = "http://v3.wufazhuce.com:8000/api/movie/detail/";
        /// <summary>
        /// 相关音乐
        /// </summary>
        public static string music_related = "http://v3.wufazhuce.com:8000/api/related/music/1024?";
        /// <summary>
        /// 音乐的评论
        /// </summary>
        public static string music_comment = "http://v3.wufazhuce.com:8000/api/comment/praiseandtime/music/1024/0?";
        /// <summary>
        /// 音乐内容
        /// </summary>
        public static string music_detail = "http://v3.wufazhuce.com:8000/api/music/detail/";
    }
}
