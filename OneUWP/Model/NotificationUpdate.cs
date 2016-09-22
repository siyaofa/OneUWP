using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace OneUWP.Model
{
    class Notifications
    {
        public static void NotificationUpdate(string TextContent,int picId)
        {
           // TextContent = "第一次不会死啊啊啊啊";
           // picId = 1459;
            ///官方版https://msdn.microsoft.com/zh-cn/library/windows/apps/xaml/hh868253.aspx
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWide310x150ImageAndText01);
            XmlNodeList tileTextAttributes = tileXml.GetElementsByTagName("text");
            //tileTextAttributes[0].AppendChild(tileXml.CreateTextNode(homePage[0].data.hp_content));
            tileTextAttributes[0].InnerText =TextContent ;
            XmlNodeList tileImageAttributes = tileXml.GetElementsByTagName("image");
            //((XmlElement)tileImageAttributes[0]).SetAttribute("src", "ms-appx:///assets/redWide.png");
            // ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "http://www.contoso.com/redWide.png");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("src", "ms-appdata:///local/Pics/"+picId.ToString()+".jpg");
            ((XmlElement)tileImageAttributes[0]).SetAttribute("alt", "red graphic");

            //XmlDocument squareTileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text04);
            //XmlNodeList squareTileTextAttributes = squareTileXml.GetElementsByTagName("text");
            //squareTileTextAttributes[0].AppendChild(squareTileXml.CreateTextNode("Hello World! My very own tile notification"));
            //IXmlNode node = tileXml.ImportNode(squareTileXml.GetElementsByTagName("binding").Item(0), true);
            //tileXml.GetElementsByTagName("visual").Item(0).AppendChild(node);

            TileNotification tileNotification = new TileNotification(tileXml);

            //  tileNotification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);



        }

    }


}
