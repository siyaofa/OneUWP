using OneUWP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Xml.Dom;
using Windows.Foundation.Metadata;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace OneUWP
{
    /// <summary>
    /// 后台任务
    /// </summary>
    public class BackgroundTaskAction
    {

        /// <summary>
        /// 更新头条文章的磁贴tile
        /// </summary>
        /// <param name="t"></param>
        public static void UpdateTile()
        {
            //undevent
        }

        public static async void ShowStatusBar(ElementTheme APPTheme)
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {

                var statusbar = StatusBar.GetForCurrentView();
                if (false)
                {
                    await statusbar.ShowAsync();
                    if (APPTheme == ElementTheme.Dark)
                    {
                        statusbar.BackgroundColor = Windows.UI.Colors.Black;
                        statusbar.BackgroundOpacity = 1;
                        statusbar.ForegroundColor = Windows.UI.Colors.White;
                    }
                    else
                    {
                        statusbar.BackgroundColor = Windows.UI.Colors.White;
                        statusbar.BackgroundOpacity = 1;
                        statusbar.ForegroundColor = Windows.UI.Colors.Black;
                    }
                }
                else
                {
                    await statusbar.HideAsync();
                }


            }
        }


        public static void ShowToastNotification(string assetsImageFileName, string text)
        {
            // 1. create element
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            // 2. provide text
            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));

            // 3. provide image
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", $"ms-appx:///assets/{assetsImageFileName}");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "logo");

            // 4. duration
            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");

            // 5. audio
            XmlElement audio = toastXml.CreateElement("audio");
            //audio.SetAttribute("src", $"ms-winsoundevent:Notification.{audioName.ToString().Replace("_", ".")}");
            //Default,
            //IM,
            //Mail,
            //Reminder,
            //SMS,
            //Looping.Alarm,
            //Looping.Alarm2,
            //Looping.Alarm3,
            //Looping.Alarm4,
            //Looping.Alarm5,
            //Looping.Alarm6,
            //Looping.Alarm7,
            //Looping.Alarm8,
            //Looping.Alarm9,
            //Looping.Alarm10,
            //Looping.Call,
            //Looping.Call2,
            //Looping.Call3,
            //Looping.Call4,
            //Looping.Call5,
            //Looping.Call6,
            //Looping.Call7,
            //Looping.Call8,
            //Looping.Call9,
            //Looping.Call10
            audio.SetAttribute("src", $"ms-winsoundevent:Notification.Default");
            toastNode.AppendChild(audio);

            // 6. app launch parameter
            //((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"param1\":\"12345\",\"param2\":\"67890\"}");

            // 7. send toast
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
