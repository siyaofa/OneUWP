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
    public class GetIdFromDate
    {


        public async static Task<int> GetHomepageDate(string date)
        {
            List<Sheet> homepageSheet = App.homepageSheet;
            Sheet item = homepageSheet.Find(delegate (Sheet p) { return p.date == date; });
            //  IEnumerable<Sheet> items = from Sheet in homepageSheet where Sheet.date == date select Sheet;
            if (item == null)
            {
                //计算目标日期大概id
                DateTime theFirstDay = new DateTime(2016, 09, 06);
                int year = int.Parse(date.Substring(0, 4));
                int month = int.Parse(date.Substring(4, 2));
                int day = int.Parse(date.Substring(6, 2));
                DateTime theDate = new DateTime(year, month, day);
                TimeSpan ts = theDate.Subtract(theFirstDay);
                int vol = ts.Days + 1462;

                //在有限时间id内寻找，可适当增大寻找半径
                //homepage内存在重复元素，需剔除
                HomeRootObject homePage;
                for (int i = vol - 20; i < vol + 20; i++)
                {
                    item = homepageSheet.Find(delegate (Sheet p) { return p.id == i; });
                    if (item == null)
                    {
                        homePage = await OneHome.GetHomepage(i, true);
                        try
                        {
                            string dateText = homePage.data.hp_makettime;
                            string dateTextNumOnly = Regex.Replace(dateText, @"\D*", "");//用正则表达式将非数字全部替换成""(空）；
                            dateTextNumOnly = dateTextNumOnly.Substring(0, 8);//去数组的前两位
                            homepageSheet.Add(new Sheet { id = i, date = dateTextNumOnly });
                        }
                        catch
                        {
                        }
                    }


                    try
                    {
                        //刷新后的列表保存
                        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                        StorageFolder XMLLocation = await localFolder.CreateFolderAsync("XMLSheets", CreationCollisionOption.OpenIfExists);
                        StorageFile sampleFile = await XMLLocation.CreateFileAsync("homepageSheet.XML", CreationCollisionOption.OpenIfExists);
                        XmlDocument xd = new XmlDocument();
                        using (StringWriter sw = new StringWriter())
                        {
                            XmlSerializer xz = new XmlSerializer(homepageSheet.GetType());
                            xz.Serialize(sw, homepageSheet);
                            xd.LoadXml(sw.ToString());
                            await FileIO.WriteTextAsync(sampleFile, xd.InnerXml);
                        }

                        item = homepageSheet.Find(delegate (Sheet p) { return p.date == date; });
                        return item.id;
                    }
                    catch { }

                }


                return 0;
            }
            else
            {
                // var newItems = items.ToList();
                return item.id;
            }
        }


        public async static Task<int> GetQuestionpageDate(string date)
        {
            List<Sheet> questionSheet = App.questionpageSheet;
            Sheet item = questionSheet.Find(delegate (Sheet p) { return p.date == date; });

            //LINQ查找
            //IEnumerable<Sheet> items = from Sheet in questionSheet where Sheet.date == date select Sheet;
            if (item == null)
            {
                //计算目标日期大概id
                DateTime theFirstDay = new DateTime(2016, 09, 06);
                int year = int.Parse(date.Substring(0, 4));
                int month = int.Parse(date.Substring(4, 2));
                int day = int.Parse(date.Substring(6, 2));
                DateTime theDate = new DateTime(year, month, day);
                TimeSpan ts = theDate.Subtract(theFirstDay);
                int vol = ts.Days + 1464;
                // HomeRootObject homePage;
                QuestionRootObject questionPage;
                for (int i = vol - 20; i < vol + 20; i++)
                {
                    item = questionSheet.Find(delegate (Sheet p) { return p.id == i; });
                    if (item == null)
                    {
                        questionPage = await OneProxy.GetQuestion(i, true);
                        try
                        {
                            string dateText = questionPage.data.question_makettime;
                            string dateTextNumOnly = Regex.Replace(dateText, @"\D*", "");//用正则表达式将非数字全部替换成""(空）；
                            dateTextNumOnly = dateTextNumOnly.Substring(0, 8);//去数组的前两位
                            questionSheet.Add(new Sheet { id = i, date = dateTextNumOnly });
                        }
                        catch
                        {

                        }
                    }
                }


                try
                {
                    //刷新后的列表保存
                    StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                    StorageFolder XMLLocation = await localFolder.CreateFolderAsync("XMLSheets", CreationCollisionOption.OpenIfExists);
                    StorageFile sampleFile = await XMLLocation.CreateFileAsync("questionpageSheet.XML", CreationCollisionOption.OpenIfExists);
                    XmlDocument xd = new XmlDocument();
                    using (StringWriter sw = new StringWriter())
                    {
                        XmlSerializer xz = new XmlSerializer(questionSheet.GetType());
                        xz.Serialize(sw, questionSheet);
                        xd.LoadXml(sw.ToString());
                        await FileIO.WriteTextAsync(sampleFile, xd.InnerXml);
                    }


                    item = questionSheet.Find(delegate (Sheet p) { return p.date == date; });
                    return item.id;
                }
                catch { }

                return 0;
            }
            else
            {
                // var newItems = items.ToList();
                // return newItems[0].id;
                return item.id;
            }
        }



    }
}
