using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slack;

namespace SlackText
{
    [TestClass]
    public class IncomingWebHooksTest
    {
        private const string hooks = "https://hooks.slack.com/services/xxxxxxxxx/xxxxxxxxx/xxxxxxxxxxxxxxxxxxxxxxxx";
        private const string iconEmoji = ":slack:";
        private const string iconUrl = "https://a.slack-edge.com/12b5a/plugins/tester/assets/service_36.png";

        [TestMethod]
        public void Send_NoIcon_Success()
        {
            var iwh = new IncomingWebHooks(new Uri(hooks, UriKind.Absolute));
            var post = new IncomingWebHooksJson()
            {
                channel = "#random",
                text = "てすとです！アイコン無し",
                username = "testuser"
            };

            HttpStatusCode result = iwh.Send(post);
            Assert.AreEqual(HttpStatusCode.OK, result, "メッセージ送信失敗");
        }

        [TestMethod]
        public void Send_IconEmoji_Success()
        {
            var iwh = new IncomingWebHooks(new Uri(hooks, UriKind.Absolute));
            var post = new IncomingWebHooksJsonWithIconEmoji() 
            { 
                channel = "#random", 
                text = "てすとです！アイコン絵文字指定", 
                username = "testuser" , 
                icon_emoji = iconEmoji
            };

            HttpStatusCode result = iwh.Send(post);
            Assert.AreEqual(HttpStatusCode.OK, result, "メッセージ送信失敗");
        }

        [TestMethod]
        public void Send_IconUrl_Success()
        {
            var iwh = new IncomingWebHooks(new Uri(hooks, UriKind.Absolute));
            var post = new IncomingWebHooksJsonWithIconUrl() 
            { 
                channel = "#random", 
                text = "てすとです！アイコンURL指定", 
                username = "testuser" , 
                icon_url = new Uri(iconUrl, UriKind.Absolute)
            };

            HttpStatusCode result = iwh.Send(post);
            Assert.AreEqual(HttpStatusCode.OK, result, "メッセージ送信失敗");
        }

    }
}
